export declare function getToken(): string | null;
export declare function setToken(token: string | null): void;
export declare function setCredentials(email: string, password: string): void;
export declare function getCredentials(): {
    email: string;
    password: string;
} | null;
export declare function requireToken(): string;
//# sourceMappingURL=auth.d.ts.map