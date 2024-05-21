import React, { useEffect, useState } from 'react';
import { useUserContext } from '../../../Components/contexts/UserContextProvider';
import { getUserProfileByUsername } from '../../../Api/wikiUserApi';
import { postForumComment, postEditedForumComment } from '../../../Api/forumApi';
import { Link } from 'react-router-dom';
import { format } from 'date-fns';
import DisplayProfileImageElement from '../../ProfilePage/Components/DisplayProfileImageElement';
import ForumSubmitCommentComponent from './ForumSubmitCommentComponent';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import "../Styles/forumpost.css"

const ForumCommentComponent = ({post, cookies, isPopupVisible, togglePopupVisibility, quotedPostId, setQuotedPostMethod}) =>{
    const {decodedTokenContext} = useUserContext();
    const [user, setUser] = useState();
    const [currPost, setCurrPost] = useState(post);
    const { styles } = useStyleContext();
    const maxQuoteDepth = 1;

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

      const renderQuote = (comment, currentDepth, maxDepth) => {
        if (!comment.replyToComment || currentDepth > maxDepth) {
            return null;
        }
    
        return (
            <div className="quoted-comment">
                <p>{comment.replyToComment.userProfile.displayName} wrote:</p>
                <div dangerouslySetInnerHTML={{ __html: comment.replyToComment.content }} />
                {renderQuote(comment.replyToComment, currentDepth + 1, maxDepth)}
            </div>
        );
    };
      return (
        <>
            {currPost && (
                <div>                   
                    {currPost.comments.map((comment, index) => (
                        <div key={index}>
                            {console.log(comment)}
                            <div className="fp-grid">
                                <div className="fp-grid-row">
                                    <div className="fp-grid-cell"><Link to={`/profile/${comment.userProfile.userName}`}>{comment.userProfile.displayName}</Link></div>
                                    <div className="fp-grid-cell firstrow">
                                        <div className='fp-grid-cell-left'>Post Subject: re: {post.postTitle}</div>
                                        <div className='fp-grid-cell-right'>Posted: {formatDate(comment.postDate)}</div>
                                        <button className="quote-button" style={{backgroundColor: styles.articleColor}} onClick={() => setQuotedPostMethod(comment)}>
                                            Quote
                                        </button>
                                    </div>
                                </div>
                                <div className="fp-grid-row">
                                    <div className="fp-grid-cell">
                                        {comment.userProfile?.profilePicture && <DisplayProfileImageElement profilePicture={comment.userProfile.profilePicture}/>}
                                    </div>
                                    <div className="fp-grid-cell" >
                                        {renderQuote(comment, 0, maxQuoteDepth)}
                                        <div dangerouslySetInnerHTML={{ __html: comment.content }}></div>
                                    </div>
                                </div>
                            </div>                            
                        </div>
                    ))}
                    { isPopupVisible && user && <ForumSubmitCommentComponent user={user} page={currPost} cookies={cookies} 
                        handleCommentSubmit={handleCommentSubmit} postComment={postForumComment} 
                        togglePopupVisibility={togglePopupVisibility} quotedPostId={quotedPostId}
                    />}
                </div>
            )}
        </>
    )

}

export default ForumCommentComponent;