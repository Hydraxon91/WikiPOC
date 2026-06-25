import { useEffect, useState } from 'react';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import { useUserContext } from '../../Components/contexts/UserContextProvider';
import { Link } from 'react-router-dom';
import { getForumTopics } from '../../Api/forumApi';
import { formatDate } from '../../utils/formatDate';
import Breadcrumbs from './Components/Breadcrumbs';
import LoadingSpinner from '../../Components/LoadingSpinner';
import './Styles/forumlandingpage.css';

const ForumLandingPage = () => {
    const [topics, setTopics] = useState([]);
    const [loading, setLoading] = useState(true);
    const {styles} = useStyleContext();
    const { decodedTokenContext } = useUserContext();
    const isAdmin = decodedTokenContext?.role === 'Admin';

    useEffect(() => {
        fetchForumTopics();
    }, []);

    // useEffect(() => {
    // }, [topics]);
    
    const getCommentsLength = (topic) =>{
        var counter = 0;
        (topic.forumPosts || []).forEach(post => {
            counter += post.comments.length;
        });
        return counter;
    }

    const getLatestComment = (topic) => {
        let latestComment = null;
        (topic.forumPosts || []).forEach(post => {
            // Check if the forum post itself is the latest
            if (!latestComment || (post.postDate && new Date(post.postDate) > new Date(latestComment.postDate))) {
                latestComment = post;
            }
            // Check each comment within the post
            post.comments.forEach(comment => {
                if (!latestComment || new Date(comment.postDate) > new Date(latestComment.postDate)) {
                    latestComment = comment;
                }
            });
        });
        
        if (!latestComment) {
            return (
                <div>No comments yet</div>
            );
        }
    
        const userProfile = latestComment.userProfile ? latestComment.userProfile : latestComment.user; 
    
        // Parse the date string as UTC
        const utcDate = new Date(latestComment.postDate + 'Z');
        // Calculate time difference in minutes
        const diffInMinutes = Math.floor((Number(new Date()) - Number(utcDate)) / (1000 * 60));
        // Format the zoned date
        const formattedDate = diffInMinutes < 60 ? `${diffInMinutes} minutes ago` : formatDate(latestComment.postDate);
    
        return (
            <>
                <div>{formattedDate}</div>
                <Link to={`/profile/${userProfile.userName}`}><div>{userProfile.displayName}</div></Link>
            </>
        );
    };
    

    const fetchForumTopics = async () =>{
        setLoading(true);
        try {
            const fetchedTopics = await getForumTopics();
            setTopics(fetchedTopics);
        } catch (error) {
            console.error("Error fetching Topics:", error);
        } finally {
            setLoading(false);
        }
    };

    if (loading) return <LoadingSpinner text="Loading topics..." />;

    return (
        <div className='forum-mainsection' style={{ '--article-color': styles.articleColor, '--article-right-color': styles.articleRightColor, '--article-right-inner-color': styles.articleRightInnerColor, '--footer-link-color': styles.footerListLinkTextColor, '--footer-text-color': styles.footerListTextColor } as any}> 
        <Breadcrumbs/>
        {isAdmin && (
          <div style={{ textAlign: 'right', marginBottom: '8px' }}>
            <Link to="/forum/main-forum/create-topic" className="modular-button" style={{ backgroundColor: styles.articleColor, padding: '8px 16px', borderRadius: '4px', color: '#fff', textDecoration: 'none' }}>
              Create New Topic
            </Link>
          </div>
        )}
        <div className="forum-grid article" style={{backgroundColor: styles.articleColor}}>
            <div className="grid-header">
                <div className="header-cell">Forum</div>
                <div className="header-cell">Topics</div>
                <div className="header-cell">Posts</div>
                <div className="header-cell">Last Post</div>
            </div>
            {topics.map(topic => (
                <div className="grid-row" key={topic.id}>
                    <div className="grid-cell title">
                        <span className="topic-status read"></span>
                        <div className="topic-content">
                            <Link to={`/forum/${topic.slug}`}><div className='topicTitle'>{topic.title}</div></Link>
                            <div className="topic-description">{topic.description}</div>
                        </div>
                    </div>
                    <div className="grid-cell">{(topic.forumPosts || []).length}</div>
                    <div className="grid-cell">{(topic.forumPosts || []).length + getCommentsLength(topic)}</div>
                    <div className="grid-cell">{getLatestComment(topic)}</div>
                </div>
            ))}
        </div>
        </div>
    );
}

export default ForumLandingPage;