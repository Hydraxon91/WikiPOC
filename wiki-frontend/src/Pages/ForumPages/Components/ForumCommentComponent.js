import React, { useEffect, useState } from 'react';
import { useUserContext } from '../../../Components/contexts/UserContextProvider';
import { getUserProfileByUsername } from '../../../Api/wikiUserApi';
import { postForumComment, postEditedForumComment } from '../../../Api/forumApi';
import { Link } from 'react-router-dom';
import { format } from 'date-fns';
import DisplayProfileImageElement from '../../ProfilePage/Components/DisplayProfileImageElement';
import ForumSubmitCommentComponent from './ForumSubmitCommentComponent';
import "../Styles/forumpost.css"

const ForumCommentComponent = ({post, cookies}) =>{
    const {decodedTokenContext} = useUserContext();
    const [user, setUser] = useState();
    const [currPost, setCurrPost] = useState(post);

    useEffect(() => {
        const decodedTokenName = decodedTokenContext?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        if (decodedTokenName) {
            const decodedTokenName = decodedTokenContext["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
            getUserProfileByUsername(decodedTokenName, setUser);
        }
    }, [decodedTokenContext]);

    useEffect(()=>{
        setCurrPost(post);
    },[post])

    const handleCommentSubmit = (newComment) => {
        console.log(newComment);
        const postDate = newComment.postDate.endsWith('Z') ? newComment.postDate.slice(0, -1) : newComment.postDate;
        setCurrPost((currPost) => ({
            ...currPost,
            comments: [...currPost.comments, { ...newComment, postDate }],
        }));
      };
      

      const formatDate = (dateString) => {
        // Parse the date string as UTC
        const utcDate = new Date(dateString + 'Z');
        // Format the zoned date
        const formattedDate = format(utcDate, 'EEEE, dd MMM yyyy, HH:mm');
        return formattedDate.replace(/\//g, '-');
      }

      const renderContent = (htmlContent) => {
        // Parse the HTML content string into a DOM element
        const parser = new DOMParser();
        const doc = parser.parseFromString(htmlContent, 'text/html');
        
        // Convert <p> elements to <div> elements
        const divElements = Array.from(doc.querySelectorAll('p')).map((pElement, index) => (
            <div key={index} className="paragraph">{pElement.innerHTML}</div>
        ));
    
        // Return the array of <div> elements
        return divElements;
    };

      return (
        <>
            {currPost && (
                <div>                   
                    {currPost.comments.map((comment, index) => (
                        <div key={index}>
                            <div className="fp-grid">
                                <div className="fp-grid-row">
                                    <div className="fp-grid-cell"><Link to={`/profile/${comment.userProfile.userName}`}>{comment.userProfile.displayName}</Link></div>
                                    <div className="fp-grid-cell firstrow">
                                        <div className='fp-grid-cell-left'>Post Subject: re: {post.postTitle}</div>
                                        <div className='fp-grid-cell-right'>Posted: {formatDate(comment.postDate)}</div>
                                    </div>
                                </div>
                                <div className="fp-grid-row">
                                    <div className="fp-grid-cell">
                                        {comment.userProfile?.profilePicture && <DisplayProfileImageElement profilePicture={comment.userProfile.profilePicture}/>}
                                    </div>
                                    <div className="fp-grid-cell" dangerouslySetInnerHTML={{ __html: comment.content }}></div>
                                </div>
                            </div>                            
                        </div>
                    ))}
                    {user && <ForumSubmitCommentComponent user={user} page={currPost} cookies={cookies} handleCommentSubmit={handleCommentSubmit} postComment={postForumComment}/>}
                </div>
            )}
        </>
    )

}

export default ForumCommentComponent;