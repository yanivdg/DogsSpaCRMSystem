'use client'
// /pages/signin/layout.tsx
import React from 'react';

interface LayoutProps {
  children: React.ReactNode;
  title?: string;
}

const Layout: React.FC<LayoutProps> = ({ children, title }) => {
  return (
    <div className="layout">
      <header>
        <h1>{title || ''}</h1>
      </header>
      <main>{children}</main>
    </div>
  );
};

export default Layout;