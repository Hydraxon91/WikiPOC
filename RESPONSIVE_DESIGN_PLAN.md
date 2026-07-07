# 4-Era User-Expandable Theme Engine — Refactoring Blueprint

## 1. Architecture Overview

### 1A. The Theme Engine Model

The system moves from a single global `StyleModel` row to a multi-theme model:

```
StyleModel (table)
├── Id              (PK, int)
├── IsActive        (bool)      ← TRUE for exactly one row (the globally active theme)
├── IsSystemPreset  (bool)      ← true = shipped with app, false = user-created
├── UserId          (string?)   ← null for system presets, user GUID for custom
├── InterfaceEra    (string)    ← "wikipedia" | "glass" | "modern" | "frutiger"
├── ThemeName       (string?)   ← user-given name for custom themes
├── Logo / WikiName / BodyColor / ...
├── GlassBgOpacity / GlassBlurRadius / GlassBorderReflection / BgMeshGradient
├── BorderRadius / BorderStyle
└── CreatedAt / UpdatedAt (DateTime?)
```

**How it works at load:**

1. `GET /api/Style` returns the **active theme** — the single `StyleModel` row where `IsActive == true`.
2. `GET /api/Style/presets` returns all system presets (4 rows, `IsSystemPreset == true`).
3. `GET /api/Style/user-themes?userId={guid}` returns all custom themes for a user.
4. `POST /api/Style/user-themes` saves the current editor state as a new user theme.
5. `DELETE /api/Style/user-themes/{id}` deletes a user's custom theme.
6. `PUT /api/Style/user-themes/{id}` updates an existing custom theme.
7. `PUT /api/Style/activate/{id}` runs a transaction that sets `IsActive = false` on every row, then `IsActive = true` on the target row.

**Frontend flow:**

```
App.tsx mount
  → StyleContext.loadActiveTheme()
    → GET /api/Style
    → Sets styles state with returned StyleModel
    → Body mesh, CSS vars all derived from this active theme

EditStylePage (the Engine Dashboard)
  ├── "System Eras" zone: 4 cards → click to preview + populate sliders
  ├── "My Custom Themes" zone: user's saved themes
  │     → click to load, shows Delete button
  └── Manual adjustment sliders
        → "Save as Custom Theme" button → prompts name → POST
```

### 1B. Fallback Behavior

Each `interfaceEra` value has a hardcoded fallback config in `StyleContext.tsx`. If `GET /api/Style` returns null (fresh DB), the app renders the Wikipedia era defaults. If any field is null, the era's fallback value fills the gap.

---

## 2. Backend Model & Repository Changes

### 2A. StyleModel.cs

Add these fields:

```csharp
public bool IsActive { get; set; } = false;       // Exactly one row has IsActive == true
public bool IsSystemPreset { get; set; } = false;
public string? UserId { get; set; }              // Null for system presets
public string? ThemeName { get; set; }            // User-given name
public string? InterfaceEra { get; set; }         // "wikipedia" | "glass" | "modern" | "frutiger"
public string? BorderRadius { get; set; }         // e.g. "0px", "24px", "12px"
public string? BorderStyle { get; set; }          // e.g. "1px solid rgba(0,0,0,0.08)"
public double? GlassBgOpacity { get; set; }
public double? GlassBlurRadius { get; set; }
public double? GlassBorderReflection { get; set; }
public string? BgMeshGradient { get; set; }
```

### 2B. IStyleRepository.cs — New Methods

```csharp
public interface IStyleRepository
{
    Task<StyleModel> GetActiveStylesAsync();                          // WHERE IsActive == true
    Task<List<StyleModel>> GetSystemPresetsAsync();                   // WHERE IsSystemPreset == true
    Task<List<StyleModel>> GetUserThemesAsync(string userId);         // WHERE UserId == userId
    Task<StyleModel> CreateUserThemeAsync(StyleModel theme);          // POST new custom
    Task UpdateUserThemeAsync(StyleModel theme);                      // PUT existing custom
    Task DeleteUserThemeAsync(int id);                                // DELETE custom
    Task ActivateThemeAsync(int id);                                  // transactional swap
    Task UpdateGlobalStylesAsync(StyleModel updated, IFormFile? logo); // legacy PUT
}
```

### 2C. StyleRepository.cs — Transactional Activation

```csharp
public async Task<StyleModel> GetActiveStylesAsync()
{
    return await _dbContext.Styles
        .SingleOrDefaultAsync(s => s.IsActive)
        ?? throw new InvalidOperationException("No active theme configured. The database must have exactly one row with IsActive = true.");
}
```

**`GetActiveStylesAsync()`** uses `SingleOrDefaultAsync` with `WHERE IsActive == true`. If no active theme exists (fresh DB without seed), it throws — the frontend `StyleContext` catches this and falls back to its hardcoded era defaults.

```csharp
public async Task CreateUserThemeAsync(StyleModel theme)
{
    theme.IsSystemPreset = false;
    theme.IsActive = false;    // new custom themes are never automatically active
    _dbContext.Styles.Add(theme);
    await _dbContext.SaveChangesAsync();
}
```

**`CreateUserThemeAsync()`** sets `IsSystemPreset = false`, `IsActive = false`, stamps `UserId` and `ThemeName`, saves as new row.

