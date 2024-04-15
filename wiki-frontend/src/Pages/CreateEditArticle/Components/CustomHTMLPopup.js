import React, { useState } from 'react';
import '../Style/articleeditor.css';

const CustomHTMLPopup = ({ insertCustomHTML, togglePopupVisibility }) => {
  const [imageUrl, setImageUrl] = useState('');
  const [text, setText] = useState('');

  const handleConfirm = () => {
    // Concatenate the HTML content with the image URL and text
    const htmlContent = `<div class="articleRight"><div class="articleRightInner"><img class="paragraphImage" src="${imageUrl}" alt="logo"></div><div class="wikipage-content-container">${text}</div></div>`;
    insertCustomHTML(htmlContent);
    // togglePopupVisibility();
  };

  return (
    <div className='custom-popup-overlay'>
      <div className="custom-popup">
        <label>Image URL:</label>
        <input type="text" value={imageUrl} onChange={(e) => setImageUrl(e.target.value)} />

        <label>Text:</label>
        <textarea value={text} onChange={(e) => setText(e.target.value)} />

        <button onClick={handleConfirm}>Insert HTML</button>
        <button onClick={togglePopupVisibility}>Cancel</button>
      </div>
    </div>
  );
};

export default CustomHTMLPopup;