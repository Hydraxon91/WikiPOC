import React, { useEffect, useState } from "react";
import { Link } from 'react-router-dom';
import { useStyleContext } from './contexts/StyleContext';
import { useUserContext } from '../Components/contexts/UserContextProvider';
import { getNewPageTitles, getUpdatePageTitles } from "../Api/wikiApi";
import { getLogo } from '../Api/wikiUserApi';

const WikiList = ({ pages, handleLogout, cookies}) => {
  const { styles }  = useStyleContext();
  const [imageSrc, setImageSrc] = useState("/img/logo.png");
  const {decodedTokenContext, updateUser} = useUserContext();
  const [role, setRole] = useState(null);
  const [pagesWaitingForApproval, setPagesWaitingForApproval] = useState();
  const [updatesWaitingForApproval, setUpdatesWaitingForApproval] = useState();

  useEffect(()=>{
    if (styles.logo) {
        // Fetch profile picture when the component mounts or profilePicture prop changes
        getLogo(styles.logo)
            .then(data => {
                if (data instanceof Blob) { // Check if data is a Blob object
                    const imageUrl = URL.createObjectURL(data);
                    setImageSrc(imageUrl);
                } else if (typeof data === 'string' && data.startsWith('blob:')) {
                    setImageSrc(data);
                } else {
                    console.error('Invalid profile picture data:', data);
                    throw new Error('Invalid profile picture data');
                }
            })
            .catch(error => {
                console.error('Error fetching profile picture:', error);
                // Use default image URL in case of error
                setImageSrc("/img/logo.png");
            });
    }
},[styles.logo])

  useEffect(() => {
    if (decodedTokenContext) {
      var role = decodedTokenContext["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      setRole(role);
      if (role === "Admin") {
        fetchNewPageTitles(cookies["jwt_token"]);
        fetchUpdatePageTitles(cookies["jwt_token"]);
      }
    }
  }, [decodedTokenContext]);

  const fetchNewPageTitles = async (token) => {
    try {
      const pages = await getNewPageTitles(token);
      setPagesWaitingForApproval(pages.length);
    } catch (error) {
      console.error("Error fetching WikiPages:", error);
    }
  };
  const fetchUpdatePageTitles = async (token) => {
    try {
      const updates = await getUpdatePageTitles(token);
      setUpdatesWaitingForApproval(updates.length);
    } catch (error) {
      console.error("Error fetching WikiPages:", error);
    }
  };

  const UserTools = () =>{
    return role==="Admin" ?
     (
      <>
        <h3>Admin Tools</h3>
          <ul>
              <li>
                <Link key="approve-new-page-link" to="/user-submissions">
                  Pages Awaiting for Approval: {pagesWaitingForApproval}
                </Link>
              </li>
              <li>
                <Link key="approve-page-update-link" to="/user-updates">
                  Updates Awaiting for Approval: {updatesWaitingForApproval}
                </Link>
              </li>
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
              <li>
                <button onClick={() => handleLogout(updateUser)} className="logout-button">
                  Logout
                </button>
              </li>
        </ul>
      </>
    ) :
    (
      <>
        <h3>User Tools</h3>
          <ul>
              <li>
                <Link key="create-new-page-link" to="/create">
                  Create New Page
                </Link>
              </li>
              <li>
                <button onClick={() => handleLogout(updateUser)} className="logout-button">
                  Logout
                </button>
              </li>
        </ul>
      </>
    )
  }

  const LoginTools = () => {
    return(
      <>
      <h3>Login Tools</h3>
          <ul>
              <li>
                <Link key="login-page-link" to="/login">
                  Login
                </Link>
              </li>
              <li>
                <Link key="register-page-link" to="/register">
                  Register
                </Link>
              </li>
        </ul>
      </>
    )
  }
  
  return (
      <div className="sidebar">
        <div className="logo">
					<Link to="/"><img src={imageSrc} alt="logo"/></Link>
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
          {decodedTokenContext ? UserTools() : LoginTools()}
        </div>
        
      </div>
  );
};

export default WikiList;
