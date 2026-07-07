import {useState, useEffect} from "react";
import 'bootstrap/dist/css/bootstrap.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import EditPage from "./Pages/CreateEditArticle/EditPage";
import EditStylePage from "./Pages/EditStylePage/EditStylePage";
import SiteSettingsPage from "./Pages/SiteSettingsPage/SiteSettingsPage";
import MainPage from "./Pages/MainPage/MainPage";
import HomeComponent from "./Pages/MainPage/Components/HomeComponent";
import { StyleProvider  } from "./Components/contexts/StyleContext";
import { SiteSettingsProvider } from "./Components/contexts/SiteSettingsContext";
import { createWikiPage, updateWikiPage, getWikiPageBySlug, fetchCategories } from "./Api/wikiApi";
import LoginPageComponent from "./Pages/LoginLogoutPages/LoginPageComponent";
import { useCookies } from "react-cookie";
import { jwtDecode } from 'jwt-decode';
import { useNotification } from './Components/NotificationProvider';
import { UserContextProvider } from "./Components/contexts/UserContextProvider";

const decodeToken = (token: string) => {
  try {
    const decoded: any = jwtDecode(token);
    if (decoded.exp && Date.now() >= decoded.exp * 1000) {
      return null;
    }
    return decoded;
  } catch {
    return null;
  }
};
import RegisterPageComponent from "./Pages/LoginLogoutPages/RegisterPageComponent";
import UserRequestsPageComponent from "./Pages/UserSubmittedArticle-Update/UserRequestsPageComponent";
import CompareUpdatePage from "./Pages/UserSubmittedArticle-Update/CompareUpdatePage";
import CheckUserSubmittedPage from "./Pages/UserSubmittedArticle-Update/CheckUserSubmittedPage";
import UserManagementPage from "./Pages/UserManagement/UserManagementPage";
import DebugRolesPage from "./Pages/DebugRoles/DebugRolesPage";
import WikiPage from "./Pages/WikiPage-Article/WikiPage";
import ProfilePage from "./Pages/ProfilePage/ProfilePage";
import EditProfilePage from "./Pages/ProfilePage/EditProfilePage";
import CategoryPageComponent from "./Pages/Categories/CategoryPageComponent";
import EditCategoriesPage from "./Pages/Categories/EditCategoriesPage";
import ForumLandingPage from "./Pages/ForumPages/ForumLandingPage";
import ForumPage from "./Pages/ForumPages/ForumPage";
import ForumPost from "./Pages/ForumPages/ForumPost";
import CreateTopicPage from "./Pages/ForumPages/CreateTopicPage";
import CreatePostPage from "./Pages/ForumPages/CreatePostPage";
import ProtectedRoute from "./Components/ProtectedRoute";
import PublicRoute from "./Components/PublicRoute";

