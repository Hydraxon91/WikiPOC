import React, {useState, useEffect} from "react";
import 'bootstrap/dist/css/bootstrap.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import LegacyEditPage from "./Pages/CreateEditArticle/LegacyEditPage.js";
import EditPage from "./Pages/CreateEditArticle/EditPage.js";
import EditStylePage from "./Pages/EditStylePage/EditStylePage.js";
import MainPage from "./Pages/MainPage/MainPage.js";
import HomeComponent from "./Pages/MainPage/Components/HomeComponent.js";
import { StyleProvider  } from "./Components/contexts/StyleContext.js";
import { createWikiPage, deleteWikiPage, updateWikiPage, getWikiPageByTitle, fetchCategories } from "./Api/wikiApi.js";
import LoginPageComponent from "./Pages/LoginLogoutPages/LoginPageComponent.js";
import { CookiesProvider, useCookies } from "react-cookie";
import { jwtDecode } from 'jwt-decode';
import { UserContextProvider } from "./Components/contexts/UserContextProvider.js";
import RegisterPageComponent from "./Pages/LoginLogoutPages/RegisterPageComponent.js";
import UserRequestsPageComponent from "./Pages/UserSubmittedArticle-Update/UserRequestsPageComponent.js";
import CompareUpdatePage from "./Pages/UserSubmittedArticle-Update/CompareUpdatePage.js";
import CheckUserSubmittedPage from "./Pages/UserSubmittedArticle-Update/CheckUserSubmittedPage.js";
import WikiPage from "./Pages/WikiPage-Article/WikiPage.js";
import ProfilePage from "./Pages/ProfilePage/ProfilePage.js";
import EditProfilePage from "./Pages/ProfilePage/EditProfilePage.js";
import CategoryPageComponent from "./Pages/Categories/CategoryPageComponent.js";
import EditCategoriesPage from "./Pages/Categories/EditCategoriesPage.js";
import ForumLandingPage from "./Pages/ForumPages/ForumLandingPage.js";
import ForumPage from "./Pages/ForumPages/ForumPage.js";
import ForumPost from "./Pages/ForumPages/ForumPost.js";

