import { useEffect, useState } from 'react';
import { useUserContext } from '../../../Components/contexts/UserContextProvider';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import { getUserProfileByUsername, postEditedComment, postComment } from '../../../Api/wikiUserApi';
import type { UserProfile } from '../../../types/models';
import WikiPageSubmitCommentComponent from './WikiPageSubmitCommentComponent';
import UserCommentComponent from './UserCommentComponent';

const getCommentsPerPage = () => {
    const h = window.innerHeight;
    if (h < 700) return 4;
    if (h < 900) return 5;
    return 6;
};

const useCommentsPerPage = () => {
    const [count, setCount] = useState(getCommentsPerPage());
    useEffect(() => {
        const handler = () => setCount(getCommentsPerPage());
        window.addEventListener('resize', handler);
        return () => window.removeEventListener('resize', handler);
    }, []);
    return count;
};

const WikiPageCommentsComponent = ({ page, jwtToken, activeTab, refreshPage }) => {
    const { decodedTokenContext } = useUserContext();
    const { styles } = useStyleContext();
    const [user, setUser] = useState<UserProfile | undefined>();
    const [currPage, setCurrPage] = useState(page);
    const [showRepliesIndex, setShowRepliesIndex] = useState({});
    const [commentPage, setCommentPage] = useState(1);
    const commentsPerPage = useCommentsPerPage();
    const [sortOrder, setSortOrder] = useState('newest');
    const [focusedCommentId, setFocusedCommentId] = useState(null);

    useEffect(() => {
        setCommentPage(1);
    }, [currPage, sortOrder]);

    useEffect(() => {
        const decodedTokenName = decodedTokenContext?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        if (decodedTokenName) {
            getUserProfileByUsername(decodedTokenName, setUser);
        }
    }, [decodedTokenContext]);

    useEffect(() => {
        setCurrPage(page);
    }, [page]);

    const handleCommentSubmit = () => {
        if (refreshPage) refreshPage();
    };

    const toggleRepliesIndex = (index) => {
        setShowRepliesIndex(prevState => ({
            ...prevState,
            [index]: !prevState[index]
        }));
    };

    const rawTopLevel = currPage?.comments?.filter(c => !c.replyToCommentId) || [];
    const sorted = [...rawTopLevel].sort((a, b) => {
        const diff = new Date(a.postDate).getTime() - new Date(b.postDate).getTime();
        return sortOrder === 'newest' ? -diff : diff;
    });
    const totalPages = Math.ceil(sorted.length / commentsPerPage);
    const indexOfLast = commentPage * commentsPerPage;
    const indexOfFirst = indexOfLast - commentsPerPage;
    const currentComments = sorted.slice(indexOfFirst, indexOfLast);

    const renderPagination = () => {
        if (totalPages <= 1) return null;
        return (
            <div className="pagination" style={{ marginTop: 'auto', paddingTop: '1em' }}>
                <button onClick={() => setCommentPage(c => Math.max(1, c - 1))} disabled={commentPage === 1}>Previous</button>
                {Array.from({ length: totalPages }, (_, i) => i + 1).map(page => (
                    <button key={page} onClick={() => setCommentPage(page)} className={commentPage === page ? 'active' : ''}>{page}</button>
                ))}
                <button onClick={() => setCommentPage(c => Math.min(totalPages, c + 1))} disabled={commentPage === totalPages}>Next</button>
            </div>
        );
    };

    const focusedComment = focusedCommentId
        ? currPage?.comments?.find(c => c.id === focusedCommentId)
        : null;

    return (
        <div className={activeTab === 'comments' ? 'wikipage-component' : 'wikipage-component wikipage-hidden'}>
            {currPage && (
                <div style={{ display: 'flex', flexDirection: 'column', flex: 1 }}>
                    {focusedComment ? (
                        <div className="focused-reply-view">
                            <button onClick={() => setFocusedCommentId(null)} style={{ background: 'none', border: 'none', cursor: 'pointer', padding: 0, fontSize: '0.9em', marginBottom: '0.5em', color: styles.footerListLinkTextColor }}>← Back to comments</button>
                            <UserCommentComponent
                                key={focusedComment.id}
                                comment={focusedComment}
                                user={user}
                                jwtToken={jwtToken}
                                handleCommentSubmit={handleCommentSubmit}
                                postComment={postComment}
                                postEditedComment={postEditedComment}
                                page={page}
                                index={-1}
                                showRepliesIndex={showRepliesIndex}
                                toggleRepliesIndex={toggleRepliesIndex}
                                setFocusedCommentId={setFocusedCommentId}
                                isFocused={true}
                            />
                        </div>
                    ) : (
                        <div className="comments-list-view" style={{ display: 'flex', flexDirection: 'column', flex: 1 }}>
                            <h3>Comments</h3>
                            <select value={sortOrder} onChange={e => setSortOrder(e.target.value)} style={{ marginBottom: '0.5em', padding: '0.2em 0.5em', background: styles.articleColor, color: '#fff', border: 'none', borderRadius: '3px', fontSize: '90%', cursor: 'pointer' }}>
                                <option value="newest">Newest first</option>
                                <option value="oldest">Oldest first</option>
                            </select>
                            {user && <WikiPageSubmitCommentComponent user={user} page={currPage} jwtToken={jwtToken} handleCommentSubmit={handleCommentSubmit} postComment={postComment} />}
                            {currentComments.map((comment, index) => (
                                <UserCommentComponent
                                    key={comment.id}
                                    comment={comment}
                                    user={user}
                                    jwtToken={jwtToken}
                                    handleCommentSubmit={handleCommentSubmit}
                                    postComment={postComment}
                                    postEditedComment={postEditedComment}
                                    page={page}
                                    index={index}
                                    showRepliesIndex={showRepliesIndex}
                                    toggleRepliesIndex={toggleRepliesIndex}
                                    setFocusedCommentId={setFocusedCommentId}
                                />
                            ))}
                            {renderPagination()}
                        </div>
                    )}
                    <style>{`
                        .focused-reply-view, .comments-list-view {
                            animation: commentFadeIn 0.4s ease;
                        }
                        @keyframes commentFadeIn {
                            from { opacity: 0; transform: translateY(8px); }
                            to { opacity: 1; transform: translateY(0); }
                        }
                    `}</style>
                </div>
            )}
        </div>
    );
};

export default WikiPageCommentsComponent;
