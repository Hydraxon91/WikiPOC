# Responsive Design Plan

> Critically reviewed against actual codebase. All CSS-file claims verified
> against source. Items marked `[VERIFIED]` have been confirmed by reading
> the actual file. Items marked `[NEW]` were found during review and added.

---

## 1. Current State Assessment

### Breakpoints: effectively none [VERIFIED]

Only `style.css` has a breakpoint chain at `850px → 700px → 550px → 400px`.
These only affect search bar width, sidebar width, and tab visibility — not
main content layout at all. `profilepage.css` has 3 enormous breakpoints
(2000px/3000px) that only reposition `.avatar-container` — a decorative
element that is not critical to layout. Two empty `@media` blocks at
`style.css:216,218` suggest planned work that was never implemented.

**No responsive behavior exists** for forum pages, article view, editor,
profile, login/register, admin review, categories, style editing,
breadcrumbs, or article navigation bar.

### Layout width and height assumptions

| Area | Container | CSS | Problem | Source |
|------|-----------|-----|---------|--------|
| Root wrapper | `.wrapAll` | `width: 100vw` (inline override of CSS `90%`) | Edge-to-edge on ultra-wide | `MainPage.tsx:50`, `style.css:317` |
| Header | `.top-header` | `height: 10em` (~160px) `[NEW]` | Takes ~43% of a 375px phone screen | `headercomponent.css:3` |
| Sidebar | `.sidebar` | `position: absolute; width: 10em; float: left` | Doesn't flow; content uses `margin-left: 11em`; `float: left` is contradictory with `absolute` but harmless | `style.css:320-323` |
| Article body | `.article` | `width: 98%` | Flexible, reasonable | `style.css:453` |
| Forum grids | `.forum-mainsection` | `width: 98%` | Flexible, reasonable | `forumlandingpage.css:2` |
| Forum author sidebar | `.post-author-sidebar` | **fixed `width: 130px; min-width: 130px`** | Overwhelming on narrow screens | `forumpost.css:18-19` |
| Editor | `.editor-container` | **50/50 flex split** | Neither half usable on phones | `articleeditor.css:2-9` |
| Profile card | `.profile-container` | **fixed `width: 550px; height: 650px`** `[CORRECTED]` | Overflows in BOTH dimensions on small screens | `profilepage.css:28-29` |
| Login form | `.login-page-element-container` | **fixed `width: 450px; height: 550px; margin-top: 30vh`** `[CORRECTED]` | Overflows width; fixed height; 30vh pushes form toward bottom on short screens | `src/Styles/login.css:7-8` `[CORRECTED path]` |
| Register form | `.register-page-element-container` | **fixed `width: 450px; height: 600px; margin-top: 30vh`** `[CORRECTED]` | Same issues as login | `src/Styles/register.css:7-8` `[CORRECTED path]` |
| Thumbnails | `.thumbnail` | **fixed `width: 200px`** | Large on narrow screens | `wikipagecomponent.css:10` |
| Custom popup (editor) | `.custom-popup` | `max-width: 40%` | ~150px on a phone — unusable | `articleeditor.css:21` |
| Custom popup (forum) | `.fp-custom-popup` | `max-width: 40%` `[NEW]` | Same narrow popup issue | `forumsubmintcommentcomponent.css:14` |
| Categories row | `.category-row` | `display: flex` (no `flex-wrap`) `[NEW]` | Long names + delete button overflow horizontally | `categorypagestyle.css:2` |
| Style preset card | `.wikipage-preset-card-component` | `min-width: 45%; height: 20em` `[NEW]` | Fixed height creates excessive scrolling on mobile | `stylepage.css:19-20` |
| Style font select | `.font-change select` | `width: 20%` `[NEW]` | Extremely narrow on small screens | `stylepage.css:8` |
| Breadcrumbs | `.breadcrumbs ul` | `display: flex` (no wrap) `[NEW]` | Deep paths overflow horizontally | `Breadcrumbs.css:10` |
| Article navbar | `.wiki-navbar` | tab buttons, no wrap behavior `[NEW]` | Tab labels may overflow on narrow screens | `wikipage.css:2` |

