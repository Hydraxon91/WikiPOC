import { useEffect, useState } from 'react';
import { useCookies } from 'react-cookie';
import { useNotification } from '../../Components/NotificationProvider';
import { getFlaggedComments, resolveFlag, modDeleteComment, type FlaggedCommentItem } from '../../Api/moderationApi';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import './Moderation.css';

const FlaggedCommentsPage = () => {
    const [cookies] = useCookies(['jwt_token']);
    const { showNotification } = useNotification();
    const { styles } = useStyleContext();
    const [flags, setFlags] = useState<FlaggedCommentItem[]>([]);
    const [loading, setLoading] = useState(true);

    const token = cookies['jwt_token'];

    const loadFlags = async () => {
        try {
            const data = await getFlaggedComments(token);
            setFlags(data);
        } catch {
            showNotification('Failed to load flagged comments');
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        loadFlags();
    }, []);

    const handleResolve = async (flagId: string) => {
        try {
            await resolveFlag(flagId, token);
            setFlags(prev => prev.filter(f => f.flag.id !== flagId));
            showNotification('Flag resolved');
        } catch {
            showNotification('Failed to resolve flag');
        }
    };

    const handleDelete = async (flagId: string) => {
        if (!confirm('Delete this comment and resolve all flags?')) return;
        try {
            await modDeleteComment(flagId, token);
            setFlags(prev => prev.filter(f => f.flag.id !== flagId));
            showNotification('Comment deleted and flags resolved');
        } catch {
            showNotification('Failed to delete comment');
        }
    };

    if (loading) return <div className="article" style={{ backgroundColor: styles.articleColor }}><p>Loading...</p></div>;

    return (
        <div className="article" style={{ backgroundColor: styles.articleColor }}>
            <h2>Flagged Comments</h2>
            {flags.length === 0 ? (
                <p>No flagged comments awaiting moderation.</p>
            ) : (
                <div className="flagged-list">
                    {flags.map(item => (
                        <div key={item.flag.id} className="flagged-card">
                            <div className="flagged-comment-content">
                                <p className="flagged-comment-text">{item.commentContent || '(comment deleted)'}</p>
                                <p className="flagged-meta">
                                    Author: {item.commentAuthorName || 'Unknown'} &middot;
                                    Flagged by: {item.flag.flaggedByUserProfile?.displayName || 'Unknown'} &middot;
                                    Reason: {item.flag.reason}
                                </p>
                            </div>
                            <div className="flagged-actions">
                                <button className="btn-delete" onClick={() => handleDelete(item.flag.id)}>Delete & Resolve</button>
                                <button className="btn-resolve" onClick={() => handleResolve(item.flag.id)}>Dismiss</button>
                            </div>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
};

export default FlaggedCommentsPage;
