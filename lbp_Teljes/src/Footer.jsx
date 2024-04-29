import React from 'react';
import { useLanguage } from './LanguageProvider';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFacebook, faTwitch, faYoutube } from '@fortawesome/free-brands-svg-icons';
import './Footer.css';

const Footer = () => {
  const { translations } = useLanguage();

  const links = [
    { icon: faFacebook, url: 'https://www.facebook.com/kandomiskolc' },
    { icon: faTwitch, url: 'https://www.twitch.tv/kkszki' },
    { icon: faYoutube, url: 'https://www.youtube.com/user/kkszki/videos' },
  ];

  return (
    <footer className="footer-distributed">
      <div className="footer-left">
        <a href="https://www.kkszki.hu" target="_blank" rel="noopener noreferrer">
          <h3>{translations.footer.school_name}</h3>
        </a>
        <p className="footer-links">
          <a href="https://cms.kando.intezmeny.edir.hu/uploads/adatvedelmi_tajekoztato_2_dbb7b7e9f6.pdf" className="link-1">{translations.footer.data_policy}</a>
          <a href="/">{translations.footer.imprint}</a>
        </p>
      </div>

      <div className="footer-center">
        <div className="footer-info">
          <i className="fa fa-map-marker"></i>
          <p><span>3525 Miskolc</span>{translations.footer.address}</p>
        </div>
        <div className="footer-info">
          <i className="fa-fa-phone">
          <p>{translations.footer.opening_hours}</p></i>
        </div>
        <div className="footer-info">
          <i className="fa fa-envelope"></i>
          <p><a href="mailto:kando@kkszki.hu">kando@kkszki.hu</a></p>
        </div>
      </div>

      <div className="footer-right">
        <p className="footer-company-about">
          <span>{translations.footer.contact}</span>
        </p>
      </div>

      <div className="footer-icons">
        {links.map((link, index) => (
          <a key={index} href={link.url} target="_blank" rel="noopener noreferrer">
            <FontAwesomeIcon icon={link.icon} />
          </a>
        ))}
      </div>
    </footer>
  );
};

export default Footer;
