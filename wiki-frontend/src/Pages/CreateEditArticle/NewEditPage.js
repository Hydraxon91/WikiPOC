import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import EditPageComponent from './Components/EditPageComponent';
import ArticleEditor from './Components/ArticleEditor';
import TestWikiPageComponent from './Components/TestWikiPageComponent';
import WikiPageComponent from '../WikiPage-Article/Components/WikiPageComponent';

const NewEditPage = ({ page, handleEdit, handleCreate }) => {
  const navigate = useNavigate();

  const [temporaryPage, setTemporaryPage] = useState(null);
  const [title, setTitle] = useState('');
  const [siteSub, setSiteSub] = useState('');
  const [roleNote, setRoleNote] = useState('');
  const [newPage, setNewPage] = useState(true);
  const [paragraphs, setParagraphs] = useState([]);
  const [emptyFields, setEmptyFields] = useState([]);
  const [content, setContent] = useState('');

  useEffect(() => {
    if (page) {
      setTemporaryPage(page);
      setTitle(page.title);
      setRoleNote(page.roleNote);
      setSiteSub(page.siteSub);
      setParagraphs([...page.paragraphs]);
      setNewPage(false);
    }
    else{
      setTemporaryPage(null);
      setTitle("");
      setRoleNote("");
      setSiteSub("");
      setParagraphs([]);
      setNewPage(true);
    }
  }, [page]);

  const handleContentChange = (value) => {
    const updatedContent = value;
    setContent(updatedContent);
    updateTemporaryPage(title, siteSub, roleNote, updatedContent);
  };

  const handleFieldChange = (field, value) => {
    switch (field) {
      case 'title':
        setTitle(value);
        updateTemporaryPage(value, siteSub, roleNote, content);
        break;
      case 'siteSub':
        setSiteSub(value);
        updateTemporaryPage(title, value, roleNote, content);
        break;
      case 'roleNote':
        setRoleNote(value);
        updateTemporaryPage(title, siteSub, value, content);
        break;
      default:
        break;
    }
  
    // Update temporary page with the latest values
    updateTemporaryPage(title, siteSub, roleNote, paragraphs);
  };

  const updateTemporaryPage = (title, siteSub, roleNote, content) => {
    setTemporaryPage({
      title,
      siteSub,
      roleNote,
      content,
    });
  };

  const handleSave = () => {
    const requiredFields = ['title', 'content'];
  
    const emptyFields = paragraphs.reduce((emptyFields, paragraph, index) => {
      const missingFields = requiredFields.filter((field) => !paragraph[field]);
      if (missingFields.length > 0) {
        emptyFields.push(index);
      }
      return emptyFields;
    }, []);
  
    if (emptyFields.length > 0 || !title) {
      setEmptyFields(emptyFields);
      alert('Please make sure to have a title for all paragraphs content.');
      return;
    }
  
    setEmptyFields([]);
  
    const savePromise = newPage
      ? handleCreate(temporaryPage)
      : handleEdit({ ...page, title, paragraphs, siteSub, roleNote });

    console.log(savePromise);

    savePromise
      .then((data) => {
        // console.log(data);
        // setCurrentWikiPage(temporaryPage);
        navigate(`/page/${title}`);
      })
      .catch((error) => {
        console.error("Error during save:", error);
        // Use toast.error to display an error message
        toast.error('An error occurred while saving. Please try again.');
      });
  };

  return (
    <div style={{display: 'flex'}}>
        <ArticleEditor newPage={newPage} title={title} siteSub={siteSub} roleNote={roleNote} content={content} emptyFields={emptyFields} handleContentChange={handleContentChange} handleFieldChange={handleFieldChange} handleSave={handleSave}/>
      {/* <EditPageComponent newPage={newPage} title={title} handleFieldChange={handleFieldChange} siteSub={siteSub} roleNote={roleNote} paragraphs={paragraphs} emptyFields={emptyFields} handleParagraphChange={handleParagraphChange} handleRemoveParagraph={handleRemoveParagraph} handleAddParagraph={handleAddParagraph} handleSave={handleSave} /> */}
        <TestWikiPageComponent page={temporaryPage} activeTab={"wiki"}/>
    </div>
  );
};

export default NewEditPage;
