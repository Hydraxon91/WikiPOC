# AGENTS.md - WikiPOC Development Guide

## Agent Behavioral Rules

- **No Hallucinated Code:** Never write or refactor code you have not explicitly read in the current session. Always search for and read the target file first. Do not assume the state of any file based on previous chat memory. If a file has not been printed or searched in the current turn, you must locate and read it before proposing edits.
- **Root-Cause Debugging:** Do not "band-aid" errors (e.g., adding arbitrary null-checks or empty try/catch blocks). You must trace errors back to their origin (e.g., database schemas, incorrect foreign keys) and fix them there.
- **Style Alignment:** Strictly mirror the syntax, pattern choices, and formatting of the existing codebase. If the file uses arrow functions, use arrow functions. If it uses standard functions, match that.
- **Hypothesis Verification:** Before proposing a fix, explain the expected behavior, the actual behavior, and the evidence (log line, stack trace, or code block) that proves your theory.

## Important Rule for AI Agents

**Before performing any destructive actions** (like file deletions, large refactors, or package downgrades), **committing**, **or pushing to remote**, you **must**:
1. Explicitly propose the plan
2. Explain your reasoning
3. The only acceptable confirmation is an explicit 'y', 'yes', or direct written approval from the user. Do not treat follow-up questions, clarifications, or silence as implied consent to proceed with the proposed action.

## External Infrastructure & Integration Locks

- **Do Not Change External Services:** Never migrate, switch, or replace existing external third-party services, host providers, package managers, or image registries (e.g., Docker Hub, GitHub Packages/GHCR, Azure, NuGet, npm) under any circumstances—even if you believe a build, push, or pull failure is caused by the registry. If a registry-related error occurs, stop immediately, report the error, and await manual instruction.
- **No Stealth Infrastructure Changes:** Any proposed changes to CI/CD pipelines, environments, secrets, or deployment targets must be explicitly highlighted in your plan. If a plan involves changing where code is published, hosted, or pulled from, you must call this out as a "Major Infrastructure Change" and await explicit confirmation.

### Dependency & Ecosystem Lock

- **No Unsolicited Package Changes:** Never add, remove, or upgrade any packages in `package.json` or `.csproj` files unless explicitly requested to resolve a specific bug or feature requirement.
- **No Swapping Established Libraries:** Do not replace existing architectural libraries (e.g., replacing Axios with native Fetch, or changing the test runner). Work strictly within the established tech stack.

### Anti-Churn & Code Preservation

- **Strict Scope Containment:** Do not refactor, rewrite, or "clean up" working code outside the immediate scope of the assigned task. If you notice messy code or technical debt nearby, point it out to the user in chat—do not touch it "while you're in there".
- **No Style Conversions for Aesthetics:** If existing code is functional and matches the codebase style guidelines, leave it alone. Do not change working syntax (e.g., converting standard functions to arrow functions, or loop styles) unless aligning a newly written feature.

### Reuse Existing Architecture

- **Audit Existing Utilities First:** Before creating a new helper function, service, or utility method, explicitly search the codebase to see if a similar mechanism already exists[cite: 2]. 
- **Utilize Project Helpers:** Always prioritize using existing project utilities (for example, using the existing `SlugHelper` for text manipulation or using established repository patterns) over inventing local custom logic[cite: 2].

### Environment Variable Guardrails[cite: 2]

- **No Secret or Env Inventions:** Never introduce a new `Environment.GetEnvironmentVariable()` or `process.env` dependency without explicitly calling it out to the user first[cite: 2]. 
- **Documentation Requirement:** Any new environment variables must be simultaneously documented in the root `.env` template or the designated setup file inside the same session[cite: 2].

## Agent Behavior Guidelines[cite: 2]

- **Load the `wikipoc-mcp` and `wikipoc-frontend` skills first thing in every session.** These load the MCP tool reference, frontend conventions, and trigger the proactive session start workflow (checking for handoff notes and persistent context in WikiPOC)[cite: 2].
- **When doing backend work, load `wikipoc-backend` as well.** It covers the .NET stack, repository patterns, entity relationships, auth system, and the critical FK naming gotchas (e.g. `ForumPost.UserId` → `UserProfiles.Id`)[cite: 2].
- **Avoid over-deliberation.** Plan once, then act[cite: 2]. Do not re-plan or second-guess a chosen approach more than once before executing, unless new information (e.g. a build error) genuinely changes the picture[cite: 2].
- **Stop after completing the requested task.** Summarize what you did and what you found, then wait for the next instruction[cite: 2]. Do not move on to a new task — commits, cleanup, further refactors, starting the next item on a todo list — unless explicitly asked, even if it seems like the obvious next step[cite: 2].
- **Reserve deep reasoning for genuinely ambiguous or destructive decisions** (see confirmation rule above), not for routine refactors or migrations with a clear precedent already in this codebase[cite: 2].

