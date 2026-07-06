import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
import dotenv from "dotenv";
import { fileURLToPath } from "url";
import { dirname, resolve } from "path";
import { setToken, requireToken } from "./auth.js";
const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);
dotenv.config({ path: resolve(__dirname, "..", "..", ".env") });
const BASE_URL = process.env.WIKIPOC_API_URL ?? process.env.VITE_API_URL ?? "http://localhost:5050";
const server = new McpServer({ name: "wikipoc-mcp", version: "1.0.0" });
async function getJson(path, token) {
    const headers = {};
    if (token)
        headers["Authorization"] = "Bearer " + token;
    const res = await fetch(BASE_URL + path, { headers });
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
async function patchJson(path, body, token) {
    const headers = { "Content-Type": "application/json" };
    if (token)
        headers["Authorization"] = "Bearer " + token;
    const init = { method: "PATCH", headers };
    if (body !== undefined)
        init.body = JSON.stringify(body);
    const res = await fetch(BASE_URL + path, init);
    if (!res.ok) {
        const text = await res.text();
        throw new Error(text || res.statusText);
    }
    return res.json();
}
async function del(path, token) {
    const headers = {};
    if (token)
        headers["Authorization"] = "Bearer " + token;
    const res = await fetch(BASE_URL + path, { method: "DELETE", headers });
    if (!res.ok) {
        const text = await res.text();
        throw new Error(text || res.statusText);
    }
    if (res.status === 204)
        return { message: "Deleted successfully" };
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
server.tool("create_forum_topic", "Create a new forum topic (board). Requires admin login.", { title: z.string().describe("Topic title"), description: z.string().describe("Topic description") }, wrap(async (args) => {
    const token = requireToken();
    const data = await postJson("/api/ForumTopic", { title: args.title, description: args.description }, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("post_forum_comment", "Post a comment on a forum post. Requires login.", {
    content: z.string().describe("The comment text"),
    forumPostId: z.string().describe("The ID (GUID) of the forum post to comment on"),
    userProfileId: z.string().describe("Your user profile ID (GUID) — get this from /api/UserProfile/GetByUsername/{username}"),
}, wrap(async (args) => {
    const token = requireToken();
    const data = await postJson("/api/ForumComment/comment/", {
        content: args.content,
        forumPostId: args.forumPostId,
        userProfileId: args.userProfileId,
        postDate: new Date().toISOString(),
        isEdited: false,
    }, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("get_users", "List all wiki users with their IDs, usernames, emails, and roles. Requires admin login.", {}, wrap(async () => {
    const token = requireToken();
    const text = await getJson("/api/Users/GetUsers", token);
    return { content: [{ type: "text", text }] };
}));
server.tool("get_submitted_pages", "List all submitted new wiki pages awaiting approval. Requires moderator+ login.", {}, wrap(async () => {
    const token = requireToken();
    const text = await getJson("/api/WikiPages/GetSubmittedPageTitles", token);
    return { content: [{ type: "text", text }] };
}));
server.tool("get_submitted_updates", "List all submitted wiki page updates awaiting approval. Requires moderator+ login.", {}, wrap(async () => {
    const token = requireToken();
    const text = await getJson("/api/WikiPages/GetSubmittedUpdates", token);
    return { content: [{ type: "text", text }] };
}));
server.tool("update_user_role", "Change a user's role. Requires admin login. Can only assign roles you have permission for (Owner can do anything, Admin can only set Moderator/User).", {
    userId: z.string().describe("The user's ID (GUID) — get this from get_users"),
    role: z.string().describe("New role: Owner, Admin, Moderator, or User"),
}, wrap(async (args) => {
    const token = requireToken();
    const data = await patchJson("/api/Users/UpdateRole/" + args.userId, { role: args.role }, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("post_wiki_comment", "Post a comment on a wiki article. Requires login.", {
    content: z.string().describe("The comment text"),
    wikiPageId: z.string().describe("The ID (GUID) of the wiki page to comment on"),
    userProfileId: z.string().describe("Your user profile ID (GUID)"),
}, wrap(async (args) => {
    const token = requireToken();
    const data = await postJson("/api/UserComment/comment/", {
        content: args.content,
        wikiPageId: args.wikiPageId,
        userProfileId: args.userProfileId,
        postDate: new Date().toISOString(),
        isEdited: false,
    }, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("approve_submitted_page", "Approve a user-submitted wiki page (new page). Requires moderator+ login.", { id: z.string().describe("The ID (GUID) of the submitted page to approve") }, wrap(async (args) => {
    const token = requireToken();
    const data = await postJson("/api/WikiPages/AdminAccept", args.id, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("approve_submitted_update", "Approve a user-submitted wiki page update. Requires moderator+ login.", { id: z.string().describe("The ID (GUID) of the submitted update to approve") }, wrap(async (args) => {
    const token = requireToken();
    const data = await patchJson("/api/WikiPages/AdminAccept/" + args.id, undefined, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("delete_wiki_page", "Delete a wiki page. Requires moderator+ login.", { id: z.string().describe("The ID (GUID) of the wiki page to delete") }, wrap(async (args) => {
    const token = requireToken();
    const data = await del("/api/WikiPages/admin/" + args.id, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("delete_forum_post", "Delete a forum post. Requires login.", { id: z.string().describe("The ID (GUID) of the forum post to delete") }, wrap(async (args) => {
    const token = requireToken();
    const data = await del("/api/ForumPost/" + args.id, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
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