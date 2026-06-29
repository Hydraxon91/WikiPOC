import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import WikiPageComponent from './Components/WikiPageComponent';
import WikiPageCommentsComponent from './Components/WikiPageCommentsComponent';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import { getWikiPageBySlug } from '../../Api/wikiApi';
import LoadingSpinner from '../../Components/LoadingSpinner';
import '../../Styles/wikipage.css';

const WikiPage = ({page: wikipage, setDecodedSlug, jwtToken, disableNavbar = false, pageError = false }) => {
    const { styles } = useStyleContext();
    const { slug } = useParams();
    const decodedSlug = decodeURIComponent(slug);
    const [activeTab, setActiveTab] = useState("wiki");
    const [page, setPage] = useState(null);
    const [images, setImages] = useState(null);


    useEffect(()=>{
        console.log('WikiPage: wikipage prop', wikipage ? 'has data' : 'null');
        if (wikipage && (wikipage.wikiPage || wikipage.userSubmittedWikiPage))  {
            setActiveTab('wiki');
            setPage(wikipage.wikiPage ?? wikipage.userSubmittedWikiPage);
            setImages(wikipage.images)
        }
    },[wikipage])

    useEffect(() => {
        console.log('WikiPage: decodedSlug', decodedSlug, 'setDecodedSlug:', !!setDecodedSlug);
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
            {!disableNavbar &&(
                <>
                    <div className="wiki-navbar" style={{backgroundColor: styles.articleRightInnerColor}}>
                        <button
                            className={`wiki-navbar-button ${activeTab === 'wiki' ? 'wiki-navbar-button-active' : ''}`}
                            style={{backgroundColor: styles.articleRightInnerColor}} 
                            onClick={() => handleTabClick('wiki')}
                            >
                                {page?.title || decodedSlug}
                        </button>
                        <button 
                            className={`wiki-navbar-button ${activeTab === 'comments' ? 'wiki-navbar-button-active' : ''}`}
                            style={{backgroundColor: styles.articleRightInnerColor}} 
                            onClick={() => handleTabClick('comments')}
                            >
                                Comments
                        </button>
                    </div>
                </>
            )}
            
            <div className="wiki-page-container">
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
    )
};

export default WikiPage;