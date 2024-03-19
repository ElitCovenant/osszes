import React, { useState, useEffect } from 'react';
import './Loan.css';

const Loan = () => {
  const [emails, setEmails] = useState([]);
  const [selectedEmails, setSelectedEmails] = useState(new Set());

  useEffect(() => {
    // E-mail címek lekérése az adatbázisból
    fetch('')
      .then(response => response.json())
      .then(data => setEmails(data))
      .catch(error => console.error('Hiba történt az adatok lekérdezése közben:', error));
  }, []);

  const toggleSelectAll = () => {
    if (selectedEmails.size < emails.length) {
      setSelectedEmails(new Set(emails.map(email => email.id)));
    } else {
      setSelectedEmails(new Set());
    }
  };

  const toggleSelectEmail = (id) => {
    const newSelection = new Set(selectedEmails);
    if (newSelection.has(id)) {
      newSelection.delete(id);
    } else {
      newSelection.add(id);
    }
    setSelectedEmails(newSelection);
  };

  const sendMessage = () => {
    // Üzenet küldése a kiválasztott címzetteknek
    fetch('https://localhost:7275/Email', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ recipients: Array.from(selectedEmails) }),
    })
    .then(response => response.json())
    .then(data => console.log('Az üzenet sikeresen elküldve:', data))
    .catch(error => console.error('Hiba történt az üzenet küldése közben:', error));
  };

  return (
    <div className="loan-container">
      <div className="select-all-tab">
        <input
          type="checkbox"
          checked={selectedEmails.size === emails.length}
          onChange={toggleSelectAll}
        />
        <label>Összes kijelölése</label>
      </div>
      <div className="emails-container">
        {emails.map(({ id, email }) => (
          <div key={id} className="email-card">
            <input
              type="checkbox"
              checked={selectedEmails.has(id)}
              onChange={() => toggleSelectEmail(id)}
            />
            <span>{email}</span>
          </div>
        ))}
      </div>
      <button onClick={sendMessage} className="send-message">Üzenet küldése</button>
    </div>
  );
};

export default Loan;
