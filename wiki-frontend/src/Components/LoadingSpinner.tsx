export default function LoadingSpinner({ text = 'Loading...' }: { text?: string }) {
  return (
    <div style={{ textAlign: 'center', padding: '2rem', color: '#666' }}>
      <div style={{
        display: 'inline-block',
        width: '24px',
        height: '24px',
        border: '3px solid #ddd',
        borderTopColor: '#0645ad',
        borderRadius: '50%',
        animation: 'spin 0.8s linear infinite',
        marginRight: '8px',
        verticalAlign: 'middle',
      }} />
      <span style={{ verticalAlign: 'middle' }}>{text}</span>
      <style>{`@keyframes spin { to { transform: rotate(360deg); } }`}</style>
    </div>
  );
}
