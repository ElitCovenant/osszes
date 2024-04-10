import React from 'react';
import './BooksPagination.css'; // CSS importálása

const BooksPagination = ({ currentPage, totalPages, setCurrentPage }) => {
  const goToPreviousPage = () => {
    setCurrentPage((prevPage) => Math.max(prevPage - 1, 1));
    window.scrollTo({ top: 0, behavior: 'smooth' });
  };

  const goToNextPage = () => {
    setCurrentPage((prevPage) => Math.min(prevPage + 1, totalPages));
    window.scrollTo({ top: 0, behavior: 'smooth' });
  };

  const goToLastPage = () => {
    setCurrentPage(totalPages);
    window.scrollTo({ top: 0, behavior: 'smooth' });
  };

  const goToFirstPage = () => {
    setCurrentPage(1);
    window.scrollTo({ top: 0, behavior: 'smooth' });
  };
  
  if (totalPages <= 0) {
    return (
      <div className="pagination no-books-found">
        <span className="no-books-text">No books found</span>
        <button className="page-btn" disabled>First</button>
        <button className="page-btn" disabled>Prev</button>
        <button className="page-btn" disabled>Next</button>
        <button className="page-btn" disabled>Last</button>
        <span className="pagination-text">Page: 0/0</span>
      </div>
    );
  }

  return (
    <div className="pagination">
      <button className="page-btn" onClick={goToFirstPage} disabled={currentPage === 1}>First</button>
      <button className="page-btn" onClick={goToPreviousPage} disabled={currentPage === 1}>Prev</button>
      <button className="page-btn" onClick={goToNextPage} disabled={currentPage === totalPages}>Next</button>
      <button className="page-btn" onClick={goToLastPage} disabled={currentPage === totalPages}>Last</button>
      <span className="pagination-text">{`Page: ${currentPage}/${totalPages}`}</span>
    </div>
  );
};

export default BooksPagination;
