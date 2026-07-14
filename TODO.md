# TODO.md — WikiPOC

## Priority Legend
- **CRIT**: Must fix before production
- **HIGH**: Strongly recommended before production
- **MEDIUM**: Quality-of-life / technical debt
- **LOW**: Nice-to-have

---

## Embed System

### Cleanup (tech debt from July 2026)
- [x] **MEDIUM** Remove `/debug-middleware` diagnostic endpoint from `Program.cs`
- [x] **MEDIUM** Remove temporary inline embed generation comment from `Program.cs`
- [x] **MEDIUM** Refactor inline embed logic into proper `ScraperEmbedMiddleware` class (direct HTML generation)

### Known Issues
- `ScraperEmbedMiddleware` generates embed HTML directly (no path rewrite) — `context.Request.Path` rewrite doesn't route to controllers on Azure/ASP.NET Core 10
- `logo_pfp.png` doesn't exist on Azure — all fallbacks use `/img/logo.png` instead
- Azure Free Tier has no persistent storage — image uploads (custom logos) don't work

---

## CI/CD (DevOps Tier)

### Remaining
- [ ] **CRIT** Add immutable image tags (`${{ github.sha }}`) via `docker/metadata-action`
- [ ] **CRIT** Add deployment job (staging/prod environments)
- [ ] **HIGH** Add `USER` directive to Dockerfiles (containers run as root)
- [ ] **HIGH** Add PR template, CONTRIBUTING.md
- [ ] **HIGH** Add CodeQL workflow + Trivy image scan
- [ ] **HIGH** Add ESLint + Roslyn analyzers
- [ ] **HIGH** Enable branch protection on `main`
- [ ] **MEDIUM** Add coverage reporting (coverlet + ReportGenerator for .NET)
- [ ] **MEDIUM** Add release tagging / changelog automation
- [ ] **MEDIUM** Add GitHub Environments (staging vs prod)

---

## MCP Server (`wikipoc-mcp/`)

### Implemented tools
All read, auth, and write tools are implemented. Full list:

| Tool | Endpoint | Auth |
|------|----------|------|
| `get_wiki_articles` | `GET /api/WikiPages/GetTitles` | Public |
| `get_wiki_article` | `GET /api/WikiPages/GetBySlug/{slug}` | Public |
| `list_forum_topics` | `GET /api/ForumTopic` | Public |
| `get_forum_topic` | `GET /api/ForumTopic/{slug}` | Public |
| `get_forum_post` | `GET /api/ForumPost/{slug}` | Public |
| `list_categories` | `GET /api/Category` | Public |
| `login` | `POST /api/Auth` | Public |
| `register` | `POST /api/Auth/Register` | Public |
| `post_forum_comment` | `POST /api/ForumComment` | User+ |
| `post_wiki_comment` | `POST /api/UserComment` | User+ |
| `create_forum_topic` | `POST /api/ForumTopic` | Admin+ |
| `create_forum_post` | `POST /api/ForumPost/json` | User+ |
| `create_wiki_page` | `POST /api/WikiPages/admin-json` | Moderator+ |
| `update_wiki_page` | `PUT /api/WikiPages/{id}/admin-json` | Moderator+ |
| `get_users` | `GET /api/Users` | Admin |
| `update_user_role` | `PUT /api/Users/{id}/role` | Admin+ |
| `approve_submitted_page` | `PUT /api/WikiPages/accept-submitted/{id}` | Moderator+ |
| `approve_submitted_update` | `PUT /api/WikiPages/accept-update/{id}` | Moderator+ |
| `get_submitted_pages` | `GET /api/WikiPages/submitted-pages` | Moderator+ |
| `get_submitted_updates` | `GET /api/WikiPages/submitted-updates` | Moderator+ |
| `delete_wiki_page` | `DELETE /api/WikiPages/{id}` | Moderator+ |
| `delete_forum_post` | `DELETE /api/ForumPost/{id}` | Authorize |

### Future tools
- [ ] **LOW** `delete_forum_comment` — delete forum comment
- [ ] **LOW** `delete_wiki_comment` — delete wiki comment
- [ ] **LOW** `edit_forum_comment` — edit forum comment
- [ ] **LOW** `edit_wiki_comment` — edit wiki comment
- [ ] **LOW** `update_forum_post` — update forum post
- [ ] **LOW** `search_wiki_articles` — search wiki articles
- [ ] **LOW** `search_forum_topics` — search forum topics
- [ ] **LOW** `search_forum_posts` — search forum posts
- [ ] **LOW** `ensure_agent_notes_category` — create or verify Agent Notes category
