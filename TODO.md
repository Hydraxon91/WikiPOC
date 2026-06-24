# Frontend Migration Plan — React 19 + Vite + TypeScript

Phased migration from CRA 5.0.1 / React 18.2 / JS → Vite / React 19 / TS.
Estimated total: **16–24 hours** split across 4 phases.

---

## Phase 1 — Vite Migration (≈4h)

Replace CRA 5.0.1 with Vite as the build tool.

| # | Task | Details |
|---|------|---------|
| 1.1 | Install Vite + React plugin | `npm install -D vite @vitejs/plugin-react` |
| 1.2 | Create `vite.config.js` | Standard React plugin config |
| 1.3 | Move `index.html` → project root | `public/index.html` → `./index.html`; update `<script>` tag |
| 1.4 | Update `package.json` scripts | `"start": "vite"`, `"build": "vite build"`, `"preview": "vite preview"` |
| 1.5 | Rename `.js` → `.jsx` | All files containing JSX (~30 files) |
| 1.6 | Update env var prefix | `REACT_APP_` → `VITE_` in `.env`, Dockerfile, API files |
| 1.7 | Update env var access pattern | `process.env.REACT_APP_*` → `import.meta.env.VITE_*` (4 API files) |
| 1.8 | Create `env.d.ts` | Vite environment type declarations |
| 1.9 | Remove CRA boilerplate | `reportWebVitals.js`, `setupTests.js` (later in P4), `react-scripts` from deps |
| 1.10 | Update `.gitignore` | Add `/dist` |

---

## Phase 2 — React 19 Upgrade (≈2h)

Bump React to v19 and fix audit findings.

| # | Task | Details |
|---|------|---------|
| 2.1 | Install React 19 | `npm install react@19 react-dom@19` |
| 2.2 | Fix `for` → `htmlFor` (5×) | `LoginPageComponent.js`, `RegisterPageComponent.js` |
| 2.3 | Remove dead `useEffect` hooks (2×) | Same two files — empty body effects |
| 2.4 | Fix blob URL leaks | Add `URL.revokeObjectURL` cleanup in `HeaderComponent`, `DisplayProfileImageElement` |
| 2.5 | Remove `forwardRef` | `ReactQuillComponent.js` — optional, still works in React 19 |
| 2.6 | Remove unused imports | `dotenv`, `web-vitals`, `setupTests.js` cleanup |
| 2.7 | Smoke test | Login, create article, forum, admin workflow |

---

## Phase 3 — TypeScript Migration (8–16h)

Biggest phase. Every `.jsx` → `.tsx`, every component typed.

| # | Task | Details |
|---|------|---------|
| 3.1 | Install TypeScript | `npm install -D typescript @types/react @types/react-dom` |
| 3.2 | Create `tsconfig.json` | Strict mode recommended |
| 3.3 | Rename `.jsx` → `.tsx` | All component files (~35 files) |
| 3.4 | Rename `.js` → `.ts` | API files, hooks, contexts (~10 files) |
| 3.5 | Create shared type definitions | `src/types/api.ts`, `src/types/models.ts` |
| 3.6 | Type all 4 API files | Typed request/response for every function |
| 3.7 | Type `StyleContext` + `UserContext` | Generic provider types |
| 3.8 | Type `App.tsx` | Route props, state, callbacks |
| 3.9 | Type every component | Props interface + state types |
| 3.10 | Fix surfaced bugs | Login error bug, copy-paste error messages, `cookies` prop naming |
| 3.11 | Type `date-fns` usage | After installing it |

---

## Phase 4 — Polish (≈2h)

Fix remaining bugs and clean up dead code.

| # | Task | Details |
|---|------|---------|
| 4.1 | Install `date-fns` | Currently missing — causes crash at runtime |
| 4.2 | Fix login error-handling bug | `|| 'Invalid Username'` always truthy |
| 4.3 | Add Error Boundary component | Wrap root routes |
| 4.4 | Remove `react-toastify` | Installed but never used |
| 4.5 | Remove dead custom hook | `src/Hooks/wikiStyles.js` |
| 4.6 | Remove `dotenv` if no longer needed | CRA handled it; Vite handles it natively too |
| 4.7 | Run `vite build` — confirm 0 errors | |
| 4.8 | Manual smoke test | Full workflow pass |

---

## Order of execution

```
P2 (React 19) → P1 (Vite) → P3 (TypeScript) → P4 (Polish)
```

React 19 first isolates the framework upgrade from the build-tool swap. If something breaks after P2, you know it's React. If it breaks after P1, you know it's Vite.

---

## Effort summary

| Phase | Hours | Risk | Outcome |
|-------|-------|------|---------|
| P1 — Vite | 4 | Low | CRA replaced, faster dev/build |
| P2 — React 19 | 2 | Low | Current React, blob leaks fixed |
| P3 — TypeScript | 8–16 | Medium | Full type safety, bugs caught |
| P4 — Polish | 2 | Low | date-fns fixed, error boundary added |

**Total:** 16–24 hours of hands-on work across 4 phases.
