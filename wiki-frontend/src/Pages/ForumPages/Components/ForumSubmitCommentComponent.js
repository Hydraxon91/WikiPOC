import React, { useState } from 'react';
import DisplayProfileImageElement from '../../ProfilePage/Components/DisplayProfileImageElement';
import ReactQuill from 'react-quill';

const ForumSubmitCommentComponent = ({ user, page, cookies, handleCommentSubmit, postComment }) => {
    const [commentText, setCommentText] = useState('');

    const handleCommentChange = (event) => {
        setCommentText(event);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        const newComment = {
            content: commentText,
            userProfileId: user.id,
            // userProfile: user,
            wikiPageId: page.id,
            postDate: new Date().toISOString(),
            isReply: false,
            replyToCommentId: null,
            isEdited: false,
        };

        try {
            console.log(newComment);
            await postComment(newComment, cookies, user);
            setCommentText('');
            newComment.userProfile = user;
            handleCommentSubmit(newComment);
            alert('Successfully submitted comment');
        } catch (error) {
            console.error('Error posting comment:', error);
        }
    };

    return (
        <form autoComplete="off" method="post" encType="multipart/form-data" onSubmit={handleSubmit}>
            <div className="comment-write-container">
                {/* <div className="wikipage-comment-profilepic">
                    <DisplayProfileImageElement profilePicture={user.profilePicture}/>
                </div> */}
                <div className="comment-write-textarea">
                    <ReactQuill
                        onChange={handleCommentChange}
                    />
                </div>
            </div>
            <button className="comment-button" type="submit">
                <span className="btn-left"></span>
                <span className="btn-center">
                    <span>Send</span>
                </span>
                <span className="btn-right"></span>
            </button>
        </form>
    );
};

export default ForumSubmitCommentComponent;
