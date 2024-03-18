import React from 'react';
import './LoanHistory.css';

function LoanHistory({ loanHistory }) {
  return (
    <div className="loan-history">
      <h3>Loan History</h3>
      <ul>
        {loanHistory.map((loan, index) => (
          <li key={index}>{loan}</li>
        ))}
      </ul>
    </div>
  );
}

export default LoanHistory;
