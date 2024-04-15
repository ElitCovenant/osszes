import React, { useState, useEffect } from 'react';
import './UserPage.css';
import AvatarSelector from './AvatarSelector'; // Feltételezve, hogy ez a komponens már megíródott
import jwt_decode from './jwt_decode';
import def_logo from './img/default_prof_picture.png';
import quest1_logo from './img/quest1_prof_picture.png';
import quest2_logo from './img/quest2_prof_picture.png';
import teacher1_logo from './img/teacher1_prof_picture.png';
import teacher2_logo from './img/teacher2_prof_picture.png';
import Email from './Email';
import Loan from './Loan';
import BookHistory from './BookHistory';
import mailIcon from './img_icons/mail.png'; 

function UserPage() {
  const avatarlogos = [def_logo, teacher1_logo, teacher2_logo, quest1_logo, quest2_logo]
  const [isRoleSelectorOpen, setIsRoleSelectorOpen] = useState(false);
  const [profilePicturePath, setProfilePicturePath] = useState(null);
  const [decodedEmail, setDecodedEmail] = useState("");
  const [decodedrole, setDecodedRole] = useState("");
  const [isAdmin, setIsAdmin] = useState(false);
  const [isLoanVisible, setIsLoanVisible] = useState(false);

  const toggleRoleSelector = () => {
    setIsRoleSelectorOpen(!isRoleSelectorOpen);
  };

  const confirmRoleSelection = () => {
    setIsRoleSelectorOpen(false);
  };

  const toggleLoan = () => {
    setIsLoanVisible(!isLoanVisible);
  };

  useEffect(() => {
    const fetchProfilePicturePath = async () => {
      try {
        const token = localStorage.getItem('authToken');
        if (token) {
          const decodedToken = jwt_decode(token);
          setDecodedRole(decodedToken.role === "Admin" ? "Librarian" : "Student");
          setIsAdmin(decodedToken.role === "Admin");
          setDecodedEmail(decodedToken.emailaddress.split("@")[0].toUpperCase());
          const response = await fetch(`https://localhost:7275/önkép/${decodedToken.dns}`);
          if (response.ok) {
            const data = await response.json();
            if (data != null) {
              setProfilePicturePath(data);
            } else {
              console.error('Nincs profilkép az adatokban');
            }
          } else {
            console.error('Hiba történt a profilkép lekérésekor:', response.status);
          }
        }
      } catch (error) {
        console.error('Error fetching profile picture path:', error);
      }
    };

    fetchProfilePicturePath();
  }, []);

  return (
    <div>
      <div className="facebook-profile">
        <div className="profile-header" onClick={toggleRoleSelector}>
          <img src={profilePicturePath > 0 ? avatarlogos[profilePicturePath - 1] : avatarlogos[profilePicturePath]} alt="Profile" height={80} />
          <div>
            <h2>Welcome {decodedEmail}</h2>
            <p>{decodedrole}</p>
          </div>
        </div>
        
        {isRoleSelectorOpen && (
          <>
            <div className="role-selector-modal-overlay" onClick={toggleRoleSelector}></div>
            <div className="role-selector-modal">
              <AvatarSelector onClose={confirmRoleSelection} />
            </div>
          </>
        )}
        {isAdmin && <button className="toggleLoan-button" onClick={toggleLoan}>Send Email <img src={mailIcon} alt="Logout Icon" className="mail-icon" /></button>}
      </div>
      {isAdmin && <Loan/>}
      <BookHistory bookHistory={["History item 1", "History item 2", "History item 3"]} />

      {isLoanVisible && <Email />}
    </div>
  );
}

export default UserPage;