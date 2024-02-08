import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useStyleContext } from './contexts/StyleContext';
import { toast } from 'react-toastify';
import WikiPageComponent from './WikiPageComponent';
import ReactQuillComponent from './ReactQuillComponent';
import { useUserContext } from './contexts/UserContextProvider';

const EditPage = ({ page, handleEdit, handleCreate, setCurrentWikiPage }) => {
  const navigate = useNavigate();

  const [temporaryPage, setTemporaryPage] = useState(null);
  const [title, setTitle] = useState('');
  const [siteSub, setSiteSub] = useState('');
  const [roleNote, setRoleNote] = useState('');
  const [newPage, setNewPage] = useState(true);
  const [paragraphs, setParagraphs] = useState([]);
  const [emptyFields, setEmptyFields] = useState([]);

  const {decodedTokenContext} = useUserContext();

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
    setParagraphs(updatedParagraphs);
    updateTemporaryPage(title, siteSub, roleNote, updatedParagraphs);
  };

  const handleRemoveParagraph = (index) => {
    const updatedParagraphs = [...paragraphs];
    updatedParagraphs.splice(index, 1);
    setParagraphs(updatedParagraphs);
    updateTemporaryPage(title, siteSub, roleNote, updatedParagraphs);
  };

  const handleParagraphChange = (index, field, value) => {
    const updatedParagraphs = [...paragraphs];
    updatedParagraphs[index][field] = value;
    setParagraphs(updatedParagraphs);
    updateTemporaryPage(title, siteSub, roleNote, updatedParagraphs);
  };

  const handleFieldChange = (field, value) => {
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
      default:
        break;
    }
  
    // Update temporary page with the latest values
    updateTemporaryPage(title, siteSub, roleNote, paragraphs);
  };

  const updateTemporaryPage = (title, siteSub, roleNote, paragraphs) => {
    setTemporaryPage({
      title,
      siteSub,
      roleNote,
      paragraphs,
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
        setCurrentWikiPage(temporaryPage);
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
      <div className="article" style={{minWidth: "45%", marginRight: '1vw'}}>
        <h2>{newPage? 'Create Page' : 'Edit Page' }</h2>
        {newPage && <div className='editDiv'>
          <label className="editLabel">Page Title:</label>
          <input 
            type="text" 
            value={title} 
            onChange={(e) =>handleFieldChange('title', e.target.value)} 
          />
        </div>}
        <div className='editDiv'>
          <label className="editLabel">Page SiteSub [Not required]</label>
          <input 
            type="text" 
            value={siteSub} 
            onChange={(e) => handleFieldChange('siteSub', e.target.value)} 
          />
        </div>
        <div className='editDiv'>
          <label className="editLabel">Page RoleNote [Not required]</label>
          <input 
            type="text" 
            value={roleNote} 
            onChange={(e) => handleFieldChange('roleNote', e.target.value)} 
          />
        </div>
        <div>
          {paragraphs.map((paragraph, index) => (
            <div key={index}>
              <div className={`editDiv ${emptyFields.includes(index) ? 'emptyField' : ''}`}>
                <label className="editLabel">Paragraph Title:</label>
                <input
                  type="text"
                  value={paragraph.title}
                  onChange={(e) => handleParagraphChange(index, 'title', e.target.value)}
                  className='inputField'
                />
              </div>
              <div className={`editDiv ${emptyFields.includes(index) ? 'emptyField' : ''}`}>
                <label className="editLabel">Paragraph Content:</label>
                {/* <textarea
                  value={paragraph.content}
                  onChange={(e) => {
                    handleParagraphChange(index, 'content', e.target.value);
                    autoExpand(e);
                  }}
                  className='inputField'
                /> */}
                <ReactQuillComponent
                  handleChange={(value) => handleParagraphChange(index, 'content', value)}
                  content={paragraph.content}
                />
              </div>
              <div className='editDiv'>
                <label className="editLabel">Paragraph Image [Not required]</label>
                <input
                  type="text"
                  value={paragraph.paragraphImage}
                  onChange={(e) => handleParagraphChange(index, 'paragraphImage', e.target.value)}
                  className='inputField'
                />
              </div>
              <div className='editDiv'>
                <label className="editLabel">Paragraph Image Text [Not required]</label>
                <input
                  type="text"
                  value={paragraph.paragraphImageText}
                  onChange={(e) => handleParagraphChange(index, 'paragraphImageText', e.target.value)}
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
      <WikiPageComponent page={temporaryPage}/>
    </div>
  );
};

export default EditPage;
