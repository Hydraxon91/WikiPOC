import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import { useSiteSettings } from '../../../Components/contexts/SiteSettingsContext';
import { searchWikiPages } from '../../../Api/wikiSearch';

const SearchIcon = () => (
  <svg className="lgb-search-icon" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" aria-hidden="true">
    <circle cx="11" cy="11" r="8" />
    <path d="m21 21-4.3-4.3" />
  </svg>
);

const HomeComponent = ({ pages, categories }) => {
  const [pagesByCategory, setPagesByCategory] = useState({});
  const { styles } = useStyleContext();
  const { settings } = useSiteSettings();
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
    <div className="home-component article" style={{ backgroundColor: styles.articleColor }}>
      <h2 className="lgb-welcome">Welcome to {settings?.wikiName || 'WikiPOC'}</h2>

      <div className="lgb-search-bar">
        <SearchIcon />
        <input
          type="text"
          placeholder="Search wiki articles..."
          value={searchQuery}
          onChange={(e) => setSearchQuery(e.target.value)}
        />
      </div>

      {searchResults !== null ? (
        <div className="lgb-search-results">
          <h3>Search Results ({searchResults.length})</h3>
          {searchResults.length === 0 ? (
            <p style={{ color: styles.footerListTextColor }}>
              <svg width="48" height="48" viewBox="0 0 48 48" fill="none" aria-hidden="true" style={{display:'block',margin:'1em auto',opacity:0.3}}>
                <rect x="4" y="8" width="40" height="32" rx="3" stroke="currentColor" strokeWidth="2" />
                <path d="M4 14h40" stroke="currentColor" strokeWidth="2" />
                <path d="M16 22h16M16 28h10" stroke="currentColor" strokeWidth="2" />
              </svg>
              No articles found.
            </p>
          ) : (
            <ul className="lgb-article-list">
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
        </div>
      ) : (
        <div className="lgb-article-list">
          <h3>Wiki Articles Categorized</h3>
          {Object.entries(pagesByCategory).map(([category, pages]) => (
            <div key={category}>
              <h4>{category}</h4>
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
        </div>
      )}
    </div>
  );
};

export default HomeComponent;
