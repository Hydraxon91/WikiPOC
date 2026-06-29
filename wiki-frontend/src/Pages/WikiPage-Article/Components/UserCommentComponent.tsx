import { useState } from 'react';
import { formatDate } from '../../../utils/formatDate';
import WikiPageReplyComponent from './WikiPageReplyComponent';
import DisplayProfileImageElement from '../../ProfilePage/Components/DisplayProfileImageElement';

const UserCommentComponent = ({ comment, user, jwtToken, handleCommentSubmit, postComment, postEditedComment, page, index, showRepliesIndex, toggleRepliesIndex, setFocusedCommentId, isFocused = false }) => {
    const [editingCommentIndex, setEditingCommentIndex] = useState(null);
    const [editedComment, setEditedComment] = useState("");
    const [showReplyBox, setShowReplyBox] = useState(false);

    const handleEditClick = (initialContent) => {
        setEditingCommentIndex(index);
        setEditedComment(initialContent);
    };

    const handleCancelEdit = () => {
        setEditingCommentIndex(null);
        setEditedComment("");
    };

    const handleCommentEditSubmit = async () => {
        try {
            await postEditedComment(comment.id, editedComment, jwtToken);
            setEditingCommentIndex(null);
            setEditedComment("");
            handleCommentSubmit();
        } catch (error) {
            console.error('Error editing comment:', error);
        }
    };

    return (
        <div className='wikipage-comment'>
            <div className='wikipage-comment-profilepic'>
                <DisplayProfileImageElement profilePicture={comment.userProfile.profilePicture} classNameProp={'wikipage-comment-profilepic'} />
            </div>
            <div className='wikipage-comment-content'>
                <div className='wikipage-comment-data'>
                    <a href={`/profile/${comment.userProfile.userName}`}>
                        <span>{comment.userProfile.displayName}</span>
                        <span> ({comment.userProfile.userName})</span>
                    </a>
                    {" | "}
                    <span>{formatDate(comment.postDate)}</span>
                </div>
                <div className='wikipage-comment-text'>
                    {editingCommentIndex === index ? (
                        <>
                            <textarea value={editedComment} onChange={(e) => setEditedComment(e.target.value)} />
                            <div>
                                <button onClick={handleCommentEditSubmit}>Save</button>
                                <button onClick={handleCancelEdit}>Cancel</button>
                            </div>
                        </>
                        ) : (
                        <p>{comment.content} {comment.isEdited && "(edited)"}</p>
                        )}
                </div>
                { user && comment.userProfile && user.id === comment.userProfile.id && editingCommentIndex !== index && (<div>
                    <a href="#" onClick={() => handleEditClick(comment.content)}> Edit</a>
                </div>)}
                { user && (<div>
                    <a href="#" onClick={() => setShowReplyBox(!showReplyBox)}> Reply</a>
                </div>)}
                {showReplyBox && (
                    <WikiPageReplyComponent user={user} page={page} jwtToken={jwtToken} handleCommentSubmit={handleCommentSubmit} postComment={postComment} replyTo={comment} showReplyBoxRemoveIndex={() => setShowReplyBox(false)} index={index} />
                )}
                {comment.replies && comment.replies.length > 0 && !isFocused &&
                    <a href="#" onClick={(e) => { e.preventDefault(); if (setFocusedCommentId) setFocusedCommentId(comment.id); }}>View Replies ({comment.replies.length})</a>
                }
                {(isFocused || showRepliesIndex[index]) && comment.replies && comment.replies.length > 0 &&
                    comment.replies.map((reply, replyIndex) => (
                        <div key={replyIndex} className='wikipage-reply'>
                            <div className='wikipage-reply-profile'>
                                <div className='wikipage-comment-profilepic'>
                                    <DisplayProfileImageElement profilePicture={reply.userProfile.profilePicture} classNameProp={'reply-comment-profilepic'} />
                                </div>
                            </div>
                            <div className='wikipage-reply-content'>
                                <div className='wikipage-comment-data'>
                                    <a href={`/profile/${reply.userProfile.userName}`}>
                                        <span>{reply.userProfile.displayName}</span>
                                        <span> ({reply.userProfile.userName})</span>
                                    </a>
                                </div>
                                <div className='wikipage-comment-text'>
                                    <p>{reply.content}</p>
                                </div>
                            </div>
                        </div>
                    ))
                }
            </div>
        </div>
    );
};

export default UserCommentComponent;
