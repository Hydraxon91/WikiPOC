import React from 'react';

const WikiList = ({ pages, onDelete, onPageClick }) => {
  return (
    <div>
      <h2>Wiki Pages</h2>
      <ul>
        {pages.map((page) => (
          <li key={page.id} onClick={() => onPageClick(page)}>
            <strong>{page.title}</strong>: {page.content}
            <button onClick={() => onDelete(page.id)}>Delete</button>
           </li>
        ))}
      </ul>
    </div>
  );
};

export default WikiList;
