import React, { useState, useEffect } from 'react';
import './Books.css';
import Modal from './Modal';

const Books = () => {
  const [selectedBook, setSelectedBook] = useState(null);
  const [books, setBooks] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        // Fetch request to get books data
        const response = await fetch('https://localhost:7275/Book');
        const booksData = await response.json();
        setBooks(booksData);
      } catch (error) {
        console.error('Error fetching data:', error);
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
      {books.map((book) => (
        <div key={book.id} className={`card ${selectedBook && selectedBook.id === book.id ? 'selected' : ''}`}>
          <div className="content">
            <h2 className="title">{book.title}</h2>
            <p className="copy">{book.description || 'Nincs elérhető leírás.'}</p>
            <button className="btn" onClick={() => handleInfoClick(book.id)}>Info</button>
          </div>
        </div>
      ))}

      {selectedBook && <Modal book={selectedBook} onClose={handleCloseModal} />}
    </main>
  );
};

export default Books;
