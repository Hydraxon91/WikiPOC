import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useStyleContext } from './contexts/StyleContext';


const EditWikiComponent = () => {
  const navigate = useNavigate();
  const { styles, updateStyles, setStyles } = useStyleContext();

  const [newStyles, setNewStyles] = useState(styles);

  const handleChange = (field, value) => {
    // console.log(`${field} ${value}`);
    setNewStyles((prevStyles) => ({ ...prevStyles, [field]: value }));
    // console.log(newStyles[field]);
  };

  const handleUpdate = () => {
    console.log("Handle Update clicked");
    updateStyles(newStyles);
    setStyles(newStyles);
    navigate('/');
  };
  

  return (
    <div>
      <h2 className="mb-4">Admin Page</h2>
      <div className="form-group">
        <label className="mb-4">Logo URL:</label>
        <input type="text" 
          value={newStyles.logo} 
          style={{marginLeft: "0.5rem"}} 
          onChange={(e) => handleChange('logo', e.target.value)} />
      </div>

      <div className="form-group">
        <label className="mb-4">Wiki Name:</label>
        <input type="text" 
          value={newStyles.wikiName}
          style={{marginLeft: "0.5rem"}} 
          onChange={(e) => handleChange('wikiName', e.target.value)} />
      </div>

      <div className="form-group">
        <label className="mb-4">Body Color:</label>
        <input type="color" 
          className="form-control-color align-middle"
          style={{marginLeft: "0.5rem"}}  
          value={newStyles.bodyColor} 
          title="Choose your color"
          onChange={(e) => handleChange('bodyColor', e.target.value)} />
      </div>

      <div className="form-group">
        <label className="mb-4">Article Color:</label>
        <input type="color" 
          className="form-control-color align-middle"
          style={{marginLeft: "0.5rem"}}  
          value={newStyles.articleColor} 
          title="Choose your color"
          onChange={(e) => handleChange('articleColor', e.target.value)} />
      </div>

      <div className="form-group">
        <label className="mb-4">Article Right Color:</label>
        <input type="color" 
          className=" form-control-color align-middle"
          style={{marginLeft: "0.5rem"}} 
          value={newStyles.articleRightColor}
          title="Choose your color"
          onChange={(e) => handleChange('articleRightColor', e.target.value)} />
      </div>

      <div className="form-group">
        <label className="mb-4">Article Right Inner Color:</label>
        <input type="color" 
          className="form-control-color align-middle"
          style={{marginLeft: "0.5rem"}}  
          value={newStyles.articleRightInnerColor}
          title="Choose your color"
          onChange={(e) => handleChange('articleRightInnerColor', e.target.value)} />
      </div>

      <div className="form-group">
        <label className="mb-4">Sidebar and Footer Text Color:</label>
        <input type="color" 
          className="form-control-color align-middle"
          style={{marginLeft: "0.5rem"}} 
          value={newStyles.footerListTextColor}
          title="Choose your color"
          onChange={(e) => handleChange('footerListTextColor', e.target.value)} />
      </div>

      <div className="form-group">
        <label className="mb-4">Sidebar and Footer Link Color:</label>
        <input type="color" 
          className="form-control-color align-middle"
          style={{marginLeft: "0.5rem"}} 
          value={newStyles.footerListLinkTextColor} 
          title="Choose your color"
          onChange={(e) => handleChange('footerListLinkTextColor', e.target.value)} />
      </div>

      <button onClick={handleUpdate}>Update</button>
    </div>
  );
};

export default EditWikiComponent;
