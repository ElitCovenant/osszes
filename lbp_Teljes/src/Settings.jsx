import React, { useState, useEffect } from 'react';
import './Settings.css';
import DownloadWindow from './DownloadWindow';
import jwt_decode from './jwt_decode';

const Settings = () => {
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
                    <h2 className="panel-header">Admin Settings</h2>
                    <div className="panel-content">
                        <div className="card-settings" onClick={openDownloadWindow}>Downloads</div>
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
                <h2 className="panel-header">User Settings</h2>
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
