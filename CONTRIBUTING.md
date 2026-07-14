# Contributing to WikiPOC

## Development Setup

See [README.md](./README.md) for prerequisites and quick start instructions.

## Code Style

### Backend (C#)
- .NET 10 with implicit usings and nullable reference types enabled
- Roslyn code-style analyzers are enabled — `TreatWarningsAsErrors` is on
- Run `dotnet build` before pushing; any warnings will fail the build
- Follow existing patterns: repository pattern, async methods, nullable annotations

### Frontend (TypeScript/React)
- ESLint with TypeScript and React Hooks rules — run `npx eslint src/` before pushing
- TypeScript strict mode is not enabled, but avoid `any` where possible
- Plain CSS files (no CSS Modules, no Tailwind) — see era scoping rules in `AGENTS.md`
- Functional components with hooks, no class components

## Testing

### Backend
```bash
# Unit tests (fast, no database)
dotnet test wiki-backend/UnitTests/UnitTests.csproj

# Integration tests (requires SQL Server)
dotnet test wiki-backend/IntegrationTests/IntegrationTests.csproj
```

Please add or update tests for any new functionality. Coverage reports are generated in CI.

### Frontend
```bash
# TypeScript type check
npm test

# Production build
npm run build
```

## Commit Guidelines

- **Atomic commits**: each commit should represent one logical change
- **Descriptive messages**: explain what and why, not just "fix bug"
- **No batching**: don't bundle unrelated fixes in the same commit
- **Ask before pushing**: this project follows a confirmation workflow for destructive actions

## Pull Request Process

1. Ensure all CI checks pass (ESLint, Roslyn analyzers, unit tests, Docker build)
2. Update documentation (AGENTS.md, README) if your change affects architecture or setup
3. Request review from a maintainer
4. Squash commits if needed before merge

## CI/CD Pipeline

The `.github/workflows/ci.yml` workflow runs on every push and pull request:
- Frontend: TypeScript type-check + ESLint
- Backend: `dotnet build` with Roslyn analyzers, unit tests with coverage
- Security: CodeQL (C#, JavaScript/TypeScript)
- Docker: Multi-stage build, push to GHCR, Trivy vulnerability scan
- Deploy: Automatic deployment to Azure App Service on `main`

## Environment Variables

Required environment variables are documented in `AGENTS.md`. For CI/CD, the following GitHub secrets must be configured:

| Secret | Purpose |
|--------|---------|
| `AZURE_WEBAPP_PUBLISH_PROFILE` | Azure deployment credentials |

GitHub Variables (Settings → Variables → Actions):

| Variable | Purpose |
|----------|---------|
| `AZURE_WEBAPP_NAME` | Azure App Service name |
| `APP_URL` | Production URL for deployment status |

## Questions?

Open an issue or discussion on GitHub.
