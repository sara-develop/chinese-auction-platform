import React, { useState } from 'react';
import axiosInstance from '../api/axiosInstance';
import '../styles.css';

const LoginPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    setLoading(true);

    try {
      const response = await axiosInstance.post('/Auth/login', { email, password });
      const { token } = response.data;
      localStorage.setItem('token', token);
      alert('התחברת בהצלחה!');
    } catch (err) {
      setError('אירעה שגיאה בהתחברות. בדוק את הפרטים ונסה שוב.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="login-container">
      <h2 className="login-title">התחברות</h2>
      <form onSubmit={handleSubmit} className="login-form">
        <div className="input-group">
          <label htmlFor="email">אימייל:</label>
          <input
            id="email"
            type="email"
            value={email}
            onChange={e => setEmail(e.target.value)}
            required
            className="login-input"
          />
        </div>
        <div className="input-group">
          <label htmlFor="password">סיסמה:</label>
          <input
            id="password"
            type="password"
            value={password}
            onChange={e => setPassword(e.target.value)}
            required
            className="login-input"
          />
        </div>
        <button
          type="submit"
          disabled={loading}
          className="login-button"
        >
          {loading ? 'טוען...' : 'התחבר'}
        </button>
      </form>
      {error && <p className="login-error">{error}</p>}
    </div>
  );
};

export default LoginPage;
