import React, { useState, useEffect } from 'react';
import './CookieConsent.css'; // CSS fájl importálása

const CookieConsent = () => {
  const [isVisible, setIsVisible] = useState(true);

  useEffect(() => {
    // A cookie consent megjelenésekor letiltja az oldal görgetését
    document.body.classList.add('no-scroll');

    // Tiszta leállítás a komponens megszűnésekor
    return () => {
      document.body.classList.remove('no-scroll');
    };
  }, []);

  const handleAccept = () => {
    setIsVisible(false);
    enablePage(); // Oldal engedélyezése az elfogadás után
  };

  const enablePage = () => {
    document.body.classList.remove('no-scroll'); // Oldal görgetésének engedélyezése
  };

  return (
    <div className={`cookie-consent ${isVisible ? 'visible' : ''}`}>
      <div className="modal">
        <h1>This site uses cookies</h1>
        <p>Cookies help us deliver the best experience on our website. By using our website, you agree to the use of cookies. <a href='https://www.cookiebot.com/en/cookie-consent/' target='blank'>Find out how we use cookies.</a></p>
        <button onClick={handleAccept}>Accept</button>
      </div>
    </div>
  );
};

export default CookieConsent;
