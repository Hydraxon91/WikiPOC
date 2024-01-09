import React, { useState, useEffect } from 'react';

const EditPage = ({ page, onSave }) => {
  const [title, setTitle] = useState('');
  const [content, setContent] = useState('');

  useEffect(() => {
    setTitle(page.title);
    setContent(page.content);
  }, [page]);

  const handleSave = () => {
    onSave({ ...page, title, content });
  };

  return (
    <div>
      <h2>Edit Page</h2>
      <label>Title:</label>
      <input type="text" value={title} onChange={(e) => setTitle(e.target.value)} />
      <br />
      <label>Content:</label>
      <textarea value={content} onChange={(e) => setContent(e.target.value)} />
      <br />
      <button onClick={handleSave}>Save</button>
    </div>
  );
};

export default EditPage;
