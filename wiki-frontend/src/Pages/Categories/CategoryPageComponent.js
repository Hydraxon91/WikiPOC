import React, { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';

const CategoryPageComponent = ({ pages }) => {
  const { category } = useParams(); // Extract category from URL
  const [pagesByCategory, setPagesByCategory] = useState({});
  const [pagesInCurrentCategory, setPagesInCurrentCategory] = useState([])

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

  useEffect(()=>{
    setPagesInCurrentCategory(pagesByCategory[category] || [])
  },[pagesByCategory])

  return (
    <div className='home-component'>
      <h2>Category: {category}</h2>
      {pagesInCurrentCategory.length > 0 ? (
        <ul>
          {pagesInCurrentCategory.map((page, index) => (
            <li key={index}>
              <Link to={`/page/${encodeURIComponent(page.title)}`}>
                {page.title}
              </Link>
            </li>
          ))}
        </ul>
      ) : (
        <p>There are no pages in this category yet.</p>
      )}
    </div>
  );
};

export default CategoryPageComponent;
