import { useState, useEffect } from 'react';
import ReactQuill from 'react-quill-new';
import 'react-quill-new/dist/quill.snow.css'
import { useNavigate } from 'react-router-dom';
import { createForumPost, createForumTopic } from '../../Api/forumApi';
import { getUserProfileByUsername } from '../../Api/wikiUserApi';
import { useUserContext } from '../../Components/contexts/UserContextProvider';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import "./Styles/createforumtopic.css"
import Breadcrumbs from './Components/Breadcrumbs';

const CreateForumTopic = ({ jwtToken }) => {
    const {decodedTokenContext} = useUserContext();
    const [user, setUser] = useState<any>();
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
            const newTopic = await createForumTopic(
                { title: postTitle, description: postTitle },
                jwtToken
            );

            const forumPost = {
                postTitle,
                content,
                forumTopicId: newTopic.id,
                userId: user!.id,
                userName: user!.userName,
            };

            await createForumPost(forumPost, jwtToken);
            navigate(`/forum/${newTopic.slug}`);
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
        <div className="create-forum-topic fp-custom-popup"  style={{ backgroundColor: styles.articleRightColor, '--article-color': styles.articleColor, '--article-right-color': styles.articleRightColor, '--article-right-inner-color': styles.articleRightInnerColor, '--footer-link-color': styles.footerListLinkTextColor, '--footer-text-color': styles.footerListTextColor } as any}>
            <h2>Create a New Forum Topic</h2>
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
                    <label htmlFor="description">Description:</label>
                    <div className="fp-comment-write-textarea">
                        <ReactQuill
                            id="description"
                            theme="snow"
                            value={content}
                            onChange={setContent}
                            modules={modules}
                            formats={formats}
                        />
                    </div>
                </div>
                {error && <div className="error">{error}</div>}
                <button className="fp-comment-button" type="submit">Create Topic</button>
            </form>
        </div>
        </>
    );
};

export default CreateForumTopic;
