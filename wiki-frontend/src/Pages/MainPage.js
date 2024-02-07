import React, { useEffect, useState } from 'react';
import { Outlet  } from 'react-router-dom';
import WikiList from '../Components/WikiList';
import { useStyleContext } from '../Components/contexts/StyleContext';
import { jwtDecode } from 'jwt-decode';

const MainPage = ({ pages, cookies }) => {
  const { styles }  = useStyleContext();
  const [userName, setUserName] = useState("Not logged in");

  useEffect(()=>{
    if (cookies["jwt_token"]) {
      // console.log(cookies["jwt_token"]);
      const decoded = jwtDecode(cookies["jwt_token"]);
      // console.log(decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]);
      setUserName(decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]);
    }
    else{
      setUserName("Not logged in")
    }
  }, [cookies])

  return (
    <div className="wrapAll clearfix" style={{ backgroundColor: styles.bodyColor, width: "100vw", minHeight: "100vh"}}>
      <div>
        <WikiList pages={pages} />
        <div className="mainsection">
          <div className="headerLinks">{userName}</div>
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