```csharp
public async Task ActivateThemeAsync(int id)
{
    using var transaction = await _dbContext.Database.BeginTransactionAsync();
    try
    {
        // Deactivate ALL themes
        await _dbContext.Styles
            .ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, false));

        // Activate the target theme
        await _dbContext.Styles
            .Where(s => s.Id == id)
            .ExecuteUpdateAsync(s => s.SetProperty(p => p.IsActive, true));

        await transaction.CommitAsync();
    }
    catch
    {
        await transaction.RollbackAsync();
        throw;
    }
}
```

**`ActivateThemeAsync(int id)`** — Critical: runs inside an explicit `BeginTransactionAsync` block. First, it bulk-sets `IsActive = false` on **every row** via `ExecuteUpdateAsync` (single SQL `UPDATE` statement, no row-by-row). Then it sets `IsActive = true` on the target row. The transaction ensures atomicity — if either statement fails, no theme rows are left in an inconsistent state. EF Core's `ExecuteUpdateAsync` issues a single `UPDATE` command without loading entities into memory.

### 2D. StyleController.cs — New Endpoints

```csharp
[HttpGet("presets")]
public async Task<ActionResult<List<StyleModel>>> GetSystemPresets()
{
    return Ok(await _styleRepository.GetSystemPresetsAsync());
}

[HttpGet("user-themes/{userId}")]
[Authorize]
public async Task<ActionResult<List<StyleModel>>> GetUserThemes(string userId)
{
    return Ok(await _styleRepository.GetUserThemesAsync(userId));
}

[HttpPost("user-themes")]
[Authorize]
public async Task<IActionResult> CreateUserTheme([FromBody] StyleModel theme)
{
    var created = await _styleRepository.CreateUserThemeAsync(theme);
    return CreatedAtAction(nameof(GetActiveStyles), new { id = created.Id }, created);
}

[HttpPut("user-themes/{id}")]
[Authorize]
public async Task<IActionResult> UpdateUserTheme(int id, [FromBody] StyleModel theme)
{
    theme.Id = id;
    await _styleRepository.UpdateUserThemeAsync(theme);
    return Ok(new { Message = "Theme updated" });
}

[HttpDelete("user-themes/{id}")]
[Authorize]
public async Task<IActionResult> DeleteUserTheme(int id)
{
    await _styleRepository.DeleteUserThemeAsync(id);
    return NoContent();
}

[HttpPut("activate/{id}")]
[Authorize(Policy = IdentityData.AdminUserPolicyName)]
public async Task<IActionResult> ActivateTheme(int id)
{
    await _styleRepository.ActivateThemeAsync(id);
    return Ok(new { Message = "Theme activated" });
}
```

### 2E. DbInitializer.cs — Seed All 4 System Presets

```csharp
if (!await dbContext.Styles.AnyAsync())
{
    dbContext.Styles.AddRange(new List<StyleModel>
    {
        new()  // Wikipedia Classic
        {
            IsActive = true,          // Only Wikipedia Classic is active at seed
            IsSystemPreset = true,
            ThemeName = "Wikipedia Classic",
            InterfaceEra = "wikipedia",
            BodyColor = "#f8f9fa",
            ArticleColor = "#ffffff",
            ArticleRightColor = "#f8f9fa",
            ArticleRightInnerColor = "#eaecf0",
            FooterListTextColor = "#202122",
            FooterListLinkTextColor = "#0645ad",
            FontFamily = "'Linux Libertine', Georgia, serif",
            GlassBgOpacity = 1.0,
            GlassBlurRadius = 0,
            GlassBorderReflection = 0,
            BgMeshGradient = "none",
            BorderRadius = "0px",
            BorderStyle = "1px solid #a2a9b1",
            Logo = "logo/logo_pfp.png",
            WikiName = "Your Wiki",
        },
        new()  // Liquid Glass
        {
            IsSystemPreset = true,
            ThemeName = "Liquid Glass",
            InterfaceEra = "glass",
            BodyColor = "#507ced",
            ArticleColor = "#526cad",
            ArticleRightColor = "#3c5fb8",
            ArticleRightInnerColor = "#2b4ea6",
            FooterListTextColor = "#233a71",
            FooterListLinkTextColor = "#1d305e",
            FontFamily = "Arial, sans-serif",
            GlassBgOpacity = 0.35,
            GlassBlurRadius = 12,
            GlassBorderReflection = 0.15,
            BgMeshGradient = "radial-gradient(circle at 20% 80%, rgba(80,124,237,0.4) 0%, transparent 50%), radial-gradient(circle at 80% 20%, rgba(82,108,173,0.3) 0%, transparent 50%), linear-gradient(135deg, #1a2a6c, #2b4ea6, #507ced)",
            BorderRadius = "12px",
            BorderStyle = "1px solid rgba(255,255,255,0.12)",
            Logo = "logo/logo_pfp.png",
            WikiName = "Your Wiki",
        },
        new()  // Modern Sleek
        {
            IsSystemPreset = true,
            ThemeName = "Modern Sleek",
            InterfaceEra = "modern",
            BodyColor = "#0f1117",
            ArticleColor = "#1a1d27",
            ArticleRightColor = "#222639",
            ArticleRightInnerColor = "#2a2f45",
            FooterListTextColor = "#8b8fa3",
            FooterListLinkTextColor = "#6c63ff",
            FontFamily = "Inter, system-ui, sans-serif",
            GlassBgOpacity = 0.95,
            GlassBlurRadius = 0,
            GlassBorderReflection = 0,
            BgMeshGradient = "linear-gradient(135deg, #0f1117 0%, #1a1d27 50%, #222639 100%)",
            BorderRadius = "4px",
            BorderStyle = "1px solid rgba(255,255,255,0.06)",
            Logo = "logo/logo_pfp.png",
            WikiName = "Your Wiki",
        },
        new()  // Frutiger Aero
        {
            IsSystemPreset = true,
            ThemeName = "Frutiger Aero",
            InterfaceEra = "frutiger",
            BodyColor = "#2b8a3e",
            ArticleColor = "#e8f5e9",
            ArticleRightColor = "#a5d6a7",
            ArticleRightInnerColor = "#66bb6a",
            FooterListTextColor = "#1b5e20",
            FooterListLinkTextColor = "#1565c0",
            FontFamily = "Segoe UI, Tahoma, sans-serif",
            GlassBgOpacity = 0.85,
            GlassBlurRadius = 0,
            GlassBorderReflection = 0.25,
            BgMeshGradient = "linear-gradient(135deg, #2b8a3e 0%, #43a047 30%, #1b5e20 70%, #2b8a3e 100%)",
            BorderRadius = "24px",
            BorderStyle = "1px solid rgba(255,255,255,0.35)",
            Logo = "logo/logo_pfp.png",
            WikiName = "Your Wiki",
        },
    });
    await dbContext.SaveChangesAsync();
    // GET /api/Style returns the row where IsActive == true (Wikipedia Classic)
}
```

