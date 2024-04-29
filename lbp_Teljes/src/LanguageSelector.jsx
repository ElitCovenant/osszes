import React, { useState } from 'react';
import { useLanguage } from './LanguageProvider';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faGlobe } from '@fortawesome/free-solid-svg-icons';
import './LanguageSelector.css';

const LanguageSelector = () => {
  const { changeLanguage } = useLanguage();
  const [isOpen, setIsOpen] = useState(false);

  const languages = [
    { name: 'EN', code: 'en' },
    { name: 'HUN', code: 'hun' },
  ];

  const toggleDropdown = () => setIsOpen(!isOpen);

  const selectLanguage = (language) => {
    setIsOpen(false);
    changeLanguage(language); // A nyelv megváltoztatása a LanguageProvider segítségével
  };

  return (
    <div className="language-selector">
      <button onClick={toggleDropdown} className="dropdown-button">
      <FontAwesomeIcon icon={faGlobe} className="icon" color="white" />
      </button>
      {isOpen && (
        <ul className="dropdown-menu">
          {languages.map((language, index) => (
            <p key={index} onClick={() => selectLanguage(language.code)}>
              {language.name}
            </p>
          ))}
        </ul>
      )}
    </div>
  );
};

export default LanguageSelector;
