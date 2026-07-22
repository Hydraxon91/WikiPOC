import { useState, useEffect, CSSProperties } from 'react';
import { createPortal } from 'react-dom';
import { Link } from 'react-router-dom';
import { useCookies } from 'react-cookie';
import { useUserContext } from '../../../Components/contexts/UserContextProvider';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import { getFlaggedCommentsCount } from '../../../Api/moderationApi';
import '../Styles/hamburgermenu.css';

const HamburgerMenu = ({ categories, handleLogout }) => {
  const { decodedTokenContext, updateUser } = useUserContext();
  const { styles } = useStyleContext();
  const [isOpen, setIsOpen] = useState(false);
  const [flaggedCount, setFlaggedCount] = useState(0);
  const [cookies] = useCookies(['jwt_token']);
  const role = decodedTokenContext?.['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

  const token = cookies['jwt_token'];

  useEffect(() => {
    if (token && (role === 'Moderator' || role === 'Admin' || role === 'Owner')) {
      getFlaggedCommentsCount(token).then(data => setFlaggedCount(data.count)).catch(() => {});
    }
  }, [token, role]);

  const closeDrawer = () => setIsOpen(false);

  return (
    <>
      <button className={`hamburger-toggle${isOpen ? ' hidden' : ''}`} onClick={() => setIsOpen(true)} aria-label="Open navigation menu" aria-expanded={isOpen} aria-controls="hamburger-drawer">
        <span className="hamburger-line"></span>
        <span className="hamburger-line"></span>
        <span className="hamburger-line"></span>
      </button>
      {createPortal(
      <div className={`hamburger-overlay${isOpen ? ' open' : ''}`} onClick={closeDrawer}>
        <div id="hamburger-drawer" className={`hamburger-drawer${isOpen ? ' open' : ''}`} onClick={e => e.stopPropagation()} role="dialog" aria-modal={isOpen} aria-label="Navigation menu" style={{ '--drawer-bg': styles.articleColor, '--drawer-text': styles.footerListTextColor, '--drawer-link': styles.footerListLinkTextColor, '--drawer-heading': styles.articleRightColor } as CSSProperties}>
          <button className="hamburger-close" onClick={closeDrawer} aria-label="Close navigation menu">×</button>

            <h2 style={{ marginBottom: '5px', fontSize: '110%' }}>Categories</h2>
            {categories && categories.map((category, index) => (
              <div key={index}>
                <Link to={`/categories/${encodeURIComponent(category)}`} onClick={closeDrawer}>
                  <p style={{ marginBottom: '4px', fontSize: '80%' }}>{category}</p>
                </Link>
              </div>
            ))}

            <h2 style={{ marginBottom: '5px', fontSize: '110%' }}>Forum Tools</h2>
            <Link to="/forum" onClick={closeDrawer}>
              <p style={{ marginBottom: '4px', fontSize: '80%' }}>Forum</p>
            </Link>

            {decodedTokenContext ? (
              role === 'Admin' || role === 'Owner' ? (
                <>
                  <h2 style={{ marginBottom: '5px', fontSize: '110%' }}>Admin Tools</h2>
                  <Link to="/user-submissions" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Pages Awaiting Approval</p>
                  </Link>
                  <Link to="/user-updates" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Updates Awaiting Approval</p>
                  </Link>
                  <Link to="/create" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Create New Page</p>
                  </Link>
                  {role === 'Owner' && (
                    <Link to="/edit-wiki" onClick={closeDrawer}>
                      <p style={{ marginBottom: '4px', fontSize: '80%' }}>Edit Wiki</p>
                    </Link>
                  )}
                  <Link to="/categories/edit" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Edit Categories</p>
                  </Link>
                  <Link to="/admin/users" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Manage Users</p>
                  </Link>
                  <Link to="/moderation/flagged-comments" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Flagged Comments{flaggedCount > 0 && <span className="flag-badge">{flaggedCount}</span>}</p>
                  </Link>
                  <button onClick={() => { handleLogout(updateUser); closeDrawer(); }} className="logout-button" style={{ background: 'none', border: 'none', cursor: 'pointer', padding: 0, fontSize: '80%', marginBottom: '4px', color: '#024185', textDecoration: 'underline' }}>
                    Logout
                  </button>
                </>
              ) : role === 'Moderator' ? (
                <>
                  <h2 style={{ marginBottom: '5px', fontSize: '110%' }}>Moderator Tools</h2>
                  <Link to="/user-submissions" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Pages Awaiting Approval</p>
                  </Link>
                  <Link to="/user-updates" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Updates Awaiting Approval</p>
                  </Link>
                  <Link to="/create" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Create New Page</p>
                  </Link>
                  <Link to="/moderation/flagged-comments" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Flagged Comments{flaggedCount > 0 && <span className="flag-badge">{flaggedCount}</span>}</p>
                  </Link>
                  <button onClick={() => { handleLogout(updateUser); closeDrawer(); }} className="logout-button" style={{ background: 'none', border: 'none', cursor: 'pointer', padding: 0, fontSize: '80%', marginBottom: '4px', color: '#024185', textDecoration: 'underline' }}>
                    Logout
                  </button>
                </>
              ) : (
                <>
                  <h2 style={{ marginBottom: '5px', fontSize: '110%' }}>User Tools</h2>
                  <Link to="/create" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Create New Page</p>
                  </Link>
                  <button onClick={() => { handleLogout(updateUser); closeDrawer(); }} className="logout-button" style={{ background: 'none', border: 'none', cursor: 'pointer', padding: 0, fontSize: '80%', marginBottom: '4px', color: '#024185', textDecoration: 'underline' }}>
                    Logout
                  </button>
                </>
              )
            ) : (
              <>
                <h2 style={{ marginBottom: '5px', fontSize: '110%' }}>Login Tools</h2>
                <Link to="/login" onClick={closeDrawer}>
                  <p style={{ marginBottom: '4px', fontSize: '80%' }}>Login</p>
                </Link>
                <Link to="/register" onClick={closeDrawer}>
                  <p style={{ marginBottom: '4px', fontSize: '80%' }}>Register</p>
                </Link>
              </>
            )}
          </div>
        </div>,
        document.body
      )}
    </>
  );
};

export default HamburgerMenu;
