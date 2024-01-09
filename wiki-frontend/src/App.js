import React, {useState} from "react";
import { BrowserRouter as Router, Route, Switch, Routes } from 'react-router-dom';
import WikiList from "./Components/WikiList";
import EditPage from "./Components/EditPage";
import WikiPage from "./Pages/WikiPage.js";

function App() {
  const [wikiPages, setWikiPages] = useState([
    {
      id: 1,
      title: 'Page 1',
      paragraphs: [
        { title: 'Paragraph 1', content: 'Content for Paragraph 1' },
        { title: 'Paragraph 2', content: 'Content for Paragraph 2' },
      ],
    },
    {
      id: 2,
      title: 'Page 2',
      paragraphs: [
        { title: 'Intro', content: 'Introduction to Page 2' },
        { title: 'Conclusion', content: 'Conclusion for Page 2' },
      ],
    },
  ]);


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



  return (
    <Router>
      <div>
        <Routes>
          <Route path="/" element={<WikiList pages={wikiPages} onDelete={handleDelete}/>} />
          <Route path="/create" element={<EditPage pages={wikiPages} onSave={handleEdit} onSubmit={handleCreate}/>} />
          <Route path="/edit/:id" element={<EditPage pages={wikiPages} onSave={handleEdit} onSubmit={handleCreate} />} />
          <Route path="/page/:title" element={<WikiPage pages={wikiPages} />} />
        </Routes>
      </div>
    </Router>
    
  );
}

export default App;
