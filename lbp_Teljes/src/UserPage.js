import React from 'react';
import './UserPage.css';
import ProfileComponent from './ProfileComponent';

const UserPage = () => {
  return (
    <div className='yeep'>
      <p>Felhasználói Profil</p>
      <ProfileComponent />
    </div>
  );
};

export default UserPage;
