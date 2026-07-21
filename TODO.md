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
- Images persist only within a container session; they are lost if the container is fully killed and rehosted (Azure Free Tier limitation)

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

### Tech Debt (CI/CD accommodations) — Complete
- [x] **MEDIUM** Update Microsoft.OpenApi / Swashbuckle to remove NU1903 suppression
- [x] **MEDIUM** Enable TreatWarningsAsErrors on test projects after NU1903 fix
- [x] **MEDIUM** Refactor `var` → `let`/`const` across frontend (13 auto-fixable)
- [x] **LOW** Fix `@typescript-eslint/no-unused-expressions` violations (6 files)
- [x] **LOW** Fix `no-explicit-any`, `no-unused-vars`, `react-hooks/exhaustive-deps` across frontend

### Code Scanning Alerts (ci/cicd-tightening) — Complete
- [x] **HIGH** Fix path injection in `ImageController.cs` (4 alerts) — validate filename after `Path.GetFileName`
- [x] **LOW** Fix XSS-through-DOM in `DisplayProfileImageElement.tsx` — validate blob URL source

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

### All tools implemented (July 2026)
All 35 tools from the original spec are implemented — no remaining future tools. See `wikipoc-mcp/src/index.ts` and the available tool listing in the system prompt for the full list.
- [x] **LOW** `delete_forum_comment` — delete forum comment
- [x] **LOW** `delete_wiki_comment` — delete wiki comment
- [x] **LOW** `edit_forum_comment` — edit forum comment
- [x] **LOW** `edit_wiki_comment` — edit wiki comment
- [x] **LOW** `update_forum_post` — update forum post
- [x] **LOW** `search_wiki_articles` — search wiki articles
- [x] **LOW** `search_forum_topics` — search forum topics
- [x] **LOW** `search_forum_posts` — search forum posts
- [x] **LOW** `ensure_agent_notes_category` — create or verify Agent Notes category

---

## UI Issues

- [x] **LOW** Frutiger Aero era: sidebar background doesn't use `--custom-body-color` CSS variable (`.era-frutiger .sidebar` is hardcoded; unlike `.era-modern .sidebar` which references the variable). Update to respect theme color.

---

## Performance (Lighthouse/PageSpeed)

**Mobile: 61/100 — Desktop: 75/100**

### Mobile

#### Accessibility (94/100)
- [ ] **MEDIUM** Increase hamburger toggle button size and spacing — currently `width: 2rem, height: 2rem` is too small for mobile touch targets (minimum 44x44px per WCAG). Increase to `min-width: 44px; min-height: 44px` in `hamburgermenu.css`. Add `padding: 8px` to drawer links for better tap targets.

#### Best Practices (96/100)
- [ ] **MEDIUM** Fix `logo_pfp.png` 404 console error — the site tries to fetch `/api/Image/logo_pfp.png` which returns 404. Either suppress the error in `SiteSettingsContext.tsx` or add a guard to skip fetching if the logo is the default placeholder.
- [ ] **LOW** Enable source map generation in production builds (`build.sourcemap: true` in `vite.config.js`) for easier debugging — or suppress the Lighthouse warning if intentionally disabled.

#### Cache & Server
- [ ] **HIGH** Add `Cache-Control: public, max-age=31536000, immutable` to `UseStaticFiles()` in `Program.cs` for JS/CSS/fonts/images. Est savings: **1,314 KiB** on repeat visits.
- [ ] **MEDIUM** Configure Azure App Service caching rules via `web.config` or portal for static assets.

#### Fonts
- [ ] **HIGH** Add `font-display: swap` to the `@font-face` declaration for LinLibertine in `style.css`. Est savings: **1,720ms** FCP/LCP improvement.

#### CSS
- [ ] **HIGH** Eliminate render-blocking CSS — extract critical CSS and inline it in `index.html`, defer full bundle with `rel="preload"`. Est savings: **1,650ms** render-blocking delay.
- [ ] **MEDIUM** Reduce unused CSS — scope Bootstrap imports or add PurgeCSS. Est savings: **293 KiB**.

#### JavaScript
- [ ] **HIGH** Code-split heavy routes with `React.lazy()` + `Suspense` (edit page, forum pages, style page, moderation page — any page importing Quill editor). Est savings: **345 KiB** unused JS, reduces main-thread work (currently 32.3s).
- [ ] **MEDIUM** Break up 15 long tasks by deferring non-critical initialization (token refresh, notification timers) with `setTimeout` or `requestIdleCallback`.

#### Images
- [ ] **HIGH** Add explicit `width` and `height` attributes to the logo `<img>` in `HeaderComponent.tsx` and the edit button in `WikiPageComponent.tsx`.
- [ ] **MEDIUM** Serve logo as WebP with `<picture>` fallback or build-time conversion. Est savings: **34 KiB**.
- [ ] **LOW** Add `loading="lazy"` to below-the-fold images.

#### Animations
- [ ] **LOW** Fix non-composited animation — ensure animated elements use `transform` and `opacity` only (1 animated element found).

### Desktop

**Best Practices (96/100) — same issues as mobile (logo_pfp.png 404, source maps)**
**Trust & Safety — same missing headers as mobile (covered under Cross-Platform)**

#### Accessibility (82/100)
- [ ] **HIGH** Fix `<a href="/profile/null">` link — the profile link renders with a null username, creating a broken inaccessible link. Likely occurs when `userName` is not available. Add a guard in `HeaderComponent.tsx` to skip rendering the profile link if `userName` is null.
- [ ] **MEDIUM** Wrap page content in a `<main>` landmark element in `MainPage.tsx` around the `<Outlet />` for screen reader navigation.
- [ ] **MEDIUM** Fix heading order — ensure headings don't skip levels (e.g., if `h2` is followed by `h4`, restructure). Check the sidebar category heading hierarchy.
- [ ] **MEDIUM** Increase sidebar link touch targets on desktop — same fix as mobile hamburger (minimum 44x44px tap targets).

#### Cumulative Layout Shift (0.241)
- [ ] **HIGH** Fix CLS by setting explicit `width` and `height` on all `<img>` elements (logo, edit button, profile pictures). Currently no images have intrinsic dimensions, causing layout shifts as images load.
- [ ] **MEDIUM** Add `aspect-ratio` CSS property to image containers to reserve space before the image URL resolves.

#### Fonts
- [ ] **HIGH** Add `font-display: swap` — shares the same 1-line fix as mobile. Est savings: **1,050ms**.

#### CSS
- [ ] **HIGH** Defer render-blocking CSS. Est savings: **280ms**.

#### JavaScript
- [ ] **HIGH** Code-split heavy routes. Est savings: **344 KiB** unused JS, main-thread work currently **5.7s**.

#### Images
- [ ] **MEDIUM** Serve logo as WebP. Est savings: **33 KiB**.

#### Animations
- [ ] **LOW** Fix non-composited animations — ensure animated elements use `transform` and `opacity` only (2 animated elements found on desktop).

### Cross-Platform (applies to both mobile & desktop)

#### Security Headers (Trust & Safety — not scored, all headers missing)
All security headers currently missing:
- [ ] **CRIT** Add `Content-Security-Policy` header in `Program.cs` middleware.
- [ ] **CRIT** Add `Strict-Transport-Security` header (`max-age=31536000; includeSubDomains`).
- [ ] **CRIT** Add `X-Frame-Options: DENY` header to prevent clickjacking.
- [ ] **CRIT** Add `Cross-Origin-Opener-Policy: same-origin` header.
- [ ] **MEDIUM** Add `X-Content-Type-Options: nosniff` and `Referrer-Policy: strict-origin-when-cross-origin` headers.
