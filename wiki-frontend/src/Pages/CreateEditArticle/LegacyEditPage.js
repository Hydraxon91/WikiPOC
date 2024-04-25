import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import EditPageComponent from './Components/LegacyEditPageComponent';
import WikiPageComponent from '../WikiPage-Article/Components/LegacyWikiPageComponent';


const LegacyEditPage = ({ page, handleEdit, handleCreate }) => {
  const navigate = useNavigate();

  const [temporaryPage, setTemporaryPage] = useState(null);
  const [title, setTitle] = useState('');
  const [siteSub, setSiteSub] = useState('');
  const [roleNote, setRoleNote] = useState('');
  const [category, setCategory] = useState('');
  const [newPage, setNewPage] = useState(true);
  const [paragraphs, setParagraphs] = useState([]);
  const [emptyFields, setEmptyFields] = useState([]);

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


  const handleAddParagraph = () => {
    const updatedParagraphs = [
      ...paragraphs,
      {
        title: '',
        content: '',
        siteSub: '',
        roleNote: '',
        paragraphImage: '',
        paragraphImageText: ''
      }
    ];
    handleFieldChange('paragraphs', updatedParagraphs);
    // updateTemporaryPage(title, siteSub, roleNote, updatedParagraphs);
  };

  const handleRemoveParagraph = (index) => {
    const updatedParagraphs = [...paragraphs];
    updatedParagraphs.splice(index, 1);
    handleFieldChange('paragraphs', updatedParagraphs);
    // updateTemporaryPage(title, siteSub, roleNote, updatedParagraphs);
  };

  const handleParagraphChange = (index, field, value) => {
    const updatedParagraphs = [...paragraphs];
    updatedParagraphs[index][field] = value;
    handleFieldChange('paragraphs', updatedParagraphs);
    // updateTemporaryPage(title, siteSub, roleNote, updatedParagraphs);
  };

  // const handleFieldChange = (field, value) => {
  //   switch (field) {
  //     case 'title':
  //       setTitle(value);
  //       break;
  //     case 'siteSub':
  //       setSiteSub(value);
  //       break;
  //     case 'roleNote':
  //       setRoleNote(value);
  //       break;
  //     default:
  //       break;
  //   }
  
  //   // Update temporary page with the latest values
  //   updateTemporaryPage(title, siteSub, roleNote, paragraphs);
  // };

  // const updateTemporaryPage = (title, siteSub, roleNote, paragraphs) => {
  //   setTemporaryPage({
  //     title,
  //     siteSub,
  //     roleNote,
  //     paragraphs,
  //   });
  // };
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
      case 'paragraphs':
        setParagraphs(value);
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
    temporaryPage.LegacyWikiPage = true;
  
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
      <EditPageComponent newPage={newPage} title={title} handleFieldChange={handleFieldChange} siteSub={siteSub} roleNote={roleNote} paragraphs={paragraphs} emptyFields={emptyFields} handleParagraphChange={handleParagraphChange} handleRemoveParagraph={handleRemoveParagraph} handleAddParagraph={handleAddParagraph} handleSave={handleSave} />
      <WikiPageComponent page={temporaryPage} activeTab={"wiki"}/>
    </div>
  );
};

export default LegacyEditPage;
