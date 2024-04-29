import React, { useState, useContext, createContext } from 'react';

const LanguageContext = createContext();

export const useLanguage = () => {
  return useContext(LanguageContext);
};

const LanguageProvider = ({ children }) => {
  const [language, setLanguage] = useState('en'); // Kezdetben az angol nyelv legyen beállítva

  // Nyelvi fordítások objektuma
  const translations = {
    en: {
      navbar: {
        home: 'Home',
        books: 'Books',
        myProfile: 'My Profile',
        settings: 'Settings',
        login: 'Login',
        logout: 'Logout',
      },
      welcome_message: 'Welcome to all our dear visitors, teachers, and students to the online library page of Miskolc SZC Kandó Kálmán Information Technology High School!',
      library_goal: 'The goal of the school library is to support education and learning.',
      footer: {
        school_name: '2023 • Miskolci SZC Kandó Kálmán Informatikai Technikum',
        data_policy: 'Data Privacy Policy',
        imprint: 'Imprint',
        address: 'Palóczy László street 3.',
        contact: 'Contact\nPhone: +36 46 500 930\nOM ID: 203060/015\nAdult Education Registry Number: E-001290/2015',
        opening_hours: 'Opening hours:\nMonday 8:00–16:00\nTuesday 8:00–16:00\nWednesday 8:00–16:00\nThursday 8:00–16:00\nFriday 8:00–16:00\nSaturday Closed\nSunday Closed',
      },
      login: {
        pageTitle: 'Login',
        signInText: 'Sign in to your account',
        emailLabel: 'Email',
        emailPlaceholder: 'Enter your email...',
        passwordLabel: 'Password',
        passwordPlaceholder: 'Enter your password...',
        showPasswordLabel: 'Show Password',
        signInButton: 'Sign in',
      },
      libraryFilter: {
        authorLabel: 'Author',
        titleLabel: 'Title',
        filterButton: 'Search',
      },
      loan: {
        loanHistory: 'Loan History',
        selectAll: 'Select All',
        sendMessage: 'Send Message',
        loanedBooks: 'Book Loaned',
        returnDate: 'Return Date',
        noBooks: 'No Books Loaned',
        loading: 'Loading...',
        bookHistory: 'Book History',
        loanedBook: 'Book Loaned',
      },
      settings: {
        adminSettings: 'Admin Settings',
        userSettings: 'User Settings',
        downloads: 'Downloads',
      },
      downloadWindow: {
        title: 'Download Window',
        description: 'This is the description of the download window in English.',
        buttonLabel: 'Download',
        cancelButtonLabel: 'Cancel',
        adminPanelTitle: 'Admin Panel (WPF):',
      },
      avatarSelector: {
        title: 'Avatar Selector',
        closeButton: 'Close',
        successMessage: 'Avatar successfully changed!',
        errorMessage: 'Something went wrong',
      },
    },
    hun: {
      navbar: {
        home: 'Kezdőlap',
        books: 'Könyvek',
        myProfile: 'Profil',
        settings: 'Beállítások',
        login: 'Bejelentkezés',
        logout: 'Kijelentkezés',
      },
      welcome_message: 'Üdvözlünk minden kedves látogatót, tanárt és diákot a Miskolci SZC Kandó Kálmán Informatikai Technikum online könyvtár oldalán!',
      library_goal: 'Az iskolai könyvtár célja az oktatás és tanulás támogatása.',
      footer: {
        school_name: '2023 • Miskolci SZC Kandó Kálmán Informatikai Technikum',
        data_policy: 'Adatvédelmi irányelvek',
        imprint: 'Impresszum',
        address: 'Palóczy László utca 3.',
        contact: 'Kapcsolat\nTelefon: +36 46 500 930\nOM azonosító: 203060/015\nFelnőttképzési nyilvántartás száma: E-001290/2015',
        opening_hours: 'Nyitvatartás:\nHétfő 8:00–16:00\nKedd 8:00–16:00\nSzerda 8:00–16:00\nCsütörtök 8:00–16:00\nPéntek 8:00–16:00\nSzombat Zárva\nVasárnap Zárva',
      },
      login: {
        pageTitle: 'Belépés',
        signInText: 'Jelentkezzen be fiókjába',
        emailLabel: 'Email',
        emailPlaceholder: 'Adja meg az email címét...',
        passwordLabel: 'Jelszó',
        passwordPlaceholder: 'Adja meg a jelszavát...',
        showPasswordLabel: 'Jelszó megjelenítése',
        signInButton: 'Bejelentkezés',
      },
      libraryFilter: {
        authorLabel: 'Szerző',
        titleLabel: 'Cím',
        filterButton: 'Keresés',
      },
      loan: {
        loanHistory: 'Kölcsönzési előzmények',
        selectAll: 'Összes kijelölése',
        sendMessage: 'Üzenet küldése',
        loanedBooks: 'Kölcsönzött könyvek',
        returnDate: 'Visszaadási dátum',
        noBooks: 'Nincsenek kölcsönzött könyvek',
        loading: 'Betöltés...',
        bookHistory: 'Kölcsönzési előzmények',
        loanedBook: 'Kölcsönzött könyv',
      },
      settings: {
        adminSettings: 'Adminisztrációs beállítások',
        userSettings: 'Felhasználói beállítások',
        downloads: 'Letöltések',
      },
      downloadWindow: {
        title: 'Letöltési ablak',
        description: 'Ez a letöltési ablak leírása magyarul.',
        buttonLabel: 'Letöltés',
        cancelButtonLabel: 'Mégsem',
        adminPanelTitle: 'Adminisztrációs panel (WPF):',
      },
      avatarSelector: {
        title: 'Avatar kiválasztó',
        closeButton: 'Bezárás',
        successMessage: 'A profilkép sikeresen megváltoztatva!',
        errorMessage: 'Valami nem sikerúlt',
      }
    },
  };
  

  const changeLanguage = (lang) => {
    setLanguage(lang);
  };

  const value = {
    language,
    translations: translations[language],
    changeLanguage,
  };

  return (
    <LanguageContext.Provider value={value}>
      {children}
    </LanguageContext.Provider>
  );
};

export default LanguageProvider;
