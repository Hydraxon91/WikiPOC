import React, {useState} from "react";
import { BrowserRouter as Router, Route, Switch, Routes } from 'react-router-dom';
import WikiList from "./Components/WikiList";
import CreatePage from "./Components/CreatePage.js";
import EditPage from "./Components/EditPage";
import WikiPage from "./Pages/WikiPage.js";

function App() {
  const [wikiPages, setWikiPages] = useState([
    { id: 1, title: 'Page 1', content: 'Content for Page 1' },
    { id: 2, title: 'Page 2', content: 'Content for Page 2' },
  ]);

  const [selectedPage, setSelectedPage] = useState(null);

  const handleCreate = (newPage) => {
    setWikiPages([...wikiPages, { id: wikiPages.length + 1, ...newPage }]);
  };

  const handleDelete = (id) => {
    setWikiPages(wikiPages.filter((page) => page.id !== id));
  };

  const handleEdit = (updatedPage) => {
    setWikiPages(
      wikiPages.map((page) => (page.id === updatedPage.id ? { ...page, ...updatedPage } : page))
    );
  };

  const handlePageClick = (page) => {
    setSelectedPage(page);
  };

  return (
    <Router>
      <div>
        <Routes>
          <Route path="/" element={<WikiList pages={wikiPages} onDelete={handleDelete} onPageClick={handlePageClick} />} />
          <Route path="/create" element={<CreatePage onSubmit={handleCreate} />} />
          <Route path="/edit/:id" element={<EditPage pages={wikiPages} onSave={handleEdit} />} />
          <Route path="/page/:id" element={<WikiPage pages={wikiPages} page={selectedPage} />} />
        </Routes>
      </div>
    </Router>
    
  );
}

export default App;
