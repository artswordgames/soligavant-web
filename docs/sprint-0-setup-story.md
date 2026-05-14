# Epic: Developer Environment Setup
# Sprint 0

---

## Story: Local Dev Environment

**As a** developer on the SoliGavant web project,
**I want** a fully configured local development environment,
**So that** I can build, run, and test the full application stack on my machine.

**Points:** 5
*(Estimated 3 — bumped to 5 to account for unknown environment issues. Docker CLI PATH debugging confirmed the bump was warranted.)*

---

## Acceptance Criteria

- [x] `brew --version` returns a version
- [x] `git --version` returns a version
- [x] `docker --version` returns a version
- [x] `docker run hello-world` succeeds
- [x] `dotnet --version` returns 8.x
- [x] `node --version` returns a version
- [x] GitHub repo cloned locally and `git status` is clean
- [x] VS Code opens the project with no errors
- [x] Project CLAUDE.md exists at repo root
- [x] `docker compose up` starts API and database (end of sprint)

---

## Tasks

- [x] Verify Homebrew installed (`brew --version`)
- [x] Verify Git installed (`git --version`)
- [x] Install Docker Desktop
- [x] Fix Docker CLI PATH issue (symlink + zshrc export)
- [x] Verify `docker run hello-world` works
- [x] Install .NET 8 SDK (currently on EOL 3.1 — upgrade required)
- [x] Verify Node.js version is suitable
- [x] Install VS Code extensions (C#, Docker, GitLens, Prettier, ESLint, Playwright)
- [x] Create GitHub repo ✓ (soligavant-web)
- [x] Clone repo locally ✓
- [x] Create project CLAUDE.md at repo root
- [x] Create initial project folder structure
- [x] Set up Docker Compose (API + PostgreSQL)

---

## Notes

- Machine: MacBook Intel 2020, macOS, zsh
- Repo cloned to ~/apps/soligavant-web (not ~/dev — verify on iMac setup)
- Docker Desktop installed but CLI was not linked to PATH — required manual symlink
  and PATH export in `~/.zshrc`. Common issue on managed or multi-tool Mac environments.
- Machine has legacy tooling installed: Python 3.7/3.10, Java 1.8, Mono, .NET 3.1, Maven, Ant.
  None removed — leaving existing tools in place per standard onboarding practice.
- .NET 3.1 is EOL (Dec 2022). Install .NET 8 alongside it, do not remove 3.1 until confirmed unused.

---

## Healthcare Parallel

In a healthcare software shop, this story would likely include:
- VPN access setup
- Access to internal NuGet/npm package registries
- Certificate installation for internal HTTPS
- Compliance tool installation (DLP, MDM enrollment)
- Azure DevOps or Jira access provisioned by a team lead
