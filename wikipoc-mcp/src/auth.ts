let currentToken: string | null = null;
let loginEmail: string | null = null;
let loginPassword: string | null = null;

export function getToken(): string | null {
  return currentToken;
}

export function setToken(token: string | null) {
  currentToken = token;
}

export function setCredentials(email: string, password: string) {
  loginEmail = email;
  loginPassword = password;
}

export function getCredentials(): { email: string; password: string } | null {
  if (loginEmail && loginPassword) return { email: loginEmail, password: loginPassword };
  return null;
}

export function requireToken(): string {
  if (!currentToken) {
    throw new Error("Not logged in. Call the login tool first with your wiki credentials.");
  }
  return currentToken;
}
