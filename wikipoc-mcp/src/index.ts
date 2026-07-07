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

const server: any = new McpServer({ name: "wikipoc-mcp", version: "1.0.0" });

async function getJson(path: string, token?: string) {
  const headers: Record<string, string> = {};
  if (token) headers["Authorization"] = "Bearer " + token;
  const res = await fetch(BASE_URL + path, { headers });
  if (!res.ok) throw new Error(res.statusText);
  return JSON.stringify(await res.json(), null, 2);
}

function wrap(fn: (...args: any[]) => any) {
  return async (...args: any[]) => {
    try {
      return await fn(...args);
    } catch (err: any) {
      const msg = err?.message || String(err);
      return { content: [{ type: "text", text: msg }], isError: true };
    }
  };
}

async function postJson(path: string, body: any, token?: string) {
  const headers: Record<string, string> = { "Content-Type": "application/json" };
  if (token) headers["Authorization"] = "Bearer " + token;
  const res = await fetch(BASE_URL + path, { method: "POST", headers, body: JSON.stringify(body) });
  if (!res.ok) {
    const text = await res.text();
    throw new Error(text || res.statusText);
  }
  return res.json();
}

async function patchJson(path: string, body: any, token?: string) {
  const headers: Record<string, string> = { "Content-Type": "application/json" };
  if (token) headers["Authorization"] = "Bearer " + token;
  const init: RequestInit = { method: "PATCH", headers };
  if (body !== undefined) init.body = JSON.stringify(body);
  const res = await fetch(BASE_URL + path, init);
  if (!res.ok) {
    const text = await res.text();
    throw new Error(text || res.statusText);
  }
  return res.json();
}

async function putJson(path: string, body: any, token?: string) {
  const headers: Record<string, string> = { "Content-Type": "application/json" };
  if (token) headers["Authorization"] = "Bearer " + token;
  const res = await fetch(BASE_URL + path, { method: "PUT", headers, body: JSON.stringify(body) });
  if (!res.ok) {
    const text = await res.text();
    throw new Error(text || res.statusText);
  }
  return res.json();
}

async function del(path: string, token?: string) {
  const headers: Record<string, string> = {};
  if (token) headers["Authorization"] = "Bearer " + token;
  const res = await fetch(BASE_URL + path, { method: "DELETE", headers });
  if (!res.ok) {
    const text = await res.text();
    throw new Error(text || res.statusText);
  }
  if (res.status === 204) return { message: "Deleted successfully" };
  return res.json();
}

server.tool(
  "login",
  "Log in to the wiki and store an auth token for write operations. Use admin@admin.com / AdminPass123 for admin access, or test@test.com / TestPass123 for a regular user.",
  { email: z.string().describe("Email or username"), password: z.string().describe("Account password") } as any,
  wrap(async (args: any) => {
    const data = await postJson("/api/Auth/login", { email: args.email, password: args.password });
    setToken(data.token);
    return { content: [{ type: "text", text: "Logged in as " + data.userName }] };
  }),
);

server.tool(
  "register",
  "Create a new wiki account and log in automatically",
  { email: z.string(), username: z.string(), password: z.string() } as any,
  wrap(async (args: any) => {
    const data = await postJson("/api/Auth/register", {
      email: args.email, username: args.username, password: args.password,
    });
    setToken(data.token);
    return { content: [{ type: "text", text: "Registered and logged in as " + data.userName }] };
  }),
);

server.tool(
  "get_wiki_articles",
  "List all wiki article titles with their slugs and categories",
  {} as any,
  wrap(async () => {
    const text = await getJson("/api/WikiPages/GetTitles");
    return { content: [{ type: "text", text }] };
  }),
);

server.tool(
  "get_wiki_article",
  "Get a full wiki article by its slug",
  { slug: z.string().describe("The URL slug of the article (e.g. 'example-page-1')") } as any,
  wrap(async (args: any) => {
    const slug = encodeURIComponent(args.slug as string);
    const text = await getJson("/api/WikiPages/GetBySlug/" + slug);
    return { content: [{ type: "text", text }] };
  }),
);

