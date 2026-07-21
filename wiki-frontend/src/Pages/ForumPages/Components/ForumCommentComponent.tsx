import React, { useEffect, useState } from 'react';
import { useUserContext } from '../../../Components/contexts/UserContextProvider';
import { getUserProfileByUsername } from '../../../Api/wikiUserApi';
import { flagForumComment, postForumComment } from '../../../Api/forumApi';
import { Link } from 'react-router-dom';
import { format } from 'date-fns';
import { formatDate } from '../../../utils/formatDate';
import DisplayProfileImageElement from '../../ProfilePage/Components/DisplayProfileImageElement';
import ForumSubmitCommentComponent from './ForumSubmitCommentComponent';
import FlagCommentModal from '../../../Components/FlagCommentModal';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import type { UserProfile } from '../../../types/models';
import "../Styles/forumpost.css";

const ForumCommentComponent = ({ post, jwtToken, quotedPostId, setQuotedPostMethod, resetQuotedPostId, refreshPost }) => {
    const { decodedTokenContext } = useUserContext();
    const [user, setUser] = useState<UserProfile | undefined>();
    const [currPost, setCurrPost] = useState(post);
    const { styles } = useStyleContext();
    const maxQuoteDepth = 1;

    const [currentPage, setCurrentPage] = useState(1);
    const [commentsPerPage] = useState(20);
    const [flaggingCommentId, setFlaggingCommentId] = useState<string | null>(null);

    useEffect(() => {
        const decodedTokenName = decodedTokenContext?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        if (decodedTokenName) {
            getUserProfileByUsername(decodedTokenName, setUser);
        }
    }, [decodedTokenContext]);

    useEffect(() => {
        setCurrPost(post);
    }, [post]);

    const handleCommentSubmit = () => {
        if (refreshPost) refreshPost();
    };

    const handleFlagSubmit = async (commentId: string, reason: string) => {
        await flagForumComment(commentId, reason, jwtToken);
        setFlaggingCommentId(null);
    };

    const handleContentClick = (e) => {
        const img = e.target.closest('img');
        if (img && !img.closest('.forum-profilepic')) {
            img.classList.toggle('fp-expanded');
        }
    };

    const renderQuote = (comment, currentDepth, maxDepth) => {
        if (!comment.replyToCommentId || currentDepth >= maxDepth) {
            return null;
        }

        const replyComment = currPost.comments.find(c => c.id === comment.replyToCommentId);
        if (!replyComment || replyComment.isDeleted) {
            return (
                <div className="quoted-comment">
                    <p><em>[Quoted message has been deleted]</em></p>
                </div>
            );
        }
        
        return (
            <div className="quoted-comment">
                <p>{replyComment.userProfile.displayName} wrote:</p>
                <div dangerouslySetInnerHTML={{ __html: replyComment.content }} />
                {renderQuote(replyComment, currentDepth + 1, maxDepth)}
            </div>
        );
    };

    const indexOfLastComment = currentPage * commentsPerPage;
    const indexOfFirstComment = indexOfLastComment - commentsPerPage;
    const currentComments = currPost.comments.slice(indexOfFirstComment, indexOfLastComment);
    const totalPages = Math.ceil(currPost.comments.length / commentsPerPage);


    const renderPagination = (totalPages, currentPage, setCurrentPage, postsPerPage, postsLength) => {
        const indexOfLastPost = currentPage * postsPerPage;
    
        return (
            <div className="pagination">
                {totalPages > 1 && (
                    <>
                        <button onClick={() => setCurrentPage(currentPage - 1)} disabled={currentPage === 1}>Previous</button>
                        {Array.from({ length: totalPages }, (_, i) => i + 1).map((page) => (
                            <>
                                {(page === 1 || page === totalPages || (page >= currentPage - 2 && page <= currentPage + 2)) && (
                                    <button key={page} onClick={() => setCurrentPage(page)} className={currentPage === page ? "active" : ""}>{page}</button>
                                )}
                                {page === 1 && currentPage >= 5 && <span>...</span>}
                            </>
                        ))}
                        <button onClick={() => setCurrentPage(currentPage + 1)} disabled={indexOfLastPost >= postsLength}>Next</button>
                    </>
                )}
            </div>
        );
    };

    return (
        <>
            {currPost && (
                <div>
                    {currentComments.map((comment, index) => {
                        const postNumber = (currentPage - 1) * commentsPerPage + index + 1;
                        return (
                        <div key={index}>
                            <div className="fp-grid">
                                <div className="fp-grid-row">
                                    <div className="post-author-sidebar">
                                        <DisplayProfileImageElement profilePicture={comment.userProfile?.profilePicture} classNameProp={'forum-profilepic'} />
                                        <div className="post-author-name">
                                            <Link to={`/profile/${comment.userProfile.userName}`}>{comment.userProfile.displayName}</Link>
                                        </div>
                                        <div className="post-author-title">Member</div>
                                        <div className="post-author-stats">
                                            <span>Posts: {comment.userProfile?.postCount ?? 0}</span>
                                            {comment.userProfile?.joinDate && (
                                                <span>Joined: {format(new Date(comment.userProfile.joinDate.replace(/Z$/, '') + 'Z'), 'MMM yyyy')}</span>
                                            )}
                                        </div>
                                    </div>
                                    <div className="post-content-area" onClick={handleContentClick}>
                                        <div className="post-mobile-author">
                                            <DisplayProfileImageElement profilePicture={comment.userProfile?.profilePicture} classNameProp={'forum-mobile-profilepic'} />
                                            <span className="post-mobile-author-name">
                                                Posted by <Link to={`/profile/${comment.userProfile.userName}`}>{comment.userProfile.displayName}</Link>
                                                &middot; Posts: {comment.userProfile?.postCount ?? 0}
                                                {comment.userProfile?.joinDate && (
                                                    <> &middot; Joined: {format(new Date(comment.userProfile.joinDate.replace(/Z$/, '') + 'Z'), 'MMM yyyy')}</>
                                                )}
                                            </span>
                                        </div>
                                        <div className="post-meta">
                                            <span className="post-subject">#{postNumber} re: {post.postTitle}</span>
                                            <span className="post-date">Posted: {formatDate(comment.postDate)}</span>
                                        </div>
                                        {renderQuote(comment, 0, maxQuoteDepth)}
                                        {comment.isDeleted ? (
                                            <p className="deleted-comment-message"><em>[This comment has been deleted]</em></p>
                                        ) : (
                                            <div dangerouslySetInnerHTML={{ __html: comment.content }}></div>
                                        )}
                                        {!comment.isDeleted && (
                                        <div className="post-actions">
                                            <button className="quote-button" style={{ backgroundColor: styles.articleColor }} onClick={(e) => { e.stopPropagation(); setQuotedPostMethod(comment); }}>Quote</button>
                                            {jwtToken && (
                                                <button className="flag-button" onClick={(e) => { e.stopPropagation(); setFlaggingCommentId(comment.id); }}>Flag</button>
                                            )}
                                        </div>
                                        )}
                                        {flaggingCommentId === comment.id && (
                                            <FlagCommentModal
                                                onSubmit={async (reason) => { await handleFlagSubmit(comment.id, reason); }}
                                                onCancel={() => setFlaggingCommentId(null)}
                                            />
                                        )}
                                    </div>
                                </div>
                            </div>
                        </div>
                        );
                    })}
                    {renderPagination(totalPages, currentPage, setCurrentPage, commentsPerPage, currPost.comments.length)}
                    {user && <ForumSubmitCommentComponent user={user} page={currPost} jwtToken={jwtToken}
                        handleCommentSubmit={handleCommentSubmit} postComment={postForumComment}
                        quotedPostId={quotedPostId} resetQuotedPostId={resetQuotedPostId}
                        inline={true}
                    />}
                </div>
            )}
        </>
    );
};

export default ForumCommentComponent;
