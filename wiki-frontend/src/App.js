import React, {useState, useEffect} from "react";
import 'bootstrap/dist/css/bootstrap.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import EditPage from "./Components/EditPage";
import WikiPageComponent from "./Components/WikiPageComponent.js";
import MainPage from "./Pages/MainPage.js";
import HomeComponent from "./Components/HomeComponent.js";
import EditWikiComponent from "./Components/EditWikiComponent.js";
import { StyleProvider  } from "./Components/contexts/StyleContext.js";
import { getWikiPageTitles, createWikiPage, deleteWikiPage, updateWikiPage } from "./Api/wikiApi.js";

function App() {

  const [wikiPageTitles, setWikiPageTitles] = useState([]);
  const [currentWikiPage, setCurrentWikiPage] = useState(null);

  useEffect(() => {
    // Fetch WikiPages when the component mounts
    fetchWikiPageTitles();
  }, []);
  // useEffect(() => {
  //   console.log(currentWikiPage);
  // }, [currentWikiPage]);

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

  const handleEdit = async (updatedPage) => {
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
              <Route path="/page/:title" element={<WikiPageComponent setCurrentWikiPage={setCurrentWikiPage} page={currentWikiPage}/>} />
              <Route path="/page/:title/edit" element={<EditPage page={currentWikiPage} onSave={handleEdit} onSubmit={handleCreate}/>} />
              <Route path="/create" element={<EditPage onSave={handleEdit} onSubmit={handleCreate}/>} />
              <Route path="/edit-wiki" element={<EditWikiComponent></EditWikiComponent>}></Route>
            </Route>
            
          </Routes>
        </StyleProvider>
    </Router>
    
  );
}

export default App;
