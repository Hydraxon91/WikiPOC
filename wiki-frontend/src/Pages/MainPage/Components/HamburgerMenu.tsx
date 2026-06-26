import { useState } from 'react';
import { Link } from 'react-router-dom';
import { useUserContext } from '../../../Components/contexts/UserContextProvider';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import '../Styles/hamburgermenu.css';

const HamburgerMenu = ({ categories, handleLogout }) => {
  const { decodedTokenContext, updateUser } = useUserContext();
  const { styles } = useStyleContext();
  const [isOpen, setIsOpen] = useState(false);
  const role = decodedTokenContext?.['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

  const closeDrawer = () => setIsOpen(false);

  return (
    <>
      <button className={`hamburger-toggle${isOpen ? ' hidden' : ''}`} onClick={() => setIsOpen(true)} aria-label="Menu">
        <span className="hamburger-line"></span>
        <span className="hamburger-line"></span>
        <span className="hamburger-line"></span>
      </button>
      <div className={`hamburger-overlay${isOpen ? ' open' : ''}`} onClick={closeDrawer}>
        <div className={`hamburger-drawer${isOpen ? ' open' : ''}`} onClick={e => e.stopPropagation()} style={{ '--drawer-bg': styles.articleColor, '--drawer-text': styles.footerListTextColor, '--drawer-link': styles.footerListLinkTextColor, '--drawer-heading': styles.articleRightColor } as any}>
          <button className="hamburger-close" onClick={closeDrawer}>×</button>

            <h3 style={{ marginBottom: '5px', fontSize: '110%' }}>Categories</h3>
            {categories && categories.map((category, index) => (
              <div key={index}>
                <Link to={`/categories/${encodeURIComponent(category)}`} onClick={closeDrawer}>
                  <p style={{ marginBottom: '4px', fontSize: '80%' }}>{category}</p>
                </Link>
              </div>
            ))}

            <h3 style={{ marginBottom: '5px', fontSize: '110%' }}>Forum Tools</h3>
            <Link to="/forum" onClick={closeDrawer}>
              <p style={{ marginBottom: '4px', fontSize: '80%' }}>Forum</p>
            </Link>

            {decodedTokenContext ? (
              role === 'Admin' ? (
                <>
                  <h3 style={{ marginBottom: '5px', fontSize: '110%' }}>Admin Tools</h3>
                  <Link to="/user-submissions" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Pages Awaiting Approval</p>
                  </Link>
                  <Link to="/user-updates" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Updates Awaiting Approval</p>
                  </Link>
                  <Link to="/create" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Create New Page</p>
                  </Link>
                  <Link to="/edit-wiki" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Edit Wiki</p>
                  </Link>
                  <Link to="/categories/edit" onClick={closeDrawer}>
                    <p style={{ marginBottom: '4px', fontSize: '80%' }}>Edit Categories</p>
                  </Link>
                  <button onClick={() => { handleLogout(updateUser); closeDrawer(); }} className="logout-button" style={{ background: 'none', border: 'none', cursor: 'pointer', padding: 0, fontSize: '80%', marginBottom: '4px', color: '#024185', textDecoration: 'underline' }}>
                    Logout
                  </button>
                </>
              ) : (
                <>
                  <h3 style={{ marginBottom: '5px', fontSize: '110%' }}>User Tools</h3>
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
                <h3 style={{ marginBottom: '5px', fontSize: '110%' }}>Login Tools</h3>
                <Link to="/login" onClick={closeDrawer}>
                  <p style={{ marginBottom: '4px', fontSize: '80%' }}>Login</p>
                </Link>
                <Link to="/register" onClick={closeDrawer}>
                  <p style={{ marginBottom: '4px', fontSize: '80%' }}>Register</p>
                </Link>
              </>
            )}
          </div>
        </div>
    </>
  );
};

export default HamburgerMenu;
