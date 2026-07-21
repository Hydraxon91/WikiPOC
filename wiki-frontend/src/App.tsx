import {useState, useEffect, lazy, Suspense} from "react";
import 'bootstrap/dist/css/bootstrap.css';
import './Styles/style.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
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
import type { DecodedToken } from "./types/contexts";
import ProtectedRoute from "./Components/ProtectedRoute";
import PublicRoute from "./Components/PublicRoute";
import LoadingSpinner from "./Components/LoadingSpinner";

const EditPage = lazy(() => import("./Pages/CreateEditArticle/EditPage"));
const EditStylePage = lazy(() => import("./Pages/EditStylePage/EditStylePage"));
const SiteSettingsPage = lazy(() => import("./Pages/SiteSettingsPage/SiteSettingsPage"));
const WikiPage = lazy(() => import("./Pages/WikiPage-Article/WikiPage"));
const ProfilePage = lazy(() => import("./Pages/ProfilePage/ProfilePage"));
const EditProfilePage = lazy(() => import("./Pages/ProfilePage/EditProfilePage"));
const CategoryPageComponent = lazy(() => import("./Pages/Categories/CategoryPageComponent"));
const EditCategoriesPage = lazy(() => import("./Pages/Categories/EditCategoriesPage"));
const ForumLandingPage = lazy(() => import("./Pages/ForumPages/ForumLandingPage"));
const ForumPage = lazy(() => import("./Pages/ForumPages/ForumPage"));
const ForumPost = lazy(() => import("./Pages/ForumPages/ForumPost"));
const CreateTopicPage = lazy(() => import("./Pages/ForumPages/CreateTopicPage"));
const CreatePostPage = lazy(() => import("./Pages/ForumPages/CreatePostPage"));
const UserRequestsPageComponent = lazy(() => import("./Pages/UserSubmittedArticle-Update/UserRequestsPageComponent"));
const CompareUpdatePage = lazy(() => import("./Pages/UserSubmittedArticle-Update/CompareUpdatePage"));
const CheckUserSubmittedPage = lazy(() => import("./Pages/UserSubmittedArticle-Update/CheckUserSubmittedPage"));
const UserManagementPage = lazy(() => import("./Pages/UserManagement/UserManagementPage"));
const DebugRolesPage = lazy(() => import("./Pages/DebugRoles/DebugRolesPage"));
const FlaggedCommentsPage = lazy(() => import("./Pages/Moderation/FlaggedCommentsPage"));
import RegisterPageComponent from "./Pages/LoginLogoutPages/RegisterPageComponent";

const decodeToken = (token: string): DecodedToken | null => {
  try {
    const decoded = jwtDecode<DecodedToken>(token);
    if (decoded.exp && Date.now() >= decoded.exp * 1000) {
      return null;
    }
    return decoded;
  } catch {
    return null;
  }
};

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

  const jwtToken = cookies["jwt_token"];

  useEffect(() => {
    if (jwtToken) {
      setDecodedToken(decodeToken(jwtToken));
    }
  }, [jwtToken]);

  useEffect(() => {
    if (jwtToken) {
      setDecodedToken(decodeToken(jwtToken));
    }
    const timeout = setTimeout(() => {
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
    }, 0);
    return () => clearTimeout(timeout);
  }, [jwtToken, showNotification]);

  // On page load, silently refresh the token so role changes take effect immediately
  useEffect(() => {
    const token = cookies["jwt_token"];
    if (!token) return;
    const timeout = setTimeout(() => {
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
    }, 0);
    return () => clearTimeout(timeout);
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  useEffect(() => {
    if (!decodedSlug) return;
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
    fetchPage();
  }, [decodedSlug, showNotification]);


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
            <Suspense fallback={<LoadingSpinner />}>
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
                <Route path="/moderation/flagged-comments" element={
                  <ProtectedRoute roles={['Moderator', 'Admin', 'Owner']}>
                    <FlaggedCommentsPage />
                  </ProtectedRoute>
                } />
                <Route path="/debug/roles" element={<DebugRolesPage jwtToken={cookies["jwt_token"]} />} />
                <Route path="*" element={<div style={{ padding: '2rem', textAlign: 'center' }}><h2>Page Not Found</h2></div>} />
              </Route>
            </Routes>
            </Suspense>
          </StyleProvider>
          </SiteSettingsProvider>
        </Router>
      </UserContextProvider>
  );
}

export default App;