import { useState, useEffect } from 'react';
import ReactQuill from 'react-quill-new';
import UserImagesContainer from './UserImagesContainer';
import '../Style/articleeditor.css';
import '../../WikiPage-Article/Style/wikipagecomponent.css'

const CustomHTMLPopup = ({ insertCustomHTML, togglePopupVisibility, images }) => {
  const [imageUrl, setImageUrl] = useState('');
  const [imageData, setImageData] = useState('');
  const [text, setText] = useState('');
  const [orientation, setOrientation] = useState('left');

  const handleContentChange = (value) => {
    setText(value);
  };

  useEffect(()=>{
    if (imageUrl) {
      const image = images.find(image => image.name === imageUrl);
      if (image) {
        setImageData(image.dataURL);
      }
    }
  },[imageUrl, images])

  const insertImage = (imageData) =>{
    setImageUrl(imageData);
  }

  const trimText = (text) => {
    const textRegex = /<p>(.*?)<\/p>/g;
    const textMatch = Array.from(text.matchAll(textRegex)).map(match => match[1]);
    if (textMatch) {
      const trimmedText = textMatch.map(match => `<p>${match.trim()}</p>`).join('\n');
      return <div dangerouslySetInnerHTML={{ __html: trimmedText }} />
    }
  }

  const handleOrientationChange = (event) => {
    setOrientation(event.target.value);
  };

  const handleConfirm = () => {
    const thumbnailHtml = `<div class="thumbnail ${orientation}">
      <div class="thumbnail-inner">
        <img class="paragraph-image" alt="logo" src="${imageData}">
      </div>
      <div class="wikipage-content-container">
        <div>${text}</div>
      </div>
    </div>`;
    insertCustomHTML(thumbnailHtml);
    togglePopupVisibility();
  };

  return (
    <div className='custom-popup-overlay'>
      <div className="custom-popup">
      
        {imageData && text &&
          <>
            <label className='article-preview'>Preview:</label>
            <div className='article-container'>
            <div className={`thumbnail ${orientation}`}>
              <div className='thumbnail-inner'>
                <img className="paragraph-image" src={imageData} alt="logo" loading="lazy"/>
              </div>
              <div className="wikipage-content-container">{trimText(text)}</div>
            </div>
            </div>
          </>
        }
        <label>Image</label>
        <UserImagesContainer images={images} insertImage={insertImage}/>

        <label>Text:</label>
        <ReactQuill 
            theme="snow" 
            value={text} 
            onChange={handleContentChange}
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