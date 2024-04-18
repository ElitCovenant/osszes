import React from 'react';

const Modal = ({ book, onClose }) => {
    if (!book) return null;

    return (
        <div className="modal" onClick={onClose}>
            <div className="modal-content" onClick={e => e.stopPropagation()}>
                <h1>{book.author.name}</h1>
                <h2>{book.title}</h2>
                <p>{book.description || "Nincs elérhető leírás."}</p>
                {book.userId != 1 && <p>Ez a könyv már ki lett kölcsönözve!</p>}
                <button className="btn" onClick={onClose}>Close</button>
            </div>
        </div>
    );
};

export default Modal;
