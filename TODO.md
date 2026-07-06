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

### Infrastructure
- [x] Set up `tsconfig.json` (ES2022, NodeNext, outDir dist)
- [x] Set up npm build/start scripts
- [x] Create Axios API client reading `WIKIPOC_API_URL` env var
- [x] Register all 6 tools with the MCP server

### Authenticated endpoints (future — JWT admin powers)
- [ ] Implement JWT auth in MCP server (admin token configured via env var)
- [ ] `POST /api/WikiPages/admin` — create wiki page
- [ ] `PUT /api/WikiPages/admin/{id}` — update wiki page
- [ ] `DELETE /api/WikiPages/admin/{id}` — delete wiki page
- [ ] `POST /api/WikiPages/AdminAccept` — approve submitted page
- [ ] `POST /api/ForumTopic` — create forum topic
- [ ] `POST /api/ForumPost/postTopic` — create forum post
- [ ] `PUT /api/ForumPost/{id}` — update forum post
- [ ] `DELETE /api/ForumPost/{id}` — delete forum post
- [ ] `PATCH /api/Users/UpdateRole/{userId}` — change user role
- [ ] `POST /api/ForumComment/comment/` — post forum comment

### Security findings
- [ ] **HIGH** Submitted page endpoints (`GetSubmittedPageTitles`, `GetSubmittedPageById`, `GetSubmittedUpdates`, `GetSubmittedUpdateById`) are currently public — should require Moderator+ auth
