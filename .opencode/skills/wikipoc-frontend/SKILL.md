---
name: wikipoc-frontend
description: Use when working on the WikiPOC React frontend — pages, components, CSS, theming, API integration, or routing. Triggers on React, Vite, TypeScript, CSS, styling, component, UI, page, frontend, StyleModel, StyleContext, era-*, glass-card, Bootstrap override, or any file under wiki-frontend/.
---

# WikiPOC Frontend — SKILL

## Project structure

```
wiki-frontend/src/
├── Api/                  # One file per domain (wikiApi, wikiAuthApi, forumApi, wikiUserApi, wikiSearch)
├── Components/
│   └── contexts/         # StyleContext.tsx, UserContextProvider.tsx, SiteSettingsContext.tsx
├── Pages/
│   ├── MainPage/         # Shell layout: header, sidebar, hamburger menu, footer
│   ├── WikiPage-Article/ # Article view + comments
│   ├── CreateEditArticle/ # ReactQuill WYSIWYG editor
│   ├── EditStylePage/    # Theme editor: presets, manual sliders, save/activate
│   ├── ForumPages/       # Forum landing, topic view, post view, create topic/post
│   ├── LoginLogoutPages/ # Login / Register
│   ├── ProfilePage/      # View + edit profile
│   ├── UserSubmittedArticle-Update/ # Admin approval workflow
│   ├── Categories/       # Category page + edit categories
│   ├── UserManagement/   # Admin user list
│   └── SiteSettingsPage/ # Wiki name + logo upload
├── Styles/               # Global CSS (style.css, glass-card.css, etc.)
├── types/                # models.ts (all interfaces), contexts.ts
└── utils/                # articleRenderer.ts, formatDate.ts, resizeImage.ts
```

## Component conventions

- **Functional components** with hooks (React 19). No class components except `ErrorBoundary`.
- **Naming**: Pages suffixed with `Page`/`Component` (e.g. `WikiPage`, `ForumLandingPage`). Components are PascalCase descriptive names.
- **Props**: Defined inline or via interface. Pages commonly receive `jwtToken: string` and `decodedToken: object`.
- **State**: `useState` for local state, context for global state (user, styles, site settings).
- **CSS**: Plain `.css` files imported directly — no CSS Modules, no Tailwind. Classes are kebab-case.

### Common prop pattern

```typescript
jwtToken: string              // Raw JWT cookie value
decodedToken: DecodedToken     // From App.tsx
styles: StyleModel             // From useStyleContext()
categories: string[]           // Category names passed from App
handleLogout: () => void       // From App
handleLogin: () => void        // From App
```

### Hooks used
`useState`, `useEffect`, `useCallback`, `useRef`, `useNavigate`, `useParams`, `useLocation`, `useCookies` (react-cookie), `useStyleContext`, `useUserContext`, `useSiteSettings`, `useNotification` (toasts)

## CSS architecture — critical rules

### No CSS Modules, no Tailwind
All CSS is **global**. Class names are kebab-case. Files live in `src/Styles/` (global) or `src/Pages/<Page>/Styles/` (per-page).

### Bootstrap is imported globally BEFORE custom CSS
In `App.tsx` line 2: `import 'bootstrap/dist/css/bootstrap.css'`. This means **every custom style must use era-scoped selectors with `!important`** to override Bootstrap. A bare `.btn { ... }` or `.form-control { ... }` will be silently ignored.

```css
/* WRONG — Bootstrap wins: */
.form-control { background: rgba(255,255,255,0.2); }

/* RIGHT: */
.era-glass .form-control { background: rgba(255,255,255,0.15) !important; }
```

### Era class system
Body gets an era class via `MainPage.tsx`:
```typescript
document.body.classList.add(`era-${styles.interfaceEra || 'wikipedia'}`);
```

The root wrapper also gets `className={`wrapAll clearfix era-${era}`}`.

All era-specific rules **must** scope with the era prefix:
```css
.era-wikipedia .sidebar { background: #f8f9fa; }
.era-glass .sidebar { backdrop-filter: blur(12px); background: rgba(82,108,173,0.25); }
.era-modern .sidebar { background: rgba(26,29,39,0.95); }
.era-frutiger .sidebar { border-radius: 24px; background: rgba(232,245,233,0.9); }
```

### The four Critical CSS Gotchas

**1. Bootstrap Specificity Walls.** Every selector that touches Bootstrap components (`.btn`, `.form-control`, `.input-group`, `textarea`) needs both an era scope AND `!important`.

**2. Volumetric Reflection Blockers.** Frutiger Aero and Glassmorphic eras use `::before` glossy overlays. These **must** have `pointer-events: none` or they block all clicks, text selection, and form interactions:
```css
.era-frutiger .frutiger-gloss-effect::before {
  content: '';
  position: absolute;
  top: 0; left: 0; right: 0; height: 50%;
  background: linear-gradient(180deg, rgba(255,255,255,0.35) 0%, transparent 100%);
  pointer-events: none;   /* ← REQUIRED — omit and UI is bricked */
  z-index: 1;
}
```

