import React, { useRef, useEffect, useState } from 'react';
import ReactQuill, { Quill } from 'react-quill';
import CustomHTMLPopup from './CustomHTMLPopup';
import CustomQuillToolbar from './CustomQuillToolbar';
import 'react-quill/dist/quill.snow.css';

// // Define a custom blot for the custom HTML structure
// const CustomHTMLBlot = Quill.import('blots/block')
// class CustomQuillHTML extends CustomHTMLBlot{
//     static create(value) {
//         const node = super.create(value);
//         // Set the innerHTML of the node based on the value
//         node.innerHTML = value.content;
//         // Set other attributes or styles if needed
//         return node;
//     }
    
//     static value(node) {
//         return { content: node.innerHTML };
//       }
    
//       // static formats(node) {
//       //   // Return formats for the node, if necessary
//       //   return {};
//       // }
    
//       // static sanitize(value) {
//       //   // Sanitize the value, if necessary
//       //   return value;
//       // }
// }
// CustomQuillHTML.blotName = 'custom-html';
// CustomQuillHTML.tagName = 'p';
// Quill.register(CustomQuillHTML);


const ArticleEditor = ({ title, siteSub, roleNote, content, handleFieldChange, handleContentChange, handleSave }) => {
  const quillRef = useRef(null); // Define quillRef
  const [lastSelection, setLastSelection] = useState(null);
  const [isPopupVisible, setIsPopupVisible] = useState(false);

  useEffect(() => {
    if (quillRef.current) {
      // Initialize Quill editor
      const editor = quillRef.current.getEditor();
      if (editor) {
        editor.enable(true);
        // editor.getModule('toolbar').addHandler('custom-html', insertCustomHTML);
      }
    }
  }, []);

  useEffect(() => {
    const editor = quillRef.current?.getEditor();
    if (editor) {
      let timeoutId;

      const handleChange = (delta, oldDelta, source) => {
        if (source === 'user') {
          clearTimeout(timeoutId); // Clear previous timeout
          timeoutId = setTimeout(() => {
            const selection = editor.getSelection();
            if (selection !== null) {
              // console.log(selection);
              setLastSelection(selection);
            }
          }, 100); // Adjust the delay as needed
        }
      };

      editor.on('selection-change', handleChange);
      editor.on('text-change', handleChange);

      return () => {
        editor.off('selection-change', handleChange);
        editor.off('text-change', handleChange);
      };
    }
  }, [quillRef]);

  const togglePopupVisibility = () => {
    setIsPopupVisible(!isPopupVisible);
  };

  const customModules = {
    toolbar: [
        ['bold', 'italic', 'underline', 'strike'],
        [{ 'header': [2, 3, false] }],
        ['link'],
        [{ 'image': {} }],
    ],
    
  };

  const insertCustomHTML = (htmlContent) => {
    const editor = quillRef.current?.getEditor();
    if (editor) {
      const cursorPosition = lastSelection ? lastSelection.index + lastSelection.length : editor.getSelection();
      // editor.insertEmbed(cursorPosition, 'html', { content: htmlContent }, 'user');
      // console.log(cursorPosition);
      editor.clipboard.dangerouslyPasteHTML(cursorPosition, htmlContent, 'user');
    } else {
      console.error('Could not get current selection.');
    }
  };

  return (
    <div className="article article-editor">
      <div className='editDiv'>
        <label className="editLabel">Article Title:</label>
        <input 
          type="text" 
          value={title} 
          onChange={(e) => handleFieldChange('title', e.target.value)} 
        />
      </div>
      <div className='editDiv'>
        <label className="editLabel">Site Sub [Optional]</label>
        <input 
          type="text" 
          value={siteSub} 
          onChange={(e) => handleFieldChange('siteSub', e.target.value)} 
        />
      </div>
      <div className='editDiv'>
        <label className="editLabel">Role Note [Optional]</label>
        <input 
          type="text" 
          value={roleNote} 
          onChange={(e) => handleFieldChange('roleNote', e.target.value)} 
        />
      </div>
      <div>
        {/* <CustomQuillToolbar togglePopupVisibility={togglePopupVisibility} /> */}
        <ReactQuill
            value={content? content : ''} 
            onChange={handleContentChange}
            modules={customModules}
            ref={quillRef}
        />
        {/* <button onClick={insertCustomHTML}>Insert Custom HTML</button> */}
        {!isPopupVisible && <button onClick={togglePopupVisibility}>Insert Custom HTML</button>}
        {/* Render the popup component if isPopupVisible is true */}
        {isPopupVisible && <CustomHTMLPopup insertCustomHTML={insertCustomHTML} togglePopupVisibility={togglePopupVisibility}/>}
      </div>
      
      <button onClick={() => handleSave(content)}>Save</button>
    </div>
  );
}

export default ArticleEditor;
