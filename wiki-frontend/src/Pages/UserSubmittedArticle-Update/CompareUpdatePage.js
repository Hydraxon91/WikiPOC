import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { useCookies } from 'react-cookie';
import { getUpdatePageById, getWikiPageByTitle, acceptUserSubmittedUpdate, declineUserSubmittedWikiPage } from '../../Api/wikiApi';
import CompareUpdatePageComponent from './CompareUpdatePageComponent';
import WikiPage from '../WikiPage-Article/WikiPage';
import '../../Styles/compareupdates.css';

const CompareUpdatePage = () => {
    const location = useLocation();
    const navigate = useNavigate();

    const [cookies] = useCookies(['jwt_token']);
    const [originalPage, setOriginalPage] = useState();
    const [updatePage, setUpdatePage] = useState();

    useEffect(() => {
        // console.log(location.pathname);
        const match = location.pathname.match(/\/([a-f\d-]+)$/i);
        // console.log(match);
        const numberAtEnd = match ? match[1] : null;
        fetchUpdatePage(numberAtEnd);
    }, [location.pathname]);

    useEffect(()=>{
        // console.log(updatePage);
        if (updatePage && updatePage.wikiPage.title) {
            fetchOriginalPage(updatePage.wikiPage.title);
        }
    },[updatePage])

    const fetchUpdatePage = async (id) => {
        try {
            const data = await getUpdatePageById(id, cookies['jwt_token'])
            console.log(data);
            setUpdatePage(data)
        } catch (error) {
          console.error('Error fetching page:', error);
        }
      };

      const fetchOriginalPage = async (title) => {
        try {
            const data = await getWikiPageByTitle(title)
            console.log(data);
            setOriginalPage(data)
        } catch (error) {
          console.error('Error fetching page:', error);
        }
      };

      const handleAccept = () => {
        acceptUserSubmittedUpdate(updatePage, originalPage.id, cookies["jwt_token"])
          .then(() => {
            // setWikiPageTitles(wikiPageTitles.filter((page) => page !== currentWikiPage.Title));
            alert("Succesfully updated page");
            navigate(`/user-updates`);
          })
          .catch((error) => {
            console.error("Error updating WikiPage:", error);
          });
      };

      const handleDecline = () => {
        declineUserSubmittedWikiPage(updatePage.id, cookies["jwt_token"])
          .then(() => {
            // setWikiPageTitles(wikiPageTitles.filter((page) => page !== currentWikiPage.Title));
            alert("Declined Change");
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
            <div style={{display: 'flex'}}>
            {
                originalPage && originalPage.wikiPage && originalPage.wikiPage.legacyWikiPage ?
                (
                    <>
                        <CompareUpdatePageComponent page={originalPage.wikiPage}></CompareUpdatePageComponent>
                        <div style={{ borderRight: '1px solid #ccc', margin: '0 10px' }}></div>
                        <CompareUpdatePageComponent page={updatePage.wikiPage} originalPage={originalPage.wikiPage}></CompareUpdatePageComponent>
                    </>
                ) :
                (
                  <>
                    <WikiPage page={originalPage} disableNavbar={true}></WikiPage>
                    <div style={{ borderRight: '1px solid #ccc', margin: '0 10px' }}></div>
                    <WikiPage page={updatePage} disableNavbar={true}></WikiPage>
                  </>
              )
            }
            </div>
        </>
      )
}

export default CompareUpdatePage;