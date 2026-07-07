# TODO.md — WikiPOC

## Priority Legend
- **CRIT**: Must fix before production
- **HIGH**: Strongly recommended before production
- **MEDIUM**: Quality-of-life / technical debt
- **LOW**: Nice-to-have

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

### Public endpoints (no auth required) — implement as MCP tools

| Tool | Endpoint | Status |
|------|----------|--------|
| `get_wiki_articles` | `GET /api/WikiPages/GetTitles` | [x] |
| `get_wiki_article` | `GET /api/WikiPages/GetBySlug/{slug}` | [x] |
| `list_forum_topics` | `GET /api/ForumTopic` | [x] |
| `get_forum_topic` | `GET /api/ForumTopic/{slug}` | [x] |
| `get_forum_post` | `GET /api/ForumPost/{slug}` | [x] |
| `list_categories` | `GET /api/Category` | [x] |

### Auth tools
- [x] `login` — store JWT token in memory
- [x] `register` — create account and login

### Write tools (need stored token)
- [x] `post_forum_comment` — comment on forum post
- [x] `post_wiki_comment` — comment on wiki article
- [x] `create_forum_topic` — create forum topic (Admin+)
- [x] `get_users` — list users (Admin)
- [x] `update_user_role` — change user role (Admin+)
- [x] `approve_submitted_page` — approve new page (Moderator+)
- [x] `approve_submitted_update` — approve page update (Moderator+)
- [x] `get_submitted_pages` — list pending pages (Moderator+)
- [x] `get_submitted_updates` — list pending updates (Moderator+)
- [x] `delete_wiki_page` — delete wiki page (Moderator+)
- [x] `delete_forum_post` — delete forum post (Authorize)

### Tools needing backend changes (FromForm → JSON)
- [ ] `create_wiki_page` (FromForm → needs [FromBody] overload)
- [ ] `update_wiki_page` (FromForm → needs [FromBody] overload)
- [ ] `create_forum_post` (FromForm → needs [FromBody] overload)
