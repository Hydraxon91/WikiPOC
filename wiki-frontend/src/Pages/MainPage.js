import React, { useEffect, useState } from 'react';
import { Outlet, useLocation } from 'react-router-dom';
import WikiList from '../Components/WikiList';
import { useStyleContext } from '../Components/contexts/StyleContext';
import { useUserContext } from '../Components/contexts/UserContextProvider';
import { getWikiPageTitles } from '../Api/wikiApi';

const MainPage = ({ pages, decodedToken, handleLogout, cookies, setWikiPageTitles }) => {
  const location = useLocation();
  const { styles }  = useStyleContext();
  const { updateUser } = useUserContext();
  const [userName, setUserName] = useState("Not logged in");
  const [userRole, setUserRole] = useState(null);

  useEffect(()=>{
    // console.log(decodedToken);
    if (decodedToken) {
      updateUser(decodedToken);
      setUserName(decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]);
      setUserRole("Role: " +decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
    }
    else{
      setUserName("Not logged in")
      setUserRole(null);
    }
  }, [decodedToken])

  useEffect(() => {
    // Fetch WikiPages when the component mounts
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

  return (
    <div className="wrapAll clearfix" style={{ backgroundColor: styles.bodyColor, width: "100vw", minHeight: "100vh"}}>
      <div>
        <WikiList pages={pages} handleLogout={handleLogout} cookies={cookies}/>
        <div className="mainsection">
          <div className="headerLinks"><a href={`/profile/${userName}`}>{userName}</a> {userRole}</div>
          <div className="article" style={{backgroundColor: styles.articleColor}}>
            {/* Render children, which will be the specific WikiPage component */}
            <Outlet />
          </div>
          <div className="pagefooter" style={{color: styles.footerListTextColor}}>
            This is a footer | Template by <a href="http://html5-templates.com/" target="_blank" rel="nofollow" style={{color: styles.footerListLinkTextColor}}>HTML5 Templates</a>
            <div className="footerlinks" >
              <a href="#" style={{color: styles.footerListLinkTextColor}}>Privacy policy</a> 
              <a href="#" style={{color: styles.footerListLinkTextColor}}>About</a> 
              <a href="#" style={{color: styles.footerListLinkTextColor}}>Terms and conditions</a> 
              <a href="#" style={{color: styles.footerListLinkTextColor}}>Cookie statement</a> 
              <a href="#" style={{color: styles.footerListLinkTextColor}}>Developers</a>
            </div>
        </div>
        </div>
      </div>
    </div>
  );
};

export default MainPage;
