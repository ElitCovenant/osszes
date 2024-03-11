import React from 'react';

const BookList = ({ books, fetchBooks }) => {

    const handleDelete = async (bookId) => {
      try {
        await fetch(`https://your-api-endpoint/books/${bookId}`, { method: 'DELETE' });
        fetchBooks(); // Frissítsd a könyvlistát a törlés után
      } catch (error) {
        console.error('Hiba a könyv törlésekor:', error);
      }
    };
  
    return (
      <ul>
        {books.map(book => (
          <li key={book.id}>
            {book.title} - {book.author}
            <button onClick={() => handleDelete(book.id)}>Törlés</button>
          </li>
        ))}
      </ul>
    );
  };

  
  export default BookList;