function App() {

  const [wikiPageTitles, setWikiPageTitles] = useState([]);
  const [currentWikiPage, setCurrentWikiPage] = useState(null);
  const [categories, setCategories] = useState([]);
  const [decodedTitle, setDecodedTitle] = useState(null);

  const [cookies, setCookie, removeCookie] = useCookies(["jwt_token"]);
  const [decodedToken, setDecodedToken] = useState(null);

  useEffect(() => {
    if (cookies["jwt_token"]) {
      setDecodedToken(jwtDecode(cookies["jwt_token"]));
    }
  }, [cookies["jwt_token"]]); // Trigger the effect when the token changes

  useEffect(() => {
    if (cookies["jwt_token"]) {
      setDecodedToken(jwtDecode(cookies["jwt_token"]));
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
      });
  }, []); // Trigger the effect when just loading

  const fetchPage = async () => {
    try {
      const data = await getWikiPageByTitle(decodedTitle);
      setCurrentWikiPage(data);
      // console.log(data);
    } catch (error) {
      console.error('Error fetching page:', error);
    }
  };

  useEffect(() => {
    if (decodedTitle) {
      fetchPage(decodedTitle);
    }
  }, [decodedTitle]);


  const handleCreate = (newPage, images) => {
    console.log('Inside handleCreate');
    return createWikiPage(newPage, cookies["jwt_token"], decodedToken, images)
      .then((createdPage) => {
        console.log('createWikiPage resolved:', createdPage);
        setWikiPageTitles([...wikiPageTitles, [createdPage.Title, createdPage.Category]]);
        return createdPage; // Ensure you're returning a value
      })
      .catch((error) => {
        console.error("Error creating WikiPage:", error);
        throw error; // Rethrow the error to propagate it to the next .catch
      });
  };
  const handleDelete = (id) => {
    deleteWikiPage(id, cookies["jwt_token"])
      .then(() => {
        setWikiPageTitles(wikiPageTitles.filter((page) => page.Title !== currentWikiPage.Title));
      })
      .catch((error) => {
        console.error("Error deleting WikiPage:", error);
      });
  };
  
  const handleEdit = (updatedPage, images) => {
    console.log(updatedPage);
    console.log('Inside handleEdit');
    console.log(images);
    return updateWikiPage(updatedPage, cookies["jwt_token"], decodedToken, images)
      .then((updatedWikiPage) => {
        console.log('updateWikiPage resolved:', updatedWikiPage);
        setWikiPageTitles((prevPages) =>
          prevPages.map((page) => (page === updatedWikiPage.Title ? updatedWikiPage.Title : page))
        );
        return updatedWikiPage; // Ensure you're returning a value
      })
      .catch((error) => {
        console.error("Error updating WikiPage:", error);
        throw error; // Rethrow the error to propagate it to the next .catch
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
    <CookiesProvider>
      <UserContextProvider>
        <Router>
            <StyleProvider>
              <Routes>
                <Route path="/" element={<MainPage decodedToken={decodedToken} handleLogout={handleLogout} cookies={cookies} setWikiPageTitles = {setWikiPageTitles} categories={categories}/>} > 
                  <Route path="/" element={<HomeComponent pages={wikiPageTitles} categories={categories}/>} />
                  <Route path="/page/:title" element={<WikiPage page={currentWikiPage} setDecodedTitle={setDecodedTitle} cookies={cookies["jwt_token"]}/>} />
                  <Route path="/page/:title/edit" element={<EditPage page={currentWikiPage} handleEdit={handleEdit} handleCreate={handleCreate} setCurrentWikiPage={setCurrentWikiPage}/> } />
                  <Route path="/page/:title/legacyedit" element={<LegacyEditPage page={currentWikiPage} handleEdit={handleEdit} handleCreate={handleCreate} setCurrentWikiPage={setCurrentWikiPage}/> } />
                  <Route path="/legacycreate" element={<LegacyEditPage handleEdit={handleEdit} handleCreate={handleCreate} setCurrentWikiPage={setCurrentWikiPage}/>} />
                  <Route path="/create" element={<EditPage handleEdit={handleEdit} handleCreate={handleCreate} setCurrentWikiPage={setCurrentWikiPage}/>} />
                  <Route path="/edit-wiki" element={<EditStylePage cookies={cookies["jwt_token"]}></EditStylePage>}/>
                  <Route path="/login" element = {<LoginPageComponent handleLogin={handleLogin}></LoginPageComponent>}/>
                  <Route path="/register" element = {<RegisterPageComponent/>}/>
                  <Route path="/user-submissions" element = {<UserRequestsPageComponent/>}/>
                  <Route path="/user-submissions/:id" element = {<CheckUserSubmittedPage/>}/>
                  <Route path="/user-updates" element = {<UserRequestsPageComponent/>}/>
                  <Route path="/user-updates/:id" element = {<CompareUpdatePage/>}/>
                  <Route path="/profile/:username" element= {<ProfilePage loggedInUser={decodedToken?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]}/>}/>
                  <Route path="/profile/edit/:username" element={<EditProfilePage cookies={cookies["jwt_token"]}/>}/>
                  <Route path="/categories/edit" element={<EditCategoriesPage setAppCategories={setCategories} cookies={cookies["jwt_token"]}/>}/>
                  <Route path="/categories/:category" element={<CategoryPageComponent pages={wikiPageTitles} categories={categories}/>}/>
                  <Route path="/forum" element={<ForumLandingPage/>}/>
                  <Route path="/forum/:slug" element={<ForumPage/>}/>
                  <Route path="/forum/post/:slug" element={<ForumPost/>}/>
                </Route>
              </Routes>
            </StyleProvider>
        </Router>
      </UserContextProvider>
    </CookiesProvider>
  );
}

export default App;
