import React, { useEffect } from 'react';
import './DownloadWindow.css';
import { useLanguage } from './LanguageProvider'; // Importáljuk a nyelv hook-ot


const DownloadWindow = ({ onClose }) => {
  const { translations } = useLanguage(); // Használjuk a nyelvi fordításokat

    
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
  <h2>{translations?.downloadWindow?.title || 'Downloadable Contents'}</h2> {/* Letölthető tartalmak */}
  <h3>{translations?.downloadWindow?.adminPanelTitle || 'Adminisztrációs panel (WPF):'}</h3> {/* Adminisztrációs panel (WPF) */}
    <button onClick={handleDownload} className="download-button">{translations?.downloadWindow?.buttonLabel || 'Download'}</button> {/* Letöltés gomb */}
    <button onClick={onClose} className="close-button">{translations?.downloadWindow?.cancelButtonLabel || 'Close'}</button> {/* Bezárás gomb */}
  </div>
</div>
  );
};

export default DownloadWindow;
