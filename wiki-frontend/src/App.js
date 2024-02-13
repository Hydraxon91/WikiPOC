import React, {useState, useEffect} from "react";
import 'bootstrap/dist/css/bootstrap.css';
import { BrowserRouter as Router, Route, Routes, useParams } from 'react-router-dom';
import EditPage from "./Components/EditPage";
import WikiPageComponent from "./Components/WikiPageComponent.js";
import MainPage from "./Pages/MainPage.js";
import HomeComponent from "./Components/HomeComponent.js";
import EditWikiComponent from "./Components/EditWikiComponent.js";
import { StyleProvider  } from "./Components/contexts/StyleContext.js";
import { getWikiPageTitles, createWikiPage, deleteWikiPage, updateWikiPage, getWikiPageByTitle } from "./Api/wikiApi.js";
import LoginPageComponent from "./Components/LoginPageComponent.js";
import { CookiesProvider, useCookies } from "react-cookie";
import { jwtDecode } from 'jwt-decode';
import { UserContextProvider } from "./Components/contexts/UserContextProvider.js";
import RegisterPageComponent from "./Components/RegisterPageComponent.jsx";
import UserRequestsPageComponent from "./Components/UserRequestsPageComponent.js";
import CompareUpdatePage from "./Components/CompareUpdatePage.js";

function App() {

  const [wikiPageTitles, setWikiPageTitles] = useState([]);
  const [currentWikiPage, setCurrentWikiPage] = useState(null);

  const [decodedTitle, setDecodedTitle] = useState(null);

  const [cookies, setCookie, removeCookie] = useCookies(["jwt_token"]);
  const [decodedToken, setDecodedToken] = useState(null);

  useEffect(() => {
    if (cookies["jwt_token"]) {
      setDecodedToken(jwtDecode(cookies["jwt_token"]));
    }
    
    // Fetch WikiPages when the component mounts
    fetchWikiPageTitles();
  }, [cookies["jwt_token"]]); // Trigger the effect when the token changes

  // useEffect(() => {
  //   // Fetch WikiPages when the component mounts
  //   fetchWikiPageTitles();
  // }, []);

  useEffect(() => {
    fetchWikiPageTitles();
    // console.log(currentWikiPage.id);
  }, [currentWikiPage]);

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

  const fetchWikiPageTitles = async () => {
    try {
      const pages = await getWikiPageTitles();
      setWikiPageTitles(pages);
    } catch (error) {
      console.error("Error fetching WikiPages:", error);
    }
  };


  const handleCreate = (newPage) => {
    console.log('Inside handleCreate');
    return createWikiPage(newPage, cookies["jwt_token"], decodedToken)
      .then((createdPage) => {
        console.log('createWikiPage resolved:', createdPage);
        setWikiPageTitles([...wikiPageTitles, createdPage.Title]);
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
        setWikiPageTitles(wikiPageTitles.filter((page) => page !== currentWikiPage.Title));
      })
      .catch((error) => {
        console.error("Error deleting WikiPage:", error);
      });
  };
  
  const handleEdit = (updatedPage) => {
    // console.log('Inside handleEdit');
    // console.log(updatedPage);
    return updateWikiPage(updatedPage, cookies["jwt_token"], decodedToken)
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
                <Route path="/" element={<MainPage pages={wikiPageTitles} decodedToken={decodedToken} handleLogout={handleLogout} cookies={cookies}/>} > 
                  <Route path="/" element={<HomeComponent pages={wikiPageTitles} />} />
                  <Route path="/page/:title" element={<WikiPageComponent page={currentWikiPage} setDecodedTitle={setDecodedTitle}/>} />
                  <Route path="/page/:title/edit" element={<EditPage page={currentWikiPage} handleEdit={handleEdit} handleCreate={handleCreate} setCurrentWikiPage={setCurrentWikiPage}/> } />
                  <Route path="/create" element={<EditPage handleEdit={handleEdit} handleCreate={handleCreate} setCurrentWikiPage={setCurrentWikiPage}/>} />
                  <Route path="/edit-wiki" element={<EditWikiComponent></EditWikiComponent>}/>
                  <Route path="/login" element = {<LoginPageComponent handleLogin={handleLogin}></LoginPageComponent>}/>
                  <Route path="/register" element = {<RegisterPageComponent/>}/>
                  <Route path="/user-submissions" element = {<UserRequestsPageComponent></UserRequestsPageComponent>}/>
                  <Route path="/user-updates" element = {<UserRequestsPageComponent></UserRequestsPageComponent>}/>
                  <Route path="/user-updates/:id" element = {<CompareUpdatePage></CompareUpdatePage>}/>
                </Route>
              </Routes>
            </StyleProvider>
        </Router>
      </UserContextProvider>
    </CookiesProvider>
  );
}

export default App;
