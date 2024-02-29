import React, { useEffect, useState, useRef } from 'react';
import { Link, useParams} from 'react-router-dom';
import WikiPageComponent from '../Components/WikiPageComponent';
import '../Styles/wikipage.css';

const WikiPage = ({page, setDecodedTitle}) => {
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
            ):(
                <div className='wikipage-component'>Nothing here yet</div>
                )
            }
        </>
    )
};

export default WikiPage;