---

## 3. Frontend API Layer

### 3A. wikiApi.ts — New Functions

```typescript
export const fetchActiveStyle = (): Promise<StyleModel> =>          // GET /api/Style
export const fetchSystemPresets = (): Promise<StyleModel[]> =>       // GET /api/Style/presets
export const fetchUserThemes = (userId: string): Promise<StyleModel[]> // GET /api/Style/user-themes/:userId
export const saveUserTheme = (theme: Partial<StyleModel>, token: string): Promise<StyleModel> // POST /api/Style/user-themes
export const updateUserTheme = (id: number, theme: Partial<StyleModel>, token: string): Promise<void> // PUT /api/Style/user-themes/:id
export const deleteUserTheme = (id: number, token: string): Promise<void> // DELETE /api/Style/user-themes/:id
export const activateTheme = (id: number, token: string): Promise<void> // PUT /api/Style/activate/:id
```

### 3B. Frontend Types — models.ts

```typescript
export interface StyleModel {
  id?: number;
  isActive?: boolean;
  isSystemPreset?: boolean;
  userId?: string;
  themeName?: string;
  interfaceEra?: 'wikipedia' | 'glass' | 'modern' | 'frutiger';
  borderRadius?: string;
  borderStyle?: string;
  logo?: string;
  wikiName?: string;
  bodyColor?: string;
  articleColor?: string;
  articleRightColor?: string;
  articleRightInnerColor?: string;
  footerListLinkTextColor?: string;
  footerListTextColor?: string;
  fontFamily?: string;
  glassBgOpacity?: number;
  glassBlurRadius?: number;
  glassBorderReflection?: number;
  bgMeshGradient?: string;
}
```

### 3C. StyleContext.tsx — Era Fallback Presets

```typescript
const ERA_PRESETS: Record<string, Omit<StyleModel, 'id' | 'isSystemPreset' | 'userId' | 'themeName'>> = {
  wikipedia: {
    interfaceEra: 'wikipedia',
    bodyColor: '#f8f9fa',
    articleColor: '#ffffff',
    articleRightColor: '#f8f9fa',
    articleRightInnerColor: '#eaecf0',
    footerListTextColor: '#202122',
    footerListLinkTextColor: '#0645ad',
    fontFamily: "'Linux Libertine', Georgia, serif",
    glassBgOpacity: 1.0,
    glassBlurRadius: 0,
    glassBorderReflection: 0,
    bgMeshGradient: 'none',
    borderRadius: '0px',
    borderStyle: '1px solid #a2a9b1',
    logo: 'logo_pfp.png',
    wikiName: 'Your Wiki',
  },
  glass: { /* ... full glass config ... */ },
  modern: { /* ... full modern config ... */ },
  frutiger: { /* ... full frutiger config ... */ },
};

// Context value expands to include:
interface StyleContextType {
  styles: StyleModel;
  setStyles: Dispatch<SetStateAction<StyleModel>>;
  updateStyles: (styles: StyleModel, logo?: File | null, jwtToken?: string) => void;
  systemPresets: StyleModel[];      // loaded on mount
  userThemes: StyleModel[];          // loaded when user is logged in
  refreshUserThemes: () => void;    // re-fetch after save/delete
  loadTheme: (theme: StyleModel) => void; // populate editor + set active
  setActiveTheme: (id: number, token: string) => void; // activate + reload
}
```

On mount, `StyleProvider` fetches:
1. `GET /api/Style` → active theme → set as `styles`
2. `GET /api/Style/presets` → all 4 system presets → `systemPresets`
3. If user logged in, `GET /api/Style/user-themes/{userId}` → `userThemes`

---

## 4. EditStylePage — The Theme Engine Dashboard

### 4A. Layout Structure

