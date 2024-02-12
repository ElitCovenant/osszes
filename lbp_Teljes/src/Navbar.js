import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './Navbar.css';
import LanguageSelector from './LanguageSelector';
import logo from './default_prof_picture.png';

const Navbar = () => {
  const [isLogo1, setIsLogo1] = useState(true);
  const [searchTerm, setSearchTerm] = useState('');
  const [searchHistory, setSearchHistory] = useState([]);
  const [isProfileMenuOpen, setIsProfileMenuOpen] = useState(false); // State to track profile menu
  const [isLoggedIn, setIsLoggedIn] = useState(false); // State to track login status
  const navigate = useNavigate();

  const toggleLogo = () => {
    setIsLogo1((prevIsLogo) => !prevIsLogo);
  };

  const toggleProfileMenu = () => {
    setIsProfileMenuOpen((prevIsOpen) => !prevIsOpen);
  };

  const toggleLogin = () => {
    setIsLoggedIn((prevIsLoggedIn) => !prevIsLoggedIn);
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
          {/* Profile Menu */}
          <div className="profile-menu">
            <button className="profile-button" onClick={toggleProfileMenu}>
              <img src={logo} alt="Profile" height={30} />
            </button>
            {isProfileMenuOpen && (
              <div className="dropdown-content">
                {isLoggedIn ? (
                  <>
                    <Link to="/myprofile">My Profile</Link>
                    <Link to="/settings">Settings</Link>
                    <Link to="/logout" onClick={toggleLogin}>Logout</Link>
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
