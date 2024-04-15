import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Login.css';
const Login = ({ isLoggedIn, toggleLogin = () => {} }) => {
  const [userName, setUserName] = useState('');
  const [hash, setPassword] = useState('');
  const [passwordVisible, setPasswordVisible] = useState(false);
  const navigate = useNavigate();

  const login = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch('https://localhost:7275/Login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ userName, hash }),
      });
      const data = await response.json();
      if (response.ok && data.troken) {
        localStorage.setItem('authToken', data.troken);
        toggleLogin();
        navigate('/');
      } else {
        console.error('Bejelentkezés sikertelen, válasz státusz:', response.status);
      }
    } catch (error) {
      console.error('Hiba történt a bejelentkezés során:', error);
    }
  };

  return (
    <div className="login-root">
      <div className="box-root padding-top--24 flex-flex flex-direction--column" style={{ flexGrow: 1, zIndex: 9 }}>
        <div className="box-root padding-top--48 padding-bottom--24 flex-flex flex-justifyContent--center">
          <h1>LibraryLogin</h1>
        </div>
        <div className="formbg-outer">
          <div className="formbg">
            <div className="formbg-inner padding-horizontal--48">
              <span className="padding-bottom--15">
                <p className='login-name' >Sign in to your account</p>
              </span>
              <form onSubmit={login}>
                
              <div className="field padding-bottom--24">
              <label className="userName" htmlFor="userName">Email</label>
              <input
                type="text"
                name="userName"
                value={userName}
                onChange={(e) => setUserName(e.target.value)}
                placeholder="Enter your email..."
              />
            </div>
            <div className="field padding-bottom--24">
              <label className="password" htmlFor="password">Password</label>
              <input
                type={passwordVisible ? 'text' : 'password'}
                name="hash"
                value={hash}
                onChange={(e) => setPassword(e.target.value)}
                placeholder="Enter your password..."
              />
              <div className="field-checkbox padding-top--8">
                <label className="Show-Password">
                  <input 
                    type="checkbox"
                    checked={passwordVisible}
                    onChange={() => setPasswordVisible(!passwordVisible)}
                  /> Show Password
                </label>
              </div>
            </div>

                <div className="field padding-bottom--24">
                  <button type="submit" className="submit">Sign in</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
  
};

export default Login;