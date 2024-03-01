import React from 'react';

const BooksPagination = ({ currentPage, totalPages, setCurrentPage }) => {
  const goToPreviousPage = () => {
    setCurrentPage((prevPage) => Math.max(prevPage - 1, 1)); // Csökkenti az aktuális oldalszámot, de legalább 1-ig
  };

  const goToNextPage = () => {
    setCurrentPage((prevPage) => Math.min(prevPage + 1, totalPages)); // Növeli az aktuális oldalszámot, de legfeljebb a maximális oldalszámig
  };

  return (
    <div className="pagination">
      <button className="page-btn" onClick={goToPreviousPage} disabled={currentPage === 1}>Prev</button>
      <button className="page-btn" onClick={goToNextPage} disabled={currentPage === totalPages}>Next</button>
      <span className="pagination-text">{`Page: ${currentPage}/${totalPages}`}</span>
    </div>
  );
};

export default BooksPagination;
