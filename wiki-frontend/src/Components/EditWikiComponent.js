import React, {useState} from 'react';
import WikiStyles from '../Hooks/wikiStyles';

const EditWikiComponent = () => {

    const {
        logo, setLogo,
        wikiName, setWikiName,
        bodyColor, setBodyColor,
        articleRightColor, setArticleRightColor,
        articleRightInnerColor, setArticleRightInnerColor,
        articleColor, setArticleColor,
        footerListLinkTextColor, setFooterListLinkTextColor,
        footerListTextColor, setFooterListTextColor,
      } = WikiStyles();

    const [newLogo, setNewLogo] = useState(logo);
    const [newWikiName, setNewWikiName] = useState(wikiName);
    const [newBodyColor, setNewBodyColor] = useState(bodyColor);
    const [newArticleColor, setNewArticleColor] = useState(articleColor);
    const [newArticleRightColor, setNewArticleRightColor] = useState(articleRightColor);
    const [newArticleRightInnerColor, setNewArticleRightInnerColor] = useState(articleRightInnerColor);
    const [newFooterListTextColor, setNewFooterListTextColor] = useState(footerListTextColor);
    const [newFooterListLinkTextColor, setNewFooterListLinkTextColor] = useState(footerListLinkTextColor);
    
    const handleChange = (setState, value) => {
        setState(value);
      };
    
      const handleUpdate = () => {
        setLogo(newLogo);
        setWikiName(newWikiName);
        setBodyColor(newBodyColor);
        setArticleColor(newArticleColor);
        setArticleRightColor(newArticleRightColor);
        setArticleRightInnerColor(newArticleRightInnerColor);
        setFooterListTextColor(newFooterListTextColor);
        setFooterListLinkTextColor(newFooterListLinkTextColor);
      };


    return (
    <div>
      <h2>Admin Page</h2>
      <div>
        <label>Logo URL:</label>
        <input type="text" value={newLogo} onChange={(e) => handleChange(setNewLogo, e.target.value)} />
      </div>
      <div>
        <label>Wiki Name:</label>
        <input type="text" value={newWikiName} onChange={(e) => handleChange(setNewWikiName, e.target.value)} />
      </div>
      <div>
        <label>Body Color:</label>
        <input type="text" value={newBodyColor} onChange={(e) => handleChange(setNewBodyColor, e.target.value)} />
      </div>
      <div>
        <label>Article Color:</label>
        <input type="text" value={newArticleColor} onChange={(e) => handleChange(setNewArticleColor, e.target.value)} />
      </div>
      <div>
        <label>Article Right Color:</label>
        <input type="text" value={newArticleRightColor} onChange={(e) => handleChange(setNewArticleRightColor, e.target.value)} />
      </div>
      <div>
        <label>Article Right Inner Color:</label>
        <input type="text" value={newArticleRightInnerColor} onChange={(e) => handleChange(setNewArticleRightInnerColor, e.target.value)} />
      </div>
      <div>
        <label>Sidebar and Footer Text Color:</label>
        <input type="text" value={newFooterListTextColor} onChange={(e) => handleChange(setNewFooterListTextColor, e.target.value)} />
      </div>
      <div>
        <label>Sidebar and Footer Link Color:</label>
        <input type="text" value={newFooterListLinkTextColor} onChange={(e) => handleChange(setNewFooterListLinkTextColor, e.target.value)} />
      </div>
      <button onClick={handleUpdate}>Update</button>
    </div>
  );
};

export default EditWikiComponent;