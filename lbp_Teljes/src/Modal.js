import React from 'react';

const Modal = ({ book, onClose }) => {
    if (!book) return null;
  
    return (
      <div className="modal" onClick={onClose}>
        <div className="modal-content" onClick={e => e.stopPropagation()}>
          <h2>{book.title}</h2>
          <p>{book.description || "Nincs elérhető leírás."}</p>
          <button className="btn" onClick={onClose}>Close</button>
        </div>
      </div>
    );
  };
  
  export default Modal;