import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
import dotenv from "dotenv";
import { fileURLToPath } from "url";
import { dirname, resolve } from "path";
import { setToken, requireToken, setCredentials, getCredentials } from "./auth.js";
const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);
dotenv.config({ path: resolve(__dirname, "..", "..", ".env") });
const BASE_URL = process.env.WIKIPOC_API_URL ?? process.env.VITE_API_URL ?? "http://localhost:5050";
const server = new McpServer({ name: "wikipoc-mcp", version: "1.0.0" });
// --- Helpers ---
async function tryRelogin(headers) {
    const creds = getCredentials();
    if (!creds)
        return false;
    const res = await fetch(BASE_URL + "/api/Auth/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(creds),
    });
    if (!res.ok)
        return false;
    const data = await res.json();
    setToken(data.token);
    headers["Authorization"] = "Bearer " + data.token;
    return true;
}
async function authFetch(path, init, retry = true) {
    const headers = { ...(init.headers || {}) };
    if (init.token)
        headers["Authorization"] = "Bearer " + init.token;
    if (!headers["Content-Type"] && init.method !== "DELETE")
        headers["Content-Type"] = "application/json";
    const res = await fetch(BASE_URL + path, { ...init, headers, body: init.body });
    if (res.status === 401 && retry && await tryRelogin(headers)) {
        const retryRes = await fetch(BASE_URL + path, { ...init, headers, body: init.body });
        if (retryRes.ok) {
            if (retryRes.status === 204 || retryRes.headers.get("content-length") === "0")
                return null;
            return retryRes.json();
        }
        const text = await retryRes.text();
        throw new Error(text || "Unauthorized");
    }
    if (!res.ok) {
        const text = await res.text();
        throw new Error(text || res.statusText);
    }
    if (res.status === 204 || res.headers.get("content-length") === "0")
        return null;
    return res.json();
}
async function getJson(path, token) {
    return authFetch(path, { method: "GET", token }, false);
}
async function postJson(path, body, token) {
    return authFetch(path, { method: "POST", token, body: JSON.stringify(body) });
}
async function patchJson(path, body, token) {
    const init = { method: "PATCH", token };
    if (body !== undefined)
        init.body = JSON.stringify(body);
    return authFetch(path, init);
}
async function putJson(path, body, token) {
    return authFetch(path, { method: "PUT", token, body: JSON.stringify(body) });
}
async function del(path, token) {
    return authFetch(path, { method: "DELETE", token });
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
// --- Auth tools ---
server.tool("login", "Log in to the wiki and store an auth token for write operations.", { email: z.string(), password: z.string() }, wrap(async (args) => {
    const data = await postJson("/api/Auth/login", { email: args.email, password: args.password });
    setToken(data.token);
    setCredentials(args.email, args.password);
    return { content: [{ type: "text", text: "Logged in as " + data.userName }] };
}));
server.tool("register", "Create a new wiki account and log in automatically", { email: z.string(), username: z.string(), password: z.string() }, wrap(async (args) => {
    const data = await postJson("/api/Auth/register", { email: args.email, username: args.username, password: args.password });
    setToken(data.token);
    setCredentials(args.email, args.password);
    return { content: [{ type: "text", text: "Registered and logged in as " + data.userName }] };
}));
// --- Read tools ---
server.tool("get_wiki_articles", "List all wiki article titles with their slugs and categories", {}, wrap(async () => {
    return { content: [{ type: "text", text: await getJson("/api/WikiPages/GetTitles") }] };
}));
server.tool("get_wiki_article", "Get a full wiki article by its slug", { slug: z.string().describe("The URL slug of the article (e.g. 'example-page-1')") }, wrap(async (args) => {
    return { content: [{ type: "text", text: await getJson("/api/WikiPages/GetBySlug/" + encodeURIComponent(args.slug)) }] };
}));
server.tool("search_wiki_articles", "Search wiki articles by title and content", { query: z.string().describe("The search query") }, wrap(async (args) => {
    return { content: [{ type: "text", text: await getJson("/api/WikiPages/Search/" + encodeURIComponent(args.query)) }] };
}));
server.tool("list_forum_topics", "List all forum topics (boards) with their slugs", {}, wrap(async () => {
    return { content: [{ type: "text", text: await getJson("/api/ForumTopic") }] };
}));
server.tool("get_forum_topic", "Get a single forum topic (board) with its posts, by slug", { slug: z.string().describe("The slug of the forum topic (e.g. 'main-forum')") }, wrap(async (args) => {
    return { content: [{ type: "text", text: await getJson("/api/ForumTopic/" + encodeURIComponent(args.slug)) }] };
}));
server.tool("get_forum_post", "Get a single forum post with its comments, by slug", { slug: z.string().describe("The slug of the forum post") }, wrap(async (args) => {
    return { content: [{ type: "text", text: await getJson("/api/ForumPost/" + encodeURIComponent(args.slug)) }] };
}));
server.tool("list_categories", "List all categories", {}, wrap(async () => {
    return { content: [{ type: "text", text: await getJson("/api/Category") }] };
}));
server.tool("search_forum_topics", "Search forum topics by title and description", { query: z.string().describe("The search query") }, wrap(async (args) => {
    return { content: [{ type: "text", text: await getJson("/api/ForumTopic/Search/" + encodeURIComponent(args.query)) }] };
}));
server.tool("search_forum_posts", "Search forum posts by title and content within a specific topic", { topicId: z.string(), query: z.string() }, wrap(async (args) => {
    return { content: [{ type: "text", text: await getJson("/api/ForumPost/Search/" + encodeURIComponent(args.topicId) + "/" + encodeURIComponent(args.query)) }] };
}));
// --- Write tools ---
server.tool("get_users", "List all wiki users with their IDs, usernames, emails, and roles. Requires admin login.", {}, wrap(async () => {
    const token = requireToken();
    return { content: [{ type: "text", text: await getJson("/api/Users/GetUsers", token) }] };
}));
server.tool("get_submitted_pages", "List all submitted new wiki pages awaiting approval. Requires moderator+ login.", {}, wrap(async () => {
    return { content: [{ type: "text", text: await getJson("/api/WikiPages/GetSubmittedPageTitles", requireToken()) }] };
}));
server.tool("get_submitted_updates", "List all submitted wiki page updates awaiting approval. Requires moderator+ login.", {}, wrap(async () => {
    return { content: [{ type: "text", text: await getJson("/api/WikiPages/GetSubmittedUpdates", requireToken()) }] };
}));
server.tool("create_forum_topic", "Create a new forum topic (board). Requires admin login.", { title: z.string(), description: z.string() }, wrap(async (args) => {
    const data = await postJson("/api/ForumTopic", { title: args.title, description: args.description }, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("post_forum_comment", "Post a comment on a forum post. Requires login.", { content: z.string(), forumPostId: z.string(), userProfileId: z.string() }, wrap(async (args) => {
    const data = await postJson("/api/ForumComment/comment/", {
        content: args.content, forumPostId: args.forumPostId,
        userProfileId: args.userProfileId, postDate: new Date().toISOString(), isEdited: false,
    }, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("post_wiki_comment", "Post a comment on a wiki article. Requires login.", { content: z.string(), wikiPageId: z.string(), userProfileId: z.string() }, wrap(async (args) => {
    const data = await postJson("/api/UserComment/comment/", {
        content: args.content, wikiPageId: args.wikiPageId,
        userProfileId: args.userProfileId, postDate: new Date().toISOString(), isEdited: false,
    }, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("approve_submitted_page", "Approve a user-submitted wiki page (new page). Requires moderator+ login.", { id: z.string() }, wrap(async (args) => {
    const data = await postJson("/api/WikiPages/AdminAccept", args.id, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("approve_submitted_update", "Approve a user-submitted wiki page update. Requires moderator+ login.", { id: z.string() }, wrap(async (args) => {
    const data = await patchJson("/api/WikiPages/AdminAccept/" + args.id, undefined, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("update_user_role", "Change a user's role. Requires admin login.", { userId: z.string(), role: z.string() }, wrap(async (args) => {
    const data = await patchJson("/api/Users/UpdateRole/" + args.userId, { role: args.role }, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("delete_wiki_page", "Delete a wiki page. Requires moderator+ login.", { id: z.string() }, wrap(async (args) => {
    const data = await del("/api/WikiPages/admin/" + args.id, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("delete_forum_post", "Delete a forum post. Requires login.", { id: z.string() }, wrap(async (args) => {
    const data = await del("/api/ForumPost/" + args.id, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("create_wiki_page", "Create a new wiki page. Requires moderator+ login.", { title: z.string(), content: z.string().optional(), siteSub: z.string().optional(), roleNote: z.string().optional(), categoryId: z.string().optional() }, wrap(async (args) => {
    const data = await postJson("/api/WikiPages/admin-json", {
        title: args.title, content: args.content, siteSub: args.siteSub,
        roleNote: args.roleNote, categoryId: args.categoryId, paragraphs: [], images: [],
    }, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("update_wiki_page", "Update a wiki page. Requires moderator+ login.", { id: z.string(), title: z.string().optional(), content: z.string().optional(), siteSub: z.string().optional(), roleNote: z.string().optional(), categoryId: z.string().optional() }, wrap(async (args) => {
    const data = await putJson("/api/WikiPages/admin-json/" + args.id, args, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("create_forum_post", "Create a new forum post. Requires login.", { postTitle: z.string(), content: z.string(), forumTopicId: z.string(), userId: z.string(), userName: z.string() }, wrap(async (args) => {
    const data = await postJson("/api/ForumPost/postTopic-json", {
        postTitle: args.postTitle, content: args.content,
        forumTopicId: args.forumTopicId, userId: args.userId, userName: args.userName,
    }, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
// --- New tools: Forum CRUD, comment edit/delete, category ---
server.tool("update_forum_post", "Update a forum post. Requires login.", { id: z.string(), postTitle: z.string().optional(), content: z.string().optional() }, wrap(async (args) => {
    const token = requireToken();
    const existing = await authFetch(BASE_URL + "/api/ForumPost/" + encodeURIComponent(args.id), { method: "GET", token }, false);
    const data = await putJson("/api/ForumPost/" + args.id, {
        id: args.id, postTitle: args.postTitle || existing.postTitle,
        content: args.content || existing.content, forumTopicId: existing.forumTopicId,
        userId: existing.userId, userName: existing.userName,
    }, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("edit_forum_comment", "Edit a forum comment. Requires login.", { id: z.string(), content: z.string() }, wrap(async (args) => {
    const data = await putJson("/api/ForumComment/comment/" + args.id, args.content, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("delete_forum_comment", "Delete a forum comment. Requires login.", { id: z.string() }, wrap(async (args) => {
    const data = await del("/api/ForumComment/comment/" + args.id, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("edit_wiki_comment", "Edit a comment on a wiki article. Requires login.", { id: z.string(), content: z.string() }, wrap(async (args) => {
    const data = await putJson("/api/UserComment/comment/" + args.id, args.content, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("delete_wiki_comment", "Delete a comment on a wiki article. Requires login.", { id: z.string() }, wrap(async (args) => {
    const data = await del("/api/UserComment/comment/" + args.id, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("create_category", "Create a new category. Requires admin login.", { name: z.string() }, wrap(async (args) => {
    const data = await postJson("/api/Category", args.name, requireToken());
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
}));
server.tool("ensure_agent_notes_category", "Ensure a category named 'Agent Notes' exists. Creates it if missing. Requires admin login.", {}, wrap(async () => {
    const token = requireToken();
    const catsText = await getJson("/api/Category", token);
    const cats = JSON.parse(catsText);
    const existing = cats.find((c) => c.categoryName === "Any agents notes");
    if (existing)
        return { content: [{ type: "text", text: "Category 'Agent Notes' already exists with ID: " + existing.id }] };
    const data = await postJson("/api/Category", "Any agents notes", token);
    return { content: [{ type: "text", text: "Created category 'Agent Notes': " + JSON.stringify(data) }] };
}));
// --- Startup ---
const transport = new StdioServerTransport();
try {
    await server.connect(transport);
}
catch (err) {
    process.stderr.write("CONNECT ERR: " + (err?.message || String(err)) + "\n");
    process.exit(1);
}
//# sourceMappingURL=index.js.map