## Commit Discipline[cite: 2]

- **Always ask before committing or pushing, full stop — no exceptions.** This applies to code changes too, not just housekeeping files[cite: 2]. Before running `git commit` or `git push`, show me what you're about to commit (`git status` / `git diff --stat` and the proposed commit message) and wait for my confirmation[cite: 2]. Do not commit as an automatic last step of finishing a task, even if the fix is small and confirmed working[cite: 2].
- **Commit immediately after each individual fix is done and verified — don't batch multiple fixes into one commit-at-the-end.** If a session involves fixing 3 separate things, that's 3 separate commit proposals at 3 separate points, not one summary commit after everything is done[cite: 2]. As soon as one fix is complete and verified, stop and propose committing just that fix before moving to the next one[cite: 2].
- **A commit should touch the smallest number of files possible for the one change it represents.** If you're about to commit and the file list includes anything not directly required for the one fix being committed (e.g. an unrelated formatting change, a file you touched while investigating but didn't actually need to change), stop and either revert that unrelated change or ask whether it should be a separate commit[cite: 2].
- **Keep commits atomic.** Each commit should represent one logical change — not a grab-bag of everything done in a session[cite: 2]. If a task naturally splits into unrelated parts (e.g. "migrate assertions" + "fix unrelated .env typo" + "suppress a migration warning"), commit them separately, even if they happened back-to-back in the same session[cite: 2].
- **Commit message should describe the one thing, not summarize everything.** If you're struggling to write a single clear sentence for what changed, that's a sign the commit should be split[cite: 2].
- **Don't bundle unrelated fixes "while you're in there."** If you notice an unrelated issue while working on something else, mention it and ask, or commit it separately — don't fold it into the current commit[cite: 2].

## CI/CD Pipeline & GitHub Actions

The repository enforces a highly optimized, DAG-based CI/CD pipeline via GitHub Actions to ensure maximum speed and safety. Any changes you make to the codebase *must* keep this pipeline green.

### Pipeline Workflows
1. **`backend-tests.yml` (Reusable):** Runs type-checking (`tsc --noEmit`), build check, and backend tests against a live SQL Server container on every push/PR[cite: 2].
2. **`ci.yml` (Primary Pipeline):** An optimized, non-linear dependency tree designed to minimize run times and fail-fast[cite: 2]:
   * **Stage 1 (Immediate parallel execution):** 
     * `frontend-lint` (no dependencies; starts immediately)
     * `backend-build` (no dependencies; starts immediately)
     * `codeql-javascript` (no dependencies; starts immediately)
   * **Stage 2 (Build-dependent parallel execution):**
     * `backend-test` (runs in parallel with `codeql-csharp` after `backend-build` succeeds; automatically skipped on build failure to save ~2-3 min)
     * `codeql-csharp` (runs in parallel with `backend-test` after `backend-build` succeeds; automatically skipped on build failure to save ~2-3 min)
   * **Stage 3 (Validation & Publish):**
     * `docker-build` (requires **all five** preceding jobs to pass successfully before starting)
     * `docker-publish` (runs after `docker-build` succeeds; restricted to the `main` branch)[cite: 2]
     * `deploy` (runs after `docker-publish` succeeds; restricted to the `main` branch)[cite: 2]

### Security & Compliance Constraints
- **CodeQL Integration:** Every PR/merge runs CodeQL analysis for C# (build-dependent) and JS/TS (independent)[cite: 2]. Avoid introducing patterns that trigger security alerts (e.g., path traversal, unvalidated redirects, XSS)[cite: 2].
- **Trivy Vulnerability Scan:** The Docker publish stage runs a Trivy scan[cite: 2]. If you add third-party dependencies or change base images, verify they do not introduce HIGH or CRITICAL vulnerabilities, or the deployment will fail[cite: 2].
- **Non-Root Runtime Container:** The final stage of the `Dockerfile` enforces a non-root `USER` directive[cite: 2]. Do not write scripts or backend code that assume root-level directory write access at runtime[cite: 2].

### Branch Protection & Merging
- Direct pushes to `main` are restricted[cite: 2]. All changes must go through a Pull Request, requiring a passing CI run and peer approval before merging[cite: 2]. Use the `PULL_REQUEST_TEMPLATE.md` guidelines for PR descriptions[cite: 2].

## Docker Workflow[cite: 2]

- **Run Docker commands one at a time, not chained with `&&`.** Check the
  result of each command before running the next. If a command fails,
  stop and show the actual error — don't chain to the next step assuming
  it succeeded.
- **For frontend-only changes:**
  ```bash
  docker-compose up -d --build wiki-backend
  ```
  (single command; the multi-stage Dockerfile rebuilds the SPA and backend)
