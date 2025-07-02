import React, { useEffect, useState } from 'react';
import axiosInstance from '../api/axiosInstance';
import '../styles.css';

const PrizesList = () => {
  const [prizes, setPrizes] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [hoveredBtn, setHoveredBtn] = useState(null);

  useEffect(() => {
    const fetchPrizes = async () => {
      try {
        const response = await axiosInstance.get('/Prizes');
        setPrizes(response.data);
      } catch (err) {
        setError('שגיאה בטעינת המתנות');
      } finally {
        setLoading(false);
      }
    };
    fetchPrizes();
  }, []);

  const addToCart = (prize) => {
    let cart = JSON.parse(localStorage.getItem('cart')) || [];
    cart.push(prize);
    localStorage.setItem('cart', JSON.stringify(cart));
    alert(`המתנה '${prize.name}' נוספה לסל!`);
  };

  if (loading) return <p className="loading-text">טוען מתנות...</p>;
  if (error) return <p className="error-text">{error}</p>;

  return (
    <div className="prizes-container">
      <h2 className="prizes-title">רשימת מתנות</h2>
      <ul className="prizes-list">
        {prizes.map((prize) => (
          <li key={prize.id} className="prize-item">
            <h3 className="prize-name">{prize.name}</h3>
            <p className="prize-info">קטגוריה: {prize.category?.name || prize.categoryId}</p>
            <p className="prize-info">מתרום: {prize.donor?.name || prize.donorId}</p>
            <p className="prize-info">מחיר כרטיס: ₪{prize.price.toLocaleString()}</p>
            <button
              className={`prize-button ${hoveredBtn === prize.id ? 'prize-button-hover' : ''}`}
              onClick={() => addToCart(prize)}
              onMouseEnter={() => setHoveredBtn(prize.id)}
              onMouseLeave={() => setHoveredBtn(null)}
            >
              הוסף לסל
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PrizesList;
