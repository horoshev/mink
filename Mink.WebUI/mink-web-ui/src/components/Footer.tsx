import React from 'react';
import './Footer.css';

function Footer() {

  const year = new Date().getFullYear();

  return (
    <footer className="footer">
      <div className="container">
        <div className="copyright">
          Copyright © {year} Mink
        </div>
        <div className="footer-navigation">
          <a href="/help">Help</a>
        </div>
        <div className="footer-links">
          <a href="/help">GitHub</a>
        </div>
      </div>
    </footer>
  );
}

export default Footer;