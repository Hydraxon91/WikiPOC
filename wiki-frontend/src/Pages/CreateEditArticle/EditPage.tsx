import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import ArticleEditor from './Components/ArticleEditor';
import WikiPageComponent from '../WikiPage-Article/Components/WikiPageComponent';
import LegacyEditPage from './LegacyEditPage';
import LegacyWikiPageComponent from '../WikiPage-Article/Components/LegacyWikiPageComponent';
import LegacyEditPageComponent from './Components/LegacyEditPageComponent';
import { useNotification } from '../../Components/NotificationProvider';
import './Style/articleeditor.css';

const EditPage = ({ page, handleEdit, handleCreate }: { page?: any; handleEdit?: any; handleCreate?: any }) => {
  const navigate = useNavigate();
  const [temporaryPage, setTemporaryPage] = useState(null);
  const [title, setTitle] = useState('');
  const [siteSub, setSiteSub] = useState('');
  const [roleNote, setRoleNote] = useState('');
  const [category, setCategory] = useState('');
  const [newPage, setNewPage] = useState(true);
  const [paragraphs, setParagraphs] = useState([]);
  const [emptyFields, setEmptyFields] = useState([]);
  const [content, setContent] = useState('');
  const [images, setImages] = useState([]);
  const [usedImages, setUsedImages] = useState([]);
  const [legacyPage, setLegacyPage] = useState(false);
  const { showNotification } = useNotification();

  useEffect(() => {
    if (page) {
      const pageData = page.wikiPage || page.userSubmittedWikiPage;
      if (!pageData) return;

      setTemporaryPage(pageData);
      setTitle(pageData.title || '');
      setRoleNote(pageData.roleNote || '');
      setSiteSub(pageData.siteSub || '');
      if (pageData.content) setContent(pageData.content);
      setCategory(pageData.categoryId || '');
      if (pageData.paragraphs) setParagraphs([...pageData.paragraphs]);
      const renamedImages = page.images ? page.images.map(image => ({ ...image, name: image.fileName })) : [];
      setImages(renamedImages);
      setUsedImages(renamedImages);
      setLegacyPage(pageData.legacyWikiPage);
      setNewPage(false);
    }
    else{
      setTemporaryPage(null);
      setTitle("");
      setRoleNote("");
      setSiteSub("");
      setContent("")
      setParagraphs([]);
      setNewPage(true);
      const renamedImages =[];
      setImages(renamedImages);
      setUsedImages(renamedImages);
    }
  }, [page]);



  const handleContentChange = (value) => {
    // setContent(value);
    const hrefValues = extractHrefValues(value);
    handleFieldChange('content', value);
    const usedImagesArray = images && images.filter(image => hrefValues.some(href => href.includes(image.name)));
    setUsedImages(usedImagesArray); 
    updateTemporaryPage('content', value);
};


  const extractHrefValues = (inputString) => {
    const regex = /href="([^"]*\.(?:jpg|png|gif))"/g;
    const hrefValues = [];
    let match;
    
    while ((match = regex.exec(inputString)) !== null) {
        hrefValues.push(match[1]);
    }
    
    return hrefValues;
};

  const handleFieldChange = (field, value) => {
    // Update state based on the field parameter
    switch (field) {
      case 'title':
        setTitle(value);
        break;
      case 'siteSub':
        setSiteSub(value);
        break;
      case 'roleNote':
        setRoleNote(value);
        break;
      case 'category':
        setCategory(value);
        break;
      case 'content':
        setContent(value);
        break;
      default:
        break;
    }
  
    // Update temporary page with the latest values
    updateTemporaryPage(field, value);
  };
  
  const updateTemporaryPage = (field, value) => {
    setTemporaryPage(prevState => ({
      ...prevState,
      [field]: value,
    }));
  };


  const handleSave = () =>{
    if ( !title) {
      showNotification('Please make sure to have a title.');
      return;
    }

    const savePromise = newPage
      ? handleCreate(temporaryPage, usedImages)
      : 
      handleEdit(temporaryPage, usedImages);
      // : handleEdit(temporaryPage, usedImages);

    savePromise
      .then((data) => {
        // setCurrentWikiPage(temporaryPage);
        showNotification('Successfully submitted page!')
        navigate(`/`);
      })
      .catch((error) => {
        console.error("Error during save:", error);
      });
  }

  return (
    <>
    {!legacyPage && (
      <div className='editor-container'>
        <div className='articleeditor-container'>
          <ArticleEditor 
            title={title} siteSub={siteSub} 
            roleNote={roleNote} content={content}
            handleContentChange={handleContentChange} handleFieldChange={handleFieldChange} handleSave={handleSave}
            images={images} setImages={setImages} category={category}
          />
        </div>
        <div className='preview-container'>
          <WikiPageComponent page={temporaryPage} activeTab={"wiki"} images={images} setDecodedTitle={undefined}/>
        </div>
      </div>
    )}

    {legacyPage && (
      <LegacyEditPage page={temporaryPage} handleEdit={handleEdit} handleCreate={handleCreate}
        handleContentChange={handleContentChange} handleFieldChange={handleFieldChange} handleSave={handleSave}
        category={category} setCategory={setCategory}
      ></LegacyEditPage>
    )}
  </>
  );
};

export default EditPage;
