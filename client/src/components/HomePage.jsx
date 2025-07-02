import React, { useEffect, useState } from 'react';
import {jwtDecode} from 'jwt-decode';
import '../styles.css';

const HomePage = () => {
  const [user, setUser] = useState(null);
  const [hovered, setHovered] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem('token');
    if (token) {
      try {
        const decoded = jwtDecode(token);
        setUser({
          email: decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] || '',
          role: decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || '',
        });
      } catch (error) {
        console.error('Failed to decode token:', error);
        setUser(null);
      }
    }
  }, []);

  if (!user) {
    return <p className="loading-text">טוען...</p>;
  }

  const links = user.role === 'manager' ? [
    { label: 'ניהול תורמים', href: '/donors' },
    { label: 'ניהול מתנות', href: '/prizes' },
    { label: 'ניהול רכישות', href: '/purchases' },
    { label: 'הגרלה', href: '/raffle' },
  ] : [
    { label: 'צפייה במתנות', href: '/prizes' },
    { label: 'סל קניות', href: '/cart' },
  ];

  return (
    <div className="home-container">
      <h1 className="home-title">ברוך הבא, {user.email}</h1>
      <p className="home-role">תפקידך במערכת: {user.role}</p>

      <nav>
        <ul className="home-nav">
          {links.map((link, idx) => (
            <li key={idx}>
              <a
                href={link.href}
                className={`home-link ${hovered === idx ? 'home-link-hover' : ''}`}
                onMouseEnter={() => setHovered(idx)}
                onMouseLeave={() => setHovered(null)}
              >
                {link.label}
              </a>
            </li>
          ))}
        </ul>
      </nav>
    </div>
  );
};

export default HomePage;
