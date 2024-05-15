import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { getForumPostBySlug } from '../../Api/forumApi';
import ForumCommentComponent from './Components/ForumCommentComponent';
import DisplayProfileImageElement from '../ProfilePage/Components/DisplayProfileImageElement';
import "./Styles/forumpost.css"

const ForumPost = ({cookies}) => {
    const [post, setPost] = useState(null);
    const { slug } = useParams();

    useEffect(() => {
        const fetchForumPost = async () => {
            try {
                const fetchedPost = await getForumPostBySlug(slug);
                console.log(fetchedPost);
                setPost(fetchedPost);
            } catch (error) {
                console.error("Error fetching post:", error);
            }
        };

        fetchForumPost();
    }, [slug]);

    if (!post) {
        return <div>Loading...</div>;
    }

    return (
        <>
        <div className="forumpost-grid">
            <div className="fp-grid-header">
                <div className="fp-header-cell">Author</div>
                <div className="fp-header-cell">Message</div>
            </div>
            <div className="fp-grid-row">
                <div className="fp-grid-cell"><Link to={`/profile/${post.userName}`}>{post.user.displayName}</Link></div>
                <div className="fp-grid-cell">
                    <div className='fp-grid-cell-left'>Post Subject: {post.postTitle}</div>
                    <div className='fp-grid-cell-right'>Posted: {new Date(post.postDate).toLocaleString()}</div>
                </div>
            </div>
            <div className="fp-grid-row">
                <div className="fp-grid-cell">
                    <DisplayProfileImageElement profilePicture={post.user.profilePicture}/>
                </div>
                <div className="fp-grid-cell">{post.content}</div>
            </div>
            
            
            <ForumCommentComponent post={post} cookies={cookies}/>
        </div>
        </>
    );
};

export default ForumPost;