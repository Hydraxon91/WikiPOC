import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
import dotenv from "dotenv";
import { fileURLToPath } from "url";
import { dirname, resolve } from "path";
const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);
dotenv.config({ path: resolve(__dirname, "..", "..", ".env") });
const BASE_URL = process.env.WIKIPOC_API_URL ?? "https://wikipoc-backend.azurewebsites.net";
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
            process.stderr.write("MCP FULL ERR: " + JSON.stringify(err, Object.getOwnPropertyNames(err)) + "\n");
            return { content: [{ type: "text", text: "Error" }], isError: true };
        }
    };
}
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