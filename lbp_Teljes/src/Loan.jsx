import React, { useState, useEffect } from 'react';
import './Loan.css';
import axios from 'axios'; // Import axios for making HTTP requests
import mailIcon from './img_icons/mail.png'; 
import loanIcon from './img_icons/loanbook.png'; 
import infoIcon from './img_icons/information.png'; 
import exampleIcon from './img_icons/example.png'; 
import maintainIcon from './img_icons/maintain.png'; 
import warningIcon from './img_icons/warning.png'; 
import { ToastContainer, toast } from 'react-toastify'; // Importáljuk a ToastContainer-t és a toast függvényt
import 'react-toastify/dist/ReactToastify.css'; // Importáljuk a Toast styling-ot

const Loan = () => {
  const [emails, setEmails] = useState([]);
  const [checkedStatus, setCheckedStatus] = useState({});
  const [selectAllChecked, setSelectAllChecked] = useState(false);
  const [showModal, setShowModal] = useState(false); // Állapot a modális ablak megjelenítéséhez
  const [showMaintainModal, setShowMaintainModal] = useState(false);
  // Információs panel megjelenítésének kezelése
// Információs panel megjelenítésének kezelése
const toggleInfoPanel = () => {
  setShowModal(prevState => !prevState); // Állapot módosítása a modális ablak megjelenítéséhez
};


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

  const handleMaintenanceChange = () => {
    const maintenanceText = document.querySelector('.maintenance-input').value;
    localStorage.setItem('emailChanger', maintenanceText);
  };

  const resetText = () => {
    localStorage.removeItem('emailChanger');
  };
  
 const sendMessage = () => {
  // Logic to send a message via HTTP POST request
  // Use the index from checkedStatus to send emails
  Object.entries(checkedStatus).forEach(([index, isChecked]) => {
    if (isChecked) {
      const username = emails[index].usarname;
      const emailBody = localStorage.getItem('emailChanger') || 'Kedves Olvasónk! Ne feledje, hogy a kölcsönzött könyv(ek) visszahozatali határideje hamarosan lejár.';
      axios.post('https://localhost:7275/Email', {
        to: username,
        subject: 'Könyvtár kölcsönzés',
        body: emailBody
      })
      .then(response => {
        console.log('Message sent to', username);
        toast.success('All selected emails now sent');
      })
      .catch(error => {
        console.error('Error sending message to', username, ':', error);
      });
    }
  });

  // Reset all checkboxes to unchecked state
  setCheckedStatus({});
};

  return (
    <div className="loan-container">
      <button className="maintain-button" onClick={() => setShowMaintainModal(true)}>
        <img src={maintainIcon} alt="Maintain Icon" className="maintain-icon" />
      </button>
      <div className="select-all-tab">
        <input
          type="checkbox"
          className="styled-checkbox"
          checked={selectAllChecked}
          onChange={toggleSelectAll}
        />
        <label id="select-all-label">Select all</label>
        <button className="info-button">
          <img src={infoIcon} alt="Info Icon" className="info-icon" onClick={toggleInfoPanel}/>
        </button>
        <h3 id='loanname'>Loan History <img src={loanIcon} alt="Logout Icon" className="loanbook-icon" /></h3>
      </div>
      {showMaintainModal && (
  <div className="modal">
    <div className="modal-content">
      <button className="close-button" onClick={() => setShowMaintainModal(false)}>&times;</button>
      <p>Maintenance Text:</p>
      <footer>New text:</footer>
      <input type="text" placeholder="Enter the new email text" className='maintenance-input'/>
      <footer>Old text:</footer>
      <textarea placeholder={localStorage.getItem('emailChanger') || 'Kedves Olvasónk! Ne feledje, hogy a kölcsönzött könyv(ek) visszahozatali határideje hamarosan lejár.'} className='premaintenance-input'/>
      <button className="change-button" onClick={() => { handleMaintenanceChange(); setShowMaintainModal(false); }}>Change</button>
      <button className="reset-button" onClick={() => { resetText(); setShowMaintainModal(false); }}>Reset Text</button>
    </div>
  </div>
)}
      {showModal && (
  <div className="modal">
    <div className="modal-content">
      <button className="close-button" onClick={toggleInfoPanel}>&times;</button>
      <div className='info-tag'>
        <img src={infoIcon} alt="Info" className="example-icon" />
        Here are the book borrowings. In the first part, you can find the borrower's email, and in the second part, you can find the borrowed book.
      </div>
      <div className='info-tag'>
        <img src={exampleIcon} alt="Example" className="example-icon" />
        Examples: example@kkszki.hu - ExampleBook
      </div>
      <div className='info-tag'>
        <img src={maintainIcon} alt="Maintain" className="example-icon" />
        Here you can change what type of message you want to send to the users.
      </div>
      <div className='warning-tag'>
        <img src={warningIcon} alt="Warning" className="warning-icon" />
        Be careful with the <img src={maintainIcon} alt="Maintain" className="settings-info-icon" />, because if you change the loan text, it will be set like that from then on.
      </div>
    </div>
  </div>
)}
      <div className="emails-container">
        {emails.length > 0 ? (
        emails.map((email, index) => (
          <div key={index} className="email-item">
            <input
              type="checkbox"
              className="styled-checkbox"
              checked={checkedStatus[index]}
              onChange={() => toggleCheckbox(index)}
            />
            <span className="email-info">{email.usarname} - {email.title}</span>
          </div>
        ))
        ) : (
          <div className="no-books">No Books Loaned</div>
        )}
      </div>
      <ToastContainer />
      <button onClick={sendMessage} className="send-message">Send Email(s) <img src={mailIcon} alt="Logout Icon" className="mail-icon" /></button>
    </div>
    
  );
};

export default Loan;
