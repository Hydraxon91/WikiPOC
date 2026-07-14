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

### Completed
- Removed orphaned `wiki-frontend/Dockerfile` (unused nginx-based image, replaced by multi-stage backend Dockerfile)
- Hardenend backend Dockerfile with non-root `USER`
- Added ESLint flat config (`eslint.config.js`) with TypeScript + React Hooks rules
- Enabled Roslyn code-style analyzers (`TreatWarningsAsErrors`, `EnforceCodeStyleInBuild`)
- Created `.github/workflows/ci.yml` with 7 jobs: lint, build, test, CodeQL (C# + JS/TS), Docker build, Docker publish, deploy
- Switched container registry from GHCR to DockerHub (Azure compatibility)
- DockerHub push + Trivy scan on main
- Azure App Service deploy on main
- Branch protection enabled on `main`

### Remaining
- [x] **CRIT** Add immutable image tags (`${{ github.sha }}`) via `docker/metadata-action`
- [x] **CRIT** Add deployment job (staging/prod environments)
- [x] **HIGH** Add `USER` directive to Dockerfiles (containers run as root)
- [x] **HIGH** Add PR template, CONTRIBUTING.md
- [x] **HIGH** Add CodeQL workflow + Trivy image scan
- [x] **HIGH** Add ESLint + Roslyn analyzers
- [x] **HIGH** Enable branch protection on `main`
- [x] **MEDIUM** Add coverage reporting (coverlet + ReportGenerator for .NET)
- [x] **MEDIUM** Add release tagging / changelog automation
- [x] **MEDIUM** Add GitHub Environments (staging vs prod)

### Tech Debt (CI/CD accommodations)
- [ ] **MEDIUM** Update Microsoft.OpenApi / Swashbuckle to remove NU1903 suppression
- [ ] **MEDIUM** Enable TreatWarningsAsErrors on test projects after NU1903 fix
- [ ] **MEDIUM** Refactor `var` → `let`/`const` across frontend (13 auto-fixable)
- [ ] **LOW** Fix `@typescript-eslint/no-unused-expressions` violations (6 files)
- [ ] **LOW** Fix `no-explicit-any`, `no-unused-vars`, `react-hooks/exhaustive-deps` across frontend

### Code Scanning Alerts (ci/cicd-tightening)
- [ ] **HIGH** Fix path injection in `ImageController.cs` (4 alerts) — validate filename after `Path.GetFileName`
- [ ] **LOW** Fix XSS-through-DOM in `DisplayProfileImageElement.tsx` — validate blob URL source

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

---

## UI Issues

- [ ] **LOW** Frutiger Aero era: sidebar background doesn't use `--custom-body-color` CSS variable (`.era-frutiger .sidebar` is hardcoded; unlike `.era-modern .sidebar` which references the variable). Update to respect theme color.