**3. Proportional Nested Blurs.** Deeply nested forum comments scale down blurs to preserve legibility:
```css
.glass-card           { backdrop-filter: blur(var(--glass-blur-radius, 0px)); }
.glass-card.depth-1   { backdrop-filter: blur(calc(var(--glass-blur-radius) * 0.6)); }
.glass-card.depth-2   { backdrop-filter: blur(calc(var(--glass-blur-radius) * 0.4)); }
```

**4. Era-anchored header styles.** `.top-header` uses `!important` on background/backdrop-filter with position: sticky. Changing header styles without era scoping will break across eras. Always write `.era-glass .top-header { ... }`, `.era-wikipedia .top-header { ... }`, etc.

## Context providers — nesting and APIs

Provider nesting (outer → inner) in `App.tsx`:
```
UserContextProvider > BrowserRouter > SiteSettingsProvider > StyleProvider > Routes
```

### StyleContext (`StyleContext.tsx`)
**Provides:**
```typescript
styles: StyleModel              // Active theme
systemPresets: StyleModel[]     // 4 system eras (wikipedia, glass, modern, frutiger)
userThemes: StyleModel[]        // User-saved custom themes
setStyles: Dispatch             // Update local state
updateStyles: (styles, logo?, jwtToken?) => void  // PUT /api/Style
refreshUserThemes: () => void
loadTheme: (theme) => void      // Apply era fallbacks + set as active
```

**On mount:** Fetches active style from `GET /api/Style`, fetches presets from `GET /api/Style/presets`, injects CSS custom properties on `document.documentElement` whenever `styles` changes.

**Era fallback:** `applyEraFallbacks(data, preserveIdentity)` merges incoming partial `StyleModel` over hardcoded era defaults in `ERA_FALLBACKS`. `preserveIdentity=false` strips wikiName/logo when loading a system preset.

### UserContextProvider (`UserContextProvider.tsx`)
```typescript
decodedTokenContext: DecodedToken | null
updateUser: (token: DecodedToken | null) => void
```
JWT is decoded in `App.tsx` via `jwtDecode()`, then synced into context. `ProtectedRoute` reads from this context.

### SiteSettingsContext (`SiteSettingsContext.tsx`)
```typescript
settings: { wikiName?: string; logo?: string }
refresh: () => void
save: (wikiName, logoFile, token) => void
```

## API layer (`apiClient.ts`)

- **Native `fetch`** wrapper (no axios). Base URL from `VITE_API_URL` env var.
- Exports: `get`, `post`, `put`, `del`, `patch`, `postForm`, `putForm`.
- Bearer token read from `options.token` injected as `Authorization` header.
- **401 auto-refresh**: On 401 with `reason: 'role_changed'`, automatically calls `POST /api/Users/RefreshToken`, updates the `jwt_token` cookie, and retries the original request.
- Non-OK responses throw `ApiError` with status code. 204/empty returns `undefined`.
- `postForm`/`putForm` send FormData (for images). Regular methods send JSON.

### Domain API files
| File | Purpose |
|------|---------|
| `wikiApi.ts` | Pages CRUD, styles CRUD + activate, categories, site settings, images |
| `wikiAuthApi.ts` | Login/register |
| `wikiUserApi.ts` | Profiles, comments, profile pictures |
| `forumApi.ts` | Topics, posts, comments |
| `wikiSearch.ts` | Search wiki pages, forum topics, forum posts |

Admin endpoints use `/admin` paths; regular users use `/user` paths for the submission workflow.

## Routing (`App.tsx`)

Route table (all nested under `/` which renders `MainPage` layout):

| Path | Component | Access |
|------|-----------|--------|
| `/` | HomeComponent | Public |
| `/page/:slug` | WikiPage | Public |
| `/page/:slug/edit` | EditPage | User+ |
| `/create` | EditPage | User+ |
| `/edit-wiki` | EditStylePage | Owner only |
| `/site-settings` | SiteSettingsPage | Owner only |
| `/login` | LoginPageComponent | Public |
| `/register` | RegisterPageComponent | Public |
| `/user-submissions` | UserRequestsPageComponent | Moderator+ |
| `/user-submissions/:id` | CheckUserSubmittedPage | Moderator+ |
| `/user-updates` | UserRequestsPageComponent | Moderator+ |
| `/user-updates/:id` | CompareUpdatePage | Moderator+ |
| `/profile/:username` | ProfilePage | Public |
| `/profile/edit/:username` | EditProfilePage | User+ |
| `/categories/edit` | EditCategoriesPage | Admin+ |
| `/admin/users` | UserManagementPage | Admin+ |
| `/categories/:category` | CategoryPageComponent | Public |
| `/forum` | ForumLandingPage | Public |
| `/forum/:slug` | ForumPage | Public |
| `/forum/create-topic` | CreateTopicPage | User+ |
| `/forum/:slug/create-post` | CreatePostPage | User+ |
| `/forum/:slug/:postSlug` | ForumPost | Public |

