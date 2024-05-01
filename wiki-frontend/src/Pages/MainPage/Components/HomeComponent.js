import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

const HomeComponent = ({ pages }) => {
  const [pagesByCategory, setPagesByCategory] = useState({});

  useEffect(() => {
    // Organize pages by category
    const pagesByCategory = {};
    pages.forEach(page => {
      if (!pagesByCategory[page.category]) {
        pagesByCategory[page.category] = [];
      }
      pagesByCategory[page.category].push(page);
    });
    setPagesByCategory(pagesByCategory);
  }, [pages]);

  return (
    <div className='home-component'>
      <h2>Wiki Articles Categorized</h2>
      {Object.entries(pagesByCategory).map(([category, pages]) => (
        <div key={category}>
          <h3>{category}</h3>
          <ul>
            {pages.map((page, index) => (
              <li key={index}>
                <Link to={`/page/${encodeURIComponent(page.title)}`}>
                  {page.title}
                </Link>
              </li>
            ))}
          </ul>
        </div>
      ))}
    </div>
  );
};

export default HomeComponent;
