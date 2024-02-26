import React, { useState, useEffect } from 'react';
import './Books.css';
import Modal from './Modal';
import Loader from './Loader'; // A Loader komponens importálása

const Books = () => {
  const [selectedBook, setSelectedBook] = useState(null);
  const [books, setBooks] = useState([]);
  const [isLoading, setIsLoading] = useState(true); // Állapot hozzáadása az oldal betöltésének állapotának követésére

  useEffect(() => {
    const fetchData = async () => {
      try {
        // Fetch request to get books data
        const response = await fetch('https://localhost:7275/GuestInformations');
        const booksData = await response.json();
        setBooks(booksData);
        setIsLoading(false); // A betöltés vége, állapot frissítése
      } catch (error) {
        console.error('Error fetching data:', error);
        setIsLoading(false); // Hiba esetén is frissítjük az állapotot
      }
    };

    fetchData();
  }, []);


  const handleInfoClick = (bookId) => {
    const book = books.find((book) => book.id === bookId);
    setSelectedBook(book);
    document.body.style.overflow = 'hidden'; // Letiltja a háttér görgetését
  };

  const handleCloseModal = () => {
    setSelectedBook(null);
    document.body.style.overflow = 'auto'; // Visszaállítja a görgetést
  };

  return (
    <main className="page-content">
      {/* Loader megjelenítése, amíg az adatok betöltődnek */}
      {isLoading && <Loader />}

      {!isLoading && books.map((book) => (
        <div key={book.id} className={`card ${selectedBook && selectedBook.id === book.id ? 'selected' : ''}`}>
          <div className="content">
            <h2 className="title">{book.title}</h2>
            <button className="btn" onClick={() => handleInfoClick(book.id)}>Info</button>
          </div>
        </div>
      ))}

      {selectedBook && <Modal book={selectedBook} onClose={handleCloseModal} />}
    </main>
  );
};

export default Books;
