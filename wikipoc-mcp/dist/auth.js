let currentToken = null;
let loginEmail = null;
let loginPassword = null;
export function getToken() {
    return currentToken;
}
export function setToken(token) {
    currentToken = token;
}
export function setCredentials(email, password) {
    loginEmail = email;
    loginPassword = password;
}
export function getCredentials() {
    if (loginEmail && loginPassword)
        return { email: loginEmail, password: loginPassword };
    return null;
}
export function requireToken() {
    if (!currentToken) {
        throw new Error("Not logged in. Call the login tool first with your wiki credentials.");
    }
    return currentToken;
}
//# sourceMappingURL=auth.js.map