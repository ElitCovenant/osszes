import React, { useState, useEffect, useCallback } from 'react';
import { useLanguage } from './LanguageProvider';
import './LibraryFilter.css';

const LibraryFilter = ({ onSubmit }) => {

  const [books, setBooks] = useState([]);
  const [searchTitle, setSearchTitle] = useState('');
  const [authors, setAuthors] = useState([]);
  const [selectedAuthor, setSelectedAuthor] = useState('0');
  const [filteredBooks, setFilteredBooks] = useState([]);

  const { translations } = useLanguage(); // Megfelelő használat a useLanguage hooknak


  useEffect(() => {
    const fetchBooks = async () => {
      try {
        let url = `https://localhost:7275/Search/${selectedAuthor}?nae=${encodeURIComponent(searchTitle)}`;
        if (searchTitle.trim() === '') {
          url = `https://localhost:7275/Search/${selectedAuthor}`;
        }
        const response = await fetch(url);
        const data = await response.json();
        setBooks(data);
      } catch (error) {
        console.error('Error fetching books:', error);
      }
    };

    // Csak ha van valami beírva a Title input mezőbe, hívjuk meg a keresést
    if (searchTitle.trim() !== '' || selectedAuthor !== '0') {
      fetchBooks();
    } else {
      // Ha a Title input és az Author mező is üres, visszaállítjuk az összes könyvet
      setBooks([]);
    }
  }, [searchTitle, selectedAuthor]);

  useEffect(() => {
    const fetchAuthors = async () => {
      try {
        const response = await fetch('https://localhost:7275/Author');
        const data = await response.json();
        // Az "All Authors" opciót manuálisan adjuk hozzá a szerzők listájához az id beállításával
        const allAuthorsOption = [{ id: '0', name: "All Authors" }, ...data];
        setAuthors(allAuthorsOption);
      } catch (error) {
        console.error('Error fetching authors:', error);
      }
    };

    fetchAuthors();
  }, []);

  const handleFilterSubmit = async (e) => {
    e.preventDefault();
    try {
      let url = `https://localhost:7275/Search/${selectedAuthor}?nae=${encodeURIComponent(searchTitle)}`;
      if (searchTitle.trim() === '') {
        url = `https://localhost:7275/Search/${selectedAuthor}`;
      }
      const response = await fetch(url);
      const data = await response.json();
      setFilteredBooks(data);
      onSubmit(data); // Szűrt könyvek átadása a Books komponensnek
    } catch (error) {
      console.error('Error fetching books:', error);
    }
  };

  const handleAuthorChange = (e) => {
    setSelectedAuthor(e.target.value);
  };

  return (
    <div className='library_filter_container'>
    <form className="library_filter_form" onSubmit={handleFilterSubmit}>
      
      {/* Author szűrő */}
      <div className="filter_section">
      <label htmlFor="author_filter">{translations?.libraryFilter?.authorLabel || "Author"}</label>
        <select id="author_filter" className="author_select" name="author" onChange={handleAuthorChange} value={selectedAuthor}>
          {/* Mapping through the authors list */} 
          {authors.map(author => (
            <option className="author_option" key={author.id} value={author.id}>{author.name}</option>
          ))}
        </select>
      </div>
      
      {/* Cím szűrő */}
      <div className="filter_section">
      <label htmlFor="title_filter">{translations?.libraryFilter?.titleLabel || "Title"}</label>
        <input 
          id="title_filter" 
          type="text" 
          name="title" 
          placeholder={translations.titlePlaceholder} 
          value={searchTitle} 
          onChange={(e) => setSearchTitle(e.target.value)} 
        />
      </div>

      <button type="submit" className="filter_button">{translations?.libraryFilter?.filterButton || "Filter"}</button>
    </form>
    
  </div>

  );
};

export default LibraryFilter;
