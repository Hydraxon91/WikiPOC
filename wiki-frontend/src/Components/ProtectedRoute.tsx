import React from 'react';
import { Navigate } from 'react-router-dom';
import { useCookies } from 'react-cookie';
import { useUserContext } from './contexts/UserContextProvider';
import LoadingSpinner from './LoadingSpinner';

const ProtectedRoute: React.FC<{ roles: string[]; children: React.ReactNode }> = ({ children, roles }) => {
    const { decodedTokenContext } = useUserContext();
    const [cookies] = useCookies(["jwt_token"]);

    if (cookies["jwt_token"] && !decodedTokenContext) {
        return <LoadingSpinner text="Checking authorization..." />;
    }

    if (!decodedTokenContext) {
        return <Navigate to="/" />;
    }

    const userRoles = decodedTokenContext?.['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

    if (!roles || roles.length === 0) {
        return children;
    }

    if (Array.isArray(userRoles)) {
        if (roles.some(role => userRoles.includes(role))) {
            return children;
        }
        if (roles.includes('Admin') && userRoles.includes('Owner')) {
            return children;
        }
    } else {
        if (roles.includes(userRoles)) {
            return children;
        }
        if (roles.includes('Admin') && userRoles === 'Owner') {
            return children;
        }
    }

    return <Navigate to="/" />;
};

export default ProtectedRoute;
