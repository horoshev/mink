import React from 'react';
import './Header.css';

function Header() {
  return (
      <header className="header">
        <div className="logo">
          <div className="logo-image">
            {/*<img src="./mink-logo-no-bg.png" className="header-mink-logo" alt="logo" />*/}
          </div>
          <div className="logo-title">Mink</div>
        </div>
        <div className="" />
        <div className="help">?</div>
      </header>
  );
}

export default Header;