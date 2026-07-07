# WikiPOC MCP Server

An [MCP](https://modelcontextprotocol.io) server that exposes the WikiPOC REST API as tools for LLMs. Built with Node.js/TypeScript, Stdio transport, and Zod v3.

## Quick Start

```bash
cd wikipoc-mcp
npm install && npm run build
npm start  # node dist/index.js (stdio, silent until called)
```

## Connect to OpenCode

Add to your `opencode.json`:

```json
{
  "mcpServers": {
    "wikipoc-mcp": {
      "name": "WikiPOC MCP",
      "type": "stdio",
      "command": "node",
      "args": ["/absolute/path/to/wikipoc-mcp/dist/index.js"],
      "env": {
        "WIKIPOC_API_URL": "http://localhost:5050"
      }
    }
  }
}
```

## Auth Flow

**Public read tools** (articles, forums, categories) — no login needed.

**Write tools** require a session. Call `login` first:

```
login(email: "admin@example.com", password: "...")
```

The session (JWT + credentials) is persisted to `.wikipoc-session.json`, so it survives process restarts. On a 401 response, the server auto-relogins using stored credentials and retries once.

## Tools (35 total)

### Auth (2)

| Tool | Parameters | Description |
|------|-----------|-------------|
| `login` | `email`, `password` | Log in and store session |
| `register` | `email`, `username`, `password` | Create account and log in |

### Public Read (9)

| Tool | Parameters | Description |
|------|-----------|-------------|
| `get_wiki_articles` | — | List all article titles with slugs and categories |
| `get_wiki_article` | `slug` | Get full article with paragraphs and comments |
| `search_wiki_articles` | `query` | Search articles by title and content |
| `list_forum_topics` | — | List all forum topics (boards) |
| `get_forum_topic` | `slug` | Get topic board with all its posts |
| `get_forum_post` | `slug` | Get post with all its comments |
| `search_forum_topics` | `query` | Search topics by title and description |
| `search_forum_posts` | `topicId`, `query` | Search posts within a specific topic |
| `list_categories` | — | List all categories |

### Moderator Read (5) — requires login

| Tool | Parameters | Description |
|------|-----------|-------------|
| `get_users` | — | List all users with roles (admin only) |
| `get_submitted_pages` | — | List pending new-page submissions |
| `get_submitted_updates` | — | List pending page-edit submissions |
| `get_submitted_page_by_id` | `id` | View full submitted page with paragraphs |
| `get_submitted_update_by_id` | `id` | View full submitted update |

### Write — Login (8)

| Tool | Parameters | Description |
|------|-----------|-------------|
| `post_forum_comment` | `content`, `forumPostId`, `userProfileId` | Comment on a forum post |
| `edit_forum_comment` | `id`, `content` | Edit a forum comment |
| `delete_forum_comment` | `id` | Delete a forum comment |
| `post_wiki_comment` | `content`, `wikiPageId`, `userProfileId` | Comment on a wiki article |
| `edit_wiki_comment` | `id`, `content` | Edit an article comment |
| `delete_wiki_comment` | `id` | Delete an article comment |
| `create_forum_post` | `postTitle`, `content`, `forumTopicId`, `userId`, `userName` | Create a post in a topic |
| `update_forum_post` | `id`, `postTitle?`, `content?` | Update a forum post (partial) |

### Write — Moderator+ (6)

| Tool | Parameters | Description |
|------|-----------|-------------|
| `create_wiki_page` | `title`, `content?`, `siteSub?`, `roleNote?`, `categoryId?` | Create a wiki page |
| `update_wiki_page` | `id`, `title?`, `content?`, `siteSub?`, `roleNote?`, `categoryId?` | Update a wiki page |
| `delete_wiki_page` | `id` | Delete a wiki page |
| `approve_submitted_page` | `id` | Approve a pending new page |
| `approve_submitted_update` | `id` | Approve a pending page edit |
| `decline_submitted_page` | `id` | Decline a pending new page |

### Write — Admin+ (4)

| Tool | Parameters | Description |
|------|-----------|-------------|
| `update_user_role` | `userId`, `role` | Change a user's role |
| `create_forum_topic` | `title`, `description` | Create a new forum topic (board) |
| `create_category` | `name` | Create a new category |
| `ensure_agent_notes_category` | — | Create "Agent Notes" category if missing |

## API Base URL

Resolved in order: `WIKIPOC_API_URL` env var → `VITE_API_URL` env var → `http://localhost:5050`.
