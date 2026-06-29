import { useState, useEffect } from 'react';
import WikiPageComponent from '../WikiPage-Article/Components/WikiPageComponent';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import '../../Styles/wikipage.css';

const NewCompareUpdatePage = ({page: wikipage, setDecodedSlug}) => {
    const [activeTab, setActiveTab] = useState("wiki");
    const [page, setPage] = useState(null);
    const [images, setImages] = useState(null);
    const {styles} = useStyleContext();

    useEffect(()=>{
        if (wikipage && (wikipage.wikiPage || wikipage.userSubmittedWikiPage))  {
            setActiveTab('wiki');
            setPage(wikipage.wikiPage ?? wikipage.userSubmittedWikiPage);
            setImages(wikipage.images)
        }
    },[wikipage])


    return(
        <div className="article" style={{backgroundColor: styles.articleColor}}>         
            <div className="update-page-container">
                {page && (
                    <WikiPageComponent
                        page={page}
                        setDecodedSlug={setDecodedSlug}
                        activeTab={activeTab}
                        images={images}
                    />
                )}
            </div>
        </div>
    )
};

export default NewCompareUpdatePage;