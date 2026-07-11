---
name: wikipoc-backend
description: Use when working on the WikiPOC .NET backend — controllers, repositories, models, services, auth, migrations, or tests. Triggers on .NET, ASP.NET, C#, EF Core, DbContext, migration, controller, repository, JWT, Identity, NUnit, dotnet test, or any file under wiki-backend/.
---

# WikiPOC Backend — SKILL

## Project structure

```
wiki-backend/
├── wiki-backend/              # Main ASP.NET Core app (.NET 10)
│   ├── Controllers/
│   │   ├── ArticleControllers/    # WikiPagesController
│   │   ├── UserControllers/       # Auth, Users, UserProfile, UserComment
│   │   ├── ForumControllers/      # ForumTopic, ForumPost, ForumComment
│   │   └── OtherControllers/      # Style, Category, Image, SiteSettings
│   ├── DatabaseServices/
│   │   ├── WikiDbContext.cs       # EF Core context + entity config
│   │   └── Repositories/          # One folder per domain (I*Repository + impl)
│   ├── Models/
│   │   ├── ArticleModels/        # WikiPage, UserSubmittedWikiPage, Paragraph
│   │   ├── UserModels/            # ApplicationUser, UserProfile, UserComment
│   │   ├── ForumModels/           # ForumTopic, ForumPost, ForumComment, ForumPostForm
│   │   └── Other Models/          # Category, StyleModel, SiteSettings
│   ├── Services/
│   │   ├── Authentication/        # AuthService, TokenServices, JwtSettings
│   │   ├── Storage/               # ImageStorageService
│   │   ├── Database/              # DbInitializer (seed on startup)
│   │   ├── Settings/              # StorageSettings, JwtSettings
│   │   ├── SlugHelper.cs          # Slugify + GenerateUniqueSlug
│   │   └── UserAuthorizationService.cs
│   ├── Identity/                  # IdentityData.cs (role/policy constants)
│   ├── Contracts/                 # AuthRequest, AuthResponse, RegistrationRequest
│   └── Program.cs                 # Pipeline, DI, auth, CORS, rate limiting
├── UnitTests/                 # NUnit, mocked repos
└── IntegrationTests/          # NUnit, real SQL Server, unique DB per test
```

## Repository pattern

All data access goes through repositories. Interfaces prefixed with `I`, implementations are scoped (not singleton):

```csharp
builder.Services.AddScoped<IWikiPageRepository, WikiPageRepository>();
```

Repositories by domain:

| Domain | Interface | Implementation |
|--------|-----------|----------------|
| Wiki Pages | `IWikiPageRepository` | `WikiPageRepository` |
| Styles | `IStyleRepository` | `StyleRepository` |
| Site Settings | `ISiteSettingsRepository` | `SiteSettingsRepository` |
| User Profiles | `IUserProfileRepository` | `UserProfileRepository` |
| User Comments | `IUserCommentRepository` | `UserCommentRepository` |
| Categories | `ICategoryRepository` | `CategoryRepository` |
| Forum Posts | `IForumPostRepository` | `ForumPostRepository` |
| Forum Topics | `IForumTopicRepository` | `ForumTopicRepository` |
| Forum Comments | `IForumCommentRepository` | `ForumCommentRepository` |

## Entity model — key relationships

### TPH inheritance: `UserSubmittedWikiPage` extends `WikiPage`
```csharp
public class WikiPage { ... }  // Base entity
public class UserSubmittedWikiPage : WikiPage
{
    public Guid? WikiPageId { get; set; }       // FK to original (for updates)
    public string SubmittedBy { get; set; }
    public bool Approved { get; set; }
    public bool IsNewPage { get; set; }
}
```
EF Core uses TPH (Table-Per-Hierarchy) — both types live in `WikiPages` table, discriminated by a `Discriminator` column. Queries filter with `Where(w => w is UserSubmittedWikiPage)`.

### UserProfile / ApplicationUser split
Two separate tables with a one-to-one relationship:
- **`UserProfiles`** (Guid `Id`) — wiki-specific profile data (DisplayName, ProfilePicture, UserName, JoinDate). This is what forum posts, comments, and user comments FK to.
- **`AspNetUsers`** (string `Id`) — ASP.NET Core Identity users (email, password hash, roles). There is **no FK from UserProfiles to AspNetUsers** in the EF config — `UserProfile.UserId` is a convenience string reference set during seeding, not real FK.

