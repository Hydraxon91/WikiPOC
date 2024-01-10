import React from 'react';
import { Link } from 'react-router-dom';

const WikiList = ({ pages }) => {

  return (
      <div className="sidebar">
        <div class="logo">
					<a href="/"><img src='/img/logo.png' alt="logo"/></a>
				</div>
        <div className="navigation">
          <h3>Wiki Pages</h3>
          <ul>
            {pages.map((page) => (
              <li key={page.id}>
                <Link to={`/page/${encodeURIComponent(page.title)}`}>
                  {page.title}
                </Link>
              </li>
            ))}
          </ul>
          <h3>Admin Tools</h3>
          <ul>
              <li>
                <Link key="create-new-page-link" to="/create">
                  Create New Page
                </Link>
              </li>
              <li>
                <Link key="edit-wiki-link" to="/edit-wiki">
                  Edit Wiki
                </Link>
              </li>
          </ul>
        </div>
        
      </div>
  );
};

export default WikiList;
