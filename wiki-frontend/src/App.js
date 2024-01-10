import React, {useState} from "react";
import { BrowserRouter as Router, Route, Switch, Routes } from 'react-router-dom';
import EditPage from "./Components/EditPage";
import WikiPage from "./Pages/WikiPage.js";
import MainPage from "./Pages/MainPage.js";
import HomeComponent from "./Components/HomeComponent.js";
import EditWikiComponent from "./Components/EditWikiComponent.js";

function App() {
  const [wikiPages, setWikiPages] = useState([
    {
      id: 1,
      title: 'Page 1',
      siteSub: 'SiteSub1',
      roleNote: 'RoleNote1',
      paragraphs: [
        { 
          title: 'Paragraph 1', 
          content: 'Content for Paragraph 1', 
          paragraphImage:'https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg',
          paragraphImageText: 'This is a test image'
        },
        { title: 'Paragraph 2', content: 'Content for Paragraph 2', paragraphImage: '', paragraphImageTest: '' },
      ],
    },
    {
      id: 2,
      title: 'Page 2',
      siteSub: 'SiteSub1',
      roleNote: 'RoleNote2',
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
          <Route path="/" element={<MainPage pages={wikiPages}/>} > 
            <Route path="/" element={<HomeComponent pages={wikiPages} />} />
            <Route path="/page/:title" element={<WikiPage pages={wikiPages} />} />
            <Route path="/edit/:id" element={<EditPage pages={wikiPages} onSave={handleEdit} onSubmit={handleCreate} />} />
            <Route path="/create" element={<EditPage pages={wikiPages} onSave={handleEdit} onSubmit={handleCreate}/>} />
            <Route path="/edit-wiki" element={<EditWikiComponent></EditWikiComponent>}></Route>
          </Route>
          
        </Routes>
      </div>
    </Router>
    
  );
}

export default App;
