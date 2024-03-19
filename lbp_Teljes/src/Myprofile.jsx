import React, { useState } from 'react';
import './Myprofile.css';

const myprofile = ({ userName, email, bio, profilePicture, onUpdateProfilePicture }) => {
  const [newProfilePicture, setNewProfilePicture] = useState('');

  const handleProfilePictureChange = (e) => {
    setNewProfilePicture(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onUpdateProfilePicture(newProfilePicture);
    setNewProfilePicture('');
  };

  return (
    <div className="profile-container">
      <h2>My Profile</h2>
      <div className="profile-details">
        <div>
          <strong>Username:</strong> {userName}
        </div>
        <div>
          <strong>Email:</strong> {email}
        </div>
        <div>
          <strong>Bio:</strong> {bio}
        </div>
        <div>
          <strong>Profile Picture:</strong> <img src={profilePicture} alt="Profile" height={50} />
        </div>
      </div>
      <form onSubmit={handleSubmit}>
        <div className="profile-picture-upload">
          <label htmlFor="newProfilePicture">Change Profile Picture:</label>
          <input
            type="text"
            id="newProfilePicture"
            value={newProfilePicture}
            onChange={handleProfilePictureChange}
            placeholder="Enter image URL"
          />
          <button type="submit">Update</button>
        </div>
      </form>
    </div>
  );
};

export default myprofile;