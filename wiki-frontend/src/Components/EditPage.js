import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';

const EditPage = ({ pages, onSave, onSubmit }) => {
  const navigate = useNavigate();
  const { id } = useParams();
  const page = pages.find((p) => p.id.toString() === id);
  const [title, setTitle] = useState('');
  const [content, setContent] = useState('');
  const [newPage, setNewPage] = useState(true);

  useEffect(() => {
    setTitle(page.title);
    setContent(page.content);
    setNewPage(false);
  }, [page]);

  const handleSave = () => {
    newPage ?  onSubmit({ title, content }) : onSave({ ...page, title, content });
    navigate('/');
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
