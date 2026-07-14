import { useState, useEffect, CSSProperties } from 'react';
import ReactQuill from 'react-quill-new';
import 'react-quill-new/dist/quill.snow.css'
import { useNavigate, useParams } from 'react-router-dom';
import { createForumPost, getForumTopicBySlug } from '../../Api/forumApi';
import { getUserProfileByUsername } from '../../Api/wikiUserApi';
import { useUserContext } from '../../Components/contexts/UserContextProvider';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import type { UserProfile } from '../../types/models';
import EraAwareButton from '../../Components/LiquidGlassButton/EraAwareButton';
import "./Styles/createforumtopic.css"
import Breadcrumbs from './Components/Breadcrumbs';

const CreatePostPage = ({ jwtToken }) => {
    const { decodedTokenContext } = useUserContext();
    const { slug } = useParams();
    const [user, setUser] = useState<UserProfile | undefined>();
    const [postTitle, setPostTitle] = useState('');
    const [content, setContent] = useState('');
    const [error, setError] = useState(null);
    const {styles} = useStyleContext();
    const navigate = useNavigate();

    useEffect(() => {
        const decodedTokenName = decodedTokenContext?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        if (decodedTokenName) {
            getUserProfileByUsername(decodedTokenName, setUser);
        }
    }, [decodedTokenContext]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError(null);

        if (!postTitle || !content || !user) return;

        try {
            const topic = await getForumTopicBySlug(slug);
            const forumPost = {
                postTitle,
                content,
                forumTopicId: topic.id,
                userId: user!.id,
                userName: user!.userName,
            };

            const newPost = await createForumPost(forumPost, jwtToken);
            navigate(`/forum/${slug}/${newPost.slug}`);
        } catch (err) {
            setError(err.message);
        }
    };

    const modules = {
        toolbar: [
            [{ 'header': '1'}, {'header': '2'}, {'font': []}],
            [{size: []}],
            ['bold', 'italic', 'underline', 'strike', 'blockquote'],
            [{'list': 'ordered'}, {'list': 'bullet'}, {'indent': '-1'}, {'indent': '+1'}],
            ['link', 'image', 'video'],
            ['clean']
        ],
    };

    const formats = [
        'header', 'font', 'size',
        'bold', 'italic', 'underline', 'strike', 'blockquote',
        'list', 'bullet', 'indent',
        'link', 'image', 'video'
    ];

    return (
        <>
        <Breadcrumbs/>
        <div className="create-forum-topic fp-custom-popup"  style={{ backgroundColor: styles.articleRightColor, '--article-color': styles.articleColor, '--article-right-color': styles.articleRightColor, '--article-right-inner-color': styles.articleRightInnerColor, '--footer-link-color': styles.footerListLinkTextColor, '--footer-text-color': styles.footerListTextColor } as CSSProperties}>
            <h2>Create a New Post</h2>
            <form onSubmit={handleSubmit}>
                <div className="fp-comment-write-textarea">
                    <label htmlFor="title">Title:</label>
                    <input
                        type="text"
                        id="title"
                        value={postTitle}
                        onChange={(e) => setPostTitle(e.target.value)}
                        required
                    />
                </div>
                <div className="fp-comment-write-container">
                    <label htmlFor="content">Content:</label>
                    <div className="fp-comment-write-textarea">
                        <ReactQuill
                            id="content"
                            theme="snow"
                            value={content}
                            onChange={setContent}
                            modules={modules}
                            formats={formats}
                        />
                    </div>
                </div>
                {error && <div className="error">{error}</div>}
                <EraAwareButton className="fp-comment-button" type="submit">Create Post</EraAwareButton>
            </form>
        </div>
        </>
    );
};

export default CreatePostPage;
