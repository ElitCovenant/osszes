import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './Navbar.css';
import LanguageSelector from './LanguageSelector';

const Navbar = () => {
  const [isLogo1, setIsLogo1] = useState(true);
  const [searchTerm, setSearchTerm] = useState('');
  const navigate = useNavigate(); // A React Router useNavigate hookja
  const [searchHistory, setSearchHistory] = useState([]);

  


  const toggleLogo = () => {
    setIsLogo1((prevIsLogo) => !prevIsLogo);
  };

  const logoPath = isLogo1 ? 'icon10.png' : 'icon3.png';


  const handleSearch = () => {
    console.log(`Search term: ${searchTerm}`);
    // Keresési előzmények frissítése ismétlődések nélkül
    setSearchHistory(prevHistory => {
      const updatedHistory = new Set([...prevHistory, searchTerm]);
      return [...updatedHistory];
    });

    // Ha a keresési kifejezés nem üres, navigálás a keresési eredmények oldalára
    if (searchTerm !== '') {
      navigate(`/books?search=${encodeURIComponent(searchTerm)}`);
      setSearchTerm(''); // Opcionálisan törölheted a keresési mezőt a navigálás után
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
          <li><Link to="/login">Login</Link></li>
        </ul>
        <div className="navbar-actions">
          <div className="search-container">
            <input
              type="text"
                placeholder="Search for books..."
                className="search-input"
                value={searchTerm}
                onChange={e => setSearchTerm(e.target.value)}
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
        </div>
        <LanguageSelector />
      </div>
    </nav>
  );
};

export default Navbar;
