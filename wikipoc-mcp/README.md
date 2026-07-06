# WikiPOC MCP Server

An [MCP](https://modelcontextprotocol.io) server that exposes the WikiPOC REST API as tools for LLMs.

## Tools

| Tool | Description | Auth |
|------|-------------|------|
| `get_wiki_articles` | List all wiki article titles with slugs and categories | Public |
| `get_wiki_article` | Get a full wiki article by its slug | Public |
| `list_forum_topics` | List all forum topics (boards) | Public |
| `get_forum_topic` | Get a single forum topic with its posts | Public |
| `get_forum_post` | Get a single forum post with its comments | Public |
| `list_categories` | List all categories | Public |

## Connect to OpenCode

Add this entry to your `opencode.json`:

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

Or with the deployed backend URL:

```json
{
  "mcpServers": {
    "wikipoc-mcp": {
      "name": "WikiPOC MCP",
      "type": "stdio",
      "command": "node",
      "args": ["/absolute/path/to/wikipoc-mcp/dist/index.js"],
      "env": {
        "WIKIPOC_API_URL": "https://wikipoc-backend.azurewebsites.net"
      }
    }
  }
}
```

## Build

```bash
cd wikipoc-mcp
npm install
npm run build
```

## Development

```bash
npm run build
npm start  # runs: node dist/index.js
```
