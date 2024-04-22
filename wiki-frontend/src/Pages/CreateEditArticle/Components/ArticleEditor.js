import React, { useRef, useEffect, useState } from 'react';
import ReactQuill, { Quill } from 'react-quill';
import CustomHTMLPopup from './CustomHTMLPopup';
import UserImagesContainer from './UserImagesContainer';
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


const ArticleEditor = ({ title, siteSub, roleNote, content, handleFieldChange, handleContentChange, handleSave, images, setImages }) => {
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

  const insertImageToEditor = (imageData) =>{
    const editor = quillRef.current?.getEditor();
    if (editor) {
      const cursorPosition = lastSelection ? lastSelection.index + lastSelection.length : editor.getSelection();
      const insertData = `<img src="${imageData}" alt="alt"/>`
      editor.clipboard.dangerouslyPasteHTML(cursorPosition, insertData, 'user');
    } else {
      console.error('Could not get current selection.');
    }
  }

  const handleImageInsertFromDevice = (event) => {
    const files = event.target.files;

    const acceptedTypes = ['image/jpeg', 'image/png', 'image/gif']; // Accepted image types
    const maxAspectRatio = 2; // Maximum aspect ratio (width / height)
    const maxSizeInBytes = 10 * 1024 * 1024; // Maximum size in bytes (10MB)
    const maxNameLength = 20;

    const newImages = [];

    for (let i = 0; i < files.length; i++) {
        const file = files[i];
        // let fileName = file.name.length > maxNameLength ? // Check if the file name is longer than 20 characters
        //     file.name.substring(0, maxNameLength / 2) + '...' + file.name.substring(file.name.length - maxNameLength / 2) : // Shorten the name and add ellipsis
        //     file.name; // Keep the original name if it's not too long
        let fileName = file.name;

        // Check if the file name already exists in the images array
        let count = 2;
        while (images.some(image => image.name === fileName)) {
            // If the name already exists, append '(2)' (or next available number) to the file name
            fileName = `${file.name.substring(0, file.name.lastIndexOf('.'))} (${count})${file.name.substring(file.name.lastIndexOf('.'))}`;
            count++;
        }

        // Check if the file type is accepted
        if (acceptedTypes.includes(file.type)) {
            // Check if the file size is within the limit
            if (file.size <= maxSizeInBytes) {
                const reader = new FileReader();

                reader.onload = (e) => {
                    const img = new Image();
                    img.src = e.target.result;

                    img.onload = () => {
                        const aspectRatio = img.width / img.height;

                        // Check if the aspect ratio is within the limit
                        if (aspectRatio <= maxAspectRatio) {
                            // Add the image to the list of images with the modified name
                            newImages.push({ name: fileName, dataURL: e.target.result });
                            setImages([...images, { name: fileName, dataURL: e.target.result }]);
                        } else {
                            // Display an error message or handle the invalid aspect ratio
                            window.alert(`Image ${fileName} has an invalid aspect ratio.`);
                        }
                    };
                };

                reader.readAsDataURL(file);
            } else {
                // Display an error message or handle oversized images
                window.alert(`Image ${fileName} exceeds the maximum size limit of 10 megabytes.`);
            }
        } else {
            // Display an error message or handle unsupported file types
            window.alert(`File type not supported: ${file.type}`);
        }
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
        <button onClick={togglePopupVisibility}>Insert Custom HTML</button>
        <input type="file" accept="image/*" onChange={handleImageInsertFromDevice} multiple />
        {/* Render the popup component if isPopupVisible is true */}
        {isPopupVisible && <CustomHTMLPopup insertCustomHTML={insertCustomHTML} togglePopupVisibility={togglePopupVisibility} images={images}/>}
        <UserImagesContainer images={images} insertImage={insertImageToEditor}/>
      </div>
      <button onClick={() => handleSave(content)}>Save</button>
    </div>
  );
}

export default ArticleEditor;
