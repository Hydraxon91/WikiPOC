import React, { useState, useEffect } from 'react';
import ReactQuillComponent from '../../../Components/ReactQuillComponent';

const LegacyEditPageComponent = ({newPage, title, handleFieldChange, siteSub, roleNote, paragraphs, emptyFields, handleParagraphChange, handleRemoveParagraph, handleAddParagraph, handleSave}) => {
    return (
        <div className="article wikipage-component">
        <h2>{newPage? 'Create Page' : 'Edit Page' }</h2>
        {newPage && <div className='editDiv'>
          <label className="editLabel">Page Title:</label>
          <input 
            type="text" 
            value={title} 
            onChange={(e) =>handleFieldChange('title', e.target.value)} 
          />
        </div>}
        <div className='editDiv'>
          <label className="editLabel">Category:</label>
          <input 
            type="text" 
            placeholder='Enter Category' 
            onChange={(e) => handleFieldChange('category', e.target.value)} 
          />
        </div>
        <div className='editDiv'>
          <label className="editLabel">Page SiteSub [Not required]</label>
          <input 
            type="text" 
            value={siteSub} 
            onChange={(e) => handleFieldChange('siteSub', e.target.value)} 
          />
        </div>
        <div className='editDiv'>
          <label className="editLabel">Page RoleNote [Not required]</label>
          <input 
            type="text" 
            value={roleNote} 
            onChange={(e) => handleFieldChange('roleNote', e.target.value)} 
          />
        </div>
        <div>
          {paragraphs.map((paragraph, index) => (
            <div key={index}>
              <div className={`editDiv ${emptyFields.includes(index) ? 'emptyField' : ''}`}>
                <label className="editLabel">Paragraph Title:</label>
                <input
                  type="text"
                  value={paragraph.title}
                  onChange={(e) => handleParagraphChange(index, 'title', e.target.value)}
                  className='inputField'
                />
              </div>
              <div className={`editDiv ${emptyFields.includes(index) ? 'emptyField' : ''}`}>
                <label className="editLabel">Paragraph Content:</label>
                {/* <textarea
                  value={paragraph.content}
                  onChange={(e) => {
                    handleParagraphChange(index, 'content', e.target.value);
                    autoExpand(e);
                  }}
                  className='inputField'
                /> */}
                <ReactQuillComponent
                  handleChange={(value) => handleParagraphChange(index, 'content', value)}
                  content={paragraph.content}
                />
              </div>
              <div className='editDiv'>
                <label className="editLabel">Paragraph Image [Not required]</label>
                <input
                  type="text"
                  value={paragraph.paragraphImage}
                  onChange={(e) => handleParagraphChange(index, 'paragraphImage', e.target.value)}
                  className='inputField'
                />
              </div>
              <div className='editDiv'>
                <label className="editLabel">Paragraph Image Text [Not required]</label>
                {/* <input
                  type="text"
                  value={paragraph.paragraphImageText}
                  onChange={(e) => handleParagraphChange(index, 'paragraphImageText', e.target.value)}
                  className='inputField'
                /> */}
                <ReactQuillComponent
                  handleChange={(value) => handleParagraphChange(index, 'paragraphImageText', value)}
                  content={paragraph.paragraphImageText}
                />
              </div>

              <button onClick={() => handleRemoveParagraph(index)}>Remove Paragraph</button>
            </div>
          ))}
        </div>

        <button onClick={handleAddParagraph}>Add Paragraph</button>
        <br />

        <button onClick={handleSave}>Save</button>
      </div>
    )
}

export default LegacyEditPageComponent;