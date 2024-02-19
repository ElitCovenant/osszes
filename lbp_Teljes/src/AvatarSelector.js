import React from 'react';
import './AvatarSelector.css'; // Az útvonalat szükség szerint módosítsd

const categories = {
  Teacher: ['TeacherAvatar1.png', 'TeacherAvatar2.png'],
  Student: ['StudentAvatar1.png', 'StudentAvatar2.png'],
  // További kategóriák és avatarok hozzáadhatók
};

function AvatarSelector({ onClose }) {
  return (
    <div className="avatar-selector-container">
      <button onClick={onClose}>Bezár</button>
      {Object.keys(categories).map((category) => (
        <div key={category}>
          <h3>{category}</h3>
          <div className="avatars-container">
            {categories[category].map((avatar) => (
              <div key={avatar} className="avatar-item">
                <img src={avatar} alt={avatar} />
              </div>
            ))}
          </div>
        </div>
      ))}
    </div>
  );
}

export default AvatarSelector;