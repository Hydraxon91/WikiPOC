import React from 'react';
import { Link } from 'react-router-dom';

const WikiList = ({ pages, onDelete }) => {

  return (
    <div>
      <h2>Wiki Pages</h2>
      <ul>
        {pages.map((page) => (
          <li key={page.id}>
            <Link to={`/page/${encodeURIComponent(page.title)}`}>
              <strong>{page.title}</strong>
            </Link> 
            <button onClick={() => onDelete(page.id)}>Delete</button>
            <Link to={`/edit/${page.id}`}>
              <button>Edit</button>
            </Link>
           </li>
        ))}
      </ul>
      <Link to="/create">Create New Page</Link>
    </div>
  );
};

export default WikiList;
