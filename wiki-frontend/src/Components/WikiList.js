import React from 'react';
import { Link } from 'react-router-dom';

const WikiList = ({ pages, onDelete, onPageClick }) => {

  return (
    <div>
      <h2>Wiki Pages</h2>
      <ul>
        {pages.map((page) => (
          <li key={page.id}>
            <Link onClick={(onPageClick(page))} to={`/page/${page.id}`}>
              <strong>{page.title}</strong>
            </Link>
            : {page.content}
            <button onClick={() => onDelete(page.id)}>Delete</button>
           </li>
        ))}
      </ul>
      <Link to="/create">Create New Page</Link>
    </div>
  );
};

export default WikiList;
