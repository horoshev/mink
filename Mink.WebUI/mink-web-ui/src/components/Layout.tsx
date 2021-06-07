import React from 'react';
import Header from './Header';
import UriMinifier from './UriMinifier'
import Footer from './Footer';
import './Layout.css'

function Layout() {

  return (
    <div className="layout">
      <Header />
      <div className="content">
        <UriMinifier />
      </div>
      <Footer />
    </div>
  );
}

export default Layout;