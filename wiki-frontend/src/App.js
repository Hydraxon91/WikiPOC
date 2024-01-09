import React, {useState} from "react";
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
    <div>
      <WikiList pages={wikiPages} onDelete={handleDelete} onPageClick={handlePageClick} />
      <CreatePage onSubmit={handleCreate} />
      {wikiPages.map((page) => (
        <EditPage key={page.id} page={page} onSave={handleEdit} />
      ))}
      {selectedPage && <WikiPage page={selectedPage}></WikiPage>}
    </div>
  );
}

export default App;
