import React from 'react';
import { Link } from 'react-router-dom';

const HomeComponent = ({ pages }) => {
  return [
    <h2 key="wiki-pages-heading">Wiki Pages</h2>,
    <ul key="wiki-pages-list">
      {pages.map((page) => (
        <li key={page.id}>
          <Link to={`/page/${encodeURIComponent(page.title)}`}>
            <strong>{page.title}</strong>
          </Link>
        </li>
      ))}
    </ul>,
    <Link key="create-new-page-link" to="/create">
      Create New Page
    </Link>,
  ];
};

export default HomeComponent;
