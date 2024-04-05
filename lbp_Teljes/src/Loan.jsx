import React, { useState, useEffect } from 'react';
import './Loan.css';
import axios from 'axios'; // Import axios for making HTTP requests

const Loan = () => {
  const [emails, setEmails] = useState([]);
  const [checkedStatus, setCheckedStatus] = useState({});
  const [selectAllChecked, setSelectAllChecked] = useState(false);

  useEffect(() => {
    // Fetch data from the endpoint
    axios.get('https://localhost:7275/Notreturned')
      .then(response => {
        // Upon successful response, update the state with fetched data
        setEmails(response.data);
        // Initialize the checked status for each email
        const initialCheckedStatus = {};
        response.data.forEach((email, index) => {
          initialCheckedStatus[index] = false;
        });
        setCheckedStatus(initialCheckedStatus);
      })
      .catch(error => {
        // Handle errors here
        console.error('Error fetching data:', error);
      });
  }, []); // Empty dependency array ensures the effect runs only once

  const toggleCheckbox = (index) => {
    // Function to toggle individual checkboxes
    setCheckedStatus(prevStatus => ({
      ...prevStatus,
      [index]: !prevStatus[index]
    }));
    setSelectAllChecked(false); // Uncheck select all when any individual checkbox is toggled
  };

  const toggleSelectAll = () => {
    const allChecked = Object.values(checkedStatus).every(checked => checked);
    setSelectAllChecked(!allChecked);

    const updatedCheckedStatus = {};
    for (let i = 0; i < emails.length; i++) {
      updatedCheckedStatus[i] = !allChecked;
    }
    setCheckedStatus(updatedCheckedStatus);
  };

  const sendMessage = () => {
    // Logic to send a message via HTTP POST request
    // Use the index from checkedStatus to send emails
    Object.entries(checkedStatus).forEach(([index, isChecked]) => {
      if (isChecked) {
        const username = emails[index].usarname;
        axios.post('https://localhost:7275/Email', {
          to: username,
          subject: 'Könyvtár kölcsönzés',
          body: 'Kedves Olvasónk! Ne feledje, hogy a kölcsönzött könyv(ek) visszahozatali határideje hamarosan lejár.'
        })
        .then(response => {
          console.log('Message sent to', username);
        })
        .catch(error => {
          console.error('Error sending message to', username, ':', error);
        });
      }
    });
  
    // Uncheck all checkboxes after sending the message
    const uncheckedStatus = {};
    Object.keys(checkedStatus).forEach(index => {
      uncheckedStatus[index] = false;
    });
    setCheckedStatus(uncheckedStatus);
  };

  return (
    <div className="loan-container">
      <div className="select-all-tab">
      <h3 id='loanname'>Loan History</h3>
        <input
          type="checkbox"
          checked={selectAllChecked}
          onChange={toggleSelectAll}
        />
        <label>Összes kijelölése</label>
      </div>
      <div className="emails-container">
        {emails.map((email, index) => (
          <div key={index} className="email-item">
            <input
              type="checkbox"
              checked={checkedStatus[index]}
              onChange={() => toggleCheckbox(index)}
            />
            <span className="email-info">{email.usarname} - {email.title}</span>
          </div>
        ))}
      </div>

      <button onClick={sendMessage} className="send-message">Üzenet küldése</button>
    </div>
  );
};

export default Loan;