```
+----------------------------------------------------+
| [System Eras]  [My Custom Themes]  [Manual Edit]   |  ← tab bar
+----------------------------------------------------+
|                                                    |
|  SYSTEM ERAS TAB (default):                        |
|  +------------------+  +------------------+        |
|  | Wikipedia Classic|  |  Liquid Glass    |        |
|  | Utilitarian      |  |  Ambient Frosted |        |
|  | Minimalist — 2001|  |  — 2023          |        |
|  | [swatch] [LOAD]  |  | [swatch] [LOAD]  |        |
|  +------------------+  +------------------+        |
|  +------------------+  +------------------+        |
|  | Modern Sleek     |  |  Frutiger Aero   |        |
|  | Dark Geometric   |  |  Hyper-Gloss     |        |
|  | — 2025           |  |  Retro — 2006    |        |
|  | [swatch] [LOAD]  |  | [swatch] [LOAD]  |        |
|  +------------------+  +------------------+        |
|                                                    |
|  MY CUSTOM THEMES TAB:                             |
|  [My Wiki v2] [delete] [activate]                  |
|  [DarkGreen] [delete] [activate]                    |
|  (empty state: "No custom themes yet. Adjust       |
|   the sliders and click Save as Custom Theme.")    |
|                                                    |
|  MANUAL EDIT TAB:                                  |
|  (all existing sliders + border radius +           |
|    border style + era dropdown)                    |
|  [Save as Custom Theme] [Delete Theme]             |
+----------------------------------------------------+
```

### 4B. PresetsComponent.tsx — System Presets

Renders 4 premium cards. Each card shows:

- A 5-color swatch strip (body → article → right → right-inner → link)
- Theme name + era tagline
- A "Load" button that calls `loadTheme(preset)`, which populates the editor sliders AND sets the active preview

```tsx
interface PresetCardProps {
  preset: StyleModel;
  onLoad: (preset: StyleModel) => void;
  isActive: boolean;
}
```

### 4C. UserThemesList.tsx (new component)

Fetches and lists `userThemes` from context. Each row shows:

- Theme name
- Era badge (small colored pill)
- "Load" button → calls `loadTheme(theme)`
- "Delete" button → `deleteUserTheme(id, token)` + `refreshUserThemes()`

Empty state: friendly message with a link to the manual edit tab.

### 4D. ManualEditStylesComponent.tsx — Save Action

The existing sliders gain a "Save as Custom Theme" button:

```tsx
<button onClick={handleSaveCustomTheme}>
  Save as Custom Theme
</button>
```

When clicked:

1. Prompt for theme name (inline prompt or modal)
2. Build `StyleModel` object from current `newStyles` + `interfaceEra` from dropdown
3. Set `isSystemPreset = false`
4. Set `userId` from `decodedTokenContext`
5. Call `saveUserTheme(theme, jwtToken)`
6. Show success notification
7. Refresh user themes list

If the current editor state matches one of the user's existing themes (by Id), show "Update Theme" and "Delete Theme" buttons instead:

```tsx
{editingUserThemeId ? (
  <>
    <button onClick={handleUpdateTheme}>Update Theme</button>
    <button onClick={handleDeleteTheme} className="danger">Delete Theme</button>
  </>
) : (
  <button onClick={handleSaveCustomTheme}>Save as Custom Theme</button>
)}
```

---

## 5. Era-Specific CSS Architecture

### 5A. Bootstrap Specificity Conflict — Analysis

**Problem:** `App.tsx` imports Bootstrap BEFORE our custom styles. Bootstrap uses high-specificity selectors (e.g. `.form-control`, `.btn`, `table`, `a`, `input[type="text"]`) that can override our era CSS variables. This causes:

- Glass panel backgrounds getting overwritten by Bootstrap's solid white `#fff`
- Form input backgrounds staying white instead of transparent glass
- Button colors not matching the active era
- Link colors falling back to Bootstrap's `$link-color` instead of `var(--footer-link-color)`

**Strategy:** Enforce a **specificity ladder** — every era selector chain must be at least as specific as Bootstrap's equivalent. The chain always starts with `.era-*` on the `.wrapAll` ancestor plus at least one class or element selector.

| Bootstrap Selector | Specificity | Our Counter |
|--------------------|-------------|-------------|
| `.form-control` | 0,1,0 | `.era-glass .form-control` (0,2,0) |
| `.btn` | 0,1,0 | `.era-glass .btn` (0,2,0) |
| `a` | 0,0,1 | `.era-glass a` (0,1,1) |
| `input[type="text"]` | 0,1,1 | `.era-glass input[type="text"]` (0,2,1) |
| `table` | 0,0,1 | `.era-glass table` (0,1,1) |
| `table td` | 0,0,2 | `.era-glass table td` (0,1,2) |
| `.navbar` | 0,1,0 | `.era-glass .navbar` (0,2,0) |
| `.dropdown-menu` | 0,1,0 | `.era-glass .dropdown-menu` (0,2,0) |

**When to use `!important`:**
- Only on properties that Bootstrap sets with `!important` itself (e.g. `.btn` background, `.form-control` border-color)
- Only on top-level structural properties (panel backgrounds, border radii)
- Never on text color or typography — use the specificity chain instead

### 5B. Root CSS Variable Injection (MainPage.tsx)

