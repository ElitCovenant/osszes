import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { AuthProvider } from './AuthContext';
import Navbar from './Navbar';
import Home from './Home';
import Books from './Books';
import Footer from './Footer';
import Login from './Login';
import {Hover} from './Hover';
import './App.css';
import UserPage from './UserPage';
import CookieConsent from './CookieConsent';
import Settings from './Settings';

const App = () => {
  const [searchTerm, setSearchTerm] = useState('');

  return (
    <Router>
      <div className="app-container">
        <CookieConsent />
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
        </AuthProvider>
        <Footer />
      </div>
    </Router>
  );
};

export default App;
