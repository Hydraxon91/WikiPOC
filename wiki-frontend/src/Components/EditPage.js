import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';

const EditPage = ({ pages, onSave, onSubmit }) => {
  const navigate = useNavigate();
  const { id } = useParams();
  const page = id ? pages.find((p) => p.id.toString() === id) : null;

  const [title, setTitle] = useState('');
  const [newPage, setNewPage] = useState(true);
  const [paragraphs, setParagraphs] = useState([]);

  useEffect(() => {
    if (page) {
      setTitle(page.title);
      setParagraphs([...page.paragraphs]);
      setNewPage(false);
    }
  }, [page]);

  const handleAddParagraph = () => {
    setParagraphs([...paragraphs, { title: '', content: '' }]);
  };

  const handleRemoveParagraph = (index) => {
    const updatedParagraphs = [...paragraphs];
    updatedParagraphs.splice(index, 1);
    setParagraphs(updatedParagraphs);
  };

  const handleParagraphChange = (index, field, value) => {
    const updatedParagraphs = [...paragraphs];
    updatedParagraphs[index][field] = value;
    setParagraphs(updatedParagraphs);
  };

  const handleSave = () => {
    newPage ?  onSubmit({ title, paragraphs }) : onSave({ ...page, title, paragraphs });
    navigate('/');
  };

  return (
    <div>
      <h2>{newPage? 'Create Page' : 'Edit Page' }</h2>
      <label>Page Title:</label>
      <input type="text" value={title} onChange={(e) => setTitle(e.target.value)} />
      <br />
      <div>
        {paragraphs.map((paragraph, index) => (
          <div key={index}>
            <label>Paragraph Title:</label>
            <input
              type="text"
              value={paragraph.title}
              onChange={(e) => handleParagraphChange(index, 'title', e.target.value)}
            />
            <br />
            <label>Paragraph Content:</label>
            <textarea
              value={paragraph.content}
              onChange={(e) => handleParagraphChange(index, 'content', e.target.value)}
            />
            <br />
            <button onClick={() => handleRemoveParagraph(index)}>Remove Paragraph</button>
          </div>
        ))}
      </div>
      <br />
      <button onClick={handleAddParagraph}>Add Paragraph</button>
      <br />
      <button onClick={handleSave}>Save</button>
    </div>
  );
};

export default EditPage;
