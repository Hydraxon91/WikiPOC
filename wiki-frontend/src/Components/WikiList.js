import React, { useEffect, useState } from "react";
import { Link } from 'react-router-dom';
import { useStyleContext } from './contexts/StyleContext';
import { useUserContext } from '../Components/contexts/UserContextProvider';

const WikiList = ({ pages, handleLogout }) => {
  const { styles }  = useStyleContext();
  const {decodedTokenContext, updateUser} = useUserContext();
  const [role, setRole] = useState(null);

  useEffect(() => {
    if (decodedTokenContext) {
      setRole(decodedTokenContext["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
    }
  }, [decodedTokenContext]);

  const UserTools = () =>{
    return role==="Admin" ?
     (
      <>
        <h3>Admin Tools</h3>
          <ul>
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
					<Link to="/"><img src={styles.logo} alt="logo"/></Link>
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
