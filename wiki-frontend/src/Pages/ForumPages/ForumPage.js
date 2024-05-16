import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { getForumTopicBySlug } from '../../Api/forumApi';
import { format } from 'date-fns';
import ForumPostButton from './Components/ForumPostButton';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import './Styles/forumlandingpage.css';

const ForumPage = () => {
    const [topic, setTopic] = useState([]);
    const { slug } = useParams();
    const {styles} = useStyleContext();

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

    const getLatestComment = (post) =>{
        var latestComment = null;

        post.comments.forEach(comment => {
            if (!latestComment || new Date(comment.postDate) > new Date(latestComment.postDate)) {
                latestComment = comment;
            }
        });   


        if (!latestComment) {
            return (
                <div>No comments yet</div>
            )
        }

        // Parse the date string as UTC
        const utcDate = new Date(latestComment.postDate + 'Z');
        // Format the zoned date
        const formattedDate = format(utcDate, 'EEEE, dd MMM yyyy, HH:mm');

        return (
            <>
             <div>{formattedDate}</div>
             <Link to={`/profile/${latestComment.userProfile.userName}`}><div>{latestComment.userProfile.displayName}</div></Link>
            </>
        )
    }

    return (
        <>
            <ForumPostButton buttonTitle="New Topic" linkTo={`/forum/${slug}/create-topic`} />
            <div className="forum-grid article" style={{backgroundColor: styles.articleColor}}>
                <div className="grid-header">
                    <div className="header-cell">Topics</div>
                    <div className="header-cell">Replies</div>
                    <div className="header-cell">Author</div>
                    <div className="header-cell">Last Comment</div>
                </div>
                {topic && topic.forumPosts && topic.forumPosts.map(post =>(
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
        </>
    );
}

export default ForumPage;
