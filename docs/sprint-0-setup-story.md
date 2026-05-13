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

- [ ] `brew --version` returns a version
- [ ] `git --version` returns a version
- [ ] `docker --version` returns a version
- [ ] `docker run hello-world` succeeds
- [ ] `dotnet --version` returns 8.x
- [ ] `node --version` returns a version
- [ ] GitHub repo cloned locally and `git status` is clean
- [ ] VS Code opens the project with no errors
- [ ] Project CLAUDE.md exists at repo root
- [ ] `docker compose up` starts API and database (end of sprint)

---

## Tasks

- [x] Verify Homebrew installed (`brew --version`)
- [x] Verify Git installed (`git --version`)
- [x] Install Docker Desktop
- [x] Fix Docker CLI PATH issue (symlink + zshrc export)
- [x] Verify `docker run hello-world` works
- [ ] Install .NET 8 SDK (currently on EOL 3.1 — upgrade required)
- [ ] Verify Node.js version is suitable
- [ ] Install VS Code extensions (C#, Docker, GitLens, Prettier, ESLint, Playwright)
- [ ] Create GitHub repo ✓ (soligavant-web)
- [ ] Clone repo locally ✓
- [ ] Create project CLAUDE.md at repo root
- [ ] Create initial project folder structure
- [ ] Set up Docker Compose (API + PostgreSQL)

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

In a healthcare software shop, this story would also include:
- VPN access setup
- Access to internal NuGet/npm package registries
- Certificate installation for internal HTTPS
- Compliance tool installation (DLP, MDM enrollment)
- Azure DevOps or Jira access provisioned by a team lead
