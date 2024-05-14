import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getForumPostBySlug } from '../../Api/forumApi';
import ForumCommentComponent from './Components/ForumCommentComponent';

const ForumPost = ({cookies}) => {
    const [post, setPost] = useState(null);
    const { slug } = useParams();

    useEffect(() => {
        const fetchForumPost = async () => {
            try {
                const fetchedPost = await getForumPostBySlug(slug);
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
        <div>
            <h1>Post Subject: {post.postTitle} Posted: {new Date(post.postDate).toLocaleString()}</h1>
            <p>{post.content}</p>
            <p>Posted by: {post.userName}</p>
            <ForumCommentComponent post={post} cookies={cookies}/>
        </div>
    );
};

export default ForumPost;