# AGENTS.md - WikiPOC Development Guide

## Important Rule for AI Agents

**Before performing any destructive actions** (like file deletions, large refactors, or package downgrades), you **must**:
1. Explicitly propose the plan
2. Explain your reasoning
3. Wait for the user's 'y' confirmation before executing

## Agent Behavior Guidelines

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
  — don't ask for confirmation or produce a lengthy plan first.
- **Reserve deep reasoning for genuinely ambiguous or destructive decisions**
  (see confirmation rule above), not for routine refactors or migrations with
  a clear precedent already in this codebase.

  ## Commit Discipline

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

### Test Output Handling

- **Save test output to a file once; don't re-run the suite to retry a filter.**
  Integration tests hit a real SQL Server and are slow — re-running them just to
  try a different `grep` pattern wastes time and (on free-tier hosted models)
  rate limit. Redirect once: `dotnet test ... --no-build > test-output.log 2>&1`,
  then grep/read that file as many times as needed.
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

WikiPOC is a Wikipedia-like platform with:
- **.NET 10 ASP.NET Core backend** (wiki-backend/)
- **React 18 frontend** (wiki-frontend/)
- **SQL Server database**
- **Docker Compose** orchestration

## Architecture

```
WikiPOC/
├── wiki-backend/
│   ├── wiki-backend/         # Main ASP.NET Core app
│   ├── UnitTests/            # NUnit unit tests
│   └── IntegrationTests/     # NUnit integration tests
├── wiki-frontend/            # React SPA (Create React App)
└── docker-compose.yml        # Orchestrates backend, frontend, SQL Server
```

## Quick Start

### Prerequisites
- Docker & Docker Compose
- .NET 10 SDK (for local backend dev)
- Node.js 16+ (for local frontend dev)

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
npm install && npm start
```

## Environment Variables (.env)

Required in root `.env` file:

```bash
# Database
ASPNETCORE_CONNECTIONSTRING=Server=sql-server;Database=WikiDb;User=sa;Password=<DB_PASSWORD>
DB_PASSWORD=YourStrongPassword123!
INTEGRATIONTEST_CONNECTIONSTRING=Server=localhost;Database=master;User=sa;Password=<DB_PASSWORD>

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
PROFILE_PICTURES_PATH=/path/to/profile/pictures

# Frontend API URL
REACT_APP_API_URL=http://localhost:5050
```

## Authentication & Authorization

### Backend Auth Setup
- **JWT Bearer authentication** with configurable signing key
- **ASP.NET Core Identity** for user management
- **Two roles**: `Admin` and `User`

### Authorization Policies
```csharp
// Policy: "Admin" - requires Role claim = "Admin"
// Policy: "User" - requires Role claim = "User"
```

### Default Users (seeded on startup)
| Role  | Email           | Username |
|-------|-----------------|----------|
| Admin | admin@admin.com | Admin    |
| User  | test@test.com   | TestUser |

### Protected Routes (Frontend)
- **Admin-only**: `/edit-wiki`, `/user-submissions`, `/user-updates`, `/categories/edit`, `/forum/:slug/create-topic`
- **Authenticated**: `/create`, `/page/:title/edit`, `/profile/edit/:username`
- **Public**: `/login`, `/register`

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
dotnet ef database update
```

### Frontend
```bash
cd wiki-frontend

# Dev server
npm start

# Build production
npm run build

# Tests
npm test
```

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
- `ArticleControllers/` - WikiPages, Paragraphs
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

### Frontend (wiki-frontend/src/)

**Context Providers:**
- `StyleContext` - Global wiki styling (colors, logo, fonts)
- `UserContextProvider` - Current user state

**API Layer (src/Api/):**
- `wikiApi.js` - Wiki pages, categories, styles
- `wikiAuthApi.js` - Login/register
- `wikiUserApi.js` - User profiles
- `forumApi.js` - Forum operations

**Key Pages:**
- `MainPage/` - Home with article list
- `WikiPage-Article/` - Article view
- `CreateEditArticle/` - Editor (legacy + new)
- `UserSubmittedArticle-Update/` - Admin approval workflow
- `ForumPages/` - Forum components

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
- Admin-only feature at `/edit-wiki`
- Controls: wiki name, colors, fonts, logo
- Stored in database, fetched by frontend on load

## Testing Notes

### Unit Tests
- Pure unit tests with mocks
- Run with: `dotnet test wiki-backend/UnitTests/`

### Integration Tests
- Use real SQL Server (separate test DB per run)
- Require `INTEGRATIONTEST_CONNECTIONSTRING` in .env
- Auto-create unique test databases, clean up on dispose
- Run with: `dotnet test wiki-backend/IntegrationTests/`

## Gotchas

1. **Docker startup race**: Backend may start before SQL Server is ready. If you see connection errors, the `wait-for-it.sh` script in docker-compose handles this (uncomment entrypoint if needed).

2. **Frontend build**: `REACT_APP_API_URL` must be passed as build arg to Docker. The frontend Dockerfile captures this correctly.

3. **JWT expiration**: Default 60 minutes (`JWT_TOKEN_TIME`). Adjust in .env.

4. **Database migrations**: Backend auto-migrates on startup. For manual migrations, run from `wiki-backend/wiki-backend/` directory.

5. **CORS**: Configured for `http://localhost:3000` and `http://localhost:3001`. Update `Program.cs:AddCors()` if using different ports.

6. **Profile pictures path**: Ensure `PICTURES_PATH` directory exists on host machine before starting Docker.

## Files of Interest

- `wiki-backend/wiki-backend/Program.cs` - Main entry point, DI setup, seeding
- `wiki-backend/wiki-backend/Identity/IdentityData.cs` - Role/policy constants
- `wiki-frontend/src/App.js` - React router, protected routes
- `wiki-frontend/src/Api/wikiApi.js` - API client for wiki operations
- `docker-compose.yml` - Service orchestration