### Mobile usability today: essentially broken [VERIFIED]

On a 375px phone screen:
- The sidebar's `position: absolute` at `10em` (~160px) overlaps the
  content area (`margin-left: 11em`, ~176px) — content gets ~200px
- The header at `height: 10em` (~160px) takes ~43% of the viewport `[NEW]`
- Fixed-width containers (profile 550px, login 450px) overflow
- Login/register `margin-top: 30vh` + fixed height means on a 667px tall
  phone, the form starts at 200px and needs 550px more — total 750px,
  exceeding the viewport `[NEW]`
- Forum author sidebar at 130px takes 35% of the screen
- Editor 50/50 split gives each panel ~175px — both unusable
- Categories page flex rows don't wrap — long names overflow `[NEW]`

---

## 2. Recommended Breakpoint Strategy

```
Ultra-wide     ≥ 2560px    Cap content width, center
Desktop        ≥ 1024px    Full layout (current default)
Tablet         768–1023px  Collapse sidebar, stack columns
Phone          < 768px      Single column, stacked navigation
Narrow phone   < 400px      Minimal padding, essential only
```

Rationale: 768px aligns with iPad portrait and is a widely-used tablet
boundary. The current ~850px breakpoint was arbitrary.

---

## 3. Per-Area Recommendations

### Main Page / Home (`CSS-only`)
- Cap `.wrapAll` at `max-width: 1600px; margin: 0 auto;` — remove the
  `width: 100vw` inline override from `MainPage.tsx:50`
- Collapse `.sidebar` into a hamburger or top navigation bar below 768px
- Adjust `.mainsection` margin to `0` when sidebar is hidden
- Sidebar content (nav links, user tools) moves to a top bar or drawer
- `[NEW]` Reduce `.top-header` height below 768px to a slim bar
  (~3em) showing only the logo (title hidden, hamburger menu added)

### Article View (`CSS-only`)
- `.article` at `width: 98%` and `.wikipage-component` at `min-width: 45%`
  are reasonably flexible — just need a `max-width` cap
- Cap article max-width: `max-width: 960px` on `.article`
- Table of contents (`.contentsPanel`) should go full width below 768px
- Thumbnails: `width: 200px` → `width: 40%; max-width: 200px` on narrow
  screens
- `[NEW]` Article navbar (`.wiki-navbar`) tab buttons should remain
  side-by-side but shrink padding/font below 768px

### Forum (`CSS-only` + responsive variant)
- **Critical**: 130px fixed author sidebar needs to collapse to a
  horizontal mini-profile or inline "Posted by" line on narrow screens
- **Landing page grid**: 4-column flex (Forum / Topics / Posts / Last
  Post) → 2-column or stacked below 768px
- `.post-meta` should wrap — subject + date on one line, quote button
  below if needed
- Image thumbnail max-height should reduce on mobile
- `[NEW]` Forum reply popup (`.fp-custom-popup`) at `max-width: 40%` →
  `min-width: 90%; max-width: 600px` on narrow screens
- `[NEW]` Breadcrumbs (`.breadcrumbs ul`) should allow wrapping or
  truncate with ellipsis on narrow screens

### Profile Page (`CSS-only`)
- `.profile-container`: `width: 550px; height: 650px` →
  `max-width: 550px; width: 90%; height: auto; min-height: 400px`
  `[CORRECTED — height fix added]`
- Profile image and stats stack vertically below 600px
- `[NEW]` Check profile editor page for same fixed-width issues

### Editor (`responsive variant`, same component)
- 50/50 split collapses to single column below 768px: editor on top,
  preview below (or preview hidden behind a tab toggle)
- ReactQuill toolbar needs overflow handling (wraps/overflows on narrow
  screens with many buttons)
