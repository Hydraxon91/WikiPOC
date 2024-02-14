import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { useCookies } from 'react-cookie';
import { toast } from 'react-toastify';
import { getUpdatePageById, getWikiPageByTitle, acceptUserSubmittedUpdate, declineUserSubmittedWikiPage } from '../Api/wikiApi';
import CompareUpdatePageComponent from './CompareUpdatePageComponent';
import '../Styles/compareupdates.css';

const CompareUpdatePage = () => {
    const location = useLocation();
    const navigate = useNavigate();

    const [cookies] = useCookies(['jwt_token']);
    const [originalPage, setOriginalPage] = useState();
    const [updatePage, setUpdatePage] = useState();

    useEffect(() => {
        // console.log(location.pathname);
        const match = location.pathname.match(/\/(\d+)$/);
        const numberAtEnd = match ? match[1] : null;
        // console.log(numberAtEnd);
        fetchUpdatePage(numberAtEnd);
    }, [location.pathname]);

    useEffect(()=>{
        // console.log(updatePage);
        if (updatePage && updatePage.title) {
            fetchOriginalPage(updatePage.title);
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
            const data = await getWikiPageByTitle(title)
            // console.log(data);
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
                originalPage &&
                (
                    <>
                        <CompareUpdatePageComponent page={originalPage}></CompareUpdatePageComponent>
                        <div style={{ borderRight: '1px solid #ccc', margin: '0 10px' }}></div>
                        <CompareUpdatePageComponent page={updatePage} originalPage={originalPage}></CompareUpdatePageComponent>
                    </>
                )
            }
            </div>
        </>
      )
}

export default CompareUpdatePage;