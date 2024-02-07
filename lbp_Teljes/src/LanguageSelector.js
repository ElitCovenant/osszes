import React, { useState } from 'react';
import './LanguageSelector.css';

function LanguageSelector() {
    const [isOpen, setIsOpen] = useState(false);
    const [selectedLanguage, setSelectedLanguage] = useState('English (US)');

    const languages = [
        { name: 'English (US)', code: 'us'  },

        { name: 'Hungary (HUN)' , code: 'hun' },
    
    ];

    const toggleDropdown = () => setIsOpen(!isOpen);
    const selectLanguage = (language) => {
        setSelectedLanguage(language);
        setIsOpen(false);
    };

    return (
        <div className="language-selector">
            <button onClick={toggleDropdown} className="dropdown-button">
                {selectedLanguage}
            </button>
            {isOpen && (
                <ul className="dropdown-menu">
                    {languages.map((language, index) => (
                        <p key={index} onClick={() => selectLanguage(language.name)}>
                            {language.name}
                        </p>
                    ))}
                </ul>
            )}
        </div>
    );
}

export default LanguageSelector;
