import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import { useCookies } from 'react-cookie';
import { getUpdatePageById, getWikiPageByTitle } from '../Api/wikiApi';
import WikiPageComponent from './WikiPageComponent';

const CompareUpdatePage = () => {
    const location = useLocation();
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

      return (
        <div style={{display: 'flex'}}>
        {
            originalPage &&
            (
                <>
                    <WikiPageComponent page={originalPage}></WikiPageComponent>
                    <div style={{ borderRight: '1px solid #ccc', margin: '0 10px' }}></div>
                    <WikiPageComponent page={updatePage}></WikiPageComponent>
                </>
            )
        }
        </div>
      )
}

export default CompareUpdatePage;