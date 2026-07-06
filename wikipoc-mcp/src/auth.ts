let currentToken: string | null = null;

export function getToken(): string | null {
  return currentToken;
}

export function setToken(token: string | null) {
  currentToken = token;
}

export function requireToken(): string {
  if (!currentToken) {
    throw new Error("Not logged in. Call the login tool first with your wiki credentials.");
  }
  return currentToken;
}
