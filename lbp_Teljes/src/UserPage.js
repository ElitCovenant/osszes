import React, { useState, useEffect } from 'react';
import './UserPage.css';
import AvatarSelector from './AvatarSelector'; // Assuming this component has already been implemented
import jwt_decode from './jwt_decode';
import def_logo from './img/default_prof_picture.png';
import quest1_logo from './img/quest1_prof_picture.png';
import quest2_logo from './img/quest2_prof_picture.png';
import teacher1_logo from './img/teacher1_prof_picture.png';
import teacher2_logo from './img/teacher2_prof_picture.png';

function UserPage() {
  const avatarlogos = [def_logo, teacher1_logo, teacher2_logo, quest1_logo, quest2_logo];
  const [isMailboxOpen, setIsMailboxOpen] = useState(false);
  const [isRoleSelectorOpen, setIsRoleSelectorOpen] = useState(false);
  const [profilePicturePath, setProfilePicturePath] = useState(null);
  const [decodedEmail, setDecodedEmail] = useState('');
  const [decodedrole, setDecodedRole] = useState('');

  const toggleMailbox = (e) => {
    e.stopPropagation(); // Prevent click event propagation
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
          const response = await fetch(`https://localhost:7275/önkép/${decodedToken.dns}`);
          if (response.ok) {
            const data = await response.json();
            if (data != null) {
              setProfilePicturePath(data);
              setDecodedEmail(decodedToken.emailaddress.split('@')[0].toUpperCase());
              setDecodedRole(decodedToken.role === 'Admin' ? 'Librarian' : 'Student');
            } else {
              console.error('No profile picture found in the data');
            }
          } else {
            console.error('Error fetching profile picture:', response.status);
          }
        }
      } catch (error) {
        console.error('Error fetching profile picture:', error);
      }
    };

    fetchProfilePicturePath();
  }, []);

  const handleLibraryManagerDownload = () => {
    // Create an anchor element
    const anchor = document.createElement('a');
    // Set href to the URL of the MSI file
    anchor.href = 'http://img.library.nhely.hu/setup/KonyvtarKarbantarto_Setup.msi';
    // Set the download attribute and the filename
    anchor.download = 'KonyvtarKarbantarto_Setup.msi';
    // Simulate a click on the anchor element
    anchor.click();
  };

  return (
    <div className="facebook-profile">
      <div className="profile-header" onClick={toggleRoleSelector}>
        <img src={profilePicturePath > 0 ? avatarlogos[profilePicturePath - 1] : avatarlogos[profilePicturePath]} alt="Profile" height={80} />
        <div>
          <h2>Welcome {decodedEmail}</h2>
          <p>{decodedrole}</p>
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
          <button onClick={handleLibraryManagerDownload}>Library Manager Download</button>
          <button onClick={toggleMailbox}>Close</button>
        </div>
      )}
    </div>
  );
}

export default UserPage;
