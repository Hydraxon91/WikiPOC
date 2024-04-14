import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { useCookies } from 'react-cookie';
import WikiPageComponent from '../Pages/WikiPage-Article/Components/WikiPageComponent';
import { acceptUserSubmittedPage, declineUserSubmittedWikiPage, getNewPageById } from '../Api/wikiApi';
const CheckUserSubmittedPage = () => {
    const [cookies] = useCookies(['jwt_token']);
    const [page, setPage] = useState();
    const location = useLocation();
    const navigate = useNavigate();

    useEffect(() => {
        // console.log(location.pathname);
        const match = location.pathname.match(/\/(\d+)$/);
        const numberAtEnd = match ? match[1] : null;
        // console.log(numberAtEnd);
        fetchSubmittedPage(numberAtEnd);
    }, [location.pathname]);


    const fetchSubmittedPage = async (id) => {
        try {
            const data = await getNewPageById(id, cookies['jwt_token'])
            // console.log(data);
            setPage(data);
        } catch (error) {
          console.error('Error fetching page:', error);
        }
      };

      const handleAccept = () => {
        acceptUserSubmittedPage(page, cookies["jwt_token"])
          .then(() => {
            // setWikiPageTitles(wikiPageTitles.filter((page) => page !== currentWikiPage.Title));
            alert("Succesfully Approved Submitted Page");
            navigate(`/user-submissions`);
          })
          .catch((error) => {
            console.error("Error updating WikiPage:", error);
          });
      };

      const handleDecline = () => {
        declineUserSubmittedWikiPage(page.id, cookies["jwt_token"])
          .then(() => {
            // setWikiPageTitles(wikiPageTitles.filter((page) => page !== currentWikiPage.Title));
            alert("Declined Submitted Page");
            navigate(`/user-submissions`);
          })
          .catch((error) => {
            console.error("Error deleting WikiPage:", error);
          });
      };
    return(
        <>
            <div className='compareUpdatePageButtonsDiv'>
                <button className='compareUpdatePageButtons' onClick={() => handleAccept()}>Accept New Page</button>
                <button className='compareUpdatePageButtons' onClick={() => handleDecline()}>Discard New Page</button>
            </div>
            {page &&
                (
                    <>
                        <WikiPageComponent page={page}></WikiPageComponent>
                    </>
                )
            }
        </>
    )
}
export default CheckUserSubmittedPage;