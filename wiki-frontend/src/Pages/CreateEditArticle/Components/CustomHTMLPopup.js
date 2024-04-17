import React, { useState } from 'react';
import ReactQuill from 'react-quill';
import '../Style/articleeditor.css';

const CustomHTMLPopup = ({ insertCustomHTML, togglePopupVisibility }) => {
  const [imageUrl, setImageUrl] = useState('');
  const [text, setText] = useState('');

  const handleContentChange = (value) => {
    setText(value);
  };
  

  const handleConfirm = () => {
    // Create the HTML content string with placeholders
    const htmlContent = `||articleRight//<a href="${imageUrl}" rel="noopener noreferrer" target="_blank">ImageRef</a>##<a href='${text}' rel="noopener noreferrer" target="_blank">TextRef</a>||`;
    // console.log(text);
    // Insert the processed HTML content
    insertCustomHTML(htmlContent);
    togglePopupVisibility();
  };

  return (
    <div className='custom-popup-overlay'>
      <div className="custom-popup">
        <label>Image URL:</label>
        <input type="text" value={imageUrl} onChange={(e) => setImageUrl(e.target.value)} />

        <label>Text:</label>
        {/* <textarea value={text} onChange={(e) => setText(e.target.value)} /> */}
        <ReactQuill 
            theme="snow" 
            value={text} 
            onChange={handleContentChange}
            // modules={customModules}
            // ref={quillRef}
        />

        <button className='confirm-button' onClick={handleConfirm}>Insert HTML</button>
        <button className='confirm-button' onClick={togglePopupVisibility}>Cancel</button>
      </div>
    </div>
  );
};

export default CustomHTMLPopup;