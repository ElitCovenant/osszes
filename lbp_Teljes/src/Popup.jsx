import React, { useState, useEffect } from 'react';
import './Popup.css';

const Popup = ({ onClose, bookId }) => {
  const [bookData, setBookData] = useState(null);
  const [authorName, setAuthorName] = useState(null);
  const [users, setUsers] = useState([{ id: 0, username: "No-one" }]);
  const [selectedUser, setSelectedUser] = useState(0);
  const [publishers, setPublishers] = useState([{ id: 0, name: "No-one" }]);
  const [selectedPublisher, setSelectedPublisher] = useState(0);
  const [authors, setAuthors] = useState([{ id: 0, name: "No-one" }]);
  const [selectedAuthor, setSelectedAuthor] = useState(0);

  const [bookTitle, setBookTitle] = useState('');
  const [warehouseNum, setWarehouseNum] = useState('');
  const [purchaseDate, setPurchaseDate] = useState('');
  const [seriesId, setSeriesId] = useState('');
  const [isbnNum, setIsbnNum] = useState('');
  const [szakkjelzet, setSzakkjelzet] = useState('');
  const [cutterJelzet, setCutterJelzet] = useState('');
  const [publisherId, setPublisherId] = useState('');
  const [releaseDate, setReleaseDate] = useState('');
  const [price, setPrice] = useState('');
  const [comment, setComment] = useState('');
  const [usernames, setUsernames] = useState([]);

  useEffect(() => {
    const fetchBookData = async () => {
      try {
        const response = await fetch(`https://localhost:7275/Book/${bookId}`);
        if (response.ok) {
          const data = await response.json();
          setBookData(data);
          setBookTitle(data.title || '');
          setWarehouseNum(data.warehouseNum || '');
          setPurchaseDate(data.purchaseDate || '');
          setSeriesId(data.seriesId || '');
          setIsbnNum(data.isbnNum || '');
          setSzakkjelzet(data.szakkjelzet || '');
          setCutterJelzet(data.cutterJelzet || '');
          setPublisherId(data.publisherId || '');
          setReleaseDate(data.releaseDate || '');
          setPrice(data.price || '');
          setComment(data.comment || '');
          setSelectedAuthor(data.authorId || ''); // Set selected author id
        } else {
          console.error(`Error fetching book data for id ${bookId}: ${response.status}`);
        }
      } catch (error) {
        console.error(`Error fetching book data for id ${bookId}:`, error);
      }
    };

    const fetchUsers = async () => {
      try {
        const response = await fetch('https://localhost:7275/User');
        if (response.ok) {
          const userData = await response.json();
          // Felhasználók tárolása id-val
          const modifiedUsers = [{ id: 0, username: "No-one" }, ...userData.map(user => ({ id: user.id, username: user.usarname }))];
          setUsers(modifiedUsers);
        } else {
          console.error(`Error fetching user data: ${response.status}`);
        }
      } catch (error) {
        console.error('Error fetching user data:', error);
      }
    };

    const fetchPublishers = async () => {
      try {
        const authToken = localStorage.getItem('authToken'); // Auth token kinyerése local storage-ból
        const response = await fetch('https://localhost:7275/Publisher', {
          headers: {
            Authorization: `Bearer ${authToken}` // Auth token hozzáadása az Authorization fejléchez
          }
        });
        if (response.ok) {
          const publisherData = await response.json();
          setPublishers([{ id: 0, name: "No-one" }, ...publisherData]);
        } else {
          console.error(`Error fetching publisher data: ${response.status}`);
        }
      } catch (error) {
        console.error('Error fetching publisher data:', error);
      }
    };

    const fetchAuthors = async () => {
      try {
        const response = await fetch('https://localhost:7275/Author');
        if (response.ok) {
          const authorData = await response.json();
          setAuthors([...authorData]);
        } else {
          console.error(`Error fetching author data: ${response.status}`);
        }
      } catch (error) {
        console.error('Error fetching author data:', error);
      }
    };

    fetchBookData();
    fetchUsers();
    fetchPublishers();
    fetchAuthors();
  }, [bookId]);

  const handleUserChange = (event) => {
    setSelectedUser(parseInt(event.target.value));
  };

  const handlePublisherChange = (event) => {
    setSelectedPublisher(parseInt(event.target.value));
  };

  const handleAuthorChange = (event) => {
    setSelectedAuthor(parseInt(event.target.value));
  };

  const handleConfirm = async () => {
    try {
      const response = await fetch(`https://localhost:7275/Book/${bookId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          title: bookTitle,
          warehouseNum: warehouseNum,
          purchaseDate: purchaseDate,
          seriesId: seriesId,
          isbnNum: isbnNum,
          szakkjelzet: szakkjelzet,
          cutterJelzet: cutterJelzet,
          publisherId: selectedPublisher,
          releaseDate: releaseDate,
          price: price,
          comment: comment,
          authorId: selectedAuthor,
          userId: selectedUser // Adding selected user id to the request body
        }),
      });
      if (response.ok) {
        console.log('Book data updated successfully');
        onClose();
      } else {
        console.error(`Error updating book data: ${response.status}`);
      }
    } catch (error) {
      console.error('Error updating book data:', error);
    }
  };

  return (
    <div className="popup-overlay">
      <div className="popup-content">
        <span className="close" onClick={onClose}>&times;</span>
        {bookData ? (
          <>
            <h3>Book name:</h3>
            <input
              type="text"
              className="inputbuttontext"
              placeholder={bookTitle || bookData.title || "No data"}
              onChange={(e) => setBookTitle(e.target.value)}
            />
            <h3>Author:</h3>
            <select
              className="inputbuttontext"
              value={selectedAuthor}
              onChange={handleAuthorChange}
            >
              {authors.map(author => (
                <option key={author.id} value={author.id}>{author.name}</option>
              ))}
            </select>
            <h3>Warehouse number:</h3>
            <input
              type="text"
              className="inputbuttontext"
              placeholder={warehouseNum || bookData.warehouseNum || "No data"}
              onChange={(e) => setWarehouseNum(e.target.value)}
            />
            <h3>Purchase date:</h3>
            <input
              type="date"
              className="inputbuttontext"
              value={new Date(bookData.purchaseDate).toISOString().split('T')[0]}
              onChange={(e) => setPurchaseDate(e.target.value)}
            />
            <h3>Series:</h3>
            <input
              type="text"
              className="inputbuttontext"
              placeholder={seriesId || bookData.seriesId || "No data"}
              onChange={(e) => setSeriesId(e.target.value)}
            />
            <h3>ISBN:</h3>
            <input
              type="text"
              className="inputbuttontext"
              placeholder={isbnNum || bookData.isbnNum || "No data"}
              onChange={(e) => setIsbnNum(e.target.value)}
            />
            <h3>Szakkjelzet:</h3>
            <input
              type="text"
              className="inputbuttontext"
              placeholder={szakkjelzet || bookData.szakkjelzet || "No data"}
              onChange={(e) => setSzakkjelzet(e.target.value)}
            />
            <h3>Cutterjelzet:</h3>
            <input
              type="text"
              className="inputbuttontext"
              placeholder={cutterJelzet || bookData.cutterJelzet || "No data"}
              onChange={(e) => setCutterJelzet(e.target.value)}
            />
            <h3>Publisher:</h3>
            <select
              className="inputbuttontext"
              value={selectedPublisher}
              onChange={handlePublisherChange}
            >
              {publishers.map(publisher => (
                <option key={publisher.id} value={publisher.id}>{publisher.name}</option>
              ))}
            </select>
            <h3>Release date:</h3>
            <input
              type="date"
              className="inputbuttontext"
              value={bookData.releaseDate ? new Date(bookData.releaseDate).toISOString().split('T')[0] : ''}
              onChange={(e) => setReleaseDate(e.target.value)}
            />
            <h3>Price:</h3>
            <input
              type="text"
              className="inputbuttontext"
              placeholder={price || bookData.price || "No data"}
              onChange={(e) => setPrice(e.target.value)}
            />
            <h3>Comment:</h3>
            <input
              type="text"
              className="inputbuttontext"
              placeholder={comment || bookData.comment || "No data"}
              onChange={(e) => setComment(e.target.value)}
            />
            <h3>User reservation:</h3>
            <select
              className="inputbuttontext"
              value={selectedUser}
              onChange={handleUserChange} // Handle user change event
            >
              {users.map(user => (
                <option key={user.id} value={user.id}>{user.username}</option>
              ))}
            </select>
          </>
        ) : (
          <p>Loading...</p>
        )}
        <button className="btnclosepopup" onClick={onClose}>Close</button>
        <button className="btnclosepopup" onClick={handleConfirm}>Confirm</button>
      </div>
    </div>
  );
};

export default Popup;
