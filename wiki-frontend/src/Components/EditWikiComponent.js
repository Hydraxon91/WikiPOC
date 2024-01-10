import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useStyleContext } from './contexts/StyleContext';

const EditWikiComponent = () => {
  const navigate = useNavigate();
  const { styles, updateStyles } = useStyleContext();

  const [newStyles, setNewStyles] = useState(styles);

  const handleChange = (field, value) => {
    // console.log(`${field} ${value}`);
    setNewStyles((prevStyles) => ({ ...prevStyles, [field]: value }));
    // console.log(newStyles[field]);
  };

  const handleUpdate = () => {
    console.log("Handle Update clicked");
    updateStyles(newStyles);
    navigate('/');
  };

  return (
    <div>
      <h2>Admin Page</h2>
      <div>
        <label>Logo URL:</label>
        <input type="text" value={newStyles.logo} onChange={(e) => handleChange('logo', e.target.value)} />
      </div>
      <div>
        <label>Wiki Name:</label>
        <input type="text" value={newStyles.wikiName} onChange={(e) => handleChange('wikiName', e.target.value)} />
      </div>
      <div>
        <label>Body Color:</label>
        <input type="text" value={newStyles.bodyColor} onChange={(e) => handleChange('bodyColor', e.target.value)} />
      </div>
      <div>
        <label>Article Color:</label>
        <input type="text" value={newStyles.articleColor} onChange={(e) => handleChange('articleColor', e.target.value)} />
      </div>
      <div>
        <label>Article Right Color:</label>
        <input type="text" value={newStyles.articleRightColor} onChange={(e) => handleChange('articleRightColor', e.target.value)} />
      </div>
      <div>
        <label>Article Right Inner Color:</label>
        <input type="text" value={newStyles.articleRightInnerColor} onChange={(e) => handleChange('articleRightInnerColor', e.target.value)} />
      </div>
      <div>
        <label>Sidebar and Footer Text Color:</label>
        <input type="text" value={newStyles.footerListTextColor} onChange={(e) => handleChange('footerListTextColor', e.target.value)} />
      </div>
      <div>
        <label>Sidebar and Footer Link Color:</label>
        <input type="text" value={newStyles.footerListLinkTextColor} onChange={(e) => handleChange('footerListLinkTextColor', e.target.value)} />
      </div>
      <button onClick={handleUpdate}>Update</button>
    </div>
  );
};

export default EditWikiComponent;
