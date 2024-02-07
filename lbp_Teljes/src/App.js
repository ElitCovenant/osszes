import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { AuthProvider } from './AuthContext'; // Győződj meg róla, hogy létrehoztad ezt a kontextust
import Navbar from './Navbar';
import Home from './Home';
import Books from './Books';
import Footer from './Footer';
import Login from './Login';
import {Hover} from './Hover'; // Feltételezem, hogy ez egy komponens
import './App.css';

const App = () => {
  const [searchTerm, setSearchTerm] = useState('');

  return (
    <Router>
      <AuthProvider> {/* Az AuthProvider itt kerül alkalmazásra */}
        <div className="app-container">
          <Navbar setSearchTerm={setSearchTerm} />
          <div className="content-container">
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/books" element={<Books searchTerm={searchTerm} />} />
              <Route path="/login" element={<Login />} />
              {/* További útvonalak és komponensek */}
            </Routes>
          </div>
          <Hover />
          <Footer />
        </div>
      </AuthProvider>
    </Router>
  );
};

export default App;
