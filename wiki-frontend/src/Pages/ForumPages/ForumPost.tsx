import { useEffect, useState, CSSProperties } from 'react';
import { useParams } from 'react-router-dom';
import { getForumPostBySlug } from '../../Api/forumApi';
import ForumCommentComponent from './Components/ForumCommentComponent';
import Breadcrumbs from './Components/Breadcrumbs';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import { useNotification } from '../../Components/NotificationProvider';
import { usePageMeta } from '../../hooks/usePageMeta';
import EraAwareButton from '../../Components/LiquidGlassButton/EraAwareButton';
import "./Styles/forumpost.css"

const ForumPost = ({jwtToken}) => {
    const [post, setPost] = useState(null);
    const { postSlug } = useParams();
    const {styles} = useStyleContext();
    const [quotedPostId, setQuotedPostId] = useState(null);
    const { showNotification } = useNotification();

    const stripHtml = (html) => {
        if (!html) return '';
        const doc = new DOMParser().parseFromString(html, 'text/html');
        return doc.body.textContent || '';
    };

    usePageMeta(
        post?.postTitle || undefined,
        post?.content ? stripHtml(post.content).substring(0, 200) : undefined
    );

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

    const scrollToReplyForm = () => {
        if (!jwtToken) {
            showNotification('You need to log in to post a reply.');
        } else {
            setQuotedPostId(null);
            const formElement = document.getElementById('forum-reply-form');
            if (formElement) formElement.scrollIntoView({ behavior: 'smooth' });
        }
    };

    const setQuotedPostMethod = (comment) => {
        if (!jwtToken) {
            showNotification('You need to log in to post a reply.');
        } else {
            setQuotedPostId(comment.id);
            setTimeout(() => {
                const formElement = document.getElementById('forum-reply-form');
                if (formElement) formElement.scrollIntoView({ behavior: 'smooth' });
            }, 0);
        }
    }

    if (!post) {
        return <div>Loading...</div>;
    }

    return (
        <div className='forum-mainsection' style={{ '--article-color': styles.articleColor, '--article-right-color': styles.articleRightColor, '--article-right-inner-color': styles.articleRightInnerColor, '--footer-link-color': styles.footerListLinkTextColor, '--footer-text-color': styles.footerListTextColor } as CSSProperties}>
            <Breadcrumbs/>
            <EraAwareButton
                onClick={scrollToReplyForm}
                style={{ backgroundColor: styles.articleColor }}
            >
                Post Reply
            </EraAwareButton>
            <ForumCommentComponent post={post} jwtToken={jwtToken}
                quotedPostId={quotedPostId} setQuotedPostMethod={setQuotedPostMethod}
                resetQuotedPostId={() => setQuotedPostId(null)} refreshPost={fetchForumPost}
            />
        </div>
    );
};

export default ForumPost;