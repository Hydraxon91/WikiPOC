import { useEffect, useState } from 'react';
import { Outlet, useLocation } from 'react-router-dom';
import WikiList from './Components/WikiList';
import HamburgerMenu from './Components/HamburgerMenu';
import HeaderComponent from './Components/HeaderComponent';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import { useUserContext } from '../../Components/contexts/UserContextProvider';
import { getWikiPageTitles } from '../../Api/wikiApi';

const MainPage = ({ decodedToken, handleLogout, jwtToken, setWikiPageTitles, categories }) => {
  const location = useLocation();
  const { styles } = useStyleContext();
  const { updateUser } = useUserContext();
  const [userName, setUserName] = useState(null);
  const [userRole, setUserRole] = useState(null);

  useEffect(() => {
    if (decodedToken) {
      updateUser(decodedToken);
      setUserName(decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]);
      setUserRole(decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
    } else {
      setUserName(null);
      setUserRole(null);
    }
  }, [decodedToken]);

  useEffect(() => {
    const era = styles.interfaceEra || 'wikipedia';
    if (era === 'wikipedia' || !styles.bgMeshGradient || styles.bgMeshGradient === 'none') {
      document.body.style.background = styles.bodyColor || '#f8f9fa';
      document.body.style.backgroundAttachment = 'scroll';
      document.body.style.backgroundSize = 'auto';
    } else {
      document.body.style.background = styles.bgMeshGradient;
      document.body.style.backgroundAttachment = 'fixed';
      document.body.style.backgroundSize = 'cover';
    }
  }, [styles.bgMeshGradient, styles.bodyColor, styles.interfaceEra]);

  useEffect(() => {
    fetchWikiPageTitles();
  }, [location]);

  const fetchWikiPageTitles = async () => {
    try {
      const pages = await getWikiPageTitles();
      setWikiPageTitles(pages);
    } catch (error) {
      console.error("Error fetching WikiPages:", error);
    }
  };

  const era = styles.interfaceEra || 'wikipedia';

  return (
    <div className={`wrapAll clearfix era-${era}`} style={{
      minHeight: "100vh",
      fontWeight: "bold",
      fontFamily: styles.fontFamily,
      '--accent-color': styles.articleColor,
      '--article-color': styles.articleColor,
      '--footer-link-color': styles.footerListLinkTextColor,
      '--glass-bg-opacity': styles.glassBgOpacity ?? 1,
      '--glass-blur-radius': (styles.glassBlurRadius || 0) + 'px',
      '--glass-border-reflection': styles.glassBorderReflection || 0,
      '--bg-mesh-gradient': styles.bgMeshGradient,
      '--custom-border-radius': styles.borderRadius || '0px',
      '--custom-border-style': styles.borderStyle || '1px solid #a2a9b1',
    } as any}>
      <div>
        <HeaderComponent userName={userName} userRole={userRole}>
          <HamburgerMenu handleLogout={handleLogout} categories={categories} />
        </HeaderComponent>
        <WikiList handleLogout={handleLogout} jwtToken={jwtToken} categories={categories} />
        <div className="mainsection">
          <div style={{ flex: 1 }}>
            <Outlet />
          </div>
          <div className="pagefooter" style={{ color: styles.footerListTextColor }}>
            This is a footer | Template by <a href="http://html5-templates.com/" target="_blank" rel="nofollow" style={{ color: styles.footerListLinkTextColor }}>HTML5 Templates</a>
            <div className="footerlinks">
              <a href="#" style={{ color: styles.footerListLinkTextColor }}>Privacy policy</a>
              <a href="#" style={{ color: styles.footerListLinkTextColor }}>About</a>
              <a href="#" style={{ color: styles.footerListLinkTextColor }}>Terms and conditions</a>
              <a href="#" style={{ color: styles.footerListLinkTextColor }}>Cookie statement</a>
              <a href="#" style={{ color: styles.footerListLinkTextColor }}>Developers</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default MainPage;
