import React, { useState, useEffect } from 'react';
import './AvatarSelector.css';
import jwt_decode from './jwt_decode';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import quest1_logo from './img/quest1_prof_picture.png';
import quest2_logo from './img/quest2_prof_picture.png';
import teacher1_logo from './img/teacher1_prof_picture.png';
import teacher2_logo from './img/teacher2_prof_picture.png';

function AvatarSelector({ onClose }) {
  const [avatars, setAvatars] = useState([]);
  const [profilePicturePath, setProfilePicturePath] = useState(null);
  const [isAdmin, setIsAdmin] = useState(false);

  const avatarlogos = [teacher1_logo, teacher2_logo, quest1_logo, quest2_logo];

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

  useEffect(() => {
    const fetchProfilePicturePath = async () => {
      try {
        const troken = localStorage.getItem('authToken');
        if (troken) {
          const decodedToken = jwt_decode(troken);
          if (decodedToken && decodedToken.actor) {
            const imgPath = decodedToken.actor;
            setProfilePicturePath(imgPath);
            setIsAdmin(decodedToken.role === 'Admin');
          }
        }
      } catch (error) {
        console.error('Error fetching profile picture path:', error);
      }
    };

    fetchProfilePicturePath();
  }, []);

  const handleAvatarClick = async (avatar, index) => {
    try {
      const troken = localStorage.getItem('authToken');
      if (troken) {
        const decodedToken = jwt_decode(troken);
        if (decodedToken && decodedToken.dns) {
          const response = await fetch(`https://localhost:7275/profilkepvaltas/${decodedToken.dns}?profId=${index + 2}`, {
            method: 'PUT',
            headers: {
              'Content-Type': 'application/json',
              'Authorization': `Bearer ${troken}`
            },
            body: JSON.stringify({ avatarId: avatar.id })
          });
          if (response.ok) {
            toast.success('Avatar successfully changed!');
          } else {
            console.error('Hiba történt az avatar frissítése során:', response.statusText);
          }
        }
      }
    } catch (error) {
      console.error('Hiba történt az avatar frissítése során:', error);
    }
  };

  return (
    <div className="avatar-selector-container">
      <button onClick={onClose}>Bezár</button>
      <div className="avatars-container">
        {avatarlogos.map((avatar, index) => (
          <div key={index} className="avatar-item">
            {isAdmin || index >= avatarlogos.length - 2 ? (
              <button onClick={() => handleAvatarClick(avatar, index)}>
                <img src={avatar} alt={`Avatar ${index + 1}`} />
              </button>
            ) : null}
          </div>
        ))}
      </div>
      <ToastContainer />
    </div>
  );
}

export default AvatarSelector;
