import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createForumTopic } from '../../Api/forumApi';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import EraAwareButton from '../../Components/LiquidGlassButton/EraAwareButton';
import "./Styles/createforumtopic.css"
import Breadcrumbs from './Components/Breadcrumbs';

const CreateTopicPage = ({ jwtToken }) => {
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [error, setError] = useState(null);
    const {styles} = useStyleContext();
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError(null);

        if (!title) return;

        try {
            const newTopic = await createForumTopic(
                { title, description },
                jwtToken
            );
            navigate(`/forum/${newTopic.slug}`);
        } catch (err) {
            setError(err.message);
        }
    };

    return (
        <>
        <Breadcrumbs/>
        <div className="create-forum-topic fp-custom-popup"  style={{ backgroundColor: styles.articleRightColor, '--article-color': styles.articleColor, '--article-right-color': styles.articleRightColor, '--article-right-inner-color': styles.articleRightInnerColor, '--footer-link-color': styles.footerListLinkTextColor, '--footer-text-color': styles.footerListTextColor } as any}>
            <h2>Create a New Forum</h2>
            <form onSubmit={handleSubmit}>
                <div className="fp-comment-write-textarea">
                    <label htmlFor="title">Forum Name:</label>
                    <input
                        type="text"
                        id="title"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        required
                    />
                </div>
                <div className="fp-comment-write-textarea">
                    <label htmlFor="description">Description:</label>
                    <textarea
                        id="description"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        rows={3}
                    />
                </div>
                {error && <div className="error">{error}</div>}
                <EraAwareButton className="fp-comment-button" type="submit">Create Forum</EraAwareButton>
            </form>
        </div>
        </>
    );
};

export default CreateTopicPage;