The real FK is the other direction:
```csharp
modelBuilder.Entity<ApplicationUser>()
    .HasOne(au => au.Profile)
    .WithOne(up => up.User)
    .HasForeignKey<ApplicationUser>(au => au.ProfileId);  // ApplicationUser.ProfileId → UserProfile.Id
```

### Critical FK naming gotchas

**`ForumPost.UserId` is NOT an Identity user ID.** It's a FK to `UserProfiles.Id`:
```csharp
public class ForumPost
{
    public Guid UserId { get; set; }      // ← actually references UserProfiles.Id, NOT AspNetUsers.Id
    public UserProfile User { get; set; }
}
```
Passing an `AspNetUsers.Id` to `ForumPost.UserId` will cause an FK constraint violation at insert time.

**`ForumComment.UserProfileId` and `UserComment.UserProfileId`** both reference `UserProfiles.Id` directly (not Identity).

**To convert Identity user ID → UserProfile ID:** call `GET /api/UserProfile/GetByUserId/{identityUserId}` and read the `id` from the response. Keep this in mind when writing code or MCP calls that pass user IDs to forum/wiki comment endpoints.

### Delete behaviors
| Relationship | OnDelete |
|--------------|----------|
| Category → WikiPage | `Restrict` — cannot delete category with pages |
| WikiPage → UserSubmittedWikiPage.WikiPageId | `Restrict` |
| UserComment → UserComment (self-reply) | `Restrict` |
| ForumTopic → ForumPost | `Restrict` |
| ForumPost → ForumComment | `Cascade` — deleting a post deletes its comments |
| ForumComment → ForumComment (reply) | `Restrict` |

### Slug uniqueness
`WikiPage.Slug` has a unique index with filter `[Slug] IS NOT NULL`. Use `SlugHelper.GenerateUniqueSlugAsync(title, existsAsync)` to guarantee uniqueness (appends `-1`, `-2`, etc.).

## Auth system

### JWT Bearer tokens
- Algorithm: HMAC-SHA256
- Signing key: `JWT_ISSUER_SIGNING_KEY` env var, **must be >= 32 bytes** or `Program.cs` throws on startup
- Token lifetime: `JWT_TOKEN_TIME` minutes (default 30)
- Claims: `Sub` (user ID), `Jti`, `Iat`, `NameIdentifier` (user ID), `Name` (username), `Email`, `Role`
- Role claim type: `ClaimTypes.Role` → serialized as `http://schemas.microsoft.com/ws/2008/06/identity/claims/role`

### Roles and policies
```csharp
public const string AdminUserClaimName = "Admin";
public const string UserClaimName = "User";
public const string ModeratorClaimName = "Moderator";
public const string OwnerClaimName = "Owner";
```

| Policy | Required roles |
|--------|---------------|
| `Admin` | Admin OR Owner |
| `User` | User, Moderator, Admin, OR Owner |
| `Moderator` | Moderator, Admin, OR Owner |
| `Owner` | Owner only |

**Owner inherits all other roles** — every policy that checks Admin also checks Owner.

### Role-changed middleware (Program.cs lines 123-153)
On every authenticated request (except `/api/Users/RefreshToken`), middleware re-checks the user's current roles in the database against the role claim in the JWT. If they differ, it returns 401 with `{ reason: "role_changed" }`. The frontend's `apiClient.ts` handles this by refreshing the token and retrying.

### Password rules (minimal for dev)
```
RequireDigit = false, RequiredLength = 6, RequireNonAlphanumeric = false
RequireUppercase = false, RequireLowercase = false
```

## Middleware pipeline order (Program.cs)

```
HttpsRedirection
ExceptionHandler (returns RFC 7807 problem JSON on 500)
Cors (default policy, allowed origins from env)
RateLimiter (10 login attempts per minute)
Authentication (JWT Bearer)
Role-changed check middleware
Authorization (policies)
MapControllers
HealthChecks (/health)
```

### CORS
Default origins: `http://localhost:3000;http://localhost:3001` (from `AllowedOrigins` env, semicolon-separated). Allows any header, any method, credentials.

### Rate limiting
Only `LoginPolicy` (fixed window: 10/min, no queue). Applied to login endpoint.

## Database initialization

