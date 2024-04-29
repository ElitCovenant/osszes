import React, { useState, useEffect } from 'react';
import './Settings.css';
import DownloadWindow from './DownloadWindow';
import jwt_decode from './jwt_decode';
import { useLanguage } from './LanguageProvider';

const Settings = () => {
    const { translations } = useLanguage(); // Használjuk a translations objektumot a nyelvi fordításokhoz

    const [isDownloadWindowOpen, setIsDownloadWindowOpen] = useState(false);
    const [isAdmin, setIsAdmin] = useState(false);

    const openDownloadWindow = () => {
      setIsDownloadWindowOpen(true);
    };
  
    const closeDownloadWindow = () => {
      setIsDownloadWindowOpen(false);
    };

    useEffect(() => {
        const token = localStorage.getItem('authToken');
        if (token) {
            const decodedToken = jwt_decode(token);
            setIsAdmin(decodedToken.role === "Admin");
        }
    }, []);

    return (
        <div className="settings-container">
            {isAdmin && (
                <div className="panel">
                    <h2 className="panel-header">{translations?.settings?.adminSettings || 'Admin Settings'}</h2> {/* Használjuk a fordítást a címhez */}
                    <div className="panel-content">
                    <div className="card-settings" onClick={openDownloadWindow}>{translations?.settings?.downloads || 'Downloads'}</div> {/* Használjuk a fordítást a kártyához */}
                        <div className="card-settings">(Work in Progress)</div>
                        <div className="card-settings">(Work in Progress)</div>
                        <div className="card-settings">(Work in Progress)</div>
                        <div className="card-settings">(Work in Progress)</div>
                        <div className="card-settings">(Work in Progress)</div>
                        <div className="card-settings">(Work in Progress)</div>
                        <div className="card-settings">(Work in Progress)</div>
                        <div className="card-settings">(Work in Progress)</div>
                    </div>
                </div>
            )}
            <div className="panel">
            <h2 className="panel-header">{translations?.settings?.userSettings || 'User Settings'}</h2> {/* Használjuk a fordítást a címhez */}
                <div className="panel-content">
                    <div className="card-settings">(Work in Progress)</div>
                    <div className="card-settings">(Work in Progress)</div>
                    <div className="card-settings">(Work in Progress)</div>
                    <div className="card-settings">(Work in Progress)</div>
                    <div className="card-settings">(Work in Progress)</div>
                    <div className="card-settings">(Work in Progress)</div>
                    <div className="card-settings">(Work in Progress)</div>
                    <div className="card-settings">(Work in Progress)</div>
                    <div className="card-settings">(Work in Progress)</div>
                </div>
            </div>
            {isDownloadWindowOpen && <DownloadWindow onClose={closeDownloadWindow} />}
        </div>
    );
};

export default Settings;
