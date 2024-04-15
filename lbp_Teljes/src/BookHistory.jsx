import React, { useState, useEffect } from 'react';
import jwt_decode from './jwt_decode';
import './BookHistory.css';

const BookHistory = () => {
  const [historyItems, setHistoryItems] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchHistoryItems = async () => {
      try {
        const authToken = localStorage.getItem('authToken');
        const decodedToken = jwt_decode(authToken);
        const userId = decodedToken.dns;

        const response = await fetch(`https://localhost:7275/BorrowedBooks/${userId}`, {
          headers: {
            Authorization: `Bearer ${authToken}`
          }
        });

        if (!response.ok) {
          throw new Error('Network response was not ok');
        }

        const data = await response.json();
        // Shorten the return date to only include the first 10 characters
        const modifiedData = data.map(item => ({
          ...item,
          returndate: item.returndate.substring(0, 10)
        }));
        setHistoryItems(modifiedData);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching book history:', error);
      }
    };

    fetchHistoryItems();
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="book-history-container">
      <div className="select-all-tab">
        <h2 id="bookhistoryname">Book History</h2>
      </div>
      <span>Book Loaned - Return Date</span>
      <div className="history-items-container">
        {historyItems.length > 0 ? (
          historyItems.map((item, index) => (
            <div key={index} className="history-item">
              <span className="history-info">{item.title} - {item.returndate}</span>
            </div>
          ))
        ) : (
          <div className="no-books">No Books Loaned</div>
        )}
      </div>
    </div>
  );
};

export default BookHistory;
