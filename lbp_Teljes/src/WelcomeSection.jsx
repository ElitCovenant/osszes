import React from 'react';
import { useLanguage } from './LanguageProvider';
import './WelcomeSection.css';

const WelcomeSection = () => {
  const { translations } = useLanguage();

  return (
    <div className="container">
      <div className="typed-out">
        <br />
        <p>
          {translations.welcome_message}
          <br />
          {translations.library_goal}
          <br />
        </p>
      </div>
    </div>
  );
};

export default WelcomeSection;
