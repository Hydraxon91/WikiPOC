import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';

const HomeComponent = ({ pages }) => {
  useEffect(() => {

  }, [pages]);

  return [
    <h2 key="wiki-pages-heading">Wiki Pages</h2>,
    <ul key="wiki-pages-list">
      {pages.map((page, index) => (
        <li key={index}>
          <Link to={`/page/${encodeURIComponent(page)}`}>
            <strong>{page}</strong>
          </Link>
        </li>
      ))}
    </ul>
  ];
};

export default HomeComponent;
