import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
import axios from "axios";

const BASE_URL = process.env.WIKIPOC_API_URL ?? "http://localhost:5050";

const api = axios.create({ baseURL: BASE_URL });

const server = new McpServer({
  name: "wikipoc-mcp",
  version: "1.0.0",
});

server.registerTool(
  "get_wiki_articles",
  { description: "List all wiki article titles with their slugs and categories" },
  async () => {
    const { data } = await api.get("/api/WikiPages/GetTitles");
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  },
);

server.registerTool(
  "get_wiki_article",
  {
    description: "Get a full wiki article by its slug",
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    inputSchema: { slug: z.string().describe("The URL slug of the article (e.g. 'example-page-1')") as any },
  },
  async ({ slug }: { slug: string }) => {
    const { data } = await api.get(`/api/WikiPages/GetBySlug/${encodeURIComponent(slug)}`);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  },
);

server.registerTool(
  "list_forum_topics",
  { description: "List all forum topics (boards) with their slugs" },
  async () => {
    const { data } = await api.get("/api/ForumTopic");
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  },
);

server.registerTool(
  "get_forum_topic",
  {
    description: "Get a single forum topic (board) with its posts, by slug",
    inputSchema: { slug: z.string().describe("The slug of the forum topic (e.g. 'main-forum')") as any },
  },
  async ({ slug }: { slug: string }) => {
    const { data } = await api.get(`/api/ForumTopic/${encodeURIComponent(slug)}`);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  },
);

server.registerTool(
  "get_forum_post",
  {
    description: "Get a single forum post with its comments, by slug",
    inputSchema: { slug: z.string().describe("The slug of the forum post") as any },
  },
  async ({ slug }: { slug: string }) => {
    const { data } = await api.get(`/api/ForumPost/${encodeURIComponent(slug)}`);
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  },
);

server.registerTool(
  "list_categories",
  { description: "List all categories" },
  async () => {
    const { data } = await api.get("/api/Category");
    return { content: [{ type: "text", text: JSON.stringify(data, null, 2) }] };
  },
);

/*
 * TODO: Auth — when implementing write tools, inject Authorization header here:
 *
 *   import axios from "axios";
 *   const api = axios.create({
 *     baseURL: BASE_URL,
 *     headers: { Authorization: `Bearer ${process.env.WIKIPOC_ADMIN_TOKEN}` },
 *   });
 */

const transport = new StdioServerTransport();
await server.connect(transport);
