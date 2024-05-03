import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import ArticleEditor from './Components/ArticleEditor';
import WikiPageComponent from '../WikiPage-Article/Components/WikiPageComponent';
import './Style/articleeditor.css';

const EditPage = ({ page, handleEdit, handleCreate }) => {
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

  useEffect(() => {
    console.log(page);
    if (page) {
      setTemporaryPage(page.wikiPage || page.userSubmittedWikiPage);
      setTitle(page.wikiPage.title || page.userSubmittedWikiPage.title);
      setRoleNote(page.wikiPage.roleNote || page.userSubmittedWikiPage.roleNote);
      setSiteSub(page.wikiPage.siteSub || page.userSubmittedWikiPage.siteSub);
      setContent(page.wikiPage.content || page.userSubmittedWikiPage.content);
      setCategory(page.wikiPage.categoryId || page.userSubmittedWikiPage.categoryId);
      page.wikiPage.paragraphs && setParagraphs([...page.wikiPage.paragraphs]);
      const renamedImages = page.images ? page.images.map(image => ({ ...image, name: image.fileName })) : [];
      console.log("asdasd");
      setImages(renamedImages);
      setUsedImages(renamedImages);
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
      const renamedImages = page.images ? page.images.map(image => ({ ...image, name: image.fileName })) : [];
      setImages(renamedImages);
      setUsedImages(renamedImages);
    }
  }, [page]);

  // useEffect(()=>{
  //   console.log("images");
  //   console.log(images);
  //   console.log("used images");
  //   console.log(usedImages);
  // },[usedImages])

  const handleContentChange = (value) => {
    // setContent(value);
    // console.log(images);
    const hrefValues = extractHrefValues(value);
    // console.log(hrefValues);
    handleFieldChange('content', value);
    const usedImagesArray = images && images.filter(image => hrefValues.some(href => href.includes(image.name)));
    // console.log(usedImagesArray);
    setUsedImages(usedImagesArray); 
    updateTemporaryPage(title, siteSub, roleNote, value);
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
      alert('Please make sure to have a title.');
      return;
    }

    const savePromise = newPage
      ? handleCreate(temporaryPage, usedImages)
      : 
      handleEdit(temporaryPage, usedImages);
      // : handleEdit(temporaryPage, usedImages);
    console.log(savePromise);

    savePromise
      .then((data) => {
        // console.log(data);
        // setCurrentWikiPage(temporaryPage);
        alert('Successfully submitted page!')
        navigate(`/`);
      })
      .catch((error) => {
        console.error("Error during save:", error);
      });
  }

  return (
    <div className='editor-container'>
      <div className='articleeditor-container'>
          <ArticleEditor 
              newPage={newPage} title={title} siteSub={siteSub} 
              roleNote={roleNote} content={content} emptyFields={emptyFields} 
              handleContentChange={handleContentChange} handleFieldChange={handleFieldChange} handleSave={handleSave}
              images={images} setImages={setImages} category={category}
          />
      </div>
      <div className='preview-container'>
          <WikiPageComponent page={temporaryPage} activeTab={"wiki"} images={images}/>
      </div>
  </div>
  );
};

export default EditPage;
