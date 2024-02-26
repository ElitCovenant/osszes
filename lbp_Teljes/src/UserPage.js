import React, { useState, useEffect } from 'react';
import './UserPage.css';
import AvatarSelector from './AvatarSelector'; // Feltételezve, hogy ez a komponens már megíródott
import jwt_decode from './jwt_decode';
import def_logo from './img/default_prof_picture.png';
import quest1_logo from './img/quest1_prof_picture.png';
import quest2_logo from './img/quest2_prof_picture.png';
import teacher1_logo from './img/teacher1_prof_picture.png';
import teacher2_logo from './img/teacher2_prof_picture.png';

function UserPage() {
  const avatarlogos = [def_logo,teacher1_logo,teacher2_logo,quest1_logo,quest2_logo]
  const [isMailboxOpen, setIsMailboxOpen] = useState(false);
  const [isRoleSelectorOpen, setIsRoleSelectorOpen] = useState(false);
  const [profilePicturePath, setProfilePicturePath] = useState(null);

  const toggleMailbox = (e) => {
    e.stopPropagation(); // Megakadályozza a klikk esemény terjedését
    setIsMailboxOpen(!isMailboxOpen);
  };

  const toggleRoleSelector = () => {
    setIsRoleSelectorOpen(!isRoleSelectorOpen);
  };

  const confirmRoleSelection = () => {
    setIsRoleSelectorOpen(false);
  };

  useEffect(() => {
    const fetchProfilePicturePath = async () => {
      try {
          const troken = localStorage.getItem('authToken');
          if (troken) {
            const decodedToken = jwt_decode(troken);
            if (decodedToken && decodedToken.actor) {         
              const imgPath = decodedToken.actor;
                setProfilePicturePath(imgPath)
            }
          }    
      } catch (error) {
        console.error('Error fetching profile picture path:', error);
      }
    };
  
    fetchProfilePicturePath();
  }, []);

  return (
    <div className="facebook-profile">
      <div className="profile-header" onClick={toggleRoleSelector}>
        <img src={profilePicturePath > 0 ?avatarlogos[profilePicturePath-1]:avatarlogos[profilePicturePath]} alt="Profile" className="profile-picture" />
        <div>
          <h2>Jane Doe</h2>
          <p>Software Developer at Google</p>
        </div>
        <img src="faEmail.png" alt="Mailbox" className="mail-icon" onClick={toggleMailbox} />
      </div>
      {isRoleSelectorOpen && (
        <>
          <div className="role-selector-modal-overlay" onClick={toggleRoleSelector}></div>
          <div className="role-selector-modal">
            <AvatarSelector onClose={confirmRoleSelection} />
          </div>
        </>
      )}
      {isMailboxOpen && (
        <div className="mailbox">
          {/* Mailbox tartalom */}
          <button onClick={toggleMailbox}>Bezár</button>
        </div>
      )}
      </div>
  );
}

export default UserPage;
