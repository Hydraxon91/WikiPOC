# TODO — Moderation System & Remaining CI/CD

---

## Phase 1: Moderator Role (Backend)

### 1.1 Database / Seeding
- [ ] **Add `Moderator` role to `DbInitializer.AddRolesAsync()`** — create `"Moderator"` role alongside `"Admin"` and `"User"`
- [ ] **Seed a moderator user** — add `AddModeratorAsync()` method that reads env vars `MODERATOR_USERNAME`, `MODERATOR_EMAIL`, `MODERATOR_PASSWORD`. Assigns `"Moderator"` role.
- [ ] **Add env vars to `.env`** — add `MODERATOR_USERNAME`, `MODERATOR_EMAIL`, `MODERATOR_PASSWORD` with default values
- [ ] **Add env vars to docker-compose.yml** — pass through to backend service
- [ ] **Add env vars to GitHub secrets** — so the CI integration tests can use them

### 1.2 Authorization Service
- [ ] **Update `IUserAuthorizationService` / `UserAuthorizationService`** — add `IsUserModerator(userName)` method that checks for `"Admin"` or `"Moderator"` role
- [ ] **Update `IdentityData.cs`** — add `ModeratorUserPolicyName` constant

### 1.3 Role Assignment Endpoint
- [ ] **Add `PATCH /api/Users/{userId}/role`** — Admin-only endpoint that accepts `{ "role": "Admin" | "Moderator" | "User" }`. Calls `_userManager.AddToRoleAsync()` / `RemoveFromRoleAsync()`.
- [ ] **Add validation** — prevent removing the last Admin, prevent self-demotion

### 1.4 Update Existing Controllers
- [ ] **UserSubmittedWikiPage review endpoints** — currently `[Authorize(Policy = IdentityData.AdminUserPolicyName)]`. Should also allow `Moderator`. Change to `[Authorize(Roles = "Admin, Moderator")]` or create a shared policy.
- [ ] **Category management endpoints** — same treatment (allow Moderators)
- [ ] **Forum topic creation** — currently admin-only in frontend but the backend endpoint is `[Authorize]` (any authenticated user). Clarify whether Moderators can create forum topics.

---

## Phase 2: Moderator Role (Frontend)

### 2.1 Admin User Management Page
- [ ] **Create `/admin/users` route** — `ProtectedRoute roles={['Admin']}` that renders a new `UserManagementPage` component
- [ ] **Fetch user list** — call `GET /api/Users/GetUsers` (already exists)
- [ ] **Display users** — table with Username, Email, Current Role, and a role dropdown/select
- [ ] **Role change action** — on dropdown change, call `PATCH /api/Users/{id}/role` with the new role
- [ ] **Add navigation link** — add "Manage Users" link to the Admin Tools section in the sidebar

### 2.2 Update Route Guards
- [ ] **Review all admin routes** — which should also allow Moderators?
  - `/edit-wiki` — Admin only ❌ (style changes are too sensitive)
  - `/user-submissions` — Admin + Moderator ✅
  - `/user-updates` — Admin + Moderator ✅
  - `/categories/edit` — Admin only ❌ (structural)
  - `/forum/:slug/create-topic` — already `['User', 'Admin']`, should this include Moderator? (it already works)

---

## Phase 3: Remaining CI/CD

- [ ] **Verify Docker Hub token is still valid** — the `DOCKERHUB_TOKEN` secret is 2 years old; regenerate if expired
- [ ] **Remove unused GitHub secrets** — `ADMINUSER_EMAIL`, `ADMINUSER_PASSWORD`, `ADMINUSER_USERNAME`, `ASPNETCORE_CONNECTIONSTRING`, `DB_PASSWORD`, `DOCKERHUB_REPO_NAME`, `DOCKER_PASSWORD`, `INTEGRATIONTEST_CONNECTIONSTRING`, `PICTURES_PATH`, `PICTURES_PATH_CONTAINER`, `REACT_APP_API_URL`, `TESTUSER_EMAIL`, `TESTUSER_PASSWORD`, `TESTUSER_USERNAME` — none of these are read by any workflow
- [ ] **Cherry-pick or merge strategy** — decide how to get the 30 responsive-design commits from `feature/modernize-stack` into `main` (squash merge? rebase? regular merge?)
- [ ] **Update `DOTNET_NOLOGO`** — already set to `true`, good
- [ ] **Consider adding Dependabot** — for automatic dependency updates (optional)

---

## Notes

- The `DbInitializer` checks `if (await roleManager.RoleExistsAsync("Moderator"))` before creating, so re-running the seed is safe.
- The `UserAuthorizationService.IsUserAdmin()` method currently checks `IsInRoleAsync(user, "Admin")`. The moderator variant would check `IsInRoleAsync(user, "Moderator")`.
- Frontend role detection uses the JWT claim `http://schemas.microsoft.com/ws/2008/06/identity/claims/role`. The JWT is generated at login and includes the user's role. After role change, the user must log out and back in to get a new token with the updated role.
