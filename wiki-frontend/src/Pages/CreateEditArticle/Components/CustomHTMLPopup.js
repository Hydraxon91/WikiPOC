import React, { useState } from 'react';
import ReactQuill from 'react-quill';
import '../Style/articleeditor.css';
import '../../WikiPage-Article/Style/wikipagecomponent.css'

const CustomHTMLPopup = ({ insertCustomHTML, togglePopupVisibility }) => {
  const [imageUrl, setImageUrl] = useState('');
  const [text, setText] = useState('');
  const [orientation, setOrientation] = useState('left');

  const handleContentChange = (value) => {
    setText(value);
  };

  const trimText = (text) => {
    const textRegex = /<p>(.*?)<\/p>/g;
    const textMatch = Array.from(text.matchAll(textRegex)).map(match => match[1]);
    // console.log(textMatch);
    if (textMatch) {
      const trimmedText = textMatch.map(match => `<p>${match.trim()}</p>`).join('\n');
      return <div dangerouslySetInnerHTML={{ __html: trimmedText }} />
    }
  }

  const handleOrientationChange = (event) => {
    setOrientation(event.target.value);
  };
  

  const handleConfirm = () => {
    // Create the HTML content string with placeholders
    const htmlContent = `||article-${orientation}//<a href="${imageUrl}" rel="noopener noreferrer" target="_blank">ImageRef</a>##<a href='${text}' rel="noopener noreferrer" target="_blank">TextRef</a>||`;
    // console.log(text);
    // Insert the processed HTML content
    insertCustomHTML(htmlContent);
    togglePopupVisibility();
  };

  return (
    <div className='custom-popup-overlay'>
      <div className="custom-popup">
      
        {imageUrl && text &&
          <>
            <label className='article-preview'>Preview:</label>
            <div className='article-container'>
              <div className='article-mid'>
                <div className='article-right-inner'>
                  <img className="paragraph-image" src={imageUrl} alt="logo"/>
                </div>
                <div className="wikipage-content-container">{trimText(text)}</div>
              </div>
            </div>
          </>
        }
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

        <label>Orientation:</label>
        <select value={orientation} onChange={handleOrientationChange}>
          <option value="left">Left</option>
          <option value="right">Right</option>
          <option value="mid">Middle</option>
          <option value='freeflow'>Freeflow</option>
        </select>

        <div className='confirm-button-container'>
          <button className='confirm-button left' onClick={handleConfirm}>Confirm</button>
          <button className='confirm-button right' onClick={togglePopupVisibility}>Cancel</button>
        </div>
      </div>
    </div>
  );
};

export default CustomHTMLPopup;