- **If a full rebuild is genuinely needed**, run each step separately and
  confirm it completed before the next:
  ```bash
  docker-compose down -v
  ```
  then
  ```bash
  docker-compose build --no-cache
  ```
  then
  ```bash
  docker-compose up -d
  ```
- **Reserve the full rebuild for**: `package.json`/NuGet dependency
  changes, Docker config changes (Dockerfile, docker-compose.yml), or
  database schema changes requiring a fresh volume. Don't reach for this
  by default for routine code edits.
- **If any single command fails, stop and report the exact error** — do
  not retry the same command, do not chain to the next step, and do not
  escalate to a more destructive command hoping it works instead.

### Test Output Handling

- **Run integration/unit tests with output redirected to a file — every time,
  no exceptions:**
  ```bash
  dotnet test wiki-backend/IntegrationTests/IntegrationTests.csproj --no-build > test-output.log 2>&1
  ```
  Never pipe `dotnet test` straight into `grep`/`tail` and then run it again
  with a different filter. If you need to look at the results a different
  way (failed tests only, full error messages, summary line), grep or `cat`
  `test-output.log` — do not re-run the test suite. These tests hit a real
  SQL Server and take several minutes; re-running to change a filter is
  always wrong.
- **Stop running tests once you have a clear lead, even if you don't have a
  full pass/fail summary.** A test name plus its error message is usually
  enough to start debugging. Example: if several JWT-related tests fail with
  the same underlying exception (e.g. a Base64Url decode error), that's a
  single root cause to go investigate in the token-generation code — not a
  reason to re-run the suite for a "final summary" first.
- **Look for a shared root cause before treating failures as independent.**
  When multiple failing tests share an exception type or message, fix the
  shared cause first and re-test once, rather than investigating each test
  separately.

## Project Overview

WikiPOC is a **customizable, multi-era Wikipedia-style wiki platform**. The core feature is backend-driven theming: the wiki owner can customize colors, layout tokens, and choose between distinct visual eras (Glassmorphic, Frutiger Aero, Wikipedia, Modern) through an admin interface (`/edit-wiki`), saved to the database as an expanded `StyleModel` and served via `StyleContext`.

**This means styling uses a hybrid architecture:** 
1. Inline `style={{...}}` props throughout the frontend are intentional for serving dynamic, raw database values (like specific brand accent colors).
2. Global layout configurations and era-specific aesthetics (like gloss overlays or glass blurs) are applied by appending an era class wrapper (e.g., `.era-glass`, `.era-frutiger`) to the application container, utilizing modern CSS variables and native features like `color-mix()`.

Tech stack:
- **.NET 10 ASP.NET Core backend** (wiki-backend/)
- **React 19 + Vite + TypeScript frontend** (wiki-frontend/)
- **SQL Server** database
- **Docker Compose** orchestration
- **GitHub Actions** CI/CD (unit tests, integration tests, Docker image build/push)

## Architecture

```
WikiPOC/
├── wiki-backend/
│   ├── wiki-backend/         # Main ASP.NET Core app (serves both API + SPA)
│   ├── UnitTests/            # NUnit unit tests
│   └── IntegrationTests/     # NUnit integration tests
├── wiki-frontend/            # React SPA (Vite + TypeScript, built into backend wwwroot/)
└── docker-compose.yml        # Orchestrates backend + SQL Server
```

## Quick Start

### Prerequisites
- Docker & Docker Compose
- .NET 10 SDK (for local backend dev)
- Node.js 22+ (for local frontend dev)

### Run with Docker (Recommended)
```bash
# Create .env file with required variables (see Environment section)
docker-compose up --build
```
- Frontend: http://localhost:5050
- Backend API: http://localhost:5050
- SQL Server: localhost:1433

### Local Development
```bash
# Backend (wiki-backend/wiki-backend/)
dotnet restore && dotnet run

# Frontend (wiki-frontend/)
npm install && npm run dev
```

## Environment Variables (.env)

Required in root `.env` file:

```bash
# Database
ASPNETCORE_CONNECTIONSTRING=Server=sql-server;Database=WikiDb;User=sa;Password=<DB_PASSWORD>
DB_PASSWORD=YourStrongPassword123!

# Admin User
ADMINUSER_EMAIL=admin@admin.com
ADMINUSER_PASSWORD=AdminPass123
ADMINUSER_USERNAME=Admin

# Test User
TESTUSER_EMAIL=test@test.com
TESTUSER_PASSWORD=TestPass123
TESTUSER_USERNAME=TestUser

# JWT Configuration
JWT_ISSUER_SIGNING_KEY=YourSecretKey32CharsLong!
JWT_VALID_AUDIENCE=WikiPOCAudience
JWT_VALID_ISSUER=WikiPOCIssuer
JWT_TOKEN_TIME=60

# File Paths
PICTURES_PATH=/path/to/local/pictures
PICTURES_PATH_CONTAINER=/pictures

# Frontend API URL
VITE_API_URL=http://localhost:5050

# Frontend URL (for embed OG tags — should point to the public frontend domain)
FRONTEND_URL=https://your-frontend-domain.com
```

