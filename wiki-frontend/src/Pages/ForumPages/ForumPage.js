import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { getForumTopicBySlug } from '../../Api/forumApi';
import { format } from 'date-fns';
import ForumPostButton from './Components/ForumPostButton';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import Breadcrumbs from './Components/Breadcrumbs';
import './Styles/forumlandingpage.css';

const ForumPage = () => {
    const [topic, setTopic] = useState([]);
    const { slug } = useParams();
    const {styles} = useStyleContext();
    const [currentPage, setCurrentPage] = useState(1);
    const [postsPerPage] = useState(3);

    useEffect(() => {
        fetchForumTopic();
    }, []);

    const fetchForumTopic = async () =>{
        try {
            const fetchedTopic = await getForumTopicBySlug(slug);
            setTopic(fetchedTopic);
        } catch (error) {
            console.error("Error fetching Topics:", error);
        }
    };

    const getLatestComment = (post) => {
        let latestComment = null;
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
        
        const userProfile = latestComment.userProfile ? latestComment.userProfile : latestComment.user;

        if (!userProfile) {
            return (
                <div>No comments yet</div>
            );
        }

        // Parse the date string as UTC
        const utcDate = new Date(latestComment.postDate + 'Z');
        // Calculate time difference in minutes
         const diffInMinutes = Math.floor((new Date() - utcDate) / (1000 * 60));

        // Format the zoned date
        const formattedDate = diffInMinutes < 60 ? `${diffInMinutes} minutes ago` : format(utcDate, 'EEEE, dd MMM yyyy, HH:mm');

    
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

    return (
        <>
            <Breadcrumbs/>
            <ForumPostButton buttonTitle="New Topic" linkTo={`/forum/${slug}/create-topic`} />
            <div className="forum-grid article" style={{backgroundColor: styles.articleColor}}>
                <div className="grid-header">
                    <div className="header-cell">Topics</div>
                    <div className="header-cell">Replies</div>
                    <div className="header-cell">Author</div>
                    <div className="header-cell">Last Comment</div>
                </div>
                {currentPosts && currentPosts.map(post =>(
                    <div className="grid-row" key={post.id}>
                        <div className="grid-cell title">
                            <Link to={`/forum/${slug}/${post.slug}`}><div className='topicTitle'>{post.postTitle}</div></Link>
                        </div>
                        <div className="grid-cell">{post.comments.length}</div>
                        <div className="grid-cell">{post.userName}</div>
                        <div className="grid-cell">{getLatestComment(post)}</div>
                    </div>
                ))}
            </div>
            <div className="pagination">
                {topic.forumPosts && topic.forumPosts.length > postsPerPage && (
                    <button onClick={() => setCurrentPage(currentPage - 1)} disabled={currentPage === 1}>
                        Prev
                    </button>
                )}
                {topic.forumPosts && topic.forumPosts.length > postsPerPage && (
                    <button onClick={() => setCurrentPage(currentPage + 1)} disabled={indexOfLastPost >= topic.forumPosts.length}>
                        Next
                    </button>
                )}
            </div>
        </>
    );
}

export default ForumPage;
