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

function App() {

  const [wikiPageTitles, setWikiPageTitles] = useState([]);
  const [currentWikiPage, setCurrentWikiPage] = useState(null);

  const [decodedTitle, setDecodedTitle] = useState(null);

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


  const handleCreate = async (newPage) => {
    try {
      const createdPage = await createWikiPage(newPage);
      setWikiPageTitles([...wikiPageTitles, createdPage.Title]);
    } catch (error) {
      console.error("Error creating WikiPage:", error);
    }
  };

  const handleDelete = async (id) => {
    try {
      await deleteWikiPage(id);
      setWikiPageTitles(wikiPageTitles.filter((page) => page !== currentWikiPage.Title));
    } catch (error) {
      console.error("Error deleting WikiPage:", error);
    }
  };

  const handleEdit = async (updatedPage, id) => {
    try {
      const updatedWikiPage = await updateWikiPage(updatedPage.id, updatedPage);
      setWikiPageTitles((prevPages) =>
        prevPages.map((page) => (page=== updatedWikiPage.Title ? updatedWikiPage.Title : page))
      );
    } catch (error) {
      console.error("Error updating WikiPage:", error);
    }
  };

  return (
    <Router>
        <StyleProvider>
          <Routes>
            <Route path="/" element={<MainPage pages={wikiPageTitles}/>} > 
              <Route path="/" element={<HomeComponent pages={wikiPageTitles} />} />
              <Route path="/page/:title" element={<WikiPageComponent page={currentWikiPage} setDecodedTitle={setDecodedTitle}/>} />
              <Route path="/page/:title/edit" element={<EditPage page={currentWikiPage} onSave={handleEdit} onSubmit={handleCreate} setCurrentWikiPage={setCurrentWikiPage}/> } />
              <Route path="/create" element={<EditPage onSave={handleEdit} onSubmit={handleCreate} setCurrentWikiPage={setCurrentWikiPage}/>} />
              <Route path="/edit-wiki" element={<EditWikiComponent></EditWikiComponent>}></Route>
            </Route>
            
          </Routes>
        </StyleProvider>
    </Router>
    
  );
}

export default App;
