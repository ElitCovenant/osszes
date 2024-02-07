import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [passwordVisible, setPasswordVisible] = useState(false);
  const navigate = useNavigate();

  const login = async (e) => {
    e.preventDefault();
    try {
      const loginResponse = await axios.post('https://api.example.com/login', { email, password });
      if (loginResponse.status === 200 && loginResponse.data.token) {
        localStorage.setItem('authToken', loginResponse.data.token);
        navigate('/UserPage');
      } else {
        console.error('Bejelentkezés sikertelen');
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
              <span className="padding-bottom--15">Sign in to your account</span>
              <form onSubmit={login}>
                <div className="field padding-bottom--24">
                  <label htmlFor="email">Email</label>
                  <input type="email" name="email" value={email} onChange={(e) => setEmail(e.target.value)} />
                </div>
                <div className="field padding-bottom--24">
                  <label htmlFor="password">Password</label>
                  <input
                    type={passwordVisible ? "text" : "password"}
                    name="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                  />
                  <div className="field-checkbox padding-top--8">
                    <label>
                      <input
                        type="checkbox"
                        checked={passwordVisible}
                        onChange={() => setPasswordVisible(!passwordVisible)}
                      /> Show Password
                    </label>
                  </div>
                </div>
                <div className="field padding-bottom--24">
                  <input type="submit" name="submit" value="Sign in"/>
                </div>
              </form>
            </div>
          </div>
          <div className="footer-link padding-top--24">
            <span>Don't have an account? <a href="/signup">Sign up</a></span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