- Custom HTML popup: `max-width: 40%` → `min-width: 90%; max-width: 600px`

### Login / Register (`CSS-only`) `[CORRECTED]`
- CSS files are at `src/Styles/login.css` and `src/Styles/register.css`
  (not under `LoginPage/`)
- `width: 450px` → `max-width: 450px; width: 90%`
- `[NEW]` Below 768px: go full-height — `height: auto`, remove
  `margin-top: 30vh`, form fills the viewport (no card-like centered
  box on mobile)

### Create Forum Topic (`CSS-only`)
- `max-width: 37.5rem` is already reasonable — just needs `width: 90%`

### Admin Review (Compare Updates) (`CSS-only`)
- 50/50 side-by-side → vertical stack below 768px

### Categories Page (`CSS-only`) `[NEW]`
- `.category-row` needs `flex-wrap: wrap` so long names + buttons don't
  overflow
- `.cat-text` at `font-size: 1.6em` is large on mobile — consider
  `font-size: 1.2em` below 768px

### Style Editing Page (`CSS-only`) `[NEW]`
- `.wikipage-preset-card-component` at `height: 20em` → `height: auto;
  min-height: 15em` below 768px
- `.font-change select` at `width: 20%` → `width: 50%` below 768px

---

## 4. Prioritized Task List

> Order revised: sidebar collapse should come before root width cap,
> because capping width without fixing the absolute-positioned sidebar
> first could create layout issues on medium screens.

- [x] **P1** Build hamburger drawer component and collapse sidebar into
      it below 768px — unblocks mobile entirely
- [x] **P1** Cap root layout width at `max-width: 1200px` on `.wrapAll`,
      remove `100vw` inline override — fixes ultra-wide stretch
- [x] **P1** Fix fixed-width AND fixed-height containers (profile 550×650,
      login 450×550, register 450×600 → responsive width + auto height)
- [x] **P1** Fix login/register `margin-top: 30vh` → smaller on mobile
      `[NEW]`
- [x] **P1** Reduce header height (`.top-header` 10em) on mobile `[NEW]`
- [x] **P1** Add wiki name to mobile header, left-align hamburger+logo+title `[NEW]`
- [x] **P1** Animate hamburger drawer slide-in/out `[NEW]`
- [ ] **P2** Forum author sidebar → replace 130px fixed sidebar with
      inline "Posted by Username" line on narrow screens
- [ ] **P2** Forum grid column collapse (4-col → stacked on mobile)
- [ ] **P2** Editor 50/50 split → single column on mobile, preview
      behind a toggle button
- [ ] **P2** Thumbnail sizing (fixed 200px → responsive)
- [ ] **P2** Forum reply popup + editor popup `max-width: 40%` →
      responsive `[NEW]`
- [ ] **P2** Categories page flex-wrap + font sizing `[NEW]`
- [ ] **P3** Admin compare-update 50/50 → vertical stack on mobile
- [ ] **P3** Breadcrumbs wrapping/truncation `[NEW]`
- [ ] **P3** Style page preset card height + font select width `[NEW]`
- [ ] **P3** Font sizing review with `clamp()` or `rem` for high-res
- [ ] **P3** Mobile navigation improvements (hamburger for sidebar)
- [ ] **P4** Profile page responsive refinement
- [ ] **P4** Article navbar tab responsive sizing `[NEW]`
- [ ] **P4** High-DPI / retina rendering check

---

## 5. Open Questions

