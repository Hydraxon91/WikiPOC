import React, { useState } from 'react';
import { useParams } from 'react-router-dom';
import WikiPageComponent from '../Components/WikiPageComponent';
import WikiPageCommentsComponent from '../Components/WikiPageCommentsComponent';
import '../Styles/wikipage.css';

const WikiPage = ({page, setDecodedTitle, cookies }) => {
    const { title } = useParams();
    const decodedTitle = decodeURIComponent(title);
    const [activeTab, setActiveTab] = useState("wiki");

    const handleTabClick = (tab) =>{
        setActiveTab(tab);
    }

    return(
        <>
            <div className="wiki-navbar">
                <button 
                    className={`wiki-navbar-button ${activeTab === 'wiki' ? 'wiki-navbar-button-active' : ''}`}
                    onClick={() => handleTabClick('wiki')}
                    >
                        {decodedTitle}
                </button>
                <button 
                    className={`wiki-navbar-button ${activeTab === 'comments' ? 'wiki-navbar-button-active' : ''}`}
                    onClick={() => handleTabClick('comments')}
                    >
                        Comments
                </button>
            </div>
            {activeTab === "wiki" ? (
                <WikiPageComponent page={page} setDecodedTitle={setDecodedTitle}/>
            )
            :
            (
                <WikiPageCommentsComponent page={page} cookies ={cookies}/>
            )
            }
        </>
    )
};

export default WikiPage;