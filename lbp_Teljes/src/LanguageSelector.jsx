import React, { useState } from 'react';
import './LanguageSelector.css';

function LanguageSelector() {
    const [isOpen, setIsOpen] = useState(false);
    const [selectedLanguage, setSelectedLanguage] = useState('(US)');

    const languages = [
        { name: '(US)', code: 'us'  },

        { name: '(HUN)' , code: 'hun' },
    
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
