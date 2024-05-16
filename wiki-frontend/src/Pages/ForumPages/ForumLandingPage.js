import React, { useEffect, useState } from 'react';
import ForumBreadcrumbs from './Components/Breadcrumbs';
import { Link } from 'react-router-dom';
import { getForumTopics } from '../../Api/forumApi';
import { format } from 'date-fns';
import './Styles/forumlandingpage.css';

const ForumLandingPage = () => {
    const [topics, setTopics] = useState([]);

    useEffect(() => {
        fetchForumTopics();
    }, []);

    useEffect(() => {
        console.log(topics);
    }, [topics]);
    
    const getCommentsLength = (topic) =>{
        var counter = 0;
        topic.forumPosts.forEach(post => {
            counter += post.comments.length;
        });
        return counter;
    }

    const getLatestComment = (topic) =>{
        var latestComment = null;
        topic.forumPosts.forEach(post => {
            post.comments.forEach(comment => {
                if (!latestComment || new Date(comment.postDate) > new Date(latestComment.postDate)) {
                    latestComment = comment;
                }
            });
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

    const fetchForumTopics = async () =>{
        try {
            const fetchedTopics = await getForumTopics();
            setTopics(fetchedTopics);
        } catch (error) {
            console.error("Error fetching Topics:", error);
        }
    };

    return (
        <div className="forum-grid">
            <div className="grid-header">
                <div className="header-cell">Forum</div>
                <div className="header-cell">Posts</div>
                <div className="header-cell">Comments</div>
                <div className="header-cell">Last Comment</div>
            </div>
            {topics.map(topic => (
                <div className="grid-row" key={topic.id}>
                    <div className="grid-cell title">
                        <Link to={`/forum/${topic.slug}`}><div className='topicTitle'>{topic.title}</div></Link>
                        <div>{topic.description}</div>
                    </div>
                    <div className="grid-cell">{topic.forumPosts.length}</div>
                    <div className="grid-cell">{getCommentsLength(topic)}</div>
                    <div className="grid-cell">{getLatestComment(topic)}</div>
                </div>
            ))}
        </div>
    );
}

export default ForumLandingPage;