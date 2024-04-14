import React, { useState } from 'react';
import DisplayProfileImageElement from '../../ProfilePage/Components/DisplayProfileImageElement';
import { postComment } from '../../../Api/wikiUserApi';

const WikiPageSubmitCommentComponent = ({ user, page, cookies, handleCommentSubmit }) => {
    const [commentText, setCommentText] = useState('');

    const handleCommentChange = (event) => {
        setCommentText(event.target.value);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        const newComment = {
            content: commentText,
            userProfileId: user.id,
            wikiPageId: page.id,
            postDate: new Date(),
            isReply: false,
            replyToCommentId: null,
            isEdited: false,
        };

        try {
            await postComment(newComment, cookies);
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
                <div className="wikipage-comment-profilepic">
                    <DisplayProfileImageElement profilePicture={user.profilePicture}/>
                </div>
                <div className="comment-write-textarea">
                    <textarea
                        maxLength="1500"
                        name="comment"
                        value={commentText}
                        onChange={handleCommentChange}
                    ></textarea>
                    <p className="comment-write-counter">
                        <span id="comment-counter">{commentText.length}</span>/1500
                    </p>
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

export default WikiPageSubmitCommentComponent;
