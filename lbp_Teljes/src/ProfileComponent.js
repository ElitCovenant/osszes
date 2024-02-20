import React, { useState } from 'react';
import AvatarSelector from './AvatarSelector';
import FavoriteBooks from './FavoriteBooks';
import './ProfileComponent.css'
function ProfileComponent() {
  const [isAvatarSelectorOpen, setIsAvatarSelectorOpen] = useState(false);
  const userEmail = "user@example.com"; // Ez valós alkalmazásban dinamikusan lenne beállítva

  return (
    <div className='box'>
      <h2>Felhasználó Email: {userEmail}</h2>
      <button onClick={() => setIsAvatarSelectorOpen(true)}>Válassz Avatart</button>
      {isAvatarSelectorOpen && <AvatarSelector onClose={() => setIsAvatarSelectorOpen(false)} />}
      <FavoriteBooks />
    </div>
  );
}

export default ProfileComponent;