> **Note**: Setting `FRONTEND_URL` is required for correct `og:url` meta tags in embed responses. If set to empty, the embed controller falls back to `X-Forwarded-Proto://Request.Host`, which may produce incorrect URLs behind proxies.
>
> **When the backend serves the frontend** (current architecture), set `VITE_API_URL` to empty (`""`) in production builds so API calls are same-origin relative paths. This makes the build portable across hosting providers. The `FRONTEND_URL` env var on the backend replaces what `VITE_API_URL` used to provide for embed redirects.

> **CI/CD**: The `JWT_*` secrets above must also be added as GitHub Actions secrets in the repo (Settings → Secrets and Actions) or the integration tests will fail with `IDX10703`.

## Authentication & Authorization

### Backend Auth Setup
- **JWT Bearer authentication** with configurable signing key
- **ASP.NET Core Identity** for user management
- **Four roles**: `Owner`, `Admin`, `Moderator`, and `User`
- Owner inherits Admin privileges (policies, routes, sidebar)

### Authorization Policies
```csharp
// Policy: "Admin" - requires Role claim = "Admin" or "Owner"
// Policy: "User" - requires Role claim = "User", "Moderator", "Admin", or "Owner"
// Policy: "Moderator" - requires Role claim = "Moderator", "Admin", or "Owner"
```

### Default Users (seeded on startup)
| Role     | Email              | Username   |
|----------|--------------------|------------|
| Owner    | admin@admin.com    | Admin      |
| Moderator| configurable via MODERATOR_* env vars | (from env) |
| User     | test@test.com      | TestUser   |

### Protected Routes (Frontend)
- **Admin/Moderator-only**: `/edit-wiki` (Owner only), `/user-submissions`, `/user-updates`, `/categories/edit`, `/forum/create-topic`
- **Admin-only**: `/admin/users`
- **Authenticated (User+/Moderator+)**: `/create`, `/page/:slug/edit`, `/profile/edit/:username`, `/forum/:slug/create-post`
- **Public**: `/login`, `/register`, `/forum/:slug`

## Key Commands

### Backend
```bash
# Run
dotnet run --project wiki-backend/wiki-backend

# Build
dotnet build wiki-backend/wiki-backend.sln

# Unit Tests
dotnet test wiki-backend/UnitTests/UnitTests.csproj

# Integration Tests (requires INTEGRATIONTEST_CONNECTIONSTRING)
dotnet test wiki-backend/IntegrationTests/IntegrationTests.csproj

# Migrations (run from wiki-backend/wiki-backend/)
dotnet ef migrations add MigrationName
dotnet ef database update -- --environment Development
```

### Frontend
```bash
cd wiki-frontend

# Dev server (Vite)
npm run dev

# Build production
npm run build

# Tests
npm test
```

> **Note**: `npm test` runs `tsc --noEmit` (TypeScript type-check), not a test framework. For actual frontend tests, add vitest.

### Docker
```bash
# Start all services
docker-compose up

# Rebuild and start
docker-compose up --build

# Stop
docker-compose down

# View logs
docker-compose logs -f
```

## Project Structure & Conventions

### Backend (wiki-backend/wiki-backend/)

**Controllers by Feature:**
- `ArticleControllers/` - WikiPages
- `UserControllers/` - Users, Auth, UserProfile, UserComments
- `ForumControllers/` - ForumTopics, ForumPosts, ForumComments
- `OtherControllers/` - Style, Categories, Images

**Repository Pattern:**
- All data access via repositories in `DatabaseServices/Repositories/`
- Interfaces prefixed with `I` (e.g., `IWikiPageRepository`)

**Models:**
- `ArticleModels/` - WikiPage, Paragraph, UserSubmittedWikiPage
- `UserModels/` - ApplicationUser, UserProfile, UserComment
- `ForumModels/` - ForumTopic, ForumPost, ForumComment
- `Form Input Output Models/` - DTOs for API I/O

**Services:**
- `IAuthService` / `AuthService` - Authentication logic
- `ITokenServices` / `TokenServices` - JWT token generation
- `IImageStorageService` / `ImageStorageService` - Image file I/O
- `IUserAuthorizationService` / `UserAuthorizationService` - Role checks
- `SlugHelper` - Shared slug generation utility (used by WikiPage, ForumTopic, ForumPost)

### Frontend (wiki-frontend/src/)

**Context Providers:**
- `StyleContext` - Global wiki styling (colors, logo, fonts)
- `UserContextProvider` - Current user state

**API Layer (src/Api/):**
- `wikiApi.ts` - Wiki pages, categories, styles
- `wikiAuthApi.ts` - Login/register
- `wikiUserApi.ts` - User profiles
- `forumApi.ts` - Forum operations
- `apiClient.ts` - Centralized HTTP client (handles auth, JSON, errors)

