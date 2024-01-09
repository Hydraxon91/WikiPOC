import React from 'react';
import { Link } from 'react-router-dom';

const WikiList = ({ pages }) => {

  return (
      <div className="sidebar">
        <div class="logo">
					<a href="/"><img src='/img/logo.png' alt="logo"/></a>
				</div>
        <h2>Wiki Pages</h2>
        <ul>
          {pages.map((page) => (
            <li key={page.id}>
              <Link to={`/page/${encodeURIComponent(page.title)}`}>
                {page.title}
              </Link>
            </li>
          ))}
        </ul>
      </div>
  );
};

export default WikiList;
