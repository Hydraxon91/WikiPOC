import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { getForumTopicBySlug } from '../../Api/forumApi';
import './Styles/forumlandingpage.css';

const ForumPage = () => {
    const [topic, setTopic] = useState([]);
    const { slug } = useParams();

    useEffect(() => {
        console.log(slug);
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

    return (
        <div className="forum-grid">
            <div className="grid-header">
                <div className="header-cell">Topics</div>
                <div className="header-cell">Comments</div>
                <div className="header-cell">Author</div>
                <div className="header-cell">Last Comment</div>
            </div>
            {topic && topic.forumPosts && topic.forumPosts.map(post =>(
                <div className="grid-row" key={post.id}>
                    <div className="grid-cell title">
                        <Link to={`/forum/post/${post.slug}`}><div className='topicTitle'>{post.postTitle}</div></Link>
                    </div>
                    <div className="grid-cell">{post.comments.length}</div>
                    <div className="grid-cell">{post.userName}</div>
                    <div className="grid-cell">{topic.lastPostDate}</div>
                </div>
            ))}
        </div>
    );
}

export default ForumPage;
