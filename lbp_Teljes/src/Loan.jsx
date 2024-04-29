import React, { useState, useEffect } from 'react';
import './Loan.css';
import axios from 'axios'; // Import axios for making HTTP requests
import { useLanguage } from './LanguageProvider'; // Import useLanguage hook

const Loan = () => {
  const [emails, setEmails] = useState([]);
  const [checkedStatus, setCheckedStatus] = useState({});
  const [selectAllChecked, setSelectAllChecked] = useState(false);

  const { translations } = useLanguage(); // Use useLanguage hook to access translations

  useEffect(() => {
    // Fetch data from the endpoint
    const fetchEmails = async () => {
      try {
        const token = localStorage.getItem('authToken'); // Get token from localStorage
        const response = await axios.get('https://localhost:7275/Notreturned', {
          headers: {
            Authorization: `Bearer ${token}` // Add token to headers
          }
        });
        // Upon successful response, update the state with fetched data
        setEmails(response.data);
        // Initialize the checked status for each email
        const initialCheckedStatus = {};
        response.data.forEach((email, index) => {
          initialCheckedStatus[index] = false;
        });
        setCheckedStatus(initialCheckedStatus);
      } catch (error) {
        // Handle errors here
        console.error('Error fetching data:', error);
      }
    };

    fetchEmails();
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
          subject: translations?.loanSubject || 'Könyvtár kölcsönzés', // Use translation for subject
          body: translations?.loanMessage || 'Kedves Olvasónk! Ne feledje, hogy a kölcsönzött könyv(ek) visszahozatali határideje hamarosan lejár.' // Use translation for body
        })
        .then(response => {
          console.log('Message sent to', username);
        })
        .catch(error => {
          console.error('Error sending message to', username, ':', error);
        });
      }
    });
  };

  return (
    <div className="loan-container">
      <div className="select-all-tab">
      <h3 id='loanname'>{translations?.loan?.loanHistory || 'Loan History'}</h3>
        <input
          type="checkbox"
          checked={selectAllChecked}
          onChange={toggleSelectAll}
        />
<         label>{translations?.loan?.selectAll || 'Select All'}</label>
      </div>
      <div className="emails-container">
        {emails.map((email, index) => (
          <div key={index} className="email-item">
            <input
              type="checkbox"
              className="styled-checkbox"
              checked={checkedStatus[index]}
              onChange={() => toggleCheckbox(index)}
            />
            <span className="email-info">{email.usarname} - {email.title}</span>
          </div>
        ))}
      </div>

      <button onClick={sendMessage} className="send-message">{translations?.loan?.sendMessage || 'Send Message'}</button>
    </div>
  );
};

export default Loan;
