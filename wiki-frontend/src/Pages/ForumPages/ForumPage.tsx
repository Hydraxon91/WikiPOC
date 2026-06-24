import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { getForumTopicBySlug } from '../../Api/forumApi';
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

    useEffect(() => {
        fetchForumTopic();
    }, []);

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
        post.comments.forEach(comment => {
            if (!latestComment || new Date(comment.postDate) > new Date(latestComment.postDate)) {
                latestComment = comment;
            }
        });

        const userProfile = latestComment.userProfile ? latestComment.userProfile : latestComment.user;

        if (!userProfile) {
            return <div>No comments yet</div>;
        }

        const utcDate = new Date(latestComment.postDate + 'Z');
        const diffInMinutes = Math.floor((Number(new Date()) - Number(utcDate)) / (1000 * 60));
        const formattedDate = diffInMinutes < 60 ? `${diffInMinutes} minutes ago` : formatDate(latestComment.postDate);

        return (
            <>
                <div>{formattedDate}</div>
                <Link to={`/profile/${userProfile.userName}`}><div>{userProfile.displayName}</div></Link>
            </>
        );
    };

    const indexOfLastPost = currentPage * postsPerPage;
    const indexOfFirstPost = indexOfLastPost - postsPerPage;
    const currentPosts = topic.forumPosts && topic.forumPosts.slice(indexOfFirstPost, indexOfLastPost);
    const totalPages = topic.forumPosts ? Math.ceil(topic.forumPosts.length / postsPerPage) : 0;

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
    

    if (loading) return <LoadingSpinner text="Loading forum topic..." />;

    return (
        <div className='forum-mainsection'>
            <Breadcrumbs />
            <ForumPostButton buttonTitle="New Topic" linkTo={`/forum/${slug}/create-topic`} jwtToken={jwtToken} />
            <div className="forum-grid article" style={{ backgroundColor: styles.articleColor }}>
                <div className="grid-header">
                    <div className="header-cell">Topics</div>
                    <div className="header-cell">Replies</div>
                    <div className="header-cell">Author</div>
                    <div className="header-cell">Last Post</div>
                </div>
                {currentPosts && currentPosts.map(post => (
                    <div className="grid-row" key={post.id}>
                        <div className="grid-cell title">
                            <Link to={`/forum/${slug}/${post.slug}`}><div className='topicTitle'>{post.postTitle}</div></Link>
                        </div>
                        <div className="grid-cell">{post.comments.length}</div>
                        <div className="grid-cell"><Link to={`/profile/${post.user.userName}`}><div>{post.user.displayName}</div></Link></div>
                        <div className="grid-cell">{getLatestComment(post)}</div>
                    </div>
                ))}
            </div>
            {topic.forumPosts && renderPagination(totalPages, currentPage, setCurrentPage, postsPerPage, topic.forumPosts.length)}
        </div>
    );
};

export default ForumPage;