### Role hierarchy
| Role | Access |
|------|--------|
| **Owner** | Everything (including `/edit-wiki`, `/site-settings`) |
| **Admin** | All except Owner-only routes |
| **Moderator** | Submissions, updates, create pages, forum moderation |
| **User** | Create/edit pages, forum posts, profile edit |
| **Public** | Read-only |

### JWT claim URIs (full Microsoft namespace)
```
Role: http://schemas.microsoft.com/ws/2008/06/identity/claims/role
Name: http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name
User ID: sub property on decoded token
```

### ProtectedRoute logic
1. No token → redirect to `/`
2. Has token but no decoded context yet → `LoadingSpinner "Checking authorization..."`
3. Owner → always permitted
4. Role claim checked against required `roles` array
5. PublicRoute redirects logged-in users away from login/register

## Theming system — how StyleModel reaches the DOM

**Pipeline:** Backend DB → `GET /api/Style` → `StyleContext` fetches → `applyEraFallbacks()` merges era defaults → CSS variables injected on `:root` → era body class applied → CSS rules use `.era-*` scoping → inline styles pass additional CSS vars.

### StyleModel interface
```typescript
interface StyleModel {
  id?: number; isActive?: boolean; isSystemPreset?: boolean;
  userId?: string; interfaceEra?: string; themeName?: string;
  logo?: string; wikiName?: string;
  bodyColor?: string; articleColor?: string;
  articleRightColor?: string; articleRightInnerColor?: string;
  footerListLinkTextColor?: string; footerListTextColor?: string;
  fontFamily?: string;
  glassBgOpacity?: number; glassBlurRadius?: number;
  glassBorderReflection?: number;
  bgMeshGradient?: string; borderRadius?: string; borderStyle?: string;
}
```

### CSS variables injected by StyleContext
`--custom-body-color`, `--custom-header-color`, `--glass-bg-opacity`, `--glass-blur-radius`, `--bg-mesh-gradient`, `--custom-border-radius`, `--custom-border-style`, `--glass-bg`, `--glass-panel`, `--glass-panel-accent`, `--footer-link-color`, `--footer-text-color`, `--article-color`, `--article-right-color`, `--article-right-inner-color`, `--font-family`, `--logo-url`

### Era-specific CSS files
- **`style.css`** (1141+ lines): All four era definitions, reset, layout, Bootstrap overrides, Frutiger gloss, Modern dark, Glass frosted, Wikipedia flat
- **`glass-card.css`** (113 lines): Shared card component with per-era definitions, depth classes for nested comments, quote styling
- **`stylepage.css`**: Theme editor layout

## Image handling

- Article images: FormData with wiki pages, served via `/api/Image/{filename}`
- Profile pictures: `/api/Image/profile/{filename}`, blob URL caching with `URL.revokeObjectURL`
- Logo: `/api/Image/{pictureString}`, same blob URL pattern
- `getLogo()` and `getProfilePicture()` use `useRef` for blob URL cleanup

## Article rendering pipeline

`articleRenderer.ts` processes HTML from the database:
1. `processArticleContent()` — main entry, runs all transforms
2. `extractParagraphTitles()` — parses `<h2>`/`<h3>` for table of contents
3. `replaceImageRefs()` — swaps `src="filename"` with base64 dataURL from images array
4. `addHeadingIds()` — adds sequential IDs to heading elements
5. `buildContentFromParagraphs()` — builds HTML from structured paragraph objects

## Dependencies (key versions)

| Package | Version | Purpose |
|---------|---------|---------|
| react, react-dom | 19 | UI framework |
| react-router-dom | 6 | Client-side routing |
| react-cookie | 7 | JWT cookie management |
| jwt-decode | 4 | JWT token decoding |
| bootstrap | 5.3 | Base CSS framework |
| react-quill-new | latest | WYSIWYG rich text editor |
| date-fns | 4 | Date formatting |
| typescript | 6 | Type checking |
| vite | 8 | Build tool |

## Build & test

- **Dev server:** `npm run dev` (Vite)
- **Build:** `npm run build`
- **Test:** `npm test` runs `tsc --noEmit` (type-check only, no test framework)
- **Docker:** `docker-compose up -d --build wiki-frontend`
- `VITE_API_URL` must be set in Docker build args for production

## What NOT to do

- Do not use CSS Modules or Tailwind — stick to plain `.css` files
- Do not write un-scoped `.btn`, `.form-control`, `.input-group` rules — Bootstrap wins
- Do not omit `pointer-events: none` on Frutiger/Glass gloss `::before` overlays
- Do not use hardcoded blur values for nested comments — use `calc(var(--glass-blur-radius) * <fraction>)`
- Do not change header CSS without era scoping (`.era-wikipedia .top-header`, etc.)
- Do not use axios — the codebase uses native `fetch` via `apiClient.ts`
- Do not use plain role strings like `"admin"` — use the full JWT claim URI
