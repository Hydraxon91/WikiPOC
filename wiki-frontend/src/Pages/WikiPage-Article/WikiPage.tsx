import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import WikiPageComponent from './Components/WikiPageComponent';
import WikiPageCommentsComponent from './Components/WikiPageCommentsComponent';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import { getWikiPageBySlug } from '../../Api/wikiApi';
import LoadingSpinner from '../../Components/LoadingSpinner';
import '../../Styles/wikipage.css';

import { usePageMeta } from '../../hooks/usePageMeta';

const WikiPage = ({page: wikipage, setDecodedSlug, jwtToken, disableNavbar = false, pageError = false }) => {
    const { styles } = useStyleContext();
    const { slug } = useParams();
    const decodedSlug = decodeURIComponent(slug);
    const [activeTab, setActiveTab] = useState("wiki");
    const [page, setPage] = useState(null);
    const [images, setImages] = useState(null);

    const stripHtml = (html) => {
        if (!html) return '';
        const doc = new DOMParser().parseFromString(html, 'text/html');
        return doc.body.textContent || '';
    };

    usePageMeta(
        page?.title || decodedSlug || undefined,
        page?.content ? stripHtml(page.content).substring(0, 200) : undefined
    );


    useEffect(()=>{
        if (wikipage && (wikipage.wikiPage || wikipage.userSubmittedWikiPage))  {
            setActiveTab('wiki');
            setPage(wikipage.wikiPage ?? wikipage.userSubmittedWikiPage);
            setImages(wikipage.images)
        } else {
            setPage(null);
            setImages(null);
        }
    },[wikipage])

    useEffect(() => {
        if (setDecodedSlug && decodedSlug) {
            setDecodedSlug(decodedSlug);
        }
    }, [decodedSlug]);

    const handleTabClick = (tab) =>{
        setActiveTab(tab);
    }

    const refreshPage = async () => {
        try {
            const data = await getWikiPageBySlug(decodedSlug);
            if (data) {
                setPage(data.wikiPage ?? data.userSubmittedWikiPage);
                setImages(data.images);
            }
        } catch (error) {
            console.error("Error refreshing page:", error);
        }
    };

    if (pageError) return <div style={{ padding: '2rem', textAlign: 'center' }}><h2>Page not found</h2><p>The page you're looking for doesn't exist.</p></div>;
    if (!wikipage) return <LoadingSpinner text="Loading article..." />;

    return(
        <div className="article" style={{backgroundColor: styles.articleColor}}>
            <div className="wiki-page-container">
                {!disableNavbar && (
                    <div className="wiki-navbar">
                        <button
                            className={`wiki-navbar-button ${activeTab === 'wiki' ? 'wiki-navbar-button-active' : ''}`}
                            onClick={() => handleTabClick('wiki')}
                        >
                            {page?.title || decodedSlug}
                        </button>
                        <button 
                            className={`wiki-navbar-button ${activeTab === 'comments' ? 'wiki-navbar-button-active' : ''}`}
                            onClick={() => handleTabClick('comments')}
                        >
                            Comments
                        </button>
                    </div>
                )}
                <div className="wiki-content-wrap">
                    {page && (
                        <WikiPageComponent
                            page={page}
                            setDecodedSlug={setDecodedSlug}
                            activeTab={activeTab}
                            images={images}
                        />
                    )}
                    <WikiPageCommentsComponent
                        page={page}
                        jwtToken={jwtToken}
                        activeTab={activeTab}
                        refreshPage={refreshPage}
                    />
                </div>
            </div>
        </div>
    )
};

export default WikiPage;