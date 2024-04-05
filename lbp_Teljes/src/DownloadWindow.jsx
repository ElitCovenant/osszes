import React, { useEffect } from 'react';
import './DownloadWindow.css';

const DownloadWindow = ({ onClose }) => {
    
    useEffect(() => {
        // A cookie consent megjelenésekor letiltja az oldal görgetését
        document.body.classList.add('no-scroll');
    
        // Tiszta leállítás a komponens megszűnésekor
        return () => {
          document.body.classList.remove('no-scroll');
        };
      }, []);

    const handleDownload = () => {
        window.location.href = "http://img.library.nhely.hu/setup/KonyvtarKarbantarto_Setup.msi";
    };

  return (
    <div className="download-window">
  <div className="download-content">
    <h2>Downloadable Contents</h2>
    <h3>Adminisztrációs panel (WPF):</h3>
    <button onClick={handleDownload} className="download-button">Download</button> {/* Letöltés gomb */}
    <button onClick={onClose} className="close-button">Close</button> {/* Bezárás gomb */}
  </div>
</div>
  );
};

export default DownloadWindow;
