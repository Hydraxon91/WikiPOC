import { useState } from 'react';
import ReactQuill from 'react-quill-new';
import { useNotification } from '../../../Components/NotificationProvider';
import EraAwareButton from '../../../Components/LiquidGlassButton/EraAwareButton';
import "../Styles/forumsubmintcommentcomponent.css"

const ForumSubmitCommentComponent = ({ user, page, jwtToken, handleCommentSubmit, postComment, quotedPostId, resetQuotedPostId, inline }) => {
    const [commentText, setCommentText] = useState('');
    const { showNotification } = useNotification();

    const handleCommentChange = (event) => {
        setCommentText(event);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        const newComment = {
            content: commentText,
            userProfileId: user.id,
            wikiPageId: page.id,
            postDate: new Date().toISOString(),
            isReply: false,
            replyToCommentId: quotedPostId,
            isEdited: false,
        };
        try {
            await postComment(newComment, jwtToken, user);
            setCommentText('');
            handleCommentSubmit();
            resetQuotedPostId && resetQuotedPostId();
            showNotification('Successfully submitted comment');
        } catch (error) {
            console.error('Error posting comment:', error);
        }
    };

    const modules = {
        toolbar: [
            [{ 'header': [1, 2, false] }],
            [{ 'font': [] }],
            ['image'],
        ],
        clipboard: {
            matchVisual: false,
        }
    };

    const formats = [
        'header', 'font', 'image'
    ];

    if (inline) {
        return (
            <div className="fp-inline-form" id="forum-reply-form">
                {quotedPostId && (
                    <div className="fp-inline-quote-notice">
                        Replying to a quoted comment — <button type="button" className="fp-cancel-quote" onClick={() => resetQuotedPostId && resetQuotedPostId()}>cancel quote reply</button>
                    </div>
                )}
                <form autoComplete="off" method="post" encType="multipart/form-data" onSubmit={handleSubmit}>
                    <div className="fp-comment-write-container">
                        <div className="fp-comment-write-textarea">
                            <ReactQuill
                                theme="snow"
                                onChange={handleCommentChange}
                                value={commentText}
                                modules={modules}
                                formats={formats}
                            />
                        </div>
                    </div>
                    <div className="fp-inline-buttons">
                        <EraAwareButton type="submit">Submit Comment</EraAwareButton>
                    </div>
                </form>
            </div>
        );
    }

    return (
        <div className='fp-custom-popup-overlay'>
            <div className="fp-custom-popup">
                <form autoComplete="off" method="post" encType="multipart/form-data" onSubmit={handleSubmit}>
                    <div className="fp-comment-write-container">
                        <div className="fp-comment-write-textarea">
                            <ReactQuill
                                theme="snow"
                                onChange={handleCommentChange}
                                value={commentText}
                                modules={modules}
                                formats={formats}
                            />
                        </div>
                    </div>
                    <EraAwareButton type="submit">Submit Comment</EraAwareButton>
                    <EraAwareButton className='fp-comment-button right' onClick={() => resetQuotedPostId && resetQuotedPostId()}>Cancel</EraAwareButton>
                </form>
            </div>
        </div>
    );
};

export default ForumSubmitCommentComponent;
