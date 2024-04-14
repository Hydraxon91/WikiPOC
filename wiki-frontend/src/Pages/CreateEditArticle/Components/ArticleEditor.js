import React, { useRef, useEffect } from 'react';
import ReactQuill, { Quill } from 'react-quill';
import 'react-quill/dist/quill.snow.css';

// Define a custom blot for the custom HTML structure
const CustomHTMLBlot = Quill.import('blots/block/embed')
class CustomQuillHTML extends CustomHTMLBlot{
    static create(value) {
        const node = super.create(value);
        // Set the innerHTML of the node based on the value
        node.innerHTML = value.content;
        // Set other attributes or styles if needed
        return node;
    }
    
    static value(node) {
        return { content: node.innerHTML };
      }
    
      static formats(node) {
        // Return formats for the node, if necessary
        return {};
      }
    
      static sanitize(value) {
        // Sanitize the value, if necessary
        return value;
      }
}
CustomQuillHTML.blotName = 'custom-html';
CustomQuillHTML.tagName = 'div';
Quill.register(CustomQuillHTML);


const ArticleEditor = ({ title, siteSub, roleNote, content, handleFieldChange, handleContentChange, handleSave }) => {
  const quillRef = useRef(null); // Define quillRef

  useEffect(() => {
    if (quillRef.current) {
      // Initialize Quill editor
      const editor = quillRef.current.getEditor();
      if (editor) {
        editor.enable(true);
        editor.getModule('toolbar').addHandler('custom-html', insertCustomHTML);
      }
    }
  }, []);

  const customModules = {
    toolbar: [
      ['bold', 'italic', 'underline', 'strike'],
      [{ 'header': [2, 3, false] }],
      ['link'],
      [{ 'image': {} }, { 'custom-html': {} }]
    ],
  };

  // Handler for inserting the custom HTML structure
//   const insertCustomHTML = () => {
//     const editor = quillRef.current?.getEditor();
//     if (editor) {
//         // Get the current selection
//         const range = editor.getSelection();
//         if (range) {
//             // Disable the editor's autocompletion of newline after insertion
//             const htmlContent = '<div class="articleRight"><div class="articleRightInner"><img class="paragraphImage" src="https://image.api.playstation.com/vulcan/ap/rnd/202309/0718/2c253de3117182b4a09d02ad16ebc51a25d4ea9208a5d057.jpg" alt="logo"></div><div class="wikipage-content-container">Helldivers never die!</div></div>';
//             editor.insertText(range.index, htmlContent, 'user');

//             // Manually set the selection after the inserted content
//             editor.setSelection(range.index + htmlContent.length);
//         } else {
//             console.error('Could not get current selection.');
//         }
//     }
// };

const insertCustomHTML = () => {
    const editor = quillRef.current?.getEditor();
    if (editor) {
      const range = editor.getSelection();
      if (range) {
        const htmlContent = '<div class="articleRight"><div class="articleRightInner"><img class="paragraphImage" src="https://image.api.playstation.com/vulcan/ap/rnd/202309/0718/2c253de3117182b4a09d02ad16ebc51a25d4ea9208a5d057.jpg" alt="logo"></div><div class="wikipage-content-container">Helldivers never die!</div></div>';
        editor.insertEmbed(
          range.index, 
          'custom-html', // Custom format name
          { content: htmlContent }
        );
      } else {
        console.error('Could not get current selection.');
      }
    }
  };

  

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
      <div>
        <ReactQuill 
            theme="snow" 
            value={content} 
            onChange={handleContentChange}
            modules={customModules}
            ref={quillRef}
        />
        <button onClick={insertCustomHTML}>Insert Custom HTML</button>
      </div>
      
      <button onClick={() => handleSave(content)}>Save</button>
    </div>
  );
}

export default ArticleEditor;
