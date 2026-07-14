import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import { searchWikiPages } from '../../../Api/wikiSearch';

const HomeComponent = ({ pages, categories }) => {
  const [pagesByCategory, setPagesByCategory] = useState({});
  const {styles} = useStyleContext();
  const [searchQuery, setSearchQuery] = useState('');
  const [searchResults, setSearchResults] = useState(null);

  useEffect(() => {
    const pagesByCategory = {};
    pages.forEach(page => {
      const category = categories.includes(page.category) ? page.category : 'Uncategorized';
      if (!pagesByCategory[category]) {
        pagesByCategory[category] = [];
      }
      pagesByCategory[category].push(page);
    });
    setPagesByCategory(pagesByCategory);
  }, [pages, categories]);

  useEffect(() => {
    if (!searchQuery.trim()) {
      setSearchResults(null);
      return;
    }
    const timer = setTimeout(async () => {
      try {
        const results = await searchWikiPages(searchQuery);
        setSearchResults(results);
      } catch {
        setSearchResults([]);
      }
    }, 300);
    return () => clearTimeout(timer);
  }, [searchQuery]);

  return (
    <div className='home-component article' style={{backgroundColor: styles.articleColor}}>
      <input
        type="text"
        placeholder="Search wiki articles..."
        value={searchQuery}
        onChange={(e) => setSearchQuery(e.target.value)}
        style={{ width: '100%', padding: '0.5em', marginBottom: '1em', marginTop:0, fontSize: '1em', border: '1px solid ' + styles.footerListLinkTextColor, borderRadius: '4px', backgroundColor: styles.bodyColor, color: '#fff', fontFamily: styles.fontFamily, boxSizing: 'border-box', outline: 'none' }}
      />
      {searchResults !== null ? (
        <>
          <h2>Search Results ({searchResults.length})</h2>
          {searchResults.length === 0 ? (
            <p style={{ color: styles.footerListTextColor }}>No articles found.</p>
          ) : (
            <ul>
              {searchResults.map((page, index) => (
                <li key={index}>
                  <Link to={`/page/${encodeURIComponent(page.slug)}`}>
                    {page.title}
                  </Link>
                  <span style={{ color: styles.footerListTextColor, fontSize: '0.9em', marginLeft: '0.5em' }}>({page.category})</span>
                </li>
              ))}
            </ul>
          )}
        </>
      ) : (
        <>
          <h2>Wiki Articles Categorized</h2>
          {Object.entries(pagesByCategory).map(([category, pages]) => (
            <div key={category}>
              <h3>{category}</h3>
              <ul>
                {(pages as { slug: string; title: string; category: string }[]).map((page, index) => (
                  <li key={index}>
                    <Link to={`/page/${encodeURIComponent(page.slug)}`}>
                      {page.title}
                    </Link>
                  </li>
                ))}
              </ul>
            </div>
          ))}
        </>
      )}
    </div>
  );
};

export default HomeComponent;
