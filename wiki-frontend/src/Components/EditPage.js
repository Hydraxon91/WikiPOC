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
      console.log(page);
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

  const autoExpand = (e) => {
    e.target.style.height = 'auto';
    e.target.style.height = e.target.scrollHeight + 'px';
  };

  return (
    <div className="article">
      <h2>{newPage? 'Create Page' : 'Edit Page' }</h2>
      <div className='editDiv'>
        <label className="editLabel">Page Title:</label>
        <input 
          type="text" 
          value={title} 
          onChange={(e) => setTitle(e.target.value)} 
        />
      </div>
      <div>
        {paragraphs.map((paragraph, index) => (
          <div key={index}>
            <div className='editDiv'>
              <label className="editLabel">Paragraph Title:</label>
              <input
                type="text"
                value={paragraph.title}
                onChange={(e) => handleParagraphChange(index, 'title', e.target.value)}
                className='inputField'
              />
            </div>
            <div className='editDiv'>
              <label className="editLabel">Paragraph Content:</label>
              <textarea
                value={paragraph.content}
                onChange={(e) => {
                  handleParagraphChange(index, 'content', e.target.value);
                  autoExpand(e);
                }}
                className='inputField'
              />
            </div>
            <button onClick={() => handleRemoveParagraph(index)}>Remove Paragraph</button>
          </div>
        ))}
      </div>

      <button onClick={handleAddParagraph}>Add Paragraph</button>
      <br />

      <button onClick={handleSave}>Save</button>
    </div>
  );
};

export default EditPage;
