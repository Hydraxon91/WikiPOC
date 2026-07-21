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
- [x] **MEDIUM** Increase hamburger toggle button size and spacing — changed to `min-width: 44px; min-height: 44px` + `padding: 8px` in `hamburgermenu.css`. Added `display: block; padding: 0.4em 0` to drawer links for better tap targets.

#### Best Practices (96/100)
- [x] **MEDIUM** Fix `logo_pfp.png` 404 console error — added guard in `HeaderComponent.tsx` to skip fetching if logo is the default placeholder (`logo_pfp.png`).
- [x] **LOW** Enable source map generation in production builds (`build.sourcemap: true` in `vite.config.js`).

#### Cache & Server
- [x] **HIGH** Add `Cache-Control: public, max-age=31536000, immutable` to `UseStaticFiles()` in `Program.cs` for JS/CSS/fonts/images. Added `StaticFileOptions` with `OnPrepareResponse` handler that sets cache headers for all hashed asset extensions.
- [ ] **MEDIUM** Configure Azure App Service caching rules via `web.config` or portal for static assets.

#### Fonts
- [x] **HIGH** Add `font-display: swap` to the `@font-face` declaration for LinLibertine in `style.css`. Also inlined in `index.html` for early font loading.

#### CSS
- [x] **HIGH** Eliminate render-blocking CSS — inlined critical font-face + body styles in `index.html`. Converted all heavy route imports to `React.lazy()` + `Suspense` in `App.tsx`, which defers their CSS to on-demand loading.
- [x] **MEDIUM** Reduce unused CSS — added `@fullhuman/postcss-purgecss` with PostCSS config (`postcss.config.cjs`) for production builds. Comprehensive safelist covers all era-, Bootstrap, Quill, and dynamic classes. Main CSS reduced from ~330KB to ~129KB.

#### JavaScript
- [x] **HIGH** Code-split heavy routes with `React.lazy()` + `Suspense` — all non-landing-page routes now lazy-loaded. Main bundle reduced to 237KB (73KB gzipped). Individual chunks for EditPage, EditStylePage, ForumLandingPage, ForumPost, etc.
- [x] **MEDIUM** Break up 15 long tasks by deferring non-critical initialization — token refresh and category fetching now use `setTimeout(0)` with cleanup in `App.tsx`.

#### Images
- [x] **HIGH** Add explicit `width` and `height` attributes to the logo `<img>` in `HeaderComponent.tsx` and the edit button in `WikiPageComponent.tsx`.
- [x] **MEDIUM** Serve logo as WebP with `<picture>` fallback — converted `logo.png`, `edit.png`, and `logo192.png` to WebP. Updated `HeaderComponent` default, `WikiPageComponent` edit button (`<picture>` element), and `index.html` og/twitter/apple-touch-icon references.
- [x] **LOW** Add `loading="lazy"` to below-the-fold images — added to `DisplayProfileImageElement`, `UserImagesContainer`, and `CustomHTMLPopup` preview.

#### Animations
- [x] **LOW** Fix non-composited animation — added `will-change: max-height` to `.post-content-area img` in `forumpost.css` to hint the compositor about the max-height transition.

### Desktop

**Best Practices (96/100) — same issues as mobile (logo_pfp.png 404, source maps)**
**Trust & Safety — same missing headers as mobile (covered under Cross-Platform)**

#### Accessibility (82/100)
- [x] **HIGH** Fix `<a href="/profile/null">` link — added guard in `HeaderComponent.tsx` to skip rendering profile link if `userName` is null.
- [x] **MEDIUM** Wrap page content in a `<main>` landmark element in `MainPage.tsx` around `<Outlet />`.
- [x] **MEDIUM** Fix heading order — changed sidebar + hamburger headings from `<h3>` to `<h2>` in `WikiList.tsx` and `HamburgerMenu.tsx`. Removed heading level skips.
- [x] **MEDIUM** Increase sidebar link touch targets — added `display: block; padding: 0.4em 0` to hamburger drawer links.

#### Cumulative Layout Shift (0.241)
- [x] **HIGH** Fix CLS by setting explicit `width` and `height` on all `<img>` elements — logo in HeaderComponent (`100x100`) and edit button in WikiPageComponent (`24x24`).
- [x] **MEDIUM** Add `aspect-ratio` CSS property to image containers — added `aspect-ratio: 1/1` to `.site-logo`, `aspect-ratio: 16/9` to `.paragraph-image` (already existed on `.profile-picture`).
- [x] **MEDIUM** Configure Azure App Service caching rules — handled by `StaticFileOptions` in `Program.cs` via application-level cache headers.

#### Fonts
- [x] **HIGH** Add `font-display: swap` — shares the same 1-line fix as mobile.

#### CSS
- [x] **HIGH** Defer render-blocking CSS — same fix as mobile (inline critical CSS + code splitting).

#### JavaScript
- [x] **HIGH** Code-split heavy routes — same fix as mobile.

#### Images
- [x] **MEDIUM** Serve logo as WebP — covered by mobile WebP fix (same `<picture>` fallback).

#### Animations
- [x] **LOW** Fix non-composited animations — same fix as mobile (`will-change: max-height` on `.post-content-area img`).

### Cross-Platform (applies to both mobile & desktop)

#### Security Headers (Trust & Safety — not scored, all headers missing)
All security headers now added via middleware in `Program.cs`:
- [x] **CRIT** Add `Content-Security-Policy` header in `Program.cs` middleware.
- [x] **CRIT** Add `Strict-Transport-Security` header (`max-age=31536000; includeSubDomains`) — only in non-development mode.
- [x] **CRIT** Add `X-Frame-Options: DENY` header to prevent clickjacking.
- [x] **CRIT** Add `Cross-Origin-Opener-Policy: same-origin` header.
- [x] **MEDIUM** Add `X-Content-Type-Options: nosniff` and `Referrer-Policy: strict-origin-when-cross-origin` headers.
