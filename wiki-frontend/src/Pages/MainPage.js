import React from 'react';
import { Outlet  } from 'react-router-dom';
import WikiList from '../Components/WikiList';

const MainPage = ({ children, pages }) => {
  return (
    <div className="wrapAll clearfix">
      <div>
        <WikiList pages={pages} />
        <div className="mainsection">
          <div className="headerLinks">HeaderLink</div>
          <div className="article">
            {/* Render children, which will be the specific WikiPage component */}
            <Outlet />
          </div>
        </div>
        <main>{children}</main>
        <div class="pagefooter">
          This is a footer | Template by <a href="http://html5-templates.com/" target="_blank" rel="nofollow">HTML5 Templates</a>
          <div class="footerlinks">
            <a href="#">Privacy policy</a> <a href="#">About</a> <a href="#">Terms and conditions</a> <a href="#">Cookie statement</a> <a href="#">Developers</a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default MainPage;
