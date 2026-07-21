import { useState } from 'react';

interface FlagCommentModalProps {
  onSubmit: (reason: string) => Promise<void>;
  onCancel: () => void;
}

const FlagCommentModal = ({ onSubmit, onCancel }: FlagCommentModalProps) => {
  const [reason, setReason] = useState('');
  const [submitting, setSubmitting] = useState(false);

  const handleSubmit = async () => {
    if (!reason.trim()) return;
    setSubmitting(true);
    try {
      await onSubmit(reason.trim());
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <div className="flag-modal-overlay" onClick={onCancel}>
      <div className="flag-modal" onClick={e => e.stopPropagation()}>
        <h4>Flag Comment</h4>
        <p>Why are you flagging this comment?</p>
        <textarea
          value={reason}
          onChange={e => setReason(e.target.value)}
          placeholder="Enter a reason..."
          rows={3}
          disabled={submitting}
        />
        <div className="flag-modal-actions">
          <button onClick={handleSubmit} disabled={!reason.trim() || submitting}>
            {submitting ? 'Submitting...' : 'Submit Flag'}
          </button>
          <button onClick={onCancel} disabled={submitting}>Cancel</button>
        </div>
      </div>
    </div>
  );
};

export default FlagCommentModal;
