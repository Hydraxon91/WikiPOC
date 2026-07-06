import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
import dotenv from "dotenv";
import { fileURLToPath } from "url";
import { dirname, resolve } from "path";
import { setToken } from "./auth.js";
const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);
dotenv.config({ path: resolve(__dirname, "..", "..", ".env") });
const BASE_URL = process.env.WIKIPOC_API_URL ?? process.env.VITE_API_URL ?? "http://localhost:5050";
const server = new McpServer({ name: "wikipoc-mcp", version: "1.0.0" });
async function getJson(path) {
    const res = await fetch(BASE_URL + path);
    if (!res.ok)
        throw new Error(res.statusText);
    return JSON.stringify(await res.json(), null, 2);
}
function wrap(fn) {
    return async (...args) => {
        try {
            return await fn(...args);
        }
        catch (err) {
            const msg = err?.message || String(err);
            return { content: [{ type: "text", text: msg }], isError: true };
        }
    };
}
async function postJson(path, body, token) {
    const headers = { "Content-Type": "application/json" };
    if (token)
        headers["Authorization"] = "Bearer " + token;
    const res = await fetch(BASE_URL + path, { method: "POST", headers, body: JSON.stringify(body) });
    if (!res.ok) {
        const text = await res.text();
        throw new Error(text || res.statusText);
    }
    return res.json();
}
server.tool("login", "Log in to the wiki and store an auth token for write operations. Use admin@admin.com / AdminPass123 for admin access, or test@test.com / TestPass123 for a regular user.", { email: z.string().describe("Email or username"), password: z.string().describe("Account password") }, wrap(async (args) => {
    const data = await postJson("/api/Auth/login", { email: args.email, password: args.password });
    setToken(data.token);
    return { content: [{ type: "text", text: "Logged in as " + data.userName }] };
}));
server.tool("register", "Create a new wiki account and log in automatically", { email: z.string(), username: z.string(), password: z.string() }, wrap(async (args) => {
    const data = await postJson("/api/Auth/register", {
        email: args.email, username: args.username, password: args.password,
    });
    setToken(data.token);
    return { content: [{ type: "text", text: "Registered and logged in as " + data.userName }] };
}));
server.tool("get_wiki_articles", "List all wiki article titles with their slugs and categories", {}, wrap(async () => {
    const text = await getJson("/api/WikiPages/GetTitles");
    return { content: [{ type: "text", text }] };
}));
server.tool("get_wiki_article", "Get a full wiki article by its slug", { slug: z.string().describe("The URL slug of the article (e.g. 'example-page-1')") }, wrap(async (args) => {
    const slug = encodeURIComponent(args.slug);
    const text = await getJson("/api/WikiPages/GetBySlug/" + slug);
    return { content: [{ type: "text", text }] };
}));
server.tool("list_forum_topics", "List all forum topics (boards) with their slugs", {}, wrap(async () => {
    const text = await getJson("/api/ForumTopic");
    return { content: [{ type: "text", text }] };
}));
server.tool("get_forum_topic", "Get a single forum topic (board) with its posts, by slug", { slug: z.string().describe("The slug of the forum topic (e.g. 'main-forum')") }, wrap(async (args) => {
    const slug = encodeURIComponent(args.slug);
    const text = await getJson("/api/ForumTopic/" + slug);
    return { content: [{ type: "text", text }] };
}));
server.tool("get_forum_post", "Get a single forum post with its comments, by slug", { slug: z.string().describe("The slug of the forum post") }, wrap(async (args) => {
    const slug = encodeURIComponent(args.slug);
    const text = await getJson("/api/ForumPost/" + slug);
    return { content: [{ type: "text", text }] };
}));
server.tool("list_categories", "List all categories", {}, wrap(async () => {
    const text = await getJson("/api/Category");
    return { content: [{ type: "text", text }] };
}));
const transport = new StdioServerTransport();
try {
    await server.connect(transport);
}
catch (err) {
    process.stderr.write("CONNECT ERR: " + (err?.message || String(err)) + "\n");
    process.exit(1);
}
//# sourceMappingURL=index.js.map