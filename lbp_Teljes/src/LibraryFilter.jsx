import React, { useState, useEffect } from 'react';
import './LibraryFilter.css';

const LibraryFilter = () => {
  const [books, setBooks] = useState([]);
  const [searchTitle, setSearchTitle] = useState('');
  const [authors, setAuthors] = useState([]);
  const [selectedAuthor, setSelectedAuthor] = useState('all');

  useEffect(() => {
    const fetchBooks = async () => {
      try {
        const response = await fetch('https://localhost:7275/GuestInformations');
        const data = await response.json();
        setBooks(data);
      } catch (error) {
        console.error('Error fetching books:', error);
      }
    };

    fetchBooks();
  }, []);

  useEffect(() => {
    const fetchAuthors = async () => {
      try {
        const response = await fetch('https://localhost:7275/Author');
        const data = await response.json();
        setAuthors(data);
      } catch (error) {
        console.error('Error fetching authors:', error);
      }
    };

    fetchAuthors();
  }, []);

  const handleFilterSubmit = (e) => {
    e.preventDefault();
  };

  const handleAuthorChange = (e) => {
    setSelectedAuthor(e.target.value);
  };

  return (
    <div className='library_filter_container'>
      <form className="library_filter_form" onSubmit={handleFilterSubmit}>
        
        {/* Author szűrő */}
        <div className="filter_section">
          <label htmlFor="author_filter">Author:</label>
          <select id="author_filter" name="author" onChange={handleAuthorChange} value={selectedAuthor}>
            <option value="all">All Authors</option>
            {authors.map(author => (
              <option key={author.id} value={author.name}>{author.name}</option>
            ))}
          </select>
        </div>
        
        {/* Cím szűrő */}
        <div className="filter_section">
          <label htmlFor="title_filter">Title:</label>
          <input 
            id="title_filter" 
            type="text" 
            name="title" 
            placeholder="Book title" 
            value={searchTitle} 
            onChange={(e) => setSearchTitle(e.target.value)} 
          />
        </div>

        <button type="submit" className="filter_button">Filter Books</button>
      </form>
      
    </div>
  );
};

export default LibraryFilter;
