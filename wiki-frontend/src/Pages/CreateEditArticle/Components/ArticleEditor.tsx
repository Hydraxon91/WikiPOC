import React, { useRef, useEffect, useState } from 'react';
import ReactQuill from 'react-quill-new';
import Quill from 'quill';
import CustomHTMLPopup from './CustomHTMLPopup';
import UserImagesContainer from './UserImagesContainer';
import { fetchCategories } from '../../../Api/wikiApi';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import { useNotification } from '../../../Components/NotificationProvider';
import ThumbnailBlot from '../../../utils/thumbnailBlot';
import 'react-quill-new/dist/quill.snow.css';
import '../../WikiPage-Article/Style/wikipagecomponent.css';

(Quill.register as any)(ThumbnailBlot);


const ArticleEditor = ({ title, siteSub, roleNote, content, handleFieldChange, handleContentChange, handleSave, images, setImages, category }) => {
  const quillRef = useRef(null); // Define quillRef
  const {styles} = useStyleContext();
  const { showNotification } = useNotification();
  const [lastSelection, setLastSelection] = useState(null);
  const [isPopupVisible, setIsPopupVisible] = useState(false);
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    if (quillRef.current) {
      // Initialize Quill editor
      const editor = quillRef.current.getEditor();
      if (editor) {
        editor.enable(true);
        // editor.getModule('toolbar').addHandler('custom-html', insertCustomHTML);
      }
    }
    getCategories();
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
    clipboard: {
      matchers: [
        ['div.thumbnail', (node, delta) => {
          const orientation = Array.from(node.classList).find(c => c !== 'thumbnail') || 'mid';
          const content = node.innerHTML;
          const Delta = Quill.import('delta');
          return new Delta().insert({ thumbnail: JSON.stringify({ orientation, content }) });
        }],
      ],
    },
  };

  const insertCustomHTML = (htmlContent) => {
    const editor = quillRef.current?.getEditor();
    if (!editor) {
      console.error('Could not get current selection.');
      return;
    }
    const thumbMatch = htmlContent.match(/<div class="thumbnail (\w+)">([\s\S]*)<\/div>/);
    if (thumbMatch) {
      const orientation = thumbMatch[1];
      const content = thumbMatch[2].trim();
      const selection = editor.getSelection(true);
      editor.insertEmbed(selection.index, 'thumbnail', JSON.stringify({ orientation, content }));
      return;
    }
    const selection = editor.getSelection(true);
    if (!selection) return;
    editor.clipboard.dangerouslyPasteHTML(selection.index, htmlContent, 'user');
  };

  const insertImageToEditor = (imageData) =>{
    const editor = quillRef.current?.getEditor();
    if (editor) {
      const selection = editor.getSelection(true);
      if (!selection) return;
      const insertData = `<img src="${imageData}" alt="${imageData}"/>`;
      editor.clipboard.dangerouslyPasteHTML(selection.index, insertData, 'user');
    } else {
      console.error('Could not get current selection.');
    }
  }

  const handleImageInsertFromDevice = (event) => {
    const files = event.target.files;

    const acceptedTypes = ['image/jpeg', 'image/png', 'image/gif']; // Accepted image types
    const maxAspectRatio = 2; // Maximum aspect ratio (width / height)
    const maxSizeInBytes = 10 * 1024 * 1024; // Maximum size in bytes (10MB)
    const newImages = [];

    for (let i = 0; i < files.length; i++) {
        const file = files[i];
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
                    img.src = e.target.result as string;

                    img.onload = () => {
                        const aspectRatio = img.width / img.height;

                        // Check if the aspect ratio is within the limit
                        if (aspectRatio <= maxAspectRatio) {
                            // Add the image to the list of images with the modified name
                            newImages.push({ name: fileName, dataURL: e.target.result });
                            setImages([...images, { name: fileName, dataURL: e.target.result }]);
                        } else {
                            // Display an error message or handle the invalid aspect ratio
                            showNotification(`Image ${fileName} has an invalid aspect ratio.`);
                        }
                    };
                };

                reader.readAsDataURL(file);
            } else {
                // Display an error message or handle oversized images
                showNotification(`Image ${fileName} exceeds the maximum size limit of 10 megabytes.`);
            }
        } else {
            // Display an error message or handle unsupported file types
            showNotification(`File type not supported: ${file.type}`);
        }
    }
};

const getCategories = async () => {
  try {
    const fetchedCategories = await fetchCategories();
    // const categoryNames = fetchedCategories.map(category => (category.categoryName));
    setCategories(fetchedCategories);
  } catch (error) {
    console.error("Error fetching categories:", error);
    // Handle the error if necessary
  }
}


  return (
    <div className="article article-editor" style={{backgroundColor: styles.articleColor}}>
      <div className='editDiv'>
        <label className="editLabel">Article Title:</label>
        <input 
          type="text" 
          value={title} 
          onChange={(e) => handleFieldChange('title', e.target.value)} 
        />
      </div>
      <div className='editDiv'>
        <label className="editLabel">Category:</label>
        <select 
          value={category}
          onChange={(e) => handleFieldChange('category', e.target.value)}
        >
          <option value="">Select Category</option>
          {categories.length > 0 && categories.map((cat, index) => (
            <option key={index} value={cat.id}>{cat.categoryName}</option>
          ))}
        </select>
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
        <div className="editor-tip" style={{ fontSize: '80%', opacity: 0.7, marginBottom: '0.5rem', padding: '0.3rem 0.5rem', border: '1px solid rgba(0,0,0,0.1)', borderRadius: '3px' }}>
          Tip: use <b>Heading 2</b> in the toolbar above to create paragraph titles that appear in the table of contents.
        </div>
        <ReactQuill
            value={content? content : ''} 
            onChange={handleContentChange}
            modules={customModules}
            ref={quillRef}
        />
        <button onClick={togglePopupVisibility}>Insert Thumb</button>
        <input type="file" id='file' accept="image/*" className='custom-file-upload' onChange={handleImageInsertFromDevice} multiple />
        <label htmlFor="file" className='label-for-custom-file-upload'>Choose files</label>
        {/* Render the popup component if isPopupVisible is true */}
        {isPopupVisible && <CustomHTMLPopup insertCustomHTML={insertCustomHTML} togglePopupVisibility={togglePopupVisibility} images={images}/>}
        <UserImagesContainer images={images} insertImage={insertImageToEditor}/>
      </div>
      <button onClick={() => handleSave(content)}>Save</button>
    </div>
  );
}

export default ArticleEditor;
