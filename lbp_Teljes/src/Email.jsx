import React, { useState, useEffect } from 'react';
import './Email.css';

function Loan() {
  const [newEmail, setNewEmail] = useState('');
  const [emailList, setEmailList] = useState([]);
  const [message, setMessage] = useState('');
  const [recipients, setRecipients] = useState('');
  const [file, setFile] = useState(null);
  const [isPanelVisible, setIsPanelVisible] = useState(true); // Új állapot a panel láthatóságának kezelésére



  // E-mail cím validálás
  const isValidEmail = email => /\S+@\S+\.\S+/.test(email);

  useEffect(() => {
    // Az e-mail címek lekérése a komponens betöltésekor
    const fetchEmails = async () => {
      try {
        const response = await fetch('/api/get-emails');
        if (!response.ok) throw new Error('Hiba történt az e-mail címek lekérése közben.');
        const emails = await response.json();
        setEmailList(emails);
      } catch (error) {
        console.error(error.message);
      }
    };
    fetchEmails();
  }, []);

  const saveEmail = async (email) => {
    try {
      const response = await fetch('https://localhost:7275/User', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email }),
      });
      if (!response.ok) throw new Error('Hiba történt az e-mail cím mentése közben.');
      // Sikeres mentés után frissítheted a lokális állapotot vagy visszajelzést adhatsz a felhasználónak
    } catch (error) {
      console.error(error.message);
    }
  };

  const addEmail = () => {
    if (newEmail && isValidEmail(newEmail) && !emailList.includes(newEmail)) {
      setEmailList(prevEmails => [...prevEmails, newEmail]);
      saveEmail(newEmail);
      setNewEmail('');
    } else {
      alert("Kérjük, adjon meg egy érvényes e-mail címet!");
    }
  };

  const removeEmail = index => {
    setEmailList(emailList.filter((_, i) => i !== index));
  };

  const sendMessage = async () => {
    try {
      const senderemail = {
        to: recipients,
        subject: "Könyvtár kölcsönzés",
        body: message
      };
  
      const response = await fetch('https://localhost:7275/Email', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(senderemail)
      });
  
      if (!response.ok) {
        throw new Error('Hiba történt az üzenet küldése közben.');
      }
      
      setRecipients('');
      setMessage('');
      alert("Üzenet elküldve!");
    } catch (error) {
      console.error('Hiba történt az üzenet küldése közben:', error.message);
    }
  };

  const prepareMessage = () => {
    const defaultMessage = "Kedves Olvasónk! Ne feledje, hogy a kölcsönzött könyv(ek) visszahozatali határideje hamarosan lejár.";
    setMessage(defaultMessage);
  };

  const handleFileChange = (e) => {
    const file = e.target.files[0];
    setFile(file);
    // Itt lehetne a fájl tartalmát kezelni, például olvasással vagy egy szerverre való feltöltéssel
  };

  
  
  const handleClose = () => {
    setIsPanelVisible(false); // Beállítja a panel láthatóságát hamisra
  };

  if (!isPanelVisible) return null;



  return (
    <div className="panel">
      <div className="message-window">
        <input type="text" placeholder="Adja meg a címzettek e-mail címét itt..." value={recipients} onChange={(e) => setRecipients(e.target.value)} />
        <textarea placeholder="Írjon üzenetet itt..." value={message} onChange={(e) => setMessage(e.target.value)}></textarea>
        <button onClick={sendMessage}>Üzenet küldése</button>
        <button className='prepare-message' onClick={prepareMessage}>Üzenet Előkészítése</button>
        <button className='close-panel' onClick={handleClose}>Bezárás</button>
      </div>
      {/* <div className="email-list-window">
        <input type="text" placeholder="Új e-mail cím hozzáadása..." value={newEmail} onChange={(e) => setNewEmail(e.target.value)} />
        <button onClick={addEmail}>Hozzáad</button>
        <ul>
          {emailList.map((email, index) => (
            <li key={index}>{email} <button onClick={() => removeEmail(index)}>Törlés</button></li>
          ))}
        </ul>
      </div> */}
      {/* { <div>
        <input type="file" onChange={handleFileChange} />
        {file && <p>Feltöltött fájl: {file.name}</p>}
      </div> } */}
    </div>
  );
}

export default Loan;