function App() {

  const [wikiPageTitles, setWikiPageTitles] = useState([]);
  const [currentWikiPage, setCurrentWikiPage] = useState(null);
  const [categories, setCategories] = useState([]);
  const [decodedSlug, setDecodedSlug] = useState(null);
  const [pageError, setPageError] = useState(false);

  const [cookies, setCookie, removeCookie] = useCookies(["jwt_token"]);
  const [decodedToken, setDecodedToken] = useState(() => {
    if (cookies["jwt_token"]) return decodeToken(cookies["jwt_token"]);
    return null;
  });
  const { showNotification } = useNotification();

  useEffect(() => {
    if (cookies["jwt_token"]) {
      setDecodedToken(decodeToken(cookies["jwt_token"]));
    }
  }, [cookies["jwt_token"]]); // Trigger the effect when the token changes

  useEffect(() => {
    if (cookies["jwt_token"]) {
      setDecodedToken(decodeToken(cookies["jwt_token"]));
    }
    // Fetch categories
    fetchCategories()
      .then(categories => {
        const categoryNames = categories.map(category => category.categoryName);
        categoryNames.push("Uncategorized");
        setCategories(categoryNames);
      })
      .catch(error => {
        console.error('Error fetching categories:', error);
        showNotification('Failed to load categories.');
      });
  }, []); // Trigger the effect when just loading

  // On page load, silently refresh the token so role changes take effect immediately
  useEffect(() => {
    const token = cookies["jwt_token"];
    if (!token) return;
    fetch(`${import.meta.env.VITE_API_URL}/api/Users/RefreshToken`, {
      method: 'POST',
      headers: { 'Authorization': `Bearer ${token}` }
    }).then(res => {
      if (res.ok) return res.json();
      return null;
    }).then(data => {
      if (data?.token && data.token !== token) {
        setCookie("jwt_token", data.token, { path: "/" });
      }
    });
  }, []);

  const fetchPage = async () => {
    try {
      setCurrentWikiPage(null);
      setPageError(false);
      const data = await getWikiPageBySlug(decodedSlug);
      if (!data) {
        setPageError(true);
        return;
      }
      setCurrentWikiPage(data);
    } catch (error) {
      console.error('Error fetching page:', error);
      setPageError(true);
      showNotification('Failed to load page.');
    }
  };

  useEffect(() => {
    if (decodedSlug) {
      fetchPage();
    }
  }, [decodedSlug]);


  const handleCreate = (newPage, images) => {
    return createWikiPage(newPage, cookies["jwt_token"], decodedToken, images)
      .then((createdPage) => {
        setWikiPageTitles([...wikiPageTitles, [createdPage.Title, createdPage.Category]]);
        return createdPage; // Ensure you're returning a value
      })
      .catch((error) => {
        console.error("Error creating WikiPage:", error);
        showNotification('Failed to create page.');
        throw error;
      });
  };
  
  const handleEdit = (updatedPage, images) => {
    return updateWikiPage(updatedPage, cookies["jwt_token"], decodedToken, images)
      .then((updatedWikiPage) => {
        setCurrentWikiPage({ wikiPage: updatedPage, images: images });
        return updatedWikiPage;
      })
      .catch((error) => {
        console.error("Error updating WikiPage:", error);
        showNotification('Failed to update page.');
        throw error;
      });
  };

  const handleLogin = (user, expirationDate) => {
    setCookie("jwt_token", user, { path: "/", expires: expirationDate});
  }

  const handleLogout = (updateUser) => {
    updateUser(null);
    removeCookie("jwt_token", { path: "/" });
    setDecodedToken(null);
  };

   return (
      <UserContextProvider>
        <Router>
          <SiteSettingsProvider>
          <StyleProvider>
            <Routes>
              <Route path="/" element={<MainPage decodedToken={decodedToken} handleLogout={handleLogout} jwtToken={cookies} setWikiPageTitles={setWikiPageTitles} categories={categories} />}>
                <Route path="/" element={<HomeComponent pages={wikiPageTitles} categories={categories} />} />
                <Route path="/page/:slug" element={<WikiPage page={currentWikiPage} setDecodedSlug={setDecodedSlug} jwtToken={cookies["jwt_token"]} pageError={pageError} />}/>
                <Route path="/page/:slug/edit"
                  element={
                  <ProtectedRoute roles={['User', 'Admin', 'Moderator']}>
                    <EditPage page={currentWikiPage} handleEdit={handleEdit} handleCreate={handleCreate} />
                  </ProtectedRoute>
                  } 
                />
                <Route path="/create" element={
                  <ProtectedRoute roles={['User', 'Admin', 'Moderator']}>
                    <EditPage handleEdit={handleEdit} handleCreate={handleCreate} />
                  </ProtectedRoute>
                } />
                <Route path="/edit-wiki" element={
                  <ProtectedRoute roles={['Owner']} >
                    <EditStylePage jwtToken={cookies["jwt_token"]}/>
                  </ProtectedRoute>
                } />
                <Route path="/site-settings" element={
                  <ProtectedRoute roles={['Owner']} >
                    <SiteSettingsPage jwtToken={cookies["jwt_token"]}/>
                  </ProtectedRoute>
                } />
                <Route path="/login" element={
                  <PublicRoute>
                    <LoginPageComponent handleLogin={handleLogin}/>
                  </PublicRoute>
                } />
                <Route path="/register" element={
                  <PublicRoute>
                    <RegisterPageComponent/>
                  </PublicRoute>
                } />
                <Route path="/user-submissions" element={
                  <ProtectedRoute roles={['Admin', 'Moderator']} >
                    <UserRequestsPageComponent/>
                  </ProtectedRoute>
                } />
                <Route path="/user-submissions/:id" element={
                  <ProtectedRoute roles={['Admin', 'Moderator']} >
                    <CheckUserSubmittedPage/>
                  </ProtectedRoute>
                } />
                <Route path="/user-updates" element={
                  <ProtectedRoute roles={['Admin', 'Moderator']} >
                    <UserRequestsPageComponent/>
                  </ProtectedRoute>
                } />

                <Route path="/user-updates/:id" element={
                  <ProtectedRoute  roles={['Admin', 'Moderator']} >
                    <CompareUpdatePage/>
                  </ProtectedRoute>
                } />
                <Route path="/profile/:username" element={<ProfilePage />} />
                <Route path="/profile/edit/:username" element={
                  <ProtectedRoute roles={['User', 'Admin', 'Moderator']}>
                    <EditProfilePage jwtToken={cookies["jwt_token"]}
/>
                  </ProtectedRoute>
                } />
                <Route path="/categories/edit" element={
                  <ProtectedRoute  roles={['Admin']} >
                    <EditCategoriesPage setAppCategories={setCategories} jwtToken={cookies["jwt_token"]}
/>
                  </ProtectedRoute>
                }/>
                <Route path="/admin/users" element={
                  <ProtectedRoute roles={['Admin']}>
                    <UserManagementPage jwtToken={cookies["jwt_token"]} />
                  </ProtectedRoute>
                } />
                <Route path="/categories/:category" element={<CategoryPageComponent pages={wikiPageTitles} categories={categories} />} />
                <Route path="/forum" element={<ForumLandingPage />} />
                <Route path="/forum/:slug" element={<ForumPage jwtToken={cookies["jwt_token"]}
 />} />
                <Route path="/forum/create-topic" element={
                  <ProtectedRoute  roles={['User', 'Admin', 'Moderator', 'Owner']}>
                    <CreateTopicPage jwtToken={cookies["jwt_token"]}
 />
                  </ProtectedRoute>
                }/>
                <Route path="/forum/:slug/create-post" element={
                  <ProtectedRoute  roles={['User', 'Admin', 'Moderator', 'Owner']}>
                    <CreatePostPage jwtToken={cookies["jwt_token"]}
 />
                  </ProtectedRoute>
                }/>
                <Route path="/forum/:slug/:postSlug" element={<ForumPost jwtToken={cookies["jwt_token"]}
 />} />
                <Route path="/debug/roles" element={<DebugRolesPage jwtToken={cookies["jwt_token"]} />} />
                <Route path="*" element={<div style={{ padding: '2rem', textAlign: 'center' }}><h2>Page Not Found</h2></div>} />
              </Route>
            </Routes>
          </StyleProvider>
          </SiteSettingsProvider>
        </Router>
      </UserContextProvider>
  );
}

export default App;