import React, { useState, useEffect } from 'react';
import './AvatarSelector.css';

function AvatarSelector({ onClose }) {
  const [avatars, setAvatars] = useState([]);

  useEffect(() => {
    const fetchAvatars = async () => {
      try {
        const response = await fetch('https://localhost:7275/Tanulók');
        if (response.ok) {
          const avatarsData = await response.json();
          setAvatars(avatarsData || []);
        } else {
          console.error('Avatárok lekérése sikertelen');
        }
      } catch (error) {
        console.error('Hiba történt az avatárok lekérése során:', error);
      }
    };
  
    fetchAvatars();
  }, []);

  // A fájlnév kinyerése az elérési útvonalból
  const getFileName = (path) => {
    return path.split('/').pop().split('.')[0];
  };

  return (
    <div className="avatar-selector-container">
      <button onClick={onClose}>Bezár</button>
      <div className="avatars-container">
        {avatars.map((avatar, index) => (
          <div key={index} className="avatar-item">
            {/* Az alt attribútum kiszámítása a fájl elérési útvonalának utolsó részéből */}
            <img src={avatar.imgPath} alt={getFileName(avatar.imgPath) || `Avatar ${index + 1}`} />
          </div>
        ))}
      </div>
    </div>
  );
}

export default AvatarSelector;
