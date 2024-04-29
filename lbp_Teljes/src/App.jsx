import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { AuthProvider } from './AuthContext';
import Navbar from './Navbar';
import Home from './Home';
import Books from './Books';
import Footer from './Footer';
import Login from './Login';
import { Hover } from './Hover';
import './App.css';
import UserPage from './UserPage';
import CookieConsent from './CookieConsent';
import Settings from './Settings';
import LanguageProvider from './LanguageProvider'; 

const App = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [showCookieConsent, setShowCookieConsent] = useState(true);

  useEffect(() => {
    // Check if authToken exists in localStorage
    const authToken = localStorage.getItem('authToken');
    if (authToken) {
      setShowCookieConsent(false); // Hide CookieConsent if authToken exists
    }
  }, []);

  return (
    <Router>
      <LanguageProvider> 
        <div className="app-container">
          {showCookieConsent && <CookieConsent />} 
          <AuthProvider>
            <Navbar setSearchTerm={setSearchTerm} />
            <div className="content-container">
              <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/books" element={<Books searchTerm={searchTerm} />} />
                <Route path="/login" element={<Login />} />
                <Route path="/userpage" element={<UserPage />} />
                <Route path="/settings" element={<Settings />} />
              </Routes>
            </div>
            <Hover />
            <Footer />
          </AuthProvider>
        </div>
      </LanguageProvider>
    </Router>
  );
};

export default App;
