import React, { useEffect, useState } from 'react';
import { useUserContext } from '../../../Components/contexts/UserContextProvider';
import { getUserProfileByUsername, postEditedComment, postComment } from '../../../Api/wikiUserApi';
import { format } from 'date-fns';
import WikiPageSubmitCommentComponent from './WikiPageSubmitCommentComponent';
import DisplayProfileImageElement from '../../ProfilePage/Components/DisplayProfileImageElement';

const WikiPageCommentsComponent = ({page, cookies, activeTab}) =>{
    const {decodedTokenContext} = useUserContext();
    const [user, setUser] = useState();
    const [currPage, setCurrPage] = useState(page);
    const [editingCommentIndex, setEditingCommentIndex] = useState(null);
    const [editedComment, setEditedComment] = useState("");

    useEffect(() => {
        const decodedTokenName = decodedTokenContext?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        if (decodedTokenName) {
            const decodedTokenName = decodedTokenContext["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
            getUserProfileByUsername(decodedTokenName, setUser);
        }
    }, [decodedTokenContext]);

    useEffect(()=>{
        setCurrPage(page);
    },[page])

    const handleEditClick = (index, initialContent) => {
        setEditingCommentIndex(index);
        setEditedComment(initialContent);
    };

    const handleCancelEdit = () => {
        setEditingCommentIndex(null);
        setEditedComment("");
    };

    const handleCommentEditSubmit = (index) => {
        const updatedComments = [...currPage.comments];
        updatedComments[index].content = editedComment;
        
        postEditedComment(updatedComments[index].id, editedComment, cookies);

        setCurrPage((currPage) => ({
            ...currPage,
            comments: updatedComments,
        }));

        setEditingCommentIndex(null);
        setEditedComment("");
    };

    const handleCommentSubmit = (newComment) => {
        const postDate = newComment.postDate.endsWith('Z') ? newComment.postDate.slice(0, -1) : newComment.postDate;
        setCurrPage((currPage) => ({
          ...currPage,
          comments: [...currPage.comments, { ...newComment, postDate }],
        }));
      };

      function formatDate(dateString) {
        // Parse the date string as UTC
        const utcDate = new Date(dateString + 'Z');
        // Format the zoned date
        const formattedDate = format(utcDate, 'EEEE, dd MMM yyyy, HH:mm');
        return formattedDate.replace(/\//g, '-');
      }


    function formatDate(dateString) {
        // Parse the date string as UTC
        const utcDate = new Date(dateString + 'Z');
        // Format the zoned date
        const formattedDate = format(utcDate, 'EEEE, dd MMM yyyy, HH:mm');
        return formattedDate.replace(/\//g, '-');
      }

    return (
        <div className={activeTab === 'comments' ? 'wikipage-component' : 'wikipage-component wikipage-hidden'}>
            {currPage && (
                <div>
                    <h3>Comments</h3>
                    {user?.profilePicture && <WikiPageSubmitCommentComponent user={user} page={currPage} cookies={cookies} handleCommentSubmit={handleCommentSubmit} postComment={postComment}/>}
                    {currPage.comments.map((comment, index) => (
                        <div key={index} className='wikipage-comment'>
                            <div className='wikipage-comment-profilepic'>
                                <DisplayProfileImageElement profilePicture={comment.userProfile.profilePicture}/>
                            </div>
                            <div className='wikipage-comment-content'>
                                <div className='wikipage-comment-data'>
                                    <a href={`/profile/${comment.userProfile.userName}`}>
                                        <span>{comment.userProfile.displayName}</span>
                                        <span> ({comment.userProfile.userName})</span>
                                    </a>
                                    {" | "}
                                    <span>{formatDate(comment.postDate)}</span>
                                    {comment.userProfile.userName === user?.userName && (
                                        editingCommentIndex !== index ? (
                                            <a href="#" onClick={() => handleEditClick(index, comment.content)}> edit</a>
                                        ) : (
                                            <>
                                                <button onClick={() => handleCommentEditSubmit(index)}>Submit</button>
                                                <button onClick={handleCancelEdit}>Cancel</button>
                                            </>
                                        )
                                    )}
                                </div>
                                <div className='wikipage-comment-text'>
                                    {editingCommentIndex === index ? (
                                        <textarea value={editedComment} onChange={(e) => setEditedComment(e.target.value)} />
                                    ) : (
                                        <p>{comment.content} {comment.isEdited && "(edited)"}</p>
                                    )}
                                </div>
                            </div>
                            
                        </div>
                    ))}
                </div>
            )}
        </div>
    )
};

export default WikiPageCommentsComponent;