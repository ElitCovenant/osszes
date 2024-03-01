import React, { useState, useEffect } from 'react';
import './Books.css';
import Modal from './Modal';
import Loader from './Loader'; // A Loader komponens importálása
import BooksPagination from './BooksPagination'; // Az új komponens importálása

const Books = () => {
  const [selectedBook, setSelectedBook] = useState(null);
  const [books, setBooks] = useState([]);
  const [currentPage, setCurrentPage] = useState(1); // Az aktuális oldalszám állapota
  const [isLoading, setIsLoading] = useState(true); // Állapot hozzáadása az oldal betöltésének állapotának követésére

  useEffect(() => {
    const intervalId = setInterval(() => {
      // Fetch request to get updated books data
      const fetchData = async () => {
        try {
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
    }, 5000); // Az időzítés beállítása 5000 ms-re (5 másodperc)
  
    // A komponens unmountolásakor töröljük az időzítést
    return () => clearInterval(intervalId);
  }, []);

  // Az oldalak számának kiszámítása
  const totalPages = Math.ceil(books.length / 16);

  // Az aktuális oldal könyveinek kiszámítása
  const startIndex = (currentPage - 1) * 16;
  const endIndex = startIndex + 16;
  const currentBooks = books.slice(startIndex, endIndex);

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

      {!isLoading && currentBooks.map((book) => (
        <div key={book.id} className="card">
          <div className="content">
            <h2 className="title">{book.title}</h2>
            <button className="btn" onClick={() => handleInfoClick(book.id)}>Info</button>
          </div>
        </div>
      ))}

      {selectedBook && <Modal book={selectedBook} onClose={handleCloseModal} />}

      {/* Oldalak közötti navigációs gombok */}
      <BooksPagination currentPage={currentPage} totalPages={totalPages} setCurrentPage={setCurrentPage} />
    </main>
  );
};

export default Books;
