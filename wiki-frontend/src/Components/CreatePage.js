import React, { useState } from 'react';

const CreatePage = ({ onSubmit }) => {
  const [title, setTitle] = useState('');
  const [content, setContent] = useState('');

  const handleSubmit = () => {
    onSubmit({ title, content });
    setTitle('');
    setContent('');
  };

  return (
    <div>
      <h2>Create Page</h2>
      <label>Title:</label>
      <input type="text" value={title} onChange={(e) => setTitle(e.target.value)} />
      <br />
      <label>Content:</label>
      <textarea value={content} onChange={(e) => setContent(e.target.value)} />
      <br />
      <button onClick={handleSubmit}>Create</button>
    </div>
  );
};

export default CreatePage;
