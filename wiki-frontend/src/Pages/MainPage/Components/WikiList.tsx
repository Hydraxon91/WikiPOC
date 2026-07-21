import { useEffect, useState } from "react";
import { Link, useLocation } from 'react-router-dom';
import { useUserContext } from '../../../Components/contexts/UserContextProvider';
import { getNewPageTitles, getUpdatePageTitles } from "../../../Api/wikiApi";
import { getFlaggedCommentsCount } from '../../../Api/moderationApi';

const WikiList = ({ handleLogout, jwtToken, categories}) => {
  const {decodedTokenContext, updateUser} = useUserContext();
  const location = useLocation();
  const [role, setRole] = useState(null);
  const [pagesWaitingForApproval, setPagesWaitingForApproval] = useState();
  const [updatesWaitingForApproval, setUpdatesWaitingForApproval] = useState();
  const [flaggedCount, setFlaggedCount] = useState(0);


  useEffect(() => {
    if (decodedTokenContext) {
      const role = decodedTokenContext["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      setRole(role);
      if (role === "Admin" || role === "Owner" || role === "Moderator") {
        fetchNewPageTitles(jwtToken["jwt_token"]);
        fetchUpdatePageTitles(jwtToken["jwt_token"]);
        getFlaggedCommentsCount(jwtToken["jwt_token"]).then(data => setFlaggedCount(data.count)).catch(() => {});
      }
    }
  }, [decodedTokenContext, location, jwtToken]);


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

  const ModeratorTools = () => (
    <>
      <h2 style={{ marginBottom: '5px', fontSize: '110%' }}>Admin Tools</h2>
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
          <Link key="flagged-comments-mod" to="/moderation/flagged-comments">
            Flagged Comments{flaggedCount > 0 && <span className="flag-badge">{flaggedCount}</span>}
          </Link>
        </li>
        <li>
          <button onClick={() => handleLogout(updateUser)} className="logout-button">
            Logout
          </button>
        </li>
      </ul>
    </>
  );

  const AdminTools = () => (
    <>
      <h2 style={{ marginBottom: '5px', fontSize: '110%' }}>Admin Tools</h2>
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
        {(role === "Owner") && (
        <li>
          <Link key="edit-wiki-link" to="/edit-wiki">
            Edit Wiki
          </Link>
        </li>
        )}
        <li>
          <Link key="edit-categories" to="/categories/edit">
            Edit Categories
          </Link>
        </li>
        <li>
          <Link key="manage-users" to="/admin/users">
            Manage Users
          </Link>
        </li>
        <li>
          <Link key="flagged-comments-admin" to="/moderation/flagged-comments">
            Flagged Comments{flaggedCount > 0 && <span className="flag-badge">{flaggedCount}</span>}
          </Link>
        </li>
        <li>
          <button onClick={() => handleLogout(updateUser)} className="logout-button">
            Logout
          </button>
        </li>
      </ul>
    </>
  );

  const UserTools = () => (
    <>
      <h2 style={{ marginBottom: '5px', fontSize: '110%' }}>User Tools</h2>
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
  );

  const LoginTools = () => {
    return(
      <>
      <h2 style={{marginBottom:"5px", fontSize:'110%'}}>Login Tools</h2>
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
  <div className="sidebar" role="navigation" aria-label="Sidebar navigation">
    <div className="navigation">
      <h2 style={{marginBottom:"5px", fontSize:'110%'}}>Categories</h2>
      {categories && categories.map((category, index) => (
        <div key={index}>
          <Link to={`/categories/${encodeURIComponent(category)}`}>
            <p style={{marginBottom:'4px', fontSize:'80%'}}>{category}</p>
          </Link>
        </div>
      ))}
      <h2 style={{marginBottom:"5px", fontSize:'110%'}}>Forum Tools</h2>
      <ul>
        <li>
          <Link key="forum-page-link" to="/forum">
            Forum
          </Link>
        </li>
      </ul>
      {decodedTokenContext ? (role === "Owner" || role === "Admin" ? <AdminTools /> : role === "Moderator" ? <ModeratorTools /> : <UserTools />) : <LoginTools />}
    </div>
    
  </div>
);
};

export default WikiList;
