import { useState } from 'react';
import { useStyleContext } from '../../Components/contexts/StyleContext';

const DebugRolesPage = ({ jwtToken }) => {
    const [data, setData] = useState(null);
    const [error, setError] = useState(null);
    const { styles } = useStyleContext();

    const fetchDebug = async () => {
        try {
            const res = await fetch(`${import.meta.env.VITE_API_URL}/api/Users/DebugPrincipal`, {
                headers: { 'Authorization': `Bearer ${jwtToken}` }
            });
            if (!res.ok) throw new Error(`${res.status}: ${res.statusText}`);
            const json = await res.json();
            setData(json);
            setError(null);
        } catch (e) {
            setError(e.message);
            setData(null);
        }
    };

    return (
        <div className="article" style={{ backgroundColor: styles.articleColor, padding: '1.5em' }}>
            <h2>Debug: JWT Claims</h2>
            <button onClick={fetchDebug} style={{ padding: '0.5em 1em', marginBottom: '1em', cursor: 'pointer' }}>
                Fetch My Claims
            </button>
            {error && <p style={{ color: 'red' }}>Error: {error}</p>}
            {data && (
                <pre style={{ background: '#f5f5f5', padding: '1em', borderRadius: '4px', overflow: 'auto' }}>
                    {JSON.stringify(data, null, 2)}
                </pre>
            )}
        </div>
    );
};

export default DebugRolesPage;
