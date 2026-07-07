import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { getForumTopicBySlug } from '../../Api/forumApi';
import { searchForumPosts } from '../../Api/wikiSearch';
import { formatDate } from '../../utils/formatDate';
import ForumPostButton from './Components/ForumPostButton';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import Breadcrumbs from './Components/Breadcrumbs';
import LoadingSpinner from '../../Components/LoadingSpinner';
import './Styles/forumlandingpage.css';

const ForumPage = ({ jwtToken }) => {
    const [topic, setTopic] = useState<any>(null);
    const [loading, setLoading] = useState(true);
    const { slug } = useParams();
    const { styles } = useStyleContext();
    const [currentPage, setCurrentPage] = useState(1);
    const [postsPerPage] = useState(30);
    const [searchQuery, setSearchQuery] = useState('');
    const [searchResults, setSearchResults] = useState(null);

    useEffect(() => {
        fetchForumTopic();
    }, []);

    useEffect(() => {
        if (!searchQuery.trim() || !topic) {
            setSearchResults(null);
            return;
        }
        const timer = setTimeout(async () => {
            try {
                const results = await searchForumPosts(topic.id, searchQuery);
                setSearchResults(results);
            } catch {
                setSearchResults([]);
            }
        }, 300);
        return () => clearTimeout(timer);
    }, [searchQuery, topic]);

    const fetchForumTopic = async () => {
        setLoading(true);
        try {
            const fetchedTopic = await getForumTopicBySlug(slug);
            setTopic(fetchedTopic);
        } catch (error) {
            console.error("Error fetching Topics:", error);
        } finally {
            setLoading(false);
        }
    };

    const getLatestComment = (post) => {
        let latestComment = null;
        if (!latestComment || (post.postDate && new Date(post.postDate) > new Date(latestComment.postDate))) {
            latestComment = post;
        }
        (post.comments || []).forEach(comment => {
            if (!latestComment || new Date(comment.postDate) > new Date(latestComment.postDate)) {
                latestComment = comment;
            }
        });

        const userProfile = latestComment.userProfile ? latestComment.userProfile : latestComment.user;

        if (!userProfile) {
            return <div>No comments yet</div>;
        }

        const utcDate = new Date(latestComment.postDate.replace(/Z$/, '') + 'Z');
        const diffInMinutes = Math.floor((Number(new Date()) - Number(utcDate)) / (1000 * 60));
        const formattedDate = diffInMinutes < 60 ? `${diffInMinutes} minutes ago` : formatDate(latestComment.postDate);

        return (
            <>
                <div>{formattedDate}</div>
                <Link to={`/profile/${userProfile.userName}`}><div>{userProfile.displayName}</div></Link>
            </>
        );
    };

    const displayPosts = searchResults !== null ? searchResults : topic?.forumPosts;

    const indexOfLastPost = currentPage * postsPerPage;
    const indexOfFirstPost = indexOfLastPost - postsPerPage;
    const currentPosts = displayPosts?.slice(indexOfFirstPost, indexOfLastPost);
    const totalPages = displayPosts ? Math.ceil(displayPosts.length / postsPerPage) : 0;

    const renderPagination = (totalPages, currentPage, setCurrentPage, postsPerPage, postsLength) => {
        return (
            <div className="pagination">
                {totalPages > 1 && (
                    <>
                        <button onClick={() => setCurrentPage(currentPage - 1)} disabled={currentPage === 1}>Previous</button>
                        {Array.from({ length: totalPages }, (_, i) => i + 1).map((page) => (
                            <div key={page}>
                                {(page === 1 || page === totalPages || (page >= currentPage - 2 && page <= currentPage + 2)) && (
                                    <button key={page} onClick={() => setCurrentPage(page)} className={currentPage === page ? "active" : ""}>{page}</button>
                                )}
                                {page === 1 && currentPage >= 5 && <span>...</span>}
                            </div>
                        ))}
                        <button onClick={() => setCurrentPage(currentPage + 1)} disabled={indexOfLastPost >= postsLength}>Next</button>
                    </>
                )}
            </div>
        );
    };

    if (loading) return <LoadingSpinner text="Loading forum topic..." />;

    return (
        <div className='forum-mainsection' style={{ '--article-color': styles.articleColor, '--article-right-color': styles.articleRightColor, '--article-right-inner-color': styles.articleRightInnerColor, '--footer-link-color': styles.footerListLinkTextColor, '--footer-text-color': styles.footerListTextColor } as any}>
            <Breadcrumbs />
            <ForumPostButton buttonTitle="Create Post" linkTo={`/forum/${slug}/create-post`} jwtToken={jwtToken} />
            <input
                type="text"
                placeholder="Search posts in this topic..."
                value={searchQuery}
                onChange={(e) => setSearchQuery(e.target.value)}
                style={{ width: '100%', padding: '0.5em', marginBottom: '0.5em', marginTop: '0.5em', fontSize: '1em', border: '1px solid ' + styles.footerListLinkTextColor, borderRadius: '4px', backgroundColor: styles.bodyColor, color: '#fff', fontFamily: styles.fontFamily, boxSizing: 'border-box', outline: 'none' }}
            />
            <div className="forum-grid article" style={{ backgroundColor: styles.articleColor }}>
                <div className="grid-header">
                    <div className="header-cell">Topics</div>
                    <div className="header-cell">Replies</div>
                    <div className="header-cell">Author</div>
                    <div className="header-cell">Last Post</div>
                </div>
                {currentPosts?.length === 0 ? (
                    <div className="grid-row" style={{ padding: '1em', textAlign: 'center', color: styles.footerListTextColor }}>
                        {searchQuery ? 'No posts match your search.' : 'No posts in this topic yet.'}
                    </div>
                ) : (
                    currentPosts && currentPosts.map(post => (
                        <div className="grid-row" key={post.id}>
                            <div className="grid-cell title">
                                <span className="topic-status read"></span>
                                <div className="topic-content">
                                    <Link to={`/forum/${slug}/${post.slug}`}><div className='topicTitle'>{post.postTitle}</div></Link>
                                </div>
                            </div>
                            <div className="grid-cell">{post.comments.length}</div>
                            <div className="grid-cell"><Link to={`/profile/${post.user?.userName}`}><div>{post.user?.displayName}</div></Link></div>
                            <div className="grid-cell">{getLatestComment(post)}</div>
                        </div>
                    ))
                )}
            </div>
            {displayPosts && renderPagination(totalPages, currentPage, setCurrentPage, postsPerPage, displayPosts.length)}
        </div>
    );
};

export default ForumPage;
