import React, { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';

const CategoryPageComponent = ({ pages }) => {
  const { category } = useParams(); // Extract category from URL
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
      <h2>Category: {category}</h2>
      {Object.entries(pagesByCategory).map(([cat, pages]) => (
        cat === category && // Only render pages for the current category
        <div key={cat}>
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

export default CategoryPageComponent;
