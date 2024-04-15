import React, { useState, useEffect } from 'react';
import './Hover.css';

export const Hover = () => {
  // Állapot definiálása a gomb megjelenítésének vezérlésére
  const [showButton, setShowButton] = useState(false);

  // Scroll eseménykezelő funkció definiálása
  useEffect(() => {
    const handleScroll = () => {
      // Ellenőrizze a görgetési pozíciót, és állítsa be az állapotot ennek megfelelően
      if (window.scrollY > 20) {
        setShowButton(true);
      } else {
        setShowButton(false);
      }
    };

    // Scroll esemény figyelése
    window.addEventListener('scroll', handleScroll);

    // Eseményfigyelő eltávolítása a komponens megszűnésekor (takarítás)
    return () => {
      window.removeEventListener('scroll', handleScroll);
    };
  }, []); // Az üres tömb azt jelzi, hogy az useEffect csak a komponens mount és unmount esetén fussa le

  // Vissza a tetejére gombra kattintáskor végrehajtott funkció
  const topFunction = () => {
    window.scrollTo({
      top: 0,
      behavior: 'smooth' // Felgördülő animáció bekapcsolása
    });
  };

  // A komponens JSX kódja
  return (
    <div>
      {/* Vissza a tetejére gomb */}
      <button
        id="myBtn"
        onClick={topFunction}
        title="Vissza a tetejére"
        style={{ display: showButton ? 'block' : 'none' }}
      >
        ↑
      </button>
    </div>
  );
};
