import { useState } from 'react';

const AddBookForm = () => {
    const [title, setTitle] = useState('');
    const [author, setAuthor] = useState('');
    // További állapotok a könyv adataihoz
  
    const handleSubmit = async (e) => {
      e.preventDefault();
      try {
        const book = { title, author };
        await fetch('https://your-api-endpoint/books', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(book),
        });
        // Sikeres hozzáadás után frissítheted a könyvlistát, stb.
      } catch (error) {
        console.error('Hiba a könyv hozzáadásakor:', error);
      }
    };
  
    return (
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          placeholder="Cím"
          required
        />
        <input
          type="text"
          value={author}
          onChange={(e) => setAuthor(e.target.value)}
          placeholder="Szerző"
          required
        />
        <button type="submit">Könyv Hozzáadása</button>
      </form>
    );
  };

  
  export default AddBookForm;