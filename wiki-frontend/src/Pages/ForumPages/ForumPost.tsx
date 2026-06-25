import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getForumPostBySlug } from '../../Api/forumApi';
import ForumCommentComponent from './Components/ForumCommentComponent';
import Breadcrumbs from './Components/Breadcrumbs';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import { useNotification } from '../../Components/NotificationProvider';
import "./Styles/forumpost.css"

const ForumPost = ({jwtToken}) => {
    const [post, setPost] = useState(null);
    const { postSlug } = useParams();
    const {styles} = useStyleContext();
    const [quotedPostId, setQuotedPostId] = useState(null);
    const [isPopupVisible, setIsPopupVisible] = useState(false);
    const { showNotification } = useNotification();

    const fetchForumPost = async () => {
        try {
            const fetchedPost = await getForumPostBySlug(postSlug);
            setPost(fetchedPost);
        } catch (error) {
            console.error("Error fetching post:", error);
        }
    };

    useEffect(() => {
        fetchForumPost();
    }, [postSlug]);

    const togglePopupVisibility = () => {
        if (!jwtToken) {
            showNotification('You need to log in to post a reply.');
        } else {
            setIsPopupVisible(!isPopupVisible);
        }
    };

    const setQuotedPostMethod = (comment) => {
        if (!jwtToken) {
            showNotification('You need to log in to post a reply.');
        } else {
            setQuotedPostId(comment.id);
            setIsPopupVisible(!isPopupVisible);
        }
    }

    if (!post) {
        return <div>Loading...</div>;
    }

    return (
        <div className='forum-mainsection' style={{ '--article-color': styles.articleColor, '--article-right-color': styles.articleRightColor, '--article-right-inner-color': styles.articleRightInnerColor, '--footer-link-color': styles.footerListLinkTextColor, '--footer-text-color': styles.footerListTextColor } as any}>
            <Breadcrumbs/>
            <button className="modular-button" style={{backgroundColor: styles.articleColor}} onClick={() => { setQuotedPostId(null); togglePopupVisibility(); }}>
                Post Reply
            </button>
            <ForumCommentComponent post={post} jwtToken={jwtToken} isPopupVisible={isPopupVisible} 
                togglePopupVisibility={togglePopupVisibility} quotedPostId={quotedPostId} setQuotedPostMethod={setQuotedPostMethod}
                resetQuotedPostId={() => setQuotedPostId(null)} refreshPost={fetchForumPost}
            />
        </div>
    );
};

export default ForumPost;