`DbInitializer` is a **`HostedService`** — runs once on startup. Seeds:
- 4 `StyleModel` system presets (Wikipedia, Glass, Modern, Frutiger)
- Default categories (Technologies, Sports, History, Characters, etc.)
- Default forum topics (Main Forum, Off Topic, Foreign Languages, Archive)
- Owner user (from `ADMINUSER_*` env vars) with `UserProfile`
- Test user (from `TESTUSER_*` env vars) with `UserProfile`
- Moderator (from `MODERATOR_*` env vars, if all three are set)

### Seeding creates UserProfile + ApplicationUser together
Pattern: create `UserProfile` row → save → create `ApplicationUser` with `ProfileId = profile.Id` → `UserManager.CreateAsync` → set `profile.UserId = user.Id` → update profile.

**Newly registered users (via `/api/Auth/register`) do NOT get a UserProfile automatically.** This caused FK violations when posting forum comments. If adding registration flow changes, ensure a `UserProfile` is created and linked.

## Migrations

EF Core auto-migrates on startup. To create a migration manually:
```bash
cd wiki-backend/wiki-backend/
dotnet ef migrations add MigrationName
dotnet ef database update -- --environment Development
```

`WikiDbContextDesignTimeFactory` exists for `dotnet ef` CLI support.

## Testing

### Unit tests (`wiki-backend/UnitTests/`)
- NUnit, mocks repositories/services with Moq or manual mocks
- Fast, no database dependency
- Run: `dotnet test wiki-backend/UnitTests/UnitTests.csproj`

### Integration tests (`wiki-backend/IntegrationTests/`)
- NUnit, **real SQL Server** (requires `INTEGRATIONTEST_CONNECTIONSTRING` in `.env`)
- Unique database per test class: `TestDb_{Guid.NewGuid()}`
- `IntegrationTestBase` creates and disposes databases; provides helper methods for creating test users and getting tokens
- Run: `dotnet test wiki-backend/IntegrationTests/IntegrationTests.csproj --no-build > test-output.log 2>&1`
- Always redirect to file — tests hit real SQL Server and take several minutes

### HasRuleAsync pattern
Integration test base creates roles, users, and authenticates to get tokens:
```csharp
var user = await CreateTestUserAsync(email, username, password);
var token = await GetValidUserToken(email, username, password);
```

## Dependencies

| Package | Version | Purpose |
|---------|---------|---------|
| .NET | 10.0 | Runtime |
| EF Core | 10.0 | ORM |
| EF Core SqlServer | 10.0 | SQL Server provider |
| Identity.EntityFramework | 10.0 | ASP.NET Identity |
| JwtBearer | 10.0 | JWT auth |
| Serilog.AspNetCore | 10.0 | Structured logging |
| Swashbuckle.AspNetCore | 10.0 | Swagger docs |
| Mvc.Versioning | 5.1.0 | API versioning |

## Gotchas

1. **ForumPost.UserId → UserProfiles.Id, not AspNetUsers.Id.** Passing Identity user IDs here causes FK errors. Convert with `GetByUserId/{id}` first.
2. **Newly registered users lack UserProfiles.** The register endpoint only creates Identity users, not `UserProfile` rows. Code that relies on `UserProfile` will fail with FK violations.
3. **JWT key must be >= 32 bytes.** `Program.cs` throws at startup if shorter.
4. **PendingModelChangesWarning is suppressed.** `DbContext` ignores `RelationalEventId.PendingModelChangesWarning`. Model changes that haven't been migrated won't surface as warnings.
5. **Sensitive data logging enabled in dev.** `EnableSensitiveDataLogging()` is on in Development — SQL parameter values are logged.
6. **Slug column is nullable.** `WikiPage.Slug` has a unique index but only enforces uniqueness when non-null.
7. **DbInitializer is HostedService.** It runs asynchronously on startup — the first few requests before it completes may see an unseeded database.
8. **StyleModel activation via `IsActive` column.** Activating a theme must set `IsActive = false` on all other rows before setting `IsActive = true` on the target. Don't infer active theme by ID.

## What NOT to do

- Do not use `AspNetUsers.Id` where `UserProfiles.Id` is expected (forum posts, comments)
- Do not assume registration creates a UserProfile — it doesn't
- Do not use `Database.EnsureCreated()` in app code — `DbInitializer` handles seeding; use migrations for schema changes
- Do not bypass the role-changed middleware — it's a security feature, not optional
- Do not use `AddSingleton` for repositories — they hold `DbContext` which is scoped
- Do not leave test output unredirected — integration tests take minutes, always pipe to a file
- Do not introduce new `IHostedService` seeders that run before `DbInitializer` — they may hit an unseeded DB