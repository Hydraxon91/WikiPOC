import React, { useEffect, useState } from 'react';
import { useUserContext } from './contexts/UserContextProvider';
import { getUserProfileByUsername, postEditedComment } from '../Api/wikiUserApi';
import WikiPageSubmitCommentComponent from './WikiPageSubmitCommentComponent';
import DisplayProfileImageElement from './DisplayProfileImageElement';

const WikiPageCommentsComponent = ({page, cookies}) =>{
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

    },[page.comments])

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
        setCurrPage((currPage) => ({
          ...currPage,
          comments: [...currPage.comments, newComment],
        }));
      };


    function formatDate(dateString) {
        const options = {
          year: 'numeric',
          month: '2-digit',
          day: '2-digit',
          hour: '2-digit',
          minute: '2-digit',
          second: '2-digit',
          timeZoneName: 'short',
        };
      
        const formattedDate = new Intl.DateTimeFormat('en-UK', options).format(new Date(dateString));
        return formattedDate.replace(/\//g, '-');
      }

    return (
        <div className='wikipage-component'>
            {currPage && (
                <div>
                    <h3>Comments</h3>
                    {user?.profilePicture && <WikiPageSubmitCommentComponent user={user} page={currPage} cookies={cookies} handleCommentSubmit={handleCommentSubmit}/>}
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