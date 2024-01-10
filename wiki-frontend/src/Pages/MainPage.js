import React from 'react';
import { Outlet  } from 'react-router-dom';
import WikiList from '../Components/WikiList';
import { useStyleContext } from '../Components/contexts/StyleContext';


const MainPage = ({ pages }) => {
  const { styles }  = useStyleContext();

  return (
    <div className="wrapAll clearfix" style={{ backgroundColor: styles.bodyColor, width: "100vw", height: "100vh"}}>
      <div>
        <WikiList pages={pages} />
        <div className="mainsection">
          <div className="headerLinks">HeaderLink</div>
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
