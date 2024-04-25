import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import ArticleEditor from './Components/ArticleEditor';
import WikiPageComponent from '../WikiPage-Article/Components/WikiPageComponent';

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
    if (page) {
      setTemporaryPage(page);
      setTitle(page.title);
      setRoleNote(page.roleNote);
      setSiteSub(page.siteSub);
      setContent(page.content);
      setCategory(page.category);
      setParagraphs([...page.paragraphs]);
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
    }
  }, [page]);

  const handleContentChange = (value) => {
    // setContent(value);
    handleFieldChange('content', value);
    const usedImagesArray = images.filter(image => value.includes(image.name));
    setUsedImages(usedImagesArray);
    updateTemporaryPage(title, siteSub, roleNote, value);
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

  // const handleSave = () => {
  //   const requiredFields = ['title', 'content'];
  //   const emptyFields = paragraphs.reduce((emptyFields, paragraph, index) => {
  //     const missingFields = requiredFields.filter((field) => !paragraph[field]);
  //     if (missingFields.length > 0) {
  //       emptyFields.push(index);
  //     }
  //     return emptyFields;
  //   }, []);
  
  //   if (emptyFields.length > 0 || !title) {
  //     setEmptyFields(emptyFields);
  //     alert('Please make sure to have a title for all paragraphs content.');
  //     return;
  //   }
  
  //   setEmptyFields([]);
  
  //   const savePromise = newPage
  //     ? handleCreate(temporaryPage)
  //     : handleEdit({ ...page, title, paragraphs, siteSub, roleNote });

  //   console.log(savePromise);

  //   savePromise
  //     .then((data) => {
  //       // console.log(data);
  //       // setCurrentWikiPage(temporaryPage);
  //       navigate(`/page/${title}`);
  //     })
  //     .catch((error) => {
  //       console.error("Error during save:", error);
  //       // Use toast.error to display an error message
  //       toast.error('An error occurred while saving. Please try again.');
  //     });
  // };

  const handleSave = () =>{
    console.log(images);
    console.log(usedImages);
  }

  return (
    <div style={{display: 'flex'}}>
        <ArticleEditor 
        newPage={newPage} title={title} siteSub={siteSub} 
        roleNote={roleNote} content={content} emptyFields={emptyFields} 
        handleContentChange={handleContentChange} handleFieldChange={handleFieldChange} handleSave={handleSave}
        images={images} setImages={setImages}
        />
        <WikiPageComponent page={temporaryPage} activeTab={"wiki"} images={images}/>
    </div>
  );
};

export default EditPage;
