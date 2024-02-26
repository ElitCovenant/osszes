import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './Navbar.css';
import LanguageSelector from './LanguageSelector';
import jwt_decode from './jwt_decode'; // Importáljuk a JWT dekódoló segédosztályt
import def_logo from './img/default_prof_picture.png';
import quest1_logo from './img/quest1_prof_picture.png';
import quest2_logo from './img/quest2_prof_picture.png';
import teacher1_logo from './img/teacher1_prof_picture.png';
import teacher2_logo from './img/teacher2_prof_picture.png';

const Navbar = () => {
  const avatarlogos = [def_logo,teacher1_logo,teacher2_logo,quest1_logo,quest2_logo]
  const [isLogo1, setIsLogo1] = useState(true);
  const [searchTerm, setSearchTerm] = useState('');
  const [searchHistory, setSearchHistory] = useState([]);
  const [isProfileMenuOpen, setIsProfileMenuOpen] = useState(false);
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [profilePicturePath, setProfilePicturePath] = useState(null);
  const navigate = useNavigate();

  const toggleLogo = () => {
    setIsLogo1((prevIsLogo) => !prevIsLogo);
  };

  const toggleProfileMenu = () => {
    setIsProfileMenuOpen((prevIsOpen) => !prevIsOpen);
  };

  const handleLogout = () => {
    localStorage.removeItem('authToken');
    setIsLoggedIn(false);
    setIsProfileMenuOpen(false);
  };

  const handleStorageChange = (event) => {
    if (event.key === 'authToken') {
      setIsLoggedIn(event.newValue !== null);
      setIsProfileMenuOpen(event.newValue !== null);
    }
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
    const troken = localStorage.getItem('authToken');
    
    if (troken) {
      setIsLoggedIn(true);
      setIsProfileMenuOpen(true);
    } else {
      setIsLoggedIn(false);
      setIsProfileMenuOpen(false);
      setProfilePicturePath(0); // Set the profile picture to the first element of avatar logos
    }
  }, [localStorage.getItem('authToken')]);

  useEffect(() => {
    const fetchProfilePicturePath = async () => {
      try {
        if (isLoggedIn) {
          const troken = localStorage.getItem('authToken');
          if (troken) {
            
            const decodedToken = jwt_decode(troken);
            if (decodedToken && decodedToken.actor) {         
              const imgPath = decodedToken.actor;
                setProfilePicturePath(imgPath)
            }
          }
        }
      } catch (error) {
        console.error('Error fetching profile picture path:', error);
      }
    };
  
    fetchProfilePicturePath();
  }, [isLoggedIn]); 

  useEffect(() => {
    window.addEventListener('storage', handleStorageChange);

    return () => {
      window.removeEventListener('storage', handleStorageChange);
    };
  }, []);

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
              <img src={profilePicturePath > 0 ?avatarlogos[profilePicturePath-1]:avatarlogos[profilePicturePath]} alt="Profile" height={30} />
            </button>
            {isProfileMenuOpen && (
              <div className="dropdown-content">
                {isLoggedIn ? (
                  <>
                    <Link to="/UserPage">My Profile</Link>
                    <Link to="/settings">Settings</Link>
                    <Link to="/" onClick={handleLogout}>Logout</Link>
                  </>
                ) : (
                  <Link to="/login">Log in</Link>
                  
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
