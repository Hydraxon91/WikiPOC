# AGENTS.md - WikiPOC Development Guide

## Important Rule for AI Agents

**Before performing any destructive actions** (like file deletions, large refactors, or package downgrades), **committing**, **or pushing to remote**, you **must**:
1. Explicitly propose the plan
2. Explain your reasoning
3. Wait for the user's 'y' confirmation before executing

## Agent Behavior Guidelines

- **Load the `wikipoc-mcp` and `wikipoc-frontend` skills first thing in every
  session.** These load the MCP tool reference, frontend conventions, and
  trigger the proactive session start workflow (checking for handoff notes
  and persistent context in WikiPOC).
- **When doing backend work, load `wikipoc-backend` as well.** It covers the
  .NET stack, repository patterns, entity relationships, auth system, and
  the critical FK naming gotchas (e.g. `ForumPost.UserId` → `UserProfiles.Id`).
- **Avoid over-deliberation.** Plan once, then act. Do not re-plan or second-guess
  a chosen approach more than once before executing, unless new information
  (e.g. a build error) genuinely changes the picture.
- **Stop after completing the requested task.** Summarize what you did and
  what you found, then wait for the next instruction. Do not move on to a
  new task — commits, cleanup, further refactors, starting the next item on
  a todo list — unless explicitly asked, even if it seems like the obvious
  next step.
- **Bias toward incremental action over exhaustive upfront analysis.** For
  non-destructive changes (reading code, running tests, small edits), just do it
  — don't ask for confirmation or produce a lengthy plan first. **This does NOT
  override the commit discipline below — always ask before committing.**
- **Reserve deep reasoning for genuinely ambiguous or destructive decisions**
  (see confirmation rule above), not for routine refactors or migrations with
  a clear precedent already in this codebase.

## Commit Discipline

- **Always ask before committing or pushing, full stop — no exceptions.**
  This applies to code changes too, not just housekeeping files. Before
  running `git commit` or `git push`, show me what you're about to commit
  (`git status` / `git diff --stat` and the proposed commit message) and
  wait for my confirmation. Do not commit as an automatic last step of
  finishing a task, even if the fix is small and confirmed working.
- **Commit immediately after each individual fix is done and verified —
  don't batch multiple fixes into one commit-at-the-end.** If a session
  involves fixing 3 separate things, that's 3 separate commit proposals at
  3 separate points, not one summary commit after everything is done. As
  soon as one fix is complete and verified, stop and propose committing
  just that fix before moving to the next one.
- **A commit should touch the smallest number of files possible for the
  one change it represents.** If you're about to commit and the file list
  includes anything not directly required for the one fix being committed
  (e.g. an unrelated formatting change, a file you touched while
  investigating but didn't actually need to change), stop and either
  revert that unrelated change or ask whether it should be a separate
  commit.
- **Keep commits atomic.** Each commit should represent one logical change —
  not a grab-bag of everything done in a session. If a task naturally splits
  into unrelated parts (e.g. "migrate assertions" + "fix unrelated .env typo"
  + "suppress a migration warning"), commit them separately, even if they
  happened back-to-back in the same session.
- **Commit message should describe the one thing, not summarize everything.**
  If you're struggling to write a single clear sentence for what changed,
  that's a sign the commit should be split.
- **Don't bundle unrelated fixes "while you're in there."** If you notice an
  unrelated issue while working on something else, mention it and ask, or
  commit it separately — don't fold it into the current commit.

## Docker Workflow

- **Run Docker commands one at a time, not chained with `&&`.** Check the
  result of each command before running the next. If a command fails,
  stop and show the actual error — don't chain to the next step assuming
  it succeeded.
- **For frontend-only changes:**
  ```bash
  docker-compose up -d --build wiki-frontend
  ```
  (single command, no chaining needed for this one)
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
│   ├── wiki-backend/         # Main ASP.NET Core app
│   ├── UnitTests/            # NUnit unit tests
│   └── IntegrationTests/     # NUnit integration tests
├── wiki-frontend/            # React SPA (Vite + TypeScript)
└── docker-compose.yml        # Orchestrates backend, frontend, SQL Server
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
- Frontend: http://localhost:3000
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

## Files of Interest

- `wiki-backend/wiki-backend/Program.cs` - Main entry point, DI setup, seeding
- `wiki-backend/wiki-backend/Identity/IdentityData.cs` - Role/policy constants
- `wiki-frontend/src/App.tsx` - React router, protected routes
- `wiki-frontend/src/Api/wikiApi.ts` - API client for wiki operations
- `wiki-frontend/src/Api/apiClient.ts` - Centralized HTTP client
- `docker-compose.yml` - Service orchestration
- `wikipoc-mcp/src/index.ts` - MCP server entry point (tools, transport, API client)
- `wikipoc-mcp/README.md` - MCP server documentation and opencode.json config