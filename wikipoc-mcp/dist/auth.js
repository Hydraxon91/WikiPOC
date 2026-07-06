let currentToken = null;
export function getToken() {
    return currentToken;
}
export function setToken(token) {
    currentToken = token;
}
export function requireToken() {
    if (!currentToken) {
        throw new Error("Not logged in. Call the login tool first with your wiki credentials.");
    }
    return currentToken;
}
//# sourceMappingURL=auth.js.map