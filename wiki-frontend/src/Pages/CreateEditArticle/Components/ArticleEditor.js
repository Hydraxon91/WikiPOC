import React, { useRef } from 'react';
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';

const ArticleEditor = ({ title, siteSub, roleNote, content, handleFieldChange, handleContentChange, handleSave }) => {
  const quillRef = useRef(null); // Define quillRef

  const handleImageUpload = async (file) => {
    // Upload image file to server
    const formData = new FormData();
    formData.append('image', file);

    try {
      const response = await fetch('/upload-image', {
        method: 'POST',
        body: formData,
      });

      if (response.ok) {
        const imageUrl = await response.json();
        // Insert image into editor
        const range = quillRef.current.getEditor().getSelection();
        const imagePath = imageUrl; // URL of the uploaded image
        quillRef.current.getEditor().insertEmbed(range.index, 'image', imagePath);
      } else {
        console.error('Image upload failed');
      }
    } catch (error) {
      console.error('Error uploading image:', error);
    }
  };

  return (
    <div className="article wikipage-component">
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
      {/* <ReactQuill 
        theme="snow" 
        value={content} 
        onChange={handleContentChange}
        modules={{
          toolbar: {
            container: [
              [{ 'header': [1, 2, false] }],
              ['bold', 'italic', 'underline'],
              ['image'], // Include image button in toolbar
            ],
            handlers: {
              'image': handleImageUpload, // Custom handler for image button
            },
          },
        }}
        ref={quillRef} // Assign the ref to the Quill editor
      /> */}
      <ReactQuill 
        theme="snow" 
        value={content} 
        onChange={handleContentChange} 
      />
      <button onClick={() => handleSave(content)}>Save</button>
    </div>
  );
}

export default ArticleEditor;