1. **~~Sidebar on mobile~~ RESOLVED**: Hamburger drawer. Navigation moves
   into a new hamburger-triggered drawer component on mobile, rather than
   a top bar or hiding behind existing links. This requires building a
   new component (per the plan's "Phone — may need genuinely new
   components" framing).

2. **~~Forum author sidebar collapse~~ RESOLVED**: Simple inline
   "Posted by Username" line. No horizontal stats bar — just a compact
   inline line replacing the 130px sidebar on narrow screens.

3. **~~Editor preview on mobile~~ RESOLVED**: Hide behind a "Preview"
   toggle button. Preview is not removed, just collapsed behind a toggle
   so the editor itself gets full width by default on mobile.

4. **~~Ultra-wide max-width~~ RESOLVED**: Flat `max-width: 1200px` on
   `.wrapAll` (the root wrapper) — not tied to aspect ratio. This is the
   cap for the overall page layout on ultra-wide monitors; it's separate
   from `.article`'s own `max-width: 960px` recommendation in the
   Per-Area section, which governs article content width specifically
   within whatever the page layout allows.

5. **High-DPI / 4K**: Viewport meta tag is present (`index.html:6`).
   Font sizes are mostly `rem`/`em` and scale with browser zoom.
   Recommendation: no specific 4K fix unless testing reveals actual
   problems. `[VERIFIED]`

6. **~~Header on mobile~~ RESOLVED**: Slim bar with logo only on mobile.
   The 10em header becomes a compact slim bar (e.g. `height: 3em`) below
   768px, showing just the logo. Hamburger menu for sidebar toggling can
   live here too.

7. **~~Login/register height~~ RESOLVED**: Go full-height on mobile.
   The card-like fixed-height appearance is replaced with a full-height
   form below 768px — `height: auto` with `min-height: 100vh` style
   layout, removing the `margin-top: 30vh` offset entirely on mobile.

---

## 6. Other Observations

- **`.wrapAll` inline override**: `MainPage.tsx:50` sets `width: 100vw`
  inline — this overrides the CSS `width: 90%` and should be removed.
  Note: this line also sets `minHeight: "100vh"` and `fontWeight: "bold"`
  inline — keep those, just remove `width`. `[VERIFIED]`

- **Empty media query blocks** at `style.css:216,218` — clean them up.

- **`.sidebar` has both `float: left` and `position: absolute`** —
  these are contradictory. `position: absolute` takes the element out of
  flow, making `float: left` meaningless. The `float` declaration should
  be removed as dead CSS. `[NEW]`

- **Zebra striping** on forum grids uses `rgba(0,0,0,0.03)` — invisible
  on small screens due to compressed layout; may need a different
  approach on mobile.

- **`div.articleRight` CSS was already removed** in legacy cleanup,
  but `stylepage.css` still has `.article-right-preset` and
  `.article-right-inner-preset` classes (lines 32-55) that reference
  the removed naming convention — these are used by the style preview
  cards, not the article rendering. Not a responsive issue, just
  potential confusion. `[NEW]`

- **`style.css` has both `.wrapAll { width: 90% }` and a comment that
  says the file is based on the HTML5 Wikipedia template** — the
  template's responsive intent was never fully implemented. The empty
  `@media` blocks at lines 216 and 218 are remnants of this. `[NEW]`

---

## 7. Revision Log

| Date | Changes |
|------|---------|
| Initial | First draft from codebase analysis |
| Review pass | Verified all CSS-file claims against source; corrected login/register file paths (`src/Styles/` not `LoginPage/`); added `height` and `margin-top` issues for profile/login/register; added missing areas (header, categories, style page, breadcrumbs, article navbar, forum reply popup); added `float: left` dead CSS note on sidebar; reordered P1 tasks (sidebar before root cap); added 2 new open questions |
| Decision pass | Resolved open questions #6 (header: slim bar with logo only on mobile) and #7 (login/register: full-height form on mobile, no card box) |
| User decision pass | Resolved remaining open questions #1-4 with user input: sidebar → hamburger drawer (new component), forum author info → inline "Posted by Username" line, editor preview → toggle button, ultra-wide cap → flat `max-width: 1200px` on `.wrapAll`. Updated P1/P2 task list wording to match these concrete decisions. |
| Implemented P1 | All 5 P1 tasks completed: hamburger drawer + sidebar collapse, root layout cap (1200px), fixed-width containers (profile/login/register), login/register margin-top fix, header slim bar. Also added wiki name in mobile header, hamburger slide animation. |