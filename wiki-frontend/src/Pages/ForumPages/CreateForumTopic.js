import React, { useState, useEffect } from 'react';
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css'
import { useNavigate, useParams } from 'react-router-dom';
import { createForumPost, getForumTopicBySlug } from '../../Api/forumApi';
import { getUserProfileByUsername } from '../../Api/wikiUserApi';
import { useUserContext } from '../../Components/contexts/UserContextProvider';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import "./Styles/createforumtopic.css"

const CreateForumTopic = ({ cookies }) => {
    const {decodedTokenContext} = useUserContext();
    const { slug } = useParams();
    const [forumTopic, setForumTopic] = useState(null);
    const [user, setUser] = useState();
    const [postTitle, setPostTitle] = useState('');
    const [content, setContent] = useState('');
    const [error, setError] = useState(null);
    const {styles} = useStyleContext();
    const navigate = useNavigate();

    useEffect(() => {
        const decodedTokenName = decodedTokenContext?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        if (decodedTokenName) {
            const decodedTokenName = decodedTokenContext["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
            getUserProfileByUsername(decodedTokenName, setUser);
        }
    }, [decodedTokenContext]);

    useEffect(() => {
        const fetchForumTopic = async () => {
            try {
                const fetchedForumTopic = await getForumTopicBySlug(slug);
                setForumTopic(fetchedForumTopic);
            } catch (error) {
                console.error("Error fetching ForumTopic:", error);
            }
        };
    
        fetchForumTopic();
    }, [slug]);
    

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

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError(null);

        const forumPost = {
            postTitle,
            content,
            forumTopic,
            forumTopicId: forumTopic.id,
            userId: user.id,
            userName: user.userName,
            user: user,
            slug: ''
        };

        try {
            await createForumPost(forumPost, cookies);
            navigate('/forum'); // Redirect to forum page after successful creation
        } catch (err) {
            setError(err.message);
        }
    };

    return (
        <div className="create-forum-topic"  style={{ backgroundColor: styles.articleRightColor}}>
            <h2>Create a New Forum Topic</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="title">Title:</label>
                    <input
                        type="text"
                        id="title"
                        value={postTitle}
                        onChange={(e) => setPostTitle(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="description">Description:</label>
                    <ReactQuill
                        id="description"
                        value={content}
                        onChange={setContent}
                        modules={modules}
                        formats={formats}
                        required
                    />
                </div>
                {error && <div className="error">{error}</div>}
                <button type="submit">Create Topic</button>
            </form>
        </div>
    );
};

export default CreateForumTopic;