**Key Pages:**
- `MainPage/` - Home with article list
- `WikiPage-Article/` - Article view
- `CreateEditArticle/` - Editor (legacy + new)
- `UserSubmittedArticle-Update/` - Admin approval workflow
- `ForumPages/` - Forum components (landing, topic view, post view, create topic, create post)

### MCP Server (wikipoc-mcp/)

A standalone TypeScript MCP server at `wikipoc-mcp/` that exposes WikiPOC's REST API
as tools for LLMs via the [Model Context Protocol](https://modelcontextprotocol.io).

**Tools (public, no auth):**

| Tool | Description | API Endpoint |
|------|-------------|-------------|
| `get_wiki_articles` | List all article titles | `GET /api/WikiPages/GetTitles` |
| `get_wiki_article` | Get article by slug | `GET /api/WikiPages/GetBySlug/{slug}` |
| `list_forum_topics` | List all forum topics | `GET /api/ForumTopic` |
| `get_forum_topic` | Get forum topic with posts | `GET /api/ForumTopic/{slug}` |
| `get_forum_post` | Get forum post with comments | `GET /api/ForumPost/{slug}` |
| `list_categories` | List all categories | `GET /api/Category` |

**Architecture:**
- Uses `@modelcontextprotocol/sdk` with `stdio` transport (spawned as a local child process)
- Reads `WIKIPOC_API_URL` env var (defaults to `http://localhost:5050`)
- Calls the backend via `axios` — each tool maps to one public GET endpoint
- No auth for read tools; write tools planned with JWT admin token via env var

**Connection (opencode.json):**
```json
{
  "mcpServers": {
    "wikipoc-mcp": {
      "name": "WikiPOC MCP",
      "type": "stdio",
      "command": "node",
      "args": ["/path/to/wikipoc-mcp/dist/index.js"],
      "env": {
        "WIKIPOC_API_URL": "http://localhost:5050"
      }
    }
  }
}
```

**Build & run:**
```bash
cd wikipoc-mcp
npm install && npm run build
npm start  # node dist/index.js (stdio, no output until called)
```

## Important Workflows

### User Submission Workflow (Non-Admin)
1. User creates/edits page → saved as `UserSubmittedWikiPage`
2. Admin reviews at `/user-submissions` or `/user-updates`
3. Admin accepts → page published; declines → discarded

### Image Handling
- Images stored as FormData with WikiPage submissions
- Backend path configured via `PICTURES_PATH_CONTAINER` env var
- Served via `/api/Image/{filename}` endpoint

### Style Customization
- Admin-only feature managed at `/edit-wiki`.
- Controls: wiki name, brand colors, fonts, logo, layout spacing tokens, and structural design era selections.
- **Database Activation Constraint:** Active styles are tracked via a dedicated `IsActive` boolean column in the database. Activating a theme must invoke a unified repository transaction that sets `IsActive = false` globally across all rows before setting `IsActive = true` on the targeted row. Row order or ID sequences must never be used to infer which theme is active.

### Embed System (Server-Side OG Tags)

The embed system provides correct OG meta tags (title, description, image, URL, type) for social media scrapers (Discord, Telegram, Twitter, Facebook, etc.) without requiring client-side JavaScript.

**Architecture:**
- **Bot detection**: Centralized compiled regex in `Identity/BotPatterns.cs` matching Discordbot, Twitterbot, TelegramBot, facebookexternalhit, Slackbot, LinkedInBot, WhatsApp, Pinterest, redditbot, Iframely.
- **`ScraperEmbedMiddleware`** in `Middleware/ScraperEmbedMiddleware.cs`: For scraper UAs hitting `/page/{slug}` or `/forum/{topicSlug}/{postSlug}`, the middleware directly resolves `IWikiPageRepository`, `ISiteSettingsRepository`, `IForumPostRepository`, `IForumTopicRepository`, and `IMemoryCache` from DI, builds the embed HTML, and writes it to the response — **bypassing the ASP.NET Core routing system entirely**.
- **Why bypass routing?** Setting `context.Request.Path` in middleware does NOT route to controllers on Azure/ASP.NET Core 10. The path rewrite silently falls through to `MapFallbackToFile("index.html")`. Direct embed generation avoids this.
- **`EmbedController`** at `/embed/wiki/{slug}` and `/embed/forum/{postSlug}` — a reusable controller that works when hit directly but is NOT reachable via middleware path rewrite.
- **`usePageMeta.ts`** — frontend hook that dynamically sets browser tab title, favicon, and OG meta tags for client-side navigation after the SPA loads.

**Three-Tier Image Fallback:**
1. Article-specific image from `page.Images`
2. Custom site logo from `SiteSettings.Logo` (if not the default placeholder `logo/logo_pfp.png`)
3. Bundled SPA asset at `/img/logo.png` (copied from `wiki-frontend/public/img/logo.png` to `wwwroot/img/logo.png` during build)

**Key Files:**
- `wiki-backend/wiki-backend/Middleware/ScraperEmbedMiddleware.cs` — inline embed generation for wiki pages and forum posts
- `wiki-backend/wiki-backend/Controllers/OtherControllers/EmbedController.cs` — reusable embed endpoint (shared helper methods)
- `wiki-backend/wiki-backend/Identity/BotPatterns.cs` — shared scraper UA regex (`BotPatterns.ScraperUserAgentRegex`)
- `wiki-frontend/src/hooks/usePageMeta.ts` — client-side meta tag updates
- `wiki-frontend/src/Components/contexts/SiteSettingsContext.tsx` — wiki name and logo for embeds
- `wiki-frontend/public/img/logo.png` — bundled fallback logo in wwwroot

## Testing Notes

### Unit Tests
- Pure unit tests with mocks
- Run with: `dotnet test wiki-backend/UnitTests/`

### Integration Tests
- Use real SQL Server (separate test DB per run)
- Require `INTEGRATIONTEST_CONNECTIONSTRING` env var (set in `wiki-backend/IntegrationTests/.env`)
- Auto-create unique test databases, clean up on dispose
- Run with: `dotnet test wiki-backend/IntegrationTests/`

## Gotchas

1. **Docker startup race**: Backend may start before SQL Server is ready. The docker-compose setup now uses Docker native healthchecks (`sqlcmd` query on SQL Server) with `depends_on: condition: service_healthy` to prevent this. No manual `wait-for-it.sh` uncommenting needed.

2. **Frontend build**: `VITE_API_URL` must be passed as build arg to Docker. The frontend Dockerfile captures this correctly.

3. **JWT expiration**: Default 60 minutes (`JWT_TOKEN_TIME`). Adjust in .env.

4. **Database migrations**: Backend auto-migrates on startup. For manual migrations, run from `wiki-backend/wiki-backend/` directory.

5. **CORS**: Configured for `http://localhost:3000` and `http://localhost:3001`. Override via `AllowedOrigins` env var (semicolon-separated). Update `Program.cs:AddCors()` if using different ports.

6. **Profile pictures path**: Ensure `PICTURES_PATH` directory exists on host machine before starting Docker.

7. **Bootstrap Overrides & Specificity Walls:** The app imports standard Bootstrap styles globally before applying the custom theme layer. When writing or modifying styles for buttons, input fields, select groups, or textareas, you must explicitly wrap your selectors using era scoped blocks (e.g., `.era-glass .form-control`, `.era-modern .btn`) or use context-safe overrides to prevent Bootstrap's base styles from squashing translucent glass surfaces, dynamic fonts, or border aesthetics.

8. **Volumetric Reflection Blockers:** When implementing the Frutiger Aero or Glassmorphic glossy overlays via layout pseudo-elements (`::before` / `::after`), you must apply `pointer-events: none` to the overlay layers. If omitted, these structural gloss fields act as an invisible barrier, preventing users from selecting text, clicking links, or submitting forum comments.

9. **Proportional Nested Blurs:** When working with deeply nested comment layout containers (e.g., nested forum discussion threads), avoid hardcoded recursive backdrop filters. Scale down nested container blurs proportionally using fractional CSS multipliers (`calc(var(--glass-blur-radius) * 0.6)`) to preserve clean textual legibility on high-density user displays.

10. **ScraperEmbedMiddleware uses direct HTML generation (no path rewrite):** Because `context.Request.Path` modification in middleware does NOT route to controllers on ASP.NET Core 10 + Azure, the middleware generates embed HTML directly inline instead of rewriting the path. Do NOT change it back to a path-rewrite approach.

11. **PurgeCSS Safelist (CSS Tree-Shaking):** Production builds use `@fullhuman/postcss-purgecss` via `postcss.config.cjs` to remove unused Bootstrap and custom CSS. If you add new CSS classes that are applied dynamically (template literals, state-driven, user-configured), they **must** be added to the safelist in `postcss.config.cjs` or they will be stripped in production builds. The safelist has three tiers:
    - **`standard`** (exact/regex match): `era-*`, `glass-*`, `frutiger-*`, `ql-*`, `flag-badge`, `depth-N`, `fp-*`
    - **`deep`** (children preserved): `wikipage-*`, `hamburger-*`, `profile-*`, `sidebar`, `top-header`, `editButton`, `era-button`, `aero-*`, etc.
    - **`greedy`** (entire rule kept): All Bootstrap component prefixes (`btn*`, `form-*`, `modal*`, `nav*`, `dropdown*`, etc.)
    If you add a new component with its own CSS prefix, add it to the appropriate tier. If PurgeCSS strips needed styles in production but not dev, that means the safelist is missing an entry.

## Embed Middleware (Refactored July 2026)

`ScraperEmbedMiddleware` was refactored from inline Program.cs code into a proper middleware class. The `/debug-middleware` endpoint and the old path-rewrite approach were removed.

## Session Handoff (July 2026 — Session 2)

### Current State
- Backend serves the SPA via `UseStaticFiles()` + `MapFallbackToFile("index.html")` — single container, one Azure App Service
- Multi-stage Docker build (Node 22 → .NET SDK → runtime)
- Azure SWA workflow deleted (deprecated)
- Embed system working: server-side OG tags for Discord/Telegram/Twitter/Facebook/etc.
- Image fallback: bundled `/img/logo.png` in wwwroot (replaces nonexistent DB-seeded `logo_pfp.png`)
- **0 ESLint warnings**, **0 Roslyn warnings**, both projects build clean
- CI/CD pipeline includes lint, build, test, CodeQL (C# + JS/TS), Docker build/publish, Trivy scan, Azure deploy with fail-fast DAG
- **Comment flagging & moderation system fully implemented** — users can flag comments, moderators/admins/owners can review and act on them
- **Forum comments use soft delete** (`IsDeleted` flag) — preserves quote references so replies show `[Quoted message has been deleted]`
- **Wiki comments use hard delete with cascade** — deleting a parent also removes child replies
- **Moderators, Admins, and Owners can now delete any comment** (previously only Admins could)
- **`GET /api/Users/GetUsers` now returns `userProfileId`** alongside `id` — fixes the MCP UserProfileId vs ApplicationUser ID confusion
- **Performance audit logged** — TODO.md contains all Lighthouse findings (Mobile 61/100, Desktop 75/100)

### Built This Session (July 2026 — Session 2)

#### Comment Flagging System
- **`CommentFlag` model** with `CommentId`, `CommentType` (Forum/Wiki), `FlaggedByUserProfileId`, `Reason`, resolved state — single polymorphic table, no FK constraint on CommentId
- **`ICommentFlagRepository` / `CommentFlagRepository`** — AddFlag, GetUnresolvedFlags, GetUnresolvedCount, ResolveFlag, ResolveAllFlagsForComment, DeleteFlag, DeleteFlagsForComment
- **`DbSet<CommentFlag>`** in `WikiDbContext` + fluent config for FlaggedBy/ResolvedBy relationships
- **EF Migration** `AddCommentFlags`

#### Flag Endpoints
- `POST /api/ForumComment/{id}/flag` — any authenticated user can flag a forum comment (body: reason string)
- `POST /api/UserComment/{id}/flag` — any authenticated user can flag a wiki comment (body: reason string)

#### Moderation Controller
- `GET /api/Moderation/flagged-comments` — lists unresolved flags with denormalized comment content/author (Moderator+)
- `GET /api/Moderation/flagged-comments/count` — count for badge (Moderator+)
- `PUT /api/Moderation/flagged-comments/{flagId}/resolve` — dismiss a flag (Moderator+)
- `DELETE /api/Moderation/flagged-comments/{flagId}/delete-comment` — soft-deletes forum comment or hard-deletes wiki comment, resolves all its flags (Moderator+)
- `DELETE /api/Moderation/flagged-comments/{flagId}` — admin-only hard delete of flag record

#### Frontend UI
- **"Flag" button** on each forum comment (next to Quote) and wiki comment (next to Edit/Reply) — only shows for authenticated users
- **`FlagCommentModal`** — centered overlay with reason textarea, responsive (40% desktop / 90% mobile)
- **`/moderation/flagged-comments` page** — lists flagged comments with Delete & Resolve / Dismiss buttons
- **Sidebar badge** — shows unresolved count in both desktop sidebar (`WikiList.tsx`) and hamburger menu (`HamburgerMenu.tsx`)
- **Nav route** added in `App.tsx` — `ProtectedRoute` for Moderator+, Admin+, Owner+

#### MCP Tools
- `flag_forum_comment` — flag a forum comment
- `flag_wiki_comment` — flag a wiki comment
- `get_flagged_comments` — list flagged comments (moderator+)
- `resolve_comment_flag` — resolve a flag

#### Fixes & Improvements
- **Auth fix**: Both `ForumCommentController` and `UserCommentController` now use `IsUserModerator` instead of `IsUserAdmin` — grants delete access to Moderator, Admin, AND Owner roles (previously only Admin)
- **`IUserAuthorizationService` extended**: Added `IsUserModerator(userName)` checking for "Moderator", "Admin", or "Owner" Identity roles
- **Forum comment soft delete**: `DeleteAsync` sets `Content = null, IsDeleted = true` instead of removing the row. Children with `ReplyToCommentId` pointing to the deleted parent are preserved — FK reference stays intact, frontend shows placeholder
- **Wiki comment cascade delete**: `UserCommentRepository.DeleteAsync` now loads and recursively deletes child replies before removing the parent
- **Forum quote placeholder**: `renderQuote` checks `replyComment?.isDeleted` — shows `[Quoted message has been deleted]` when the quoted comment was soft-deleted. Also checks `response`;
- **Flagged comments page**: Now uses `dangerouslySetInnerHTML` to properly render HTML content from web-posted comments
- **`GetUsers` returns `userProfileId`**: Added `user.ProfileId` as both `ProfileId` and `UserProfileId` to the response DTO — LLMs can now use this directly for comment/post creation
- **Wiki comment layout**: Edit and Flag buttons moved inline into the name/dateline (`.wikipage-comment-data`) instead of rendering below the comment text
- **Desktop sidebar link**: Added "Flagged Comments" to `WikiList.tsx` (the visible desktop sidebar, not just the hamburger drawer)
- **`.flag-badge` CSS** moved to `style.css` for global availability
- **Frutiger Aero sidebar**: Background gradient now uses `color-mix(in srgb, var(--custom-body-color, ...), white)` instead of hardcoded rgba values

### Known Issues
1. `ScraperEmbedMiddleware` generates embed HTML directly (no path rewrite) — `context.Request.Path` rewrite doesn't route to controllers on Azure/ASP.NET Core 10.
2. `logo_pfp.png` doesn't exist on Azure filesystem — all fallbacks use `/img/logo.png`. This also causes a 404 console error logged by Lighthouse (Best Practices).
3. Images persist only within a container session; lost if fully killed and rehosted (Azure Free Tier limitation). Custom logo upload via `/site-settings` survives within session but not a full restart.
4. Token refresh effect in `App.tsx` intentionally runs once on mount (not in dep array) to avoid refresh loop.
5. Performance scores: Mobile 61, Desktop 75. Lighthouse audit results in TODO.md under Performance section.
6. No security headers (CSP, HSTS, XFO, COOP) are set — noted as CRIT in TODO.md.

### Required Next Steps
- See `TODO.md` for full performance/accessibility/security improvement backlog
- Priority items: cache headers, `font-display: swap`, image width/height attributes, security headers

## Files of Interest

- `wiki-backend/wiki-backend/Program.cs` - Main entry point, DI setup, seeding
- `wiki-backend/wiki-backend/Identity/IdentityData.cs` - Role/policy constants
- `wiki-backend/wiki-backend/Identity/BotPatterns.cs` - Shared scraper UA regex for embeds
- `wiki-backend/wiki-backend/Controllers/OtherControllers/EmbedController.cs` - Reusable embed endpoint
- `wiki-backend/wiki-backend/Controllers/OtherControllers/ModerationController.cs` - Flagged comments moderation endpoints
- `wiki-backend/wiki-backend/Middleware/ScraperEmbedMiddleware.cs` - Inline embed generation for wiki pages and forum posts
- `wiki-backend/wiki-backend/Models/Other Models/CommentFlag.cs` - Comment flag entity model
- `wiki-backend/wiki-backend/DatabaseServices/Repositories/CommentFlagRepository/` - Comment flag repository
- `wiki-backend/wiki-backend/Services/UserAuthorizationService.cs` - Role-check service (IsUserAdmin, IsUserModerator)
- `wiki-frontend/src/App.tsx` - React router, protected routes, moderation route
- `wiki-frontend/src/Api/moderationApi.ts` - API client for flagged comments
- `wiki-frontend/src/Api/forumApi.ts` - Added `flagForumComment`
- `wiki-frontend/src/Api/wikiUserApi.ts` - Added `flagUserComment`
- `wiki-frontend/src/Components/FlagCommentModal.tsx` - Reusable flag reason dialog
- `wiki-frontend/src/Pages/Moderation/FlaggedCommentsPage.tsx` - Moderation queue page
- `wiki-frontend/src/Pages/Moderation/Moderation.css` - Moderation page styles
- `wiki-frontend/src/Pages/MainPage/Components/WikiList.tsx` - Desktop sidebar with flagged comments link
- `wiki-frontend/src/Pages/MainPage/Components/HamburgerMenu.tsx` - Mobile drawer with flagged comments link + badge
- `wiki-frontend/src/Styles/style.css` - Global styles (flag-badge, Frutiger Aero sidebar fix)
- `wiki-frontend/src/Styles/wikipage.css` - Wiki comment data line flex layout
- `wiki-frontend/src/types/models.ts` - Added `isDeleted` to ForumComment
- `wikipoc-mcp/src/index.ts` - MCP server entry point (has flagging tools now)
- `wikipoc-mcp/README.md` - MCP server documentation and opencode.json config
- `.github/workflows/ci.yml` — primary CI/CD pipeline
- `.github/workflows/backend-tests.yml` — reusable test workflow
- `TODO.md` — Full backlog including performance audit results