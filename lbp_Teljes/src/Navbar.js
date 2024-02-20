import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './Navbar.css';
import LanguageSelector from './LanguageSelector';
import logo from './img/default_prof_picture.png';
import jwt_decode from './jwt_decode'; // Importáljuk a JWT dekódoló segédosztályt

const Navbar = () => {
  const [isLogo1, setIsLogo1] = useState(true);
  const [searchTerm, setSearchTerm] = useState('');
  const [searchHistory, setSearchHistory] = useState([]);
  const [isProfileMenuOpen, setIsProfileMenuOpen] = useState(false);
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [profilePicturePath, setProfilePicturePath] = useState(null); // Átnevezzük userId-ról profilePicturePath-re
  const navigate = useNavigate();

  const toggleLogo = () => {
    setIsLogo1((prevIsLogo) => !prevIsLogo);
  };

  const toggleProfileMenu = () => {
    setIsProfileMenuOpen((prevIsOpen) => !prevIsOpen);
  };

  const toggleLogin = () => {
    setIsLoggedIn((prevIsLoggedIn) => {
      // Ha kijelentkeztetjük a felhasználót, töröljük a tokent a localStorage-ból
      if (prevIsLoggedIn) {
        localStorage.removeItem('authToken');
      }
      return !prevIsLoggedIn;
    });
  };

  const logoPath = isLogo1 ? 'icon10.png' : 'icon3.png';

  const handleSearch = () => {
    console.log(`Search term: ${searchTerm}`);
    setSearchHistory((prevHistory) => {
      const updatedHistory = new Set([...prevHistory, searchTerm]);
      return [...updatedHistory];
    });

    if (searchTerm !== '') {
      navigate(`/books?search=${encodeURIComponent(searchTerm)}`);
      setSearchTerm('');
    }
  };

  const handleKeyPress = (e) => {
    if (e.key === 'Enter') {
      handleSearch();
    }
  };

  useEffect(() => {
    const intervalId = setInterval(() => {
      toggleLogo();
    }, 5000);

    return () => clearInterval(intervalId);
  }, []);

  useEffect(() => {
    // Betöltjük a tokent a localStorage-ból
    const troken = localStorage.getItem('authToken');
  
    // Ha van token a localStorage-ban, a felhasználó be van jelentkezve
    if (troken) {
      setIsLoggedIn(true);
      setIsProfileMenuOpen(true); // Ha van token, akkor az ablakot megnyitjuk
    } else {
      setIsLoggedIn(false);
    }
  }, []);

  // Fetch profile picture path based on user ID
  useEffect(() => {
    const fetchProfilePicturePath = async () => {
      try {
        if (isLoggedIn) {
          const troken = localStorage.getItem('authToken');
          if (troken) {
            const decodedToken = jwt_decode(troken);
            console.log(decodedToken)
            if (decodedToken && decodedToken.Actor) {
              const response = await fetch(`https://localhost:7275/Profilképek/${decodedToken.Actor}`);
              if (response.ok) {
                const { imagePath } = await response.json();
                setProfilePicturePath(imagePath); // Beállítjuk a profilkép útvonalát
              } else {
                console.error('Failed to fetch profile picture path:', response.status);
              }
            }
          }
        }
      } catch (error) {
        console.error('Error fetching profile picture path:', error);
      }
    };
  
    fetchProfilePicturePath();
  }, [isLoggedIn]); 

  return (
    <nav className="navbar">
      <div className="navbar-left">
        {isLogo1 ? (
          <Link to="https://github.com/LibraKando/Project">
            <img src={logoPath} height={50} alt='' />
          </Link>
        ) : (
          <Link to="https://www.kkszki.hu/">
            <img src={logoPath} height={50} alt='' />
          </Link>
        )}
      </div>
      <div className="navbar-right">
        <ul className="navbar-menu">
          <li><Link to="/">Home</Link></li>
          <li><Link to="/books">Books</Link></li>
        </ul>
        <div className="navbar-actions">
          <div className="search-container">
            <input
              type="text"
              placeholder="Search for books..."
              className="search-input"
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              onKeyPress={handleKeyPress}
              list="psychology_theories_list"
            />
            {searchHistory.length > 0 && (
              <datalist id="psychology_theories_list">
                {searchHistory.map((item, index) => (
                  <option key={index} value={item} />
                ))}
              </datalist>
            )}
          </div>
          <div className="frame">
            <button className="search-button" onClick={handleSearch}>Search</button>
          </div>
          <div className="profile-menu">
            <button className="profile-button" onClick={toggleProfileMenu}>
              <img src={profilePicturePath || logo} alt="Profile" height={30} /> {/* Módosítjuk a profilkép forrását */}
            </button>
            {isProfileMenuOpen && (
              <div className="dropdown-content">
                {isLoggedIn ? (
                  <>
                    <Link to="/UserPage">My Profile</Link>
                    <Link to="/settings">Settings</Link>
                    <Link to="/" onClick={toggleLogin}>Logout</Link>
                  </>
                ) : (
                  <Link to="/login" onClick={toggleLogin}>Log in</Link>
                )}
              </div>
            )}
          </div>
        </div>
        <LanguageSelector />
      </div>
    </nav>
  );
};

export default Navbar;
