import { useState } from 'react';
import DisplayProfileImageElement from '../../ProfilePage/Components/DisplayProfileImageElement';
import { useNotification } from '../../../Components/NotificationProvider';
import type { UserProfile, UserComment } from '../../../types/models';
import '../Style/commentreply.css'

interface WikiPageReplyProps {
  user: UserProfile;
  page: { id: string };
  jwtToken: string;
  handleCommentSubmit: () => void;
  postComment: (comment: Partial<UserComment>, jwtToken: string, user: UserProfile) => Promise<unknown>;
  replyTo: { id: string };
  showReplyBoxRemoveIndex: (index: number) => void;
  index?: number;
}

const WikiPageReplyComponent = ({ user, page, jwtToken, handleCommentSubmit, postComment, replyTo, showReplyBoxRemoveIndex, index }: WikiPageReplyProps) => {
    const [commentText, setCommentText] = useState('');
    const { showNotification } = useNotification();

    const handleCommentChange = (event) => {
        setCommentText(event.target.value);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        const newComment = {
            content: commentText,
            userProfileId: user.id,
            wikiPageId: page.id,
            postDate: new Date().toISOString(),
            replyToCommentId: replyTo.id,
            isEdited: false,
        };

        try {
            await postComment(newComment, jwtToken, user);
            setCommentText('');
            handleCommentSubmit();
            showNotification('Successfully submitted comment');
        } catch (error) {
            console.error('Error posting comment:', error);
        }
    };

    return (
        <div className="reply-container">
            <div className="reply-comment-write-container">
                <div className="reply-profile-pic">
                    <DisplayProfileImageElement profilePicture={user.profilePicture} classNameProp={'reply-comment-profilepic'}/>
                </div>
                <div className="reply-comment-write-textarea">
                    <textarea
                        placeholder="Add a reply..."
                        maxLength={1500}
                        name="comment"
                        value={commentText}
                        onChange={handleCommentChange}
                    ></textarea>
                </div>
            </div>
            <div className="reply-buttons">
                <button className="reply-button cancel" onClick={() => showReplyBoxRemoveIndex(index)}>
                    Cancel
                </button>
                <button className="reply-button send" onClick={handleSubmit}>
                    Reply
                </button>
            </div>
        </div>
    );
};

export default WikiPageReplyComponent;
