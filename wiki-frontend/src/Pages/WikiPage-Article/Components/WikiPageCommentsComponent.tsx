import { useEffect, useState } from 'react';
import { useUserContext } from '../../../Components/contexts/UserContextProvider';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import { getUserProfileByUsername, postEditedComment, postComment } from '../../../Api/wikiUserApi';
import WikiPageSubmitCommentComponent from './WikiPageSubmitCommentComponent';
import UserCommentComponent from './UserCommentComponent';

const WikiPageCommentsComponent = ({ page, jwtToken, activeTab, refreshPage }) => {
    const { decodedTokenContext } = useUserContext();
    const { styles } = useStyleContext();
    const [user, setUser] = useState();
    const [currPage, setCurrPage] = useState(page);
    const [showRepliesIndex, setShowRepliesIndex] = useState({});
    const [commentPage, setCommentPage] = useState(1);
    const [commentsPerPage] = useState(5);
    const [sortOrder, setSortOrder] = useState('newest');

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
            <div className="pagination" style={{ marginTop: '1em' }}>
                <button onClick={() => setCommentPage(c => Math.max(1, c - 1))} disabled={commentPage === 1}>Previous</button>
                {Array.from({ length: totalPages }, (_, i) => i + 1).map(page => (
                    <button key={page} onClick={() => setCommentPage(page)} className={commentPage === page ? 'active' : ''}>{page}</button>
                ))}
                <button onClick={() => setCommentPage(c => Math.min(totalPages, c + 1))} disabled={commentPage === totalPages}>Next</button>
            </div>
        );
    };

    return (
        <div className={activeTab === 'comments' ? 'wikipage-component' : 'wikipage-component wikipage-hidden'}>
            {currPage && (
                <div>
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
                            page={page}
                            index={index}
                            showRepliesIndex={showRepliesIndex}
                            toggleRepliesIndex={toggleRepliesIndex}
                        />
                    ))}
                    {renderPagination()}
                </div>
            )}
        </div>
    );
};

export default WikiPageCommentsComponent;
