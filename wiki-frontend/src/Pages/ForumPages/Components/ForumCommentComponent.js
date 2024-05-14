import React, { useEffect, useState } from 'react';
import { useUserContext } from '../../../Components/contexts/UserContextProvider';
import { getUserProfileByUsername } from '../../../Api/wikiUserApi';
import { postForumComment, postEditedForumComment } from '../../../Api/forumApi';
import DisplayProfileImageElement from '../../ProfilePage/Components/DisplayProfileImageElement';
import WikiPageSubmitCommentComponent from '../../WikiPage-Article/Components/WikiPageSubmitCommentComponent';

const ForumCommentComponent = ({post, cookies}) =>{
    const {decodedTokenContext} = useUserContext();
    const [user, setUser] = useState();
    const [currPost, setCurrPost] = useState(post);
    const [editingCommentIndex, setEditingCommentIndex] = useState(null);
    const [editedComment, setEditedComment] = useState("");

    useEffect(() => {
        const decodedTokenName = decodedTokenContext?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        console.log(decodedTokenName);
        if (decodedTokenName) {
            const decodedTokenName = decodedTokenContext["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
            getUserProfileByUsername(decodedTokenName, setUser);
        }
    }, [decodedTokenContext]);

    useEffect(()=>{
        setCurrPost(post);
    },[post])

    const handleEditClick = (index, initialContent) => {
        setEditingCommentIndex(index);
        setEditedComment(initialContent);
    };

    const handleCancelEdit = () => {
        setEditingCommentIndex(null);
        setEditedComment("");
    };

    const handleCommentEditSubmit = (index) => {
        const updatedComments = [...currPost.comments];
        updatedComments[index].content = editedComment;
        
        postEditedForumComment(updatedComments[index].id, editedComment, cookies); //Needs to be implemented

        setCurrPost((currPost) => ({
            ...currPost,
            comments: updatedComments,
        }));

        setEditingCommentIndex(null);
        setEditedComment("");
    };

    const handleCommentSubmit = (newComment) => {
        setCurrPost((currPost) => ({
          ...currPost,
          comments: [...currPost.comments, newComment],
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
        <div className={'comments wikipage-component'}>
            {currPost && (
                <div>
                    <h3>Comments</h3>
                    {user?.profilePicture && <WikiPageSubmitCommentComponent user={user} page={currPost} cookies={cookies} handleCommentSubmit={handleCommentSubmit} postComment={postForumComment}/>}
                    {currPost.comments.map((comment, index) => (
                        <div key={index} className='wikipage-comment'>
                            <div className='wikipage-comment-profilepic'>
                            {user?.profilePicture && <DisplayProfileImageElement profilePicture={comment.userProfile.profilePicture}/>}
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

}

export default ForumCommentComponent;