import React from 'react';
import { createTicket } from '../api/ticketApi'; // נוודא שהנתיב נכון

function PrizeCard({ prize }) {
  const handlePurchase = () => {
    const userId = localStorage.getItem('userId'); // שמור ב־login
    if (!userId) {
      alert('עליך להתחבר קודם');
      return;
    }

    createTicket(prize.id, parseInt(userId))
      .then(() => {
        alert('הכרטיס נוסף לסל (טיוטה)');
      })
      .catch(() => {
        alert('שגיאה ביצירת כרטיס');
      });
  };

  return (
    <div style={{
      border: '1px solid #ccc',
      borderRadius: '8px',
      padding: '16px',
      width: '200px'
    }}>
      <h3>{prize.name}</h3>
      <p>מחיר כרטיס: {prize.price} ₪</p>
      <button onClick={handlePurchase}>רכוש כרטיס</button>
    </div>
  );
}

export default PrizeCard;
