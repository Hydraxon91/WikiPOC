# TODO — Moderation System & Remaining CI/CD

---

## Phase 1: Moderator Role (Backend) — DONE

### 1.1 Database / Seeding — DONE
- [x] **Add `Moderator` role to `DbInitializer.AddRolesAsync()`**
- [x] **Seed a moderator user** — `AddModeratorAsync()` reads `MODERATOR_*` env vars
- [x] **Add env vars to `.env`** / docker-compose.yml / GitHub secrets

### 1.2 Authorization Service — DONE
- [x] **`IUserAuthorizationService.IsUserModerator(userName)`** — checks Admin or Moderator
- [x] **`IdentityData.cs`** — `ModeratorClaimName` / `ModeratorPolicyName` constants

### 1.3 Role Assignment Endpoint — DONE
- [x] **`PATCH /api/Users/UpdateRole/{userId}`** — Admin/Owner-only, accepts Owner/Admin/Moderator/User
- [x] **Validation** — prevents demoting last Owner, Admin can only assign Moderator/User

### 1.4 Update Existing Controllers — DONE
- [x] **UserSubmittedWikiPage approve/decline endpoints** — switched to `ModeratorPolicyName` (Admin/Moderator/Owner)
- [x] **Create/Update page endpoints (`admin`)** — switched to `ModeratorPolicyName` (Moderators direct-publish)
- [ ] **Category management endpoints** — still Admin/Owner only (intentional — structural changes)
- [ ] **Forum topic creation** — backend is `[Authorize]` (any authenticated user); frontend allows User/Admin/Moderator

---

## Phase 2: Moderator Role (Frontend) — DONE

### 2.1 Admin User Management Page — DONE
- [x] `/admin/users` route, user list, role dropdown, role change action, sidebar link

### 2.2 Update Route Guards — DONE
- [x] `/user-submissions`, `/user-updates` — Admin + Moderator
- [x] `/create`, `/page/:slug/edit`, `/profile/edit`, `/forum/:slug/create-topic` — added Moderator
- [x] `HamburgerMenu.tsx` — three-way split: Admin/Owner → Admin Tools, Moderator → Moderator Tools, User → User Tools
- [x] `wikiApi.ts` — array-aware role detection, Moderator included in direct-publish routing
- [x] `/edit-wiki` — Owner only (intentional)
- [x] `/categories/edit` — Admin/Owner only (intentional)

---

## Phase 3: Remaining CI/CD

- [x] **Verify Docker Hub token is still valid** — confirmed valid
- [ ] **Remove unused GitHub secrets** — `ADMINUSER_EMAIL`, `ADMINUSER_PASSWORD`, `ADMINUSER_USERNAME`, `ASPNETCORE_CONNECTIONSTRING`, `DB_PASSWORD`, `DOCKERHUB_REPO_NAME`, `DOCKER_PASSWORD`, `INTEGRATIONTEST_CONNECTIONSTRING`, `PICTURES_PATH`, `PICTURES_PATH_CONTAINER`, `REACT_APP_API_URL`, `TESTUSER_EMAIL`, `TESTUSER_PASSWORD`, `TESTUSER_USERNAME` — none of these are read by any workflow
- [ ] **Cherry-pick or merge strategy** — decide how to get the 30 responsive-design commits from `feature/modernize-stack` into `main` (squash merge? rebase? regular merge?)
- [ ] **Consider adding Dependabot** — for automatic dependency updates (optional)

---

## Completed: Auth/Role Fixes

- [x] **Claims collision fix** — `TokenServices.CreateClaims` now sets `Sub = user.Id` instead of dummy `"TokenForTheApiWithAuth"`, eliminating the duplicate `NameIdentifier` claim that caused the 401 on role changes
- [x] **Moderator approve/decline** — `AdminAccept`, `AdminAccept/{id}`, `AdminDecline/{id}` switched from `AdminUserPolicyName` to `ModeratorPolicyName`
- [x] **Moderator create/edit access** — added `'Moderator'` to `ProtectedRoute` role-lists; fixed `HamburgerMenu.tsx` to show role-appropriate tools
- [x] **Submission redirect** — `EditPage.tsx` now branches: Admin/Owner/Moderator → redirect to published page; User → redirect to home with "pending approval" message
- [x] **Moderator direct-publish** — Moderators publish directly (no approval queue) since they can approve themselves; `wikiApi.ts` role detection made array-aware
- [x] **Slug-based page routing** — Pages now identified by unique `Slug` column instead of raw `Title`; auto-generated from title with collision disambiguation (`-2`, `-3`, etc.); unique filtered index; existing pages backfilled in `DbInitializer`; route changed to `/page/:slug`

---

## Notes

- The `DbInitializer` checks `if (await roleManager.RoleExistsAsync("Moderator"))` before creating, so re-running the seed is safe.
- The `UserAuthorizationService.IsUserAdmin()` method checks `IsInRoleAsync(user, "Admin")`. The moderator variant checks `IsInRoleAsync(user, "Moderator") || IsInRoleAsync(user, "Admin")`.
- Frontend role detection uses the JWT claim `http://schemas.microsoft.com/ws/2008/06/identity/claims/role`. The JWT is generated at login and includes the user's role. After role change, the user must log out and back in to get a new token with the updated role.
- Slug generation: lowercase, spaces→hyphens, non-alphanumeric stripped, collision disambiguator appended. Slug is set at page creation and preserved on edits (stable URLs). User-submitted updates inherit the original page's slug on approval.
- The `WikiDbContextDesignTimeFactory` was added to support `dotnet ef migrations` commands without needing full app startup configuration.