```tsx
<div className={`wrapAll clearfix era-${styles.interfaceEra || 'wikipedia'}`}
  style={{
    '--glass-bg-opacity': styles.glassBgOpacity,
    '--glass-blur-radius': (styles.glassBlurRadius || 0) + 'px',
    '--glass-border-reflection': styles.glassBorderReflection || 0,
    '--bg-mesh-gradient': styles.bgMeshGradient,
    '--custom-border-radius': styles.borderRadius || '0px',
    '--custom-border-style': styles.borderStyle || '1px solid #a2a9b1',
    '--glass-text-color': styles.footerListTextColor,
    '--glass-link-color': styles.footerListLinkTextColor,
    '--glass-bg': styles.interfaceEra === 'wikipedia'
      ? styles.bodyColor
      : `color-mix(in srgb, ${styles.bodyColor} calc(100% * (${styles.glassBgOpacity || 1})), transparent)`,
    '--glass-panel': styles.interfaceEra === 'wikipedia'
      ? styles.articleColor
      : `color-mix(in srgb, ${styles.articleColor} calc(100% * (${styles.glassBgOpacity || 1})), transparent)`,
    '--glass-panel-accent': styles.interfaceEra === 'wikipedia'
      ? styles.articleRightColor
      : `color-mix(in srgb, ${styles.articleRightColor} calc(100% * (${styles.glassBgOpacity || 1})), transparent)`,
  }}
>
```

### 5C. style.css — Era Root Overrides with Bootstrap Hardening

```css
/* === GLOBAL DESIGN TOKENS (lowest specificity, overridden by inline vars) === */
:root {
  --custom-border-radius: 0px;
  --custom-border-style: 1px solid #a2a9b1;
  --glass-bg-opacity: 1;
  --glass-blur-radius: 0px;
  --glass-border-reflection: 0;
  --glass-bg: transparent;
  --glass-panel: transparent;
  --glass-panel-accent: transparent;
  --glass-text-color: #202122;
  --glass-link-color: #0645ad;
}

/* === BOOTSTRAP RESET — force all bootstrap components to inherit our glass vars === */

/* Forms: override Bootstrap's white background on inputs */
.era-wikipedia input[type="text"],
.era-wikipedia input[type="email"],
.era-wikipedia input[type="password"],
.era-wikipedia input[type="color"],
.era-wikipedia input[type="file"],
.era-wikipedia select,
.era-wikipedia textarea,
.era-wikipedia .form-control {
  background: #ffffff !important;
  color: #202122 !important;
  border-color: #a2a9b1 !important;
}

.era-glass input[type="text"],
.era-glass input[type="email"],
.era-glass input[type="password"],
.era-glass input[type="color"],
.era-glass input[type="file"],
.era-glass select,
.era-glass textarea,
.era-glass .form-control {
  background: rgba(255, 255, 255, 0.08) !important;
  color: var(--glass-text-color, #233a71) !important;
  border-color: rgba(255, 255, 255, 0.15) !important;
  backdrop-filter: blur(4px);
  -webkit-backdrop-filter: blur(4px);
}

.era-modern input[type="text"],
.era-modern input[type="email"],
.era-modern input[type="password"],
.era-modern input[type="color"],
.era-modern input[type="file"],
.era-modern select,
.era-modern textarea,
.era-modern .form-control {
  background: rgba(26, 29, 39, 0.95) !important;
  color: #e0e0e0 !important;
  border-color: rgba(255, 255, 255, 0.08) !important;
}

.era-frutiger input[type="text"],
.era-frutiger input[type="email"],
.era-frutiger input[type="password"],
.era-frutiger input[type="color"],
.era-frutiger input[type="file"],
.era-frutiger select,
.era-frutiger textarea,
.era-frutiger .form-control {
  background: rgba(255, 255, 255, 0.15) !important;
  color: #1b5e20 !important;
  border-color: rgba(255, 255, 255, 0.35) !important;
  border-radius: 12px !important;
}

/* Buttons: override Bootstrap .btn defaults */
.era-wikipedia .btn,
.era-wikipedia .comment-button {
  background: #f8f9fa !important;
  border: 1px solid #a2a9b1 !important;
  color: #202122 !important;
  border-radius: 0 !important;
}

.era-glass .btn,
.era-glass .comment-button,
.era-glass .fp-comment-button {
  background: var(--glass-panel-accent, rgba(60, 95, 184, 0.5)) !important;
  border: 1px solid rgba(255, 255, 255, 0.15) !important;
  color: #ffffff !important;
  border-radius: var(--custom-border-radius, 6px) !important;
  backdrop-filter: blur(4px);
  -webkit-backdrop-filter: blur(4px);
}

.era-modern .btn,
.era-modern .comment-button {
  background: rgba(108, 99, 255, 0.9) !important;
  border: 1px solid rgba(255, 255, 255, 0.06) !important;
  color: #ffffff !important;
  border-radius: 4px !important;
}

.era-frutiger .btn,
.era-frutiger .comment-button {
  background: linear-gradient(180deg, #66bb6a, #43a047) !important;
  border: 1px solid rgba(255, 255, 255, 0.35) !important;
  color: #ffffff !important;
  border-radius: 24px !important;
  box-shadow: 0 4px 16px rgba(27, 94, 32, 0.3) !important;
}

/* Links: force era link colors over Bootstrap defaults */
.era-glass a,
.era-modern a,
.era-frutiger a {
  color: var(--glass-link-color, #0645ad);
}
.era-glass a:hover,
.era-modern a:hover,
.era-frutiger a:hover {
  color: color-mix(in srgb, var(--glass-link-color, #0645ad) 80%, black);
}

/* === ERA: WIKIPEDIA CLASSIC === */
.era-wikipedia .sidebar {
  background: transparent;
  backdrop-filter: none;
  border-right: 1px solid #a2a9b1;
  border-radius: 0;
}
.era-wikipedia .article {
  border: 1px solid #a2a9b1;
}
.era-wikipedia .top-header {
  background: #f8f9fa !important;
  backdrop-filter: none !important;
  border-bottom: 1px solid #a2a9b1 !important;
  box-shadow: none !important;
}

/* === ERA: GLASS === */
.era-glass .sidebar {
  background: var(--glass-panel, rgba(82, 108, 173, 0.3));
  backdrop-filter: blur(8px);
  -webkit-backdrop-filter: blur(8px);
  border-right: 1px solid rgba(255, 255, 255, var(--glass-border-reflection, 0.1));
}

/* === ERA: MODERN SLEEK === */
.era-modern .sidebar {
  background: rgba(26, 29, 39, 0.95);
  backdrop-filter: none;
  border-right: 1px solid rgba(255, 255, 255, 0.04);
}
.era-modern .top-header {
  background: rgba(15, 17, 23, 0.98) !important;
  backdrop-filter: none !important;
  border-bottom: 1px solid rgba(255, 255, 255, 0.04) !important;
}

/* === ERA: FRUTIGER AERO === */
.era-frutiger .frutiger-gloss-effect {
  position: relative;
  overflow: hidden;
}
.era-frutiger .frutiger-gloss-effect::before {
  content: '';
  position: absolute;
  top: 0; left: 0; right: 0;
  height: 50%;
  background: linear-gradient(180deg,
    rgba(255, 255, 255, 0.35) 0%,
    rgba(255, 255, 255, 0.15) 40%,
    transparent 100%
  );
  pointer-events: none;
  z-index: 1;
  border-radius: inherit;
}
.era-frutiger .top-header {
  border-radius: 0 0 24px 24px !important;
  box-shadow: 0 8px 32px rgba(27, 94, 32, 0.3) !important;
}
.era-frutiger .sidebar {
  border-radius: 0 24px 24px 0;
  background: rgba(232, 245, 233, 0.9);
  box-shadow: 4px 0 24px rgba(27, 94, 32, 0.15);
  backdrop-filter: none;
}
.era-frutiger .glass-card,
.era-frutiger .fp-custom-popup {
  box-shadow: 0 8px 32px rgba(27, 94, 32, 0.2),
              0 2px 8px rgba(0, 0, 0, 0.1) !important;
  border: var(--custom-border-style, 1px solid rgba(255, 255, 255, 0.35)) !important;
  border-radius: var(--custom-border-radius, 24px) !important;
}
.era-frutiger .glass-card:hover {
  box-shadow: 0 12px 48px rgba(27, 94, 32, 0.3),
              0 4px 12px rgba(0, 0, 0, 0.15) !important;
  transform: translateY(-2px);
}

/* === BOOTSTRAP `table` OVERRIDES === */
.era-glass table,
.era-modern table,
.era-frutiger table {
  background: var(--glass-panel, transparent);
  color: var(--glass-text-color, inherit);
  border-color: var(--custom-border-style, inherit);
}
.era-glass table td,
.era-modern table td,
.era-frutiger table td {
  border-color: color-mix(in srgb, var(--glass-text-color, #202122) 20%, transparent);
}
```

