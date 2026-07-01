# TODO.md — WikiPOC Pre-Production Cleanup

## Priority Legend
- **CRIT**: Must fix before production
- **HIGH**: Strongly recommended before production
- **MEDIUM**: Quality-of-life / technical debt
- **LOW**: Nice-to-have

---

## CI/CD (DevOps Tier)

### Critical
- [x] **CRIT** Frontend CI: `npm test` is aliased to `vite build` — no real tests, no `tsc --noEmit` type-check
- [x] **CRIT** Add `actions/upload-artifact` for `.trx` test results + `dorny/test-reporter` for PR annotations
- [ ] **CRIT** Add immutable image tags (`${{ github.sha }}`) via `docker/metadata-action` — currently `:latest` only
- [ ] **CRIT** Add deployment job (staging/prod environments)
- [x] **CRIT** Add backend `.dockerignore` (exclude `bin/`, `obj/`, test projects, `.env*`)

### High
- [ ] **HIGH** Containers run as root — add `USER` directive to both Dockerfiles
- [x] **HIGH** No healthchecks in docker-compose; SQL Server image unpinned (`:latest`)
- [x] **HIGH** Add CODEOWNERS
- [ ] **HIGH** Add PR template, CONTRIBUTING.md
- [x] **HIGH** Add concurrency control to workflows (cancel stale runs)
- [x] **HIGH** Add middleware to validate JWT role claim against DB on every request
- [ ] **HIGH** Add CodeQL workflow + Trivy image scan
- [ ] **HIGH** Add ESLint + Roslyn analyzers
- [ ] **HIGH** Enable branch protection on `main` (`Tests and Build` required + 1 review)

### Medium
- [ ] **MEDIUM** Add coverage reporting (coverlet + ReportGenerator for .NET)
- [ ] **MEDIUM** Add release tagging / changelog automation (release-please)
- [ ] **MEDIUM** Add GitHub Environments (staging vs prod)
- [x] **MEDIUM** Dependabot: removed (user found it annoying)

---

## Backend

### Critical
- [x] **CRIT** `UsersController.cs:32-37` — Remove `DebugPrincipal` endpoint (dumps all claims)
- [x] **CRIT** `Program.cs:89-93` — Re-enable IsDevelopment guard around Swagger (commented out — Swagger exposed in prod)

### Bugs
- [x] **BUG** `ForumTopicRepository.cs:112-124` — `GenerateSlug` reassigns `originalSlug = slug` inside loop → slugs compound incorrectly (`foo-1`, `foo-1-2`, `foo-1-2-3`)
- [x] **BUG** `UsersController.cs:49` — `.Result` on async task in LINQ `.Select()` — sync-over-async deadlock risk
- [x] **BUG** `ForumPostRepository.cs:79` — `UpdateForumPostAsync` regenerates slug on every update, even content-only edits → breaks bookmarks
- [x] **BUG** `WikiDbContext.cs:53-56,81-84` — Duplicate FK relationship config (WikiPage ↔ UserComment mapped from both sides)
- [x] **BUG** `WikiDbContext.cs:112-122` — Duplicate FK config (ForumPost ↔ ForumComment mapped from both sides)
- [x] **BUG** `UserProfileRepository.cs:100-105` — `RemoveAsync` never calls `SaveChangesAsync` (unlike `DeleteAsync` which does)
- [x] **BUG** `ForumPostRepository.cs:24-27` — Null-forgiving `!` on result that can legitimately be null; interface signature lies

### Performance
- [ ] **PERF** `ForumPostRepository.cs:38-53` — N+1: 2× `CountAsync` per comment to recompute `PostCount`
- [ ] **PERF** `ForumTopicRepository.cs:37-47` — Same N+1 pattern across topics×posts×comments

### Dead Code / Cleanup
- [x] **DEAD** `IntegrationTests/Mocks/MockTokenServices.cs` — never referenced
- [x] **DEAD** `IntegrationTests/Mocks/TestUserStore.cs` — never referenced
- [x] **DEAD** `UserAuthorizationService.cs:29-36` — `IsUserModerator()` defined, never called
- [ ] **DEAD** `WikiPageTitleEntry.cs:3` — `Slug` parameter never passed by any caller
- [x] **DEAD** `Program.cs:162-163` — Duplicate `AddControllers()` / `AddEndpointsApiExplorer()` calls
- [x] **DEAD** `WikiDbContext.cs:32` — `DbSet<ApplicationUser> ApplicationUsers` never queried
- [x] **DEAD** 8 unused `ToString()` overrides across model classes (debugging leftovers)
- [x] **DEAD** `WikiPagesController.cs:61-73` — `GetWikiPageParagraphs` endpoint, frontend doesn't call it
- [x] **DEAD** `ParagraphController` (entirely) — no frontend consumer
- [x] **DEAD** `UsersController.cs:55-62,65-72,75-85,88-99` — `GetUserById`, `CreateUser`, `UpdateUser`, `DeleteUser` — frontend never calls them

