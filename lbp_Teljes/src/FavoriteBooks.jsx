import React, { useRef, useEffect } from 'react';
import './FavoriteBooks.css'; // Bizonyosodj meg róla, hogy a stílusfájl helyesen van importálva

const favoriteBooks = [
  { id: 1, title: 'Könyv 1', author: 'Szerző 1' },
  { id: 2, title: 'Könyv 2', author: 'Szerző 2' },
  // További könyvek hozzáadása
];

function FavoriteBooks() {
  const listRef = useRef(null);

  useEffect(() => {
    if (listRef.current) {
      listRef.current.scrollTop = listRef.current.scrollHeight;
    }
  }, []);

  return (
    <div className="favorite-books-container">
      <h3>Kedvenc Könyvek</h3>
      <div className="scrollable-list" ref={listRef}>
        <ul>
          {favoriteBooks.map((book) => (
            <li key={book.id}>{book.title} - {book.author}</li>
          ))}
        </ul>
      </div>
    </div>
  );
}

export default FavoriteBooks;