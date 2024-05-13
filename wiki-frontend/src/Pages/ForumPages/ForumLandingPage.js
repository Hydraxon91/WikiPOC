import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { getForumTopics } from '../../Api/forumApi';
import './Styles/forumlandingpage.css';

const ForumLandingPage = () => {
    const [topics, setTopics] = useState([]);

    useEffect(() => {
        fetchForumTopics();
    }, []);
    
    useEffect(() => {
        console.log(topics);
    }, [topics]);

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
                     <div>{topic.title}</div>
                     <div>{topic.description}</div>
                    </div>
                    <div className="grid-cell">{topic.forumPosts.length}</div>
                    <div className="grid-cell">{topic.forumPosts.length}</div>
                    <div className="grid-cell">{topic.lastPostDate}</div>
                </div>
            ))}
        </div>
    );
}

export default ForumLandingPage;