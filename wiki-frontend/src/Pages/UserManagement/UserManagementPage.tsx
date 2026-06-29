import { useState, useEffect } from 'react';
import { useNotification } from '../../Components/NotificationProvider';
import { useUserContext } from '../../Components/contexts/UserContextProvider';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import { get, patch } from '../../Api/apiClient';
import '../../Styles/stylepage.css';

const UserManagementPage = ({ jwtToken }) => {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);
    const { styles } = useStyleContext();
    const { showNotification } = useNotification();
    const { decodedTokenContext } = useUserContext();

    const currentUserRole = decodedTokenContext?.['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

    const getRoleOptions = (targetRoles) => {
        if (currentUserRole === 'Owner') {
            return ['User', 'Moderator', 'Admin', 'Owner'];
        }
        if (currentUserRole === 'Admin') {
            if (targetRoles?.includes('Owner') || targetRoles?.includes('Admin')) return [];
            return ['User', 'Moderator'];
        }
        return [];
    };

    const fetchUsers = async () => {
        try {
            const data = await get('/api/Users/GetUsers', jwtToken);
            setUsers(data);
        } catch (err) {
            console.error('Error fetching users:', err);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchUsers();
    }, []);

    const handleRoleChange = async (userId, newRole) => {
        try {
            await patch(`/api/Users/UpdateRole/${userId}`, { role: newRole }, jwtToken);
            showNotification('User role updated successfully');
            fetchUsers();
        } catch (err) {
            console.error('Error updating role:', err);
            showNotification('Failed to update role');
        }
    };

    if (loading) return <div style={{ padding: '2rem', textAlign: 'center' }}>Loading users...</div>;

    return (
        <div className="article" style={{ backgroundColor: styles.articleColor, padding: '1.5em' }}>
            <h2 style={{ margin: '0 0 1em 0' }}>User Management</h2>
            <div style={{ overflowX: 'auto' }}>
            <table style={{ width: '100%', borderCollapse: 'collapse' }}>
                <thead>
                    <tr style={{ borderBottom: '1px solid rgba(0,0,0,0.2)', textAlign: 'left' }}>
                        <th style={{ padding: '0.5em' }}>Username</th>
                        <th style={{ padding: '0.5em' }}>Email</th>
                        <th style={{ padding: '0.5em' }}>Current Role</th>
                        <th style={{ padding: '0.5em' }}>Change Role</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map((user) => {
                        const userRole = user.roles?.[0] || 'User';
                        const options = getRoleOptions(user.roles);
                        return (
                            <tr key={user.id} style={{ borderBottom: '1px solid rgba(0,0,0,0.1)' }}>
                                <td style={{ padding: '0.5em' }}>{user.userName}</td>
                                <td style={{ padding: '0.5em' }}>{user.email}</td>
                                <td style={{ padding: '0.5em', fontWeight: 'bold' }}>{userRole}</td>
                                <td style={{ padding: '0.5em' }}>
                                    {options.length > 0 ? (
                                        <select
                                            value={userRole}
                                            onChange={(e) => handleRoleChange(user.id, e.target.value)}
                                            style={{ padding: '0.3em', borderRadius: '3px', border: '1px solid #ccc' }}
                                        >
                                            {options.map(role => (
                                                <option key={role} value={role}>{role}</option>
                                            ))}
                                        </select>
                                    ) : (
                                        <span style={{ color: '#666', fontSize: '0.9em' }}>—</span>
                                    )}
                                </td>
                            </tr>
                        );
                    })}
                </tbody>
            </table>
            </div>
        </div>
    );
};

export default UserManagementPage;