server.tool(
  "search_wiki_articles",
  "Search wiki articles by title and content",
  { query: z.string().describe("The search query") } as any,
  wrap(async (args: any) => {
    const text = await getJson("/api/WikiPages/Search/" + encodeURIComponent(args.query));
    return { content: [{ type: "text", text }] };
  }),
);

server.tool(
  "list_forum_topics",
  "List all forum topics (boards) with their slugs",
  {} as any,
  wrap(async () => {
    const text = await getJson("/api/ForumTopic");
    return { content: [{ type: "text", text }] };
  }),
);

server.tool(
  "get_forum_topic",
  "Get a single forum topic (board) with its posts, by slug",
  { slug: z.string().describe("The slug of the forum topic (e.g. 'main-forum')") } as any,
  wrap(async (args: any) => {
    const slug = encodeURIComponent(args.slug as string);
    const text = await getJson("/api/ForumTopic/" + slug);
    return { content: [{ type: "text", text }] };
  }),
);

server.tool(
  "get_forum_post",
  "Get a single forum post with its comments, by slug",
  { slug: z.string().describe("The slug of the forum post") } as any,
  wrap(async (args: any) => {
    const slug = encodeURIComponent(args.slug as string);
    const text = await getJson("/api/ForumPost/" + slug);
    return { content: [{ type: "text", text }] };
  }),
);

server.tool(
  "list_categories",
  "List all categories",
  {} as any,
  wrap(async () => {
    const text = await getJson("/api/Category");
    return { content: [{ type: "text", text }] };
  }),
);

