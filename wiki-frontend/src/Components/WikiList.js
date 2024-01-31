import React, { useEffect } from "react";
import { Link } from 'react-router-dom';
import { useStyleContext } from './contexts/StyleContext';

const WikiList = ({ pages }) => {
  const { styles }  = useStyleContext();

  useEffect(() => {

  }, [pages]);
  
  return (
      <div className="sidebar">
        <div className="logo">
					<Link to="/"><img src={styles.logo} alt="logo"/></Link>
				</div>
        <div className="navigation">
          <h3>Wiki Pages</h3>
          <ul>
            {pages.map((page, index) => (
              <li key={index}>
                <Link to={`/page/${encodeURIComponent(page)}`}>
                  {page}
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
