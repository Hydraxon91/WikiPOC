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
import RegisterPageComponent from "./Components/RegisterPageComponent.jsx";

function App() {

  const [wikiPageTitles, setWikiPageTitles] = useState([]);
  const [currentWikiPage, setCurrentWikiPage] = useState(null);

  const [decodedTitle, setDecodedTitle] = useState(null);

  const [cookies, setCookie] = useCookies(["jwt_token"]);

  useEffect(() => {
    // Fetch WikiPages when the component mounts
    fetchWikiPageTitles();
  }, []);

  useEffect(() => {
    fetchWikiPageTitles();
  }, [currentWikiPage]);

  const fetchPage = async () => {
    try {
      const data = await getWikiPageByTitle(decodedTitle);
      setCurrentWikiPage(data);
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
    return createWikiPage(newPage, cookies["jwt_token"])
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
    return updateWikiPage(updatedPage.id, updatedPage, cookies["jwt_token"])
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
    setCookie("jwt_token", user, { path: "/", expires: expirationDate})
  }

  return (
    <CookiesProvider>
      <Router>
          <StyleProvider>
            <Routes>
              <Route path="/" element={<MainPage pages={wikiPageTitles} cookies={cookies}/>} > 
                <Route path="/" element={<HomeComponent pages={wikiPageTitles} />} />
                <Route path="/page/:title" element={<WikiPageComponent page={currentWikiPage} setDecodedTitle={setDecodedTitle}/>} />
                <Route path="/page/:title/edit" element={<EditPage page={currentWikiPage} handleEdit={handleEdit} handleCreate={handleCreate} setCurrentWikiPage={setCurrentWikiPage}/> } />
                <Route path="/create" element={<EditPage handleEdit={handleEdit} handleCreate={handleCreate} setCurrentWikiPage={setCurrentWikiPage}/>} />
                <Route path="/edit-wiki" element={<EditWikiComponent></EditWikiComponent>}/>
                <Route path="/login" element = {<LoginPageComponent handleLogin={handleLogin}></LoginPageComponent>}/>
                <Route path="/register" element = {<RegisterPageComponent/>}/>
              </Route>
              
            </Routes>
          </StyleProvider>
      </Router>
    </CookiesProvider>
  );
}

export default App;
