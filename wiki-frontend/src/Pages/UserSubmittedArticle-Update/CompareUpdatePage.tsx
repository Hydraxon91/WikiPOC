import { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { useCookies } from 'react-cookie';
import { getUpdatePageById, getWikiPageById, acceptUserSubmittedUpdate, declineUserSubmittedWikiPage } from '../../Api/wikiApi';
import NewCompareUpdatePage from './NewCompareUpdatePageComponent';
import { useNotification } from '../../Components/NotificationProvider';
import './Style/compareupdates.css';

const CompareUpdatePage = () => {
    const location = useLocation();
    const navigate = useNavigate();

    const [cookies] = useCookies(['jwt_token']);
    const [originalPage, setOriginalPage] = useState();
    const [updatePage, setUpdatePage] = useState();
    const { showNotification } = useNotification();

    useEffect(() => {
        const match = location.pathname.match(/\/([a-f\d-]+)$/i);
        const numberAtEnd = match ? match[1] : null;
        fetchUpdatePage(numberAtEnd);
    }, [location.pathname]);

    useEffect(()=>{
        if (updatePage && (updatePage as any).userSubmittedWikiPage?.wikiPageId) {
            fetchOriginalPage((updatePage as any).userSubmittedWikiPage.wikiPageId);
        }
    },[updatePage])

    const fetchUpdatePage = async (id) => {
        try {
            const data = await getUpdatePageById(id, cookies['jwt_token'])
            setUpdatePage(data)
        } catch (error) {
          console.error('Error fetching page:', error);
        }
      };

      const fetchOriginalPage = async (title) => {
        try {
            const data = await getWikiPageById(title)
            setOriginalPage(data)
        } catch (error) {
          console.error('Error fetching page:', error);
        }
      };

      const handleAccept = () => {
        acceptUserSubmittedUpdate((updatePage as any).userSubmittedWikiPage.id, cookies["jwt_token"])
          .then(() => {
            // setWikiPageTitles(wikiPageTitles.filter((page) => page !== currentWikiPage.Title));
            showNotification("Succesfully updated page");
            navigate(`/user-updates`);
          })
          .catch((error) => {
            console.error("Error updating WikiPage:", error);
          });
      };

      const handleDecline = () => {
        declineUserSubmittedWikiPage((updatePage as any).userSubmittedWikiPage.id, cookies["jwt_token"])
          .then(() => {
            // setWikiPageTitles(wikiPageTitles.filter((page) => page !== currentWikiPage.Title));
            showNotification("Declined Change");
            navigate(`/user-updates`);
          })
          .catch((error) => {
            console.error("Error deleting WikiPage:", error);
          });
      };

      return (
        <>
            <div className='compareUpdatePageButtonsDiv'>
                <button className='compareUpdatePageButtons' onClick={() => handleAccept()}>Accept Change</button>
                <button className='compareUpdatePageButtons' onClick={() => handleDecline()}>Discard Change</button>
            </div>
            <div className='compare-updates-container'>
            {
                  <>
                    <NewCompareUpdatePage page={originalPage} setDecodedSlug={undefined}></NewCompareUpdatePage>
                    <div className="compare-divider"></div>
                    <NewCompareUpdatePage page={updatePage} setDecodedSlug={undefined}></NewCompareUpdatePage>
                  </> 
            }
            </div>
        </>
      )
}

export default CompareUpdatePage;