server.tool(
  "create_forum_topic",
  "Create a new forum topic (board). Requires admin login.",
  { title: z.string().describe("Topic title"), description: z.string().describe("Topic description") } as any,
  wrap(async (args: any) => {
    const token = requireToken();
    const data = await postJson("/api/ForumTopic", { title: args.title, description: args.description }, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  }),
);

server.tool(
  "post_forum_comment",
  "Post a comment on a forum post. Requires login.",
  {
    content: z.string().describe("The comment text"),
    forumPostId: z.string().describe("The ID (GUID) of the forum post to comment on"),
    userProfileId: z.string().describe("Your user profile ID (GUID) — get this from /api/UserProfile/GetByUsername/{username}"),
  } as any,
  wrap(async (args: any) => {
    const token = requireToken();
    const data = await postJson("/api/ForumComment/comment/", {
      content: args.content,
      forumPostId: args.forumPostId,
      userProfileId: args.userProfileId,
      postDate: new Date().toISOString(),
      isEdited: false,
    }, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  }),
);

server.tool(
  "get_users",
  "List all wiki users with their IDs, usernames, emails, and roles. Requires admin login.",
  {} as any,
  wrap(async () => {
    const token = requireToken();
    const text = await getJson("/api/Users/GetUsers", token);
    return { content: [{ type: "text", text }] };
  }),
);

server.tool(
  "get_submitted_pages",
  "List all submitted new wiki pages awaiting approval. Requires moderator+ login.",
  {} as any,
  wrap(async () => {
    const token = requireToken();
    const text = await getJson("/api/WikiPages/GetSubmittedPageTitles", token);
    return { content: [{ type: "text", text }] };
  }),
);

server.tool(
  "get_submitted_updates",
  "List all submitted wiki page updates awaiting approval. Requires moderator+ login.",
  {} as any,
  wrap(async () => {
    const token = requireToken();
    const text = await getJson("/api/WikiPages/GetSubmittedUpdates", token);
    return { content: [{ type: "text", text }] };
  }),
);

server.tool(
  "update_user_role",
  "Change a user's role. Requires admin login. Can only assign roles you have permission for (Owner can do anything, Admin can only set Moderator/User).",
  {
    userId: z.string().describe("The user's ID (GUID) — get this from get_users"),
    role: z.string().describe("New role: Owner, Admin, Moderator, or User"),
  } as any,
  wrap(async (args: any) => {
    const token = requireToken();
    const data = await patchJson("/api/Users/UpdateRole/" + args.userId, { role: args.role }, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  }),
);

server.tool(
  "post_wiki_comment",
  "Post a comment on a wiki article. Requires login.",
  {
    content: z.string().describe("The comment text"),
    wikiPageId: z.string().describe("The ID (GUID) of the wiki page to comment on"),
    userProfileId: z.string().describe("Your user profile ID (GUID)"),
  } as any,
  wrap(async (args: any) => {
    const token = requireToken();
    const data = await postJson("/api/UserComment/comment/", {
      content: args.content,
      wikiPageId: args.wikiPageId,
      userProfileId: args.userProfileId,
      postDate: new Date().toISOString(),
      isEdited: false,
    }, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  }),
);

server.tool(
  "approve_submitted_page",
  "Approve a user-submitted wiki page (new page). Requires moderator+ login.",
  { id: z.string().describe("The ID (GUID) of the submitted page to approve") } as any,
  wrap(async (args: any) => {
    const token = requireToken();
    const data = await postJson("/api/WikiPages/AdminAccept", args.id, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  }),
);

server.tool(
  "approve_submitted_update",
  "Approve a user-submitted wiki page update. Requires moderator+ login.",
  { id: z.string().describe("The ID (GUID) of the submitted update to approve") } as any,
  wrap(async (args: any) => {
    const token = requireToken();
    const data = await patchJson("/api/WikiPages/AdminAccept/" + args.id, undefined, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  }),
);

server.tool(
  "delete_wiki_page",
  "Delete a wiki page. Requires moderator+ login.",
  { id: z.string().describe("The ID (GUID) of the wiki page to delete") } as any,
  wrap(async (args: any) => {
    const token = requireToken();
    const data = await del("/api/WikiPages/admin/" + args.id, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  }),
);

server.tool(
  "delete_forum_post",
  "Delete a forum post. Requires login.",
  { id: z.string().describe("The ID (GUID) of the forum post to delete") } as any,
  wrap(async (args: any) => {
    const token = requireToken();
    const data = await del("/api/ForumPost/" + args.id, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  }),
);

server.tool(
  "create_wiki_page",
  "Create a new wiki page. Requires moderator+ login.",
  {
    title: z.string().describe("Page title"),
    content: z.string().optional().describe("Page content (HTML)"),
    siteSub: z.string().optional().describe("Subtitle"),
    roleNote: z.string().optional().describe("Role note"),
    categoryId: z.string().optional().describe("Category ID (GUID)"),
  } as any,
  wrap(async (args: any) => {
    const token = requireToken();
    const data = await postJson("/api/WikiPages/admin-json", {
      title: args.title,
      content: args.content,
      siteSub: args.siteSub,
      roleNote: args.roleNote,
      categoryId: args.categoryId,
      paragraphs: [],
      images: [],
    }, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  }),
);

server.tool(
  "update_wiki_page",
  "Update a wiki page. Requires moderator+ login.",
  {
    id: z.string().describe("The page ID (GUID)"),
    title: z.string().optional().describe("New title"),
    content: z.string().optional().describe("New content (HTML)"),
    siteSub: z.string().optional().describe("New subtitle"),
    roleNote: z.string().optional().describe("New role note"),
    categoryId: z.string().optional().describe("New category ID (GUID)"),
  } as any,
  wrap(async (args: any) => {
    const token = requireToken();
    const data = await putJson("/api/WikiPages/admin-json/" + args.id, args, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  }),
);

server.tool(
  "create_forum_post",
  "Create a new forum post. Requires login.",
  {
    postTitle: z.string().describe("Post title"),
    content: z.string().describe("Post content (HTML)"),
    forumTopicId: z.string().describe("Forum topic ID (GUID)"),
    userId: z.string().describe("Your user profile ID (GUID)"),
    userName: z.string().describe("Your display name"),
  } as any,
  wrap(async (args: any) => {
    const token = requireToken();
    const data = await postJson("/api/ForumPost/postTopic-json", {
      postTitle: args.postTitle,
      content: args.content,
      forumTopicId: args.forumTopicId,
      userId: args.userId,
      userName: args.userName,
    }, token);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  }),
);

const transport = new StdioServerTransport();
try {
  await server.connect(transport);
} catch (err: any) {
  process.stderr.write("CONNECT ERR: " + (err?.message || String(err)) + "\n");
  process.exit(1);
}
