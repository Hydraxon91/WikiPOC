import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import LegacyWikiPageComponent from './Components/LegacyWikiPageComponent';
import WikiPageComponent from './Components/WikiPageComponent';
import WikiPageCommentsComponent from './Components/WikiPageCommentsComponent';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import '../../Styles/wikipage.css';

const WikiPage = ({page: wikipage, setDecodedTitle, cookies }) => {
    const { styles } = useStyleContext();
    const { title } = useParams();
    const decodedTitle = decodeURIComponent(title);
    const [activeTab, setActiveTab] = useState("wiki");
    const [page, setPage] = useState(null);
    const [images, setImages] = useState(null);

    useEffect(()=>{
        if (wikipage && wikipage.wikiPage)  {
            setActiveTab('wiki');
            console.log(wikipage);
            setPage(wikipage.wikiPage);
            setImages(wikipage.images)
        }
    },[wikipage])

    const handleTabClick = (tab) =>{
        setActiveTab(tab);
    }

    return(
        <>
            <div className="wiki-navbar" style={{backgroundColor: styles.articleRightInnerColor}}>
                <button
                    className={`wiki-navbar-button ${activeTab === 'wiki' ? 'wiki-navbar-button-active' : ''}`}
                    style={{backgroundColor: styles.articleRightInnerColor}} 
                    onClick={() => handleTabClick('wiki')}
                    >
                        {decodedTitle}
                </button>
                <button 
                    className={`wiki-navbar-button ${activeTab === 'comments' ? 'wiki-navbar-button-active' : ''}`}
                    style={{backgroundColor: styles.articleRightInnerColor}} 
                    onClick={() => handleTabClick('comments')}
                    >
                        Comments
                </button>
            </div>
            <div className="wiki-page-container">
                {page && !page.legacyWikiPage ? 
                (
                    <WikiPageComponent
                        page={page}
                        setDecodedTitle={setDecodedTitle}
                        activeTab={activeTab}
                        className={activeTab === 'wiki' ? 'wikipage-visible' : 'wikipage-hidden'}
                        images={images}
                    />
                ) : (
                    <LegacyWikiPageComponent
                        page={page}
                        setDecodedTitle={setDecodedTitle}
                        activeTab={activeTab}
                        className={activeTab === 'wiki' ? 'wikipage-visible' : 'wikipage-hidden'}
                    />
                )}
                
                <WikiPageCommentsComponent
                    page={page}
                    cookies={cookies}
                    activeTab={activeTab}
                />
            </div>
        </>
    )
};

export default WikiPage;