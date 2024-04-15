import React, { useRef, useEffect, useState } from 'react';
import ReactQuill, { Quill } from 'react-quill';
import CustomHTMLPopup from './CustomHTMLPopup';
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
  const [isPopupVisible, setIsPopupVisible] = useState(false);

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

  const togglePopupVisibility = () => {
    setIsPopupVisible(!isPopupVisible);
  };

  const customModules = {
    toolbar: [
      ['bold', 'italic', 'underline', 'strike'],
      [{ 'header': [2, 3, false] }],
      ['link'],
      [{ 'image': {} }, { 'custom-html': {} }]
    ],
  };

  // Handler for inserting the custom HTML structure

  // const insertCustomHTML = (htmlContent) => {
  //   const editor = quillRef.current?.getEditor();
  //   if (editor) {
  //     const range = editor.getSelection();
  //     const editorLength = editor.getLength();
  //     if (editorLength) {
  //       const format = {
  //         'custom-html': { content: htmlContent },
  //       };
  //       const bounds = 'user';
  //       editor.insertText(editorLength, '\n', format, bounds);
  //       editor.setSelection(editorLength + htmlContent.length);

  //       const delta = editor.clipboard.convert({ html: htmlContent });
  //       editor.updateContents(delta);
  //     } else {
  //       console.error('Could not get current selection.');
  //     }
  //   }
  // };

  const insertCustomHTML = (htmlContent) => {
    const editor = quillRef.current?.getEditor();
    if (editor) {
        // Get the current length of the editor's content
        const editorLength = editor.getLength();

        // Insert the HTML content as a custom format
        const format = {
            'custom-html': { content: htmlContent },
        };
        editor.insertText(editorLength, htmlContent, 'user');

        // Manually set the selection at the end of the inserted content
        editor.setSelection(editorLength + 1);
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
        <ReactQuill 
            theme="snow" 
            value={content} 
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