### Code Smells
- [x] **SMELL** 3 different slug implementations — consolidate into shared utility
- [x] **SMELL** 4 near-identical "load WikiPage + nested data" methods in `WikiPageRepository` — extract
- [x] **SMELL** `UsersController.cs:49` — `GetUserRoles` wrapped in async but consumed via `.Result` synchronously
- [x] **SMELL** `TokenServices.cs:22` — `DefaultOutboundClaimTypeMap.Clear()` called per request (process-global mutation)
- [x] **SMELL** `AuthService.cs:98-109 vs 140-145` — Two email-format validators disagreeing
- [x] **SMELL** `DbInitializer.cs` — 4 copies of "create profile, attach UserId" pattern; extract shared helper

### Security
- [x] **MED** `WikiDbContextDesignTimeFactory.cs:11` — Hardcoded plaintext password in connection string

### Unused Imports
- [x] `ForumCommentController.cs:5` — `using wiki_backend.Models`
- [x] `ForumPostController.cs:5` — `using wiki_backend.Models`
- [x] `UserCommentController.cs:5` — `using wiki_backend.Identity`
- [x] `WikiPageRepository.cs:2` — `using System.Text`

### Commented-out Dead Code
- [x] `UserProfileRepository.cs:53-57` — commented `AddAsync` stub
- [x] `WikiPage.cs:14` — commented `Category` property
- [x] `UserSubmittedWikiPage.cs:8` — commented `Id` field
- [x] `StyleRepository.cs:44` — commented `SetValues` line
- [x] `UserComment.cs:11` — commented `[JsonIgnore]` attribute
- [x] `WikiPagesController.cs:282,303` — stale investigation comments (no longer match code)

---

## Backend

### JWT Refresh Flow — Silent Token Refresh on Role Change

**What this does:**
When a user's role is changed in the DB, the existing middleware rejects their next API request with 401 + body `{ reason: "role_changed" }`. The frontend automatically calls a refresh endpoint to get a new token with the correct role, then retries the original request — zero interruption to the user.

**Backend changes — `UsersController.cs`:**
- [x] Add `POST /api/Users/RefreshToken` endpoint
  - Reads current user from JWT claims
  - Fetches current DB roles via `UserManager`
  - Generates a new JWT token with those roles
  - Returns `{ token: "..." }`

**Backend changes — `Program.cs`:**
- [x] The existing middleware already returns 401 on role mismatch. Change the response to include `{ reason: "role_changed" }` as JSON body so the frontend can detect it.

**Frontend changes — `apiClient.ts`:**
- [x] On 401 with `reason === "role_changed"`:
  1. Call `POST /api/Users/RefreshToken` with current token
  2. If refresh succeeds, save new token (update cookie), retry the original request
  3. If refresh fails, clear cookie, redirect to login

**Frontend changes — cookie handling:**
- [x] Check how `jwt_token` cookie is set/cleared in `App.tsx` (`handleLogin` / `handleLogout` / `useCookies`)
- [x] Make refresh-token response update the cookie in the same way

**What won't change:**
- The middleware stays where it is (between auth and authorization)
- No changes to existing controllers, repositories, or models
- Unit tests still pass without modification
## New

### HIGH
- [ ] **HIGH** Add middleware to validate JWT role claim against DB on every request — prevents griefing via stale tokens after role demotion

---

## Frontend

### Bugs
- [x] **BUG** `ForumLandingPage.tsx:16` — `isAdmin` reads wrong claim key (bare `role` vs full `http://schemas.microsoft.com/.../claims/role`) → "Create New Topic" never shown
- [x] **BUG** `UserCommentComponent.tsx:52` / `WikiPageReplyComponent.tsx:52` — Cancel button crashes: `showReplyBoxRemoveIndex`/`index` props never passed by parent
- [x] **BUG** `UserCommentComponent.tsx:11-14,42` — Edit state stores `comment.id` but render compares vs `index` → edit textarea unreachable
- [x] **BUG** `UserCommentComponent.tsx:21-25` — `handleCommentEditSubmit` is a no-op stub (comment editing not wired to API)
- [ ] **BUG** `ForumPostRepository` (frontend `forumApi.ts:17,19`) — `getForumPostTitles`/`getForumPostById` exported but never imported

