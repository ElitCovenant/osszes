import React, { useState, useEffect } from 'react';
import './AvatarSelector.css'; // Az útvonalat szükség szerint módosítsd

function AvatarSelector({ onClose }) {
  const [avatars, setAvatars] = useState([]);

  useEffect(() => {
    const fetchAvatars = async () => {
      try {
        // Adatbázisból avatárok lekérése
        const response = await fetch('https://localhost:7275/Tanulók');
        if (response.ok) {
          const imgPaths = await response.json(); // Az adatok közvetlenül az elérési útvonalakat tartalmazzák
          setAvatars(imgPaths || []);
          console.log(imgPaths);
        } else {
          console.error('Avatárok lekérése sikertelen');
        }
      } catch (error) {
        console.error('Hiba történt az avatárok lekérése során:', error);
      }
    };
  
    fetchAvatars();
  }, []); // Az üres dependency array megakadályozza a useEffect újra futtatását

  return (
    <div className="avatar-selector-container">
      <button onClick={onClose}>Bezár</button>
      <div className="avatars-container">
        {avatars.map((avatar, index) => (
          <div key={index} className="avatar-item">
            <img src={avatar} alt={`Avatar ${index + 1}`} />
          </div>
        ))}
      </div>
    </div>
  );
}

export default AvatarSelector;