### 5D. glass-card.css — Era-Aware Comment Card with Bootstrap Protection

```css
/* === BOOTSTRAP RESET for cards === */
.era-wikipedia .glass-card,
.era-glass .glass-card,
.era-modern .glass-card,
.era-frutiger .glass-card {
  box-sizing: border-box;  /* prevent Bootstrap box-sizing interference */
}

/* === BASE GLASS CARD === */
.glass-card {
  background: var(--glass-panel, rgba(82, 108, 173, 0.25));
  backdrop-filter: blur(var(--glass-blur-radius, 0px));
  -webkit-backdrop-filter: blur(var(--glass-blur-radius, 0px));
  border: var(--custom-border-style, 1px solid rgba(255, 255, 255, 0.12));
  border-radius: var(--custom-border-radius, 8px);
  padding: 1rem;
  margin-bottom: 0.75rem;
  transition: box-shadow 0.2s ease, transform 0.2s ease;
}
.glass-card:hover {
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
}

/* Nested depth */
.glass-card.depth-1 {
  background: color-mix(in srgb, var(--glass-panel, #526cad) 70%, transparent);
  backdrop-filter: blur(calc(var(--glass-blur-radius, 12px) * 0.6));
  margin-left: 1.5rem;
}
.glass-card.depth-2 {
  background: color-mix(in srgb, var(--glass-panel, #526cad) 50%, transparent);
  backdrop-filter: blur(calc(var(--glass-blur-radius, 12px) * 0.4));
  margin-left: 3rem;
}
.glass-card.quote {
  background: color-mix(in srgb, var(--article-right-color, #3c5fb8) 15%, transparent);
  border-left: 3px solid var(--article-right-color, #3c5fb8);
  backdrop-filter: blur(4px);
  margin: 0.5rem 0 0.5rem 1rem;
  padding: 0.6rem;
  border-radius: 0 6px 6px 0;
}

/* Wikipedia override — bootstrap-proof */
.era-wikipedia .glass-card {
  background: var(--article-color, #ffffff) !important;
  backdrop-filter: none !important;
  border: 1px solid #a2a9b1 !important;
  border-radius: 0 !important;
  box-shadow: none !important;
}
.era-wikipedia .glass-card.depth-1 {
  background: #f8f9fa !important;
  backdrop-filter: none !important;
}
.era-wikipedia .glass-card.depth-2 {
  background: #f0f2f5 !important;
  backdrop-filter: none !important;
}

/* Modern override */
.era-modern .glass-card {
  background: rgba(26, 29, 39, 0.95) !important;
  backdrop-filter: none !important;
  border: 1px solid rgba(255, 255, 255, 0.04) !important;
  border-radius: 4px !important;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.3) !important;
}

/* Frutiger override */
.era-frutiger .glass-card {
  border-radius: 24px !important;
  box-shadow: 0 8px 32px rgba(27, 94, 32, 0.2) !important;
}
```