### Performance / State Issues
- [x] **PERF** `CategoryPageComponent.tsx:25-27` — Effect missing `category` in deps; navigating categories won't update list
- [x] **PERF** `ProfilePage.tsx:29-32` — Effect missing `username` in deps; URL change won't recompute `isYourProfile`
- [x] **PERF** `EditStylePage.tsx:25-26` — Empty `useEffect(() => {}, [manualEdit])` — pure no-op
- [x] **PERF** `EditStylePage.tsx:18-23` — Buggy backup/restore lifecycle: cleanup runs before each re-run, momentarily resetting styles

### Debug Leftovers
- [x] **LOG** `App.tsx:86,88` — `console.log` in production code
- [x] **LOG** `WikiPage.tsx:20,29` — `console.log` in `useEffect`

### Dead Code
- [x] **DEAD** `Components/ReactQuillComponent.tsx` — entire component file never imported
- [x] **DEAD** `EditPage.tsx:24` — `legacyPage` state: set but never read
- [x] **DEAD** `EditPage.tsx:20` — `emptyFields` state: set but never read
- [x] **DEAD** `LoginPageComponent.tsx:13-15` — `emailInputClass`/`passwordInputClass` state values never applied
- [x] **DEAD** `RegisterPageComponent.tsx:13` — `role` state: never set, never read; `RegisterPageComponent.tsx:16-19` — input class states never applied
- [x] **DEAD** `ArticleEditor.tsx:20` — `lastSelection` state: set but never read
- [x] **DEAD** `LoginPageComponent.tsx:37` — `InputClick` handler never wired
- [x] **DEAD** `RegisterPageComponent.tsx:37` — `InputClick` handler never wired
- [x] **DEAD** `CustomHTMLPopup.tsx:50,69` — `handleImageChange` / `fileToDataUri` defined but never called

### Unused Exports
- [x] `wikiApi.ts` — `getWikiPages`, `deleteWikiPage`
- [x] `forumApi.ts` — `createForumTopic`, `updateForumTopic`, `deleteForumTopic`, `getForumPostTitles`, `getForumPostById`, `postEditedForumComment`
- [x] `wikiUserApi.ts` — `postEditedComment` (now wired up to comment editing)
- [x] `apiClient.ts` — `ApiError` class (export removed, class kept internally)
- [x] `types/models.ts` — `WikiPage`, `UserSubmittedWikiPage`, `Category`, `Paragraph` removed (never imported); kept `StyleModel`

### Unused Imports
- [x] `HomeComponent.tsx:1` — `React`
- [x] `HomeComponent.tsx:3` — `StyleProvider`
- [x] `WikiList.tsx:1` — `React`
- [x] `EditPage.tsx:1` — `React`
- [x] `ArticleEditor.tsx:1` — `React`
- [x] `CustomHTMLPopup.tsx:1` — `React`
- [x] `WikiPageCommentsComponent.tsx:4` — `postEditedComment`
- [x] `ReactQuillComponent.tsx:1` — `useState` (whole file dead)
- [x] `MainPage.tsx:5` — `Breadcrumbs` (only usage is commented out)
- [x] `WikiPageCommentsComponent.tsx:4` — `postEditedComment`

### Commented-out Dead Code
- [x] `ReactQuillComponent.tsx:6-10` — commented useState/handleChange block
- [x] `MainPage.tsx:56` — `<Breadcrumbs/>` JSX commented out
- [x] `MainPage.tsx:59` — commented header div
- [x] `EditPage.tsx:67` — `// setContent(value);` leftover
- [x] `EditPage.tsx:132` — duplicate commented line
- [x] `ForumLandingPage.tsx:22-23` — empty useEffect comment stub
- [x] `ArticleEditor.tsx:30` — commented toolbar handler
- [x] `ArticleEditor.tsx:234` — commented `CustomQuillToolbar` reference
- [x] `EditCategoriesPage.tsx:14` — commented categories.push
- [x] `WikiPageSubmitCommentComponent.tsx:18` — commented field in payload
- [x] `CheckUserSubmittedPage.tsx:33,45` — commented filter lines
- [x] `CompareUpdatePage.tsx:51,63` — commented filter lines

### Weird / Code Smells
- [x] `Context guards never fire` — `StyleContext.tsx:33`, `UserContextProvider.tsx:21` — default `{} as Type` is truthy, throw unreachable
- [x] `MainPage.tsx:22` — Role stringified differently than WikiList/HamburgerMenu (doesn't handle array role claims)
- [x] `CreateForumTopic.tsx:67-76` — Payload includes unused fields (`forumTopic` object, `slug: ''`) — file deleted, replaced by CreateTopicPage + CreatePostPage
- [x] `articleRenderer.ts:94-116` — `processArticleContent` declares `styles` param but never uses it
- [x] Duplicate `StyleModel` interfaces in `types/models.ts:87` vs `types/contexts.ts:3` (consolidated to models.ts, contexts.ts imports it)
