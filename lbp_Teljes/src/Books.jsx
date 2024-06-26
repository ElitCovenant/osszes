import React, { useState, useEffect, useCallback } from 'react';
import './Books.css';
import Modal from './Modal';
import Loader from './Loader';
import BooksPagination from './BooksPagination';
import jwt_decode from './jwt_decode';
import Popup from './Popup';
import LibraryFilter from './LibraryFilter';

const Books = () => {
  const [selectedBook, setSelectedBook] = useState(null);
  const [books, setBooks] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [isLoading, setIsLoading] = useState(true);
  const [decodedrole, setDecodedRole] = useState("");
  const [showPopup, setShowPopup] = useState(false);
  const [selectedBookIdForPopup, setSelectedBookIdForPopup] = useState(null); 

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('https://localhost:7275/GuestInformations');
        const booksData = await response.json();
        setBooks(booksData);
        setIsLoading(false);
      } catch (error) {
        console.error('Error fetching data:', error);
        setIsLoading(false);
      }
    };

    fetchData(); 
  }, []); 

  useEffect(() => {
    const fetchProfilePicturePath = async () => {
      try {
        const token = localStorage.getItem('authToken');
        if (token) {
          const decodedToken = jwt_decode(token);
          const response = await fetch(`https://localhost:7275/önkép/${decodedToken.dns}`);
          if (response.ok) {
            const data = await response.json();
            if (data != null) {
              setDecodedRole(decodedToken.role === "Admin");
            } else {
              console.error('Nincs profilkép az adatokban');
            }
          } else {
            console.error('Hiba történt a profilkép lekérésekor:', response.status);
          }
        }
      } catch (error) {
        console.error('Error fetching profile picture path:', error);
      }
    };

    fetchProfilePicturePath();
  }, []);

  useEffect(() => {
    setCurrentPage(1); // Reset currentPage to 1 when LibraryFilter is clicked
  }, []);

  const totalPages = Math.ceil(books.length / 12);
  const startIndex = (currentPage - 1) * 12;
  const endIndex = startIndex + 12;
  const currentBooks = books.slice(startIndex, endIndex);

  const handleInfoClick = (bookId) => {
    const book = books.find((book) => book.id === bookId);
    if (book) {
      setSelectedBook(book);
      document.body.style.overflow = 'hidden'; 
    } else {
      console.error(`Book with id ${bookId} not found.`);
    }
  };

  const handleCloseModal = () => {
    setSelectedBook(null);
    document.body.style.overflow = 'auto'; 
  };

  const handlePopupOpen = (bookId) => {
    setSelectedBookIdForPopup(bookId);
    setShowPopup(true);
    document.body.style.overflow = 'hidden'; 
  };

  /*const handlePopupClose = () => {
    setShowPopup(false);
    document.body.style.overflow = 'auto'; 
  };*/

  const handleFilterSubmit = useCallback((filteredBooks) => {
    setBooks(filteredBooks);
    setCurrentPage(1); // Reset currentPage to 1 when filtering books
  }, []);

  return (
    <div className="FilterSelection">
      <LibraryFilter onSubmit={handleFilterSubmit} />
      <main className="page-content">
        {isLoading && <Loader />}
        {!isLoading && currentBooks.map((book) => (
          <div key={book.id} className="card" style={{ backgroundImage: `url(${book.bookImg})` }}>
            <div className="content">
              <h2 className="title">{book.title}</h2>
              <div className="btn-container">
                <button className="btn" onClick={() => handleInfoClick(book.id)}>Info</button>
                {/*decodedrole && <button className="btn" onClick={() => handlePopupOpen(book.id)}>Change</button>*/}
              </div>
            </div>
          </div>
        ))}  
        {selectedBook && <Modal book={selectedBook} onClose={handleCloseModal} />} 
        {/*showPopup && <Popup onClose={handlePopupClose} bookId={selectedBookIdForPopup} />*/} 
      </main>
      <BooksPagination currentPage={currentPage} totalPages={totalPages} setCurrentPage={setCurrentPage} />
    </div>
  );
};

export default Books;
