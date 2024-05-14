import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getForumPostBySlug } from '../../Api/forumApi';

const ForumPost = () => {
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
            <h1>{post.postTitle}</h1>
            <p>{post.content}</p>
            <p>Posted by: {post.userName}</p>
            <p>Post Date: {new Date(post.postDate).toLocaleString()}</p>
            <h2>Comments</h2>
            {post.comments.length > 0 ? (
                post.comments.map(comment => (
                    <div key={comment.id}>
                        <p>{comment.content}</p>
                        <p>Commented by: {comment.userName}</p>
                        <p>Comment Date: {new Date(comment.commentDate).toLocaleString()}</p>
                    </div>
                ))
            ) : (
                <p>No comments yet.</p>
            )}
        </div>
    );
};

export default ForumPost;