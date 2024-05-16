import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { getForumPostBySlug } from '../../Api/forumApi';
import ForumCommentComponent from './Components/ForumCommentComponent';
import DisplayProfileImageElement from '../ProfilePage/Components/DisplayProfileImageElement';
import { format } from 'date-fns';
import Breadcrumbs from './Components/Breadcrumbs';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import "./Styles/forumpost.css"

const ForumPost = ({cookies}) => {
    const [post, setPost] = useState(null);
    const { slug, postSlug } = useParams();
    const {styles} = useStyleContext();
    const [isPopupVisible, setIsPopupVisible] = useState(false);

    useEffect(() => {
        const fetchForumPost = async () => {
            try {
                const fetchedPost = await getForumPostBySlug(postSlug);
                setPost(fetchedPost);
            } catch (error) {
                console.error("Error fetching post:", error);
            }
        };

        fetchForumPost();
    }, [postSlug]);

    const togglePopupVisibility = () => {
        setIsPopupVisible(!isPopupVisible);
    };

    function formatDate(dateString) {
        // Parse the date string as UTC
        const utcDate = new Date(dateString + 'Z');
        // Format the zoned date
        const formattedDate = format(utcDate, 'EEEE, dd MMM yyyy, HH:mm');
        return formattedDate.replace(/\//g, '-');
      }

    if (!post) {
        return <div>Loading...</div>;
    }

    return (
        <>
            <Breadcrumbs/>
            <button className="modular-button" style={{backgroundColor: styles.articleColor}} onClick={togglePopupVisibility}>
                Post Reply
            </button>
            <div className="fp-grid">
                <div className="fp-grid-header">
                    <div className="fp-header-cell">Author</div>
                    <div className="fp-header-cell">Message</div>
                </div>
                <div className="fp-grid-row">
                    <div className="fp-grid-cell"><Link to={`/profile/${post.userName}`}>{post.user.displayName}</Link></div>
                    <div className="fp-grid-cell firstrow">
                        <div className='fp-grid-cell-left'>Post Subject: {post.postTitle}</div>
                        <div className='fp-grid-cell-right'>Posted: {formatDate(post.postDate)}</div>
                    </div>
                </div>
                <div className="fp-grid-row">
                    <div className="fp-grid-cell">
                        <DisplayProfileImageElement profilePicture={post.user.profilePicture}/>
                    </div>
                    <div className="fp-grid-cell" dangerouslySetInnerHTML={{ __html: post.content }}></div>
                </div>
            </div>
            <ForumCommentComponent post={post} cookies={cookies} isPopupVisible={isPopupVisible} togglePopupVisibility={togglePopupVisibility}/>
        </>
    );
};

export default ForumPost;