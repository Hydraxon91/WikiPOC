import { readFileSync, writeFileSync, existsSync } from "fs";
import { resolve, dirname } from "path";
import { fileURLToPath } from "url";

const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);
const SESSION_FILE = resolve(__dirname, "..", ".wikipoc-session.json");

interface SessionData {
  token: string | null;
  email: string | null;
  password: string | null;
}

let currentToken: string | null = null;
let loginEmail: string | null = null;
let loginPassword: string | null = null;

function readSessionFile(): SessionData | null {
  try {
    if (existsSync(SESSION_FILE)) {
      const raw = readFileSync(SESSION_FILE, "utf-8");
      return JSON.parse(raw) as SessionData;
    }
  } catch {
    // Corrupted or unreadable — ignore
  }
  return null;
}

function writeSessionFile(data: SessionData): void {
  try {
    writeFileSync(SESSION_FILE, JSON.stringify(data, null, 2), "utf-8");
  } catch {
    // Non-critical — fail silently
  }
}

// Bootstrap from file cache on module load
const saved = readSessionFile();
if (saved) {
  currentToken = saved.token;
  loginEmail = saved.email;
  loginPassword = saved.password;
}

export function getToken(): string | null {
  if (currentToken) return currentToken;

  // Fallback: read from file (e.g. after process restart)
  const saved = readSessionFile();
  if (saved?.token) {
    currentToken = saved.token;
    loginEmail = saved.email;
    loginPassword = saved.password;
    return currentToken;
  }
  return null;
}

export function setToken(token: string | null) {
  currentToken = token;
  writeSessionFile({ token, email: loginEmail, password: loginPassword });
}

export function setCredentials(email: string, password: string) {
  loginEmail = email;
  loginPassword = password;
  writeSessionFile({ token: currentToken, email, password });
}

export function getCredentials(): { email: string; password: string } | null {
  // Try in-memory first, then file fallback
  if (loginEmail && loginPassword) return { email: loginEmail, password: loginPassword };

  const saved = readSessionFile();
  if (saved?.email && saved?.password) {
    loginEmail = saved.email;
    loginPassword = saved.password;
    return { email: saved.email, password: saved.password };
  }
  return null;
}

export function requireToken(): string {
  const token = getToken();
  if (!token) {
    throw new Error("Not logged in. Call the login tool first with your wiki credentials.");
  }
  return token;
}
