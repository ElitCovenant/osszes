import React, { useState, useEffect, useMemo } from 'react';
import { useLocation } from 'react-router-dom';
import './Books.css';
import Modal from './Modal';


const useQuery = () => {
  return new URLSearchParams(useLocation().search);
};
const Books = () => {
  const [selectedBook, setSelectedBook] = useState(null);
  const query = useQuery();
  const searchTerm = query.get('search');

  const books = useMemo(() => [
    { id: '1', title: 'Naruto Shippuden', description: 'Egy ninja története...' },
    { id: '2', title: 'Tokyo Ghoul', description: 'Egy fiatal fiú, aki ghoul-lá válik...' },
    { id: '3', title: 'Csokonai Vitéz Mihály', description:"" },
    { id: '4', title: 'Sebzett madár' , description:""},
    { id: '5', title: 'Toldi-trilógia' , description:""},
    { id: '6', title: 'Jónás Könyve' , description:""},
    { id: '7', title: 'A vegyész' , description:""},
    { id: '8', title: 'Összes Versei' , description:""},
    { id: '9', title: 'Goriot apó' , description:""},
    { id: '10', title: 'Stanley kincse' , description:""},
    { id: '11', title: 'Arany János válogatott versei' , description:""},
    { id: '12', title: 'Az utolsó boszorkány' , description:""},
    { id: '13', title: 'Veszélyes Gazdaság' , description:""},
    { id: '14', title: 'Agykontroll' , description:""},
    { id: '15', title: 'Szótár' , description:""},
    { id: '16', title: 'Görög drámák' , description:""},
    { id: '17', title: 'Huhogók' },
    { id: '18', title: 'Az elvarázsolt lélek' , description:""},
    { id: '19', title: 'Éjjeli Őrjárat' , description:""},
    { id: '20', title: 'Tizenkilencen' , description:""},

  ], []);

  useEffect(() => {
    if (searchTerm) {
      const book = books.find(book => book.title.toLowerCase().includes(searchTerm.toLowerCase()));
      if (book) {
        setSelectedBook(book); // Automatikusan kiválasztja a keresett könyvet, ha van találat
      }
    }
  }, [searchTerm, books]);

  const handleInfoClick = (bookId) => {
    const book = books.find(book => book.id === bookId);
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
            <p className="copy">{book.description || "Nincs elérhető leírás."}</p>
            <button className="btn" onClick={() => handleInfoClick(book.id)}>Info</button>
          </div>
        </div>
      ))}

      {selectedBook && <Modal book={selectedBook} onClose={handleCloseModal} />}
    </main>
  );
};

export default Books;
