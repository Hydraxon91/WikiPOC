# WikiPOC

A customizable, Wikipedia-style wiki platform. Backend-driven theming, JWT auth with role-based access (Owner / Admin / Moderator / User), forum, user-submitted content with approval workflow, and slug-based page URLs.

## Tech Stack

- **Frontend:** React 19 + TypeScript + Vite
- **Backend:** .NET 10 ASP.NET Core
- **Database:** SQL Server (via Docker)
- **Orchestration:** Docker Compose

## Features

- Wikipedia-style article creation, editing, and categorization
- Slug-based page URLs with automatic collision disambiguation
- Role-based access: Owner, Admin, Moderator, User
  - **Owner** — full system control, including wiki styling, categories, and user management
  - **Admin** — same as Owner except cannot edit wiki styles or demote Owner
  - **Moderator** — can approve/decline submissions and direct-publish pages (no approval queue for themselves)
  - **User** — can create and edit pages, but submissions require approval
- Forum with topics, posts, and comments
- User comments on articles (with replies and pagination)
- User profiles with display names and profile pictures
- Admin user management page with inline role changes
- Customizable wiki styling (colors, fonts, logo) via admin interface
- Image upload and serving
- JWT authentication
- Responsive Wikipedia-style design

## Quick Start

### Prerequisites

- Docker & Docker Compose
- .NET 10 SDK (for local backend dev)
- Node.js 20+ (for local frontend dev)

### Run with Docker (Recommended)

```bash
git clone https://github.com/Hydraxon91/WikiPOC.git
cd WikiPOC
# Create a .env file (see Environment Variables below)
docker-compose up --build
```

- **Frontend:** http://localhost:3000
- **Backend API:** http://localhost:5050
- **SQL Server:** localhost:1433

### Local Development

```bash
# Backend
cd wiki-backend/wiki-backend
dotnet restore && dotnet run

# Frontend
cd wiki-frontend
npm install && npm run dev
```

## Environment Variables (.env)

Create a `.env` file in the project root. Required variables:

```bash
# Database
ASPNETCORE_CONNECTIONSTRING=Server=sql-server;Database=WikiDb;User=sa;Password=<DB_PASSWORD>
DB_PASSWORD=<your-strong-password>

# Admin User (seeded on startup with Owner role)
ADMINUSER_EMAIL=admin@example.com
ADMINUSER_USERNAME=admin
ADMINUSER_PASSWORD=<your-admin-password>

# Moderator User (seeded on startup with Moderator role)
MODERATOR_USERNAME=moderator
MODERATOR_EMAIL=moderator@example.com
MODERATOR_PASSWORD=<your-moderator-password>

# Test User (seeded on startup with User role)
TESTUSER_EMAIL=testuser@example.com
TESTUSER_USERNAME=testuser
TESTUSER_PASSWORD=<your-test-password>

# JWT Configuration
JWT_ISSUER_SIGNING_KEY=<32+ character random string>
JWT_VALID_AUDIENCE=https://localhost:5001
JWT_VALID_ISSUER=https://localhost:5001
JWT_TOKEN_TIME=60

# File Paths
PICTURES_PATH=./uploads/profile_pictures
PICTURES_PATH_CONTAINER=/app/uploads/pictures
PROFILE_PICTURES_PATH=./uploads/pictures

# Frontend
VITE_API_URL=http://localhost:5050
```

## Role System

| Role     | Create Pages | Edit Pages | Approve Submissions | Manage Users | Edit Styling | Edit Categories |
|----------|:---:|:---:|:---:|:---:|:---:|:---:|
| Owner    | Direct publish | Yes | Yes | Yes | Yes | Yes |
| Admin    | Direct publish | Yes | Yes | Yes | No  | Yes |
| Moderator| Direct publish | Yes | Yes | No  | No  | No  |
| User     | Needs approval | Needs approval | No  | No  | No  | No  |

All four roles can edit their own profile, create forum topics and posts, and comment on articles.

## Project Structure

```
WikiPOC/
├── wiki-backend/
│   ├── wiki-backend/           # ASP.NET Core app
│   │   ├── Controllers/        # API controllers by feature
│   │   ├── Models/             # Entity models and DTOs
│   │   ├── DatabaseServices/   # DbContext and repositories
│   │   ├── Services/           # Auth, storage, initialization
│   │   └── Identity/           # Role/policy definitions
│   ├── UnitTests/              # NUnit unit tests
│   └── IntegrationTests/       # NUnit integration tests
├── wiki-frontend/              # React SPA
│   └── src/
│       ├── Api/                # API client modules
│       ├── Pages/              # Page components
│       └── Components/         # Shared components (routing, context)
├── docker-compose.yml
└── .env
```

## Usage

1. **Browse articles** — the home page lists all published articles grouped by category
2. **Create a page** — logged-in users can create articles. Owners, Admins, and Moderators publish directly; Users submit for approval
3. **Edit a page** — click the pencil icon on any article. Same role-based rules as creation
4. **Approve submissions** — Moderators and above can review and approve/decline pending pages at `/user-submissions`
5. **Manage users** — Admins and Owners can change user roles at `/admin/users`
6. **Forum** — browse topics, create posts, and comment
7. **Customize styling** — Owners can change colors, fonts, and logo at `/edit-wiki`
8. **User profile** — any logged-in user can edit their display name and profile picture

## Key Commands

### Backend
```bash
cd wiki-backend/wiki-backend
dotnet run                    # Run
dotnet build                  # Build
dotnet ef migrations add Name # Add migration
```

### Frontend
```bash
cd wiki-frontend
npm run dev                   # Dev server
npm run build                 # Production build
```

### Docker
```bash
docker-compose up             # Start all services
docker-compose up --build     # Rebuild and start
docker-compose down           # Stop
docker-compose logs -f        # View logs
```

## License

MIT License — see [LICENSE](LICENSE) for details.