### 5E. Header + Hamburger — Era-Aware

**`headercomponent.css`**:

```css
.top-header {
  display: flex;
  height: 10em;
  justify-content: space-between;
  align-items: center;
  padding: 2em;
  background: var(--glass-panel, rgba(82, 108, 173, 0.35)) !important;
  backdrop-filter: blur(var(--glass-blur-radius, 0px));
  -webkit-backdrop-filter: blur(var(--glass-blur-radius, 0px));
  border-bottom: var(--custom-border-style, 1px solid rgba(255, 255, 255, 0.12));
  border-radius: var(--custom-border-radius, 0);
  box-shadow: 0 4px 32px rgba(0, 0, 0, 0.1);
  position: sticky;
  top: 0;
  z-index: 100;
}

/* Specular highlight — only for glass and frutiger eras */
.era-glass .top-header::after,
.era-frutiger .top-header::after {
  content: '';
  position: absolute;
  top: 0; left: 0; right: 0;
  height: 1px;
  background: linear-gradient(90deg, transparent, rgba(255, 255, 255, 0.3), transparent);
}

/* Wikipedia override — beat Bootstrap navbar specificity */
.era-wikipedia .top-header {
  background: #f8f9fa !important;
  backdrop-filter: none !important;
  border-bottom: 1px solid #a2a9b1 !important;
  box-shadow: none !important;
  border-radius: 0 !important;
}

/* Modern override */
.era-modern .top-header {
  background: rgba(15, 17, 23, 0.98) !important;
  backdrop-filter: none !important;
  border-bottom: 1px solid rgba(255, 255, 255, 0.04) !important;
  box-shadow: 0 2px 16px rgba(0, 0, 0, 0.4) !important;
}

@media (max-width: 768px) {
  .top-header { height: 2.5em; padding: 0 0.5em; border-radius: 0 !important; }
}
```

**`hamburgermenu.css`**:

```css
.hamburger-drawer {
  background: var(--glass-panel, rgba(82, 108, 173, 0.4));
  backdrop-filter: blur(var(--glass-blur-radius, 0px));
  -webkit-backdrop-filter: blur(var(--glass-blur-radius, 0px));
  border-right: var(--custom-border-style, 1px solid rgba(255, 255, 255, 0.15));
  border-radius: 0 var(--custom-border-radius, 0) var(--custom-border-radius, 0) 0;
  box-shadow: 4px 0 24px rgba(0, 0, 0, 0.15);
}

.era-wikipedia .hamburger-drawer {
  background: #f8f9fa !important;
  backdrop-filter: none !important;
  border-right: 1px solid #a2a9b1 !important;
}

.era-modern .hamburger-drawer {
  background: rgba(26, 29, 39, 0.98) !important;
  backdrop-filter: none !important;
  border-right: 1px solid rgba(255, 255, 255, 0.04) !important;
}

.era-frutiger .hamburger-drawer {
  border-radius: 0 24px 24px 0 !important;
}
```

### 5F. Body Background (MainPage.tsx)

```tsx
useEffect(() => {
  const era = styles.interfaceEra || 'wikipedia';
  if (era === 'wikipedia' || !styles.bgMeshGradient || styles.bgMeshGradient === 'none') {
    document.body.style.background = styles.bodyColor || '#f8f9fa';
    document.body.style.backgroundAttachment = 'scroll';
    document.body.style.backgroundSize = 'auto';
  } else {
    document.body.style.background = styles.bgMeshGradient;
    document.body.style.backgroundAttachment = 'fixed';
    document.body.style.backgroundSize = 'cover';
  }
}, [styles.bgMeshGradient, styles.bodyColor, styles.interfaceEra]);
```

### 5G. Bootstrap Import Order — Required Pattern

In `App.tsx`, the import order must be:

```typescript
// 1. Bootstrap first (lowest priority — our overrides win)
import 'bootstrap/dist/css/bootstrap.css';

// 2. Our global styles (override Bootstrap with .era-* specificity)
import '../Styles/style.css';

// 3. Component CSS files are imported inside individual components
```

Our `.era-*` selectors in section 5C have specificity `0,2,0` minimum, which beats Bootstrap's `0,1,0` class selectors. The `!important` flags are used only where Bootstrap itself uses `!important` (form controls, buttons).

---

## 6. Integration — Glass Card + Gloss in Comment Components

### 6A. ForumCommentComponent.tsx

Wrap each comment with `.glass-card` and conditionally `.frutiger-gloss-effect`:

```tsx
<div className={`glass-card${styles.interfaceEra === 'frutiger' ? ' frutiger-gloss-effect' : ''}`}>
  <div className="fp-grid-row">
    {/* ... existing comment content ... */}
  </div>
</div>

{/* Quote rendering */}
<div className="glass-card quote">
  <p>{replyComment.userProfile.displayName} wrote:</p>
  <div dangerouslySetInnerHTML={{ __html: replyComment.content }} />
</div>
```

### 6B. UserCommentComponent.tsx

```tsx
<div className={`glass-card${styles.interfaceEra === 'frutiger' ? ' frutiger-gloss-effect' : ''}`}>
  {/* ... existing comment content ... */}
</div>

{/* Nested replies */}
<div className="glass-card depth-1">
  {/* reply content */}
</div>
```

### 6C. Top Header + Hamburger Drawer

The `.top-header` and `.hamburger-drawer` elements already exist. Add the gloss class:

```tsx
// In MainPage.tsx, around the header:
<HeaderComponent
  className={styles.interfaceEra === 'frutiger' ? 'frutiger-gloss-effect' : ''}
  ...
>
```

Add `frutiger-gloss-effect` to the drawer div in `HamburgerMenu.tsx`:

```tsx
<div className={`hamburger-drawer${isOpen ? ' open' : ''}${styles.interfaceEra === 'frutiger' ? ' frutiger-gloss-effect' : ''}`}>
```

---

## 7. Implementation Order

| Phase | What to Do | Files Affected |
|-------|-----------|---------------|
| 1 | Add new fields to `StyleModel.cs` | 1 backend file |
| 2 | Add new methods to `IStyleRepository.cs` + `StyleRepository.cs` | 2 backend files |
| 3 | Add new endpoints to `StyleController.cs` | 1 backend file |
| 4 | Update `DbInitializer.cs` to seed all 4 system presets | 1 backend file |
| 5 | Run EF migration | CLI |
| 6 | Extend frontend `StyleModel` type in `models.ts` | 1 frontend file |
| 7 | Add era fallback presets + new API functions to `StyleContext.tsx` + `wikiApi.ts` | 2 frontend files |
| 8 | Build `PresetsComponent.tsx` with 4 system era cards | 1 frontend file (rewrite) |
| 9 | Build `UserThemesList.tsx` for My Custom Themes zone | 1 new frontend file |
| 10 | Add save/update/delete actions to `ManualEditStylesComponent.tsx` | 1 frontend file |
| 11 | Add `era-*` class + `frutiger-gloss-effect` to `MainPage.tsx`, inject all glass CSS vars | 1 frontend file |
| 12 | Replace body background with era-aware mesh | 1 frontend file |
| 13 | Remove inline `background` from `HeaderComponent.tsx` | 1 frontend file |
| 14 | Write `glass-card.css` with all era overrides | 1 new CSS file |
| 15 | Update `headercomponent.css` with era overrides | 1 CSS file |
| 16 | Update `hamburgermenu.css` with era overrides | 1 CSS file |
| 17 | Add era + `.frutiger-gloss-effect` overrides to `style.css` | 1 CSS file |
| 18 | Add Bootstrap input/button/link reset selectors to `style.css` (section 5C) | 1 CSS file |
| 19 | Apply `.glass-card` + `.frutiger-gloss-effect` to `ForumCommentComponent.tsx` and `UserCommentComponent.tsx` | 2 frontend files |
| 20 | Apply `.frutiger-gloss-effect` to header and drawer | 2 frontend files |
| 21 | Update `forumsubmintcommentcomponent.css` + `articleeditor.css` to use `var(--custom-*)` | 2 CSS files |
| 22 | Audit all CSS files for Bootstrap specificity gaps; add `!important` where Bootstrap forces a value | All CSS files |

---

## 8. Risk Mitigation

| Risk | Mitigation |
|------|-----------|
| User creates 100+ custom themes cluttering the DB | Add a per-user limit (e.g. 25 themes). Show warning near the Save button. |
| Custom theme save fails if user loses JWT mid-edit | All save calls require a fresh token. The Editor page already redirects on 401. Add autosave draft to localStorage as future enhancement. |
| Frutiger gloss overlay breaks click targets | `pointer-events: none` on `::before`; z-index stack: overlay at 1, content at 2+. |
| Wikipedia era sliders are confusing | When `interfaceEra === 'wikipedia'`, the glass/blur/border sliders still work but have no visible effect. Users can still save custom themes — the wikipedia era just uses opaque values. |
| Dark modern theme fails WCAG contrast | Text colors were chosen for AA compliance on dark backgrounds. The custom theme system lets users override, but the preset itself is validated. |
| Multiple users share the same active theme | Only admins can call `activateTheme`. User-created themes are personal until an admin promotes one. |
| Bootstrap !important overrides break glass transparency | Every Bootstrap-affected element (`.form-control`, `.btn`, `a`, `table`, `input`) gets a `.era-* .element` reset with `!important`. The specificity table in section 5A documents the minimum chain required. |
| ActivateThemeAsync transaction fails mid-way | Wrapped in `BeginTransactionAsync` + `CommitAsync`. On exception, `RollbackAsync` restores all rows to their previous `IsActive` state. No partial activation. |
| No active theme after seed (fresh DB) | `GetActiveStylesAsync()` throws `InvalidOperationException`. Frontend `StyleContext` catches the error and falls back to hardcoded Wikipedia era defaults. |
