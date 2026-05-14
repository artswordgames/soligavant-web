# SoliGavant Web

A browser-based solo RPG companion app for playing SoloDark
(the solo rules variant of the ShadowDark TTRPG system).
Designed for busy players who want their RPG fix without
books, dice, or a regular group.

## Tech Stack
- **Frontend:** React + TypeScript (via Vite)
- **Backend:** C# / .NET 8 Web API (controller-based)
- **Database:** PostgreSQL (running in Docker)
- **ORM:** Entity Framework Core + Npgsql
- **Unit Testing:** xUnit
- **E2E / Functional Testing:** Playwright
- **CI/CD:** GitHub Actions
- **Containers:** Docker / Docker Compose
- **Version Control:** Git / GitHub (github.com/artswordgames/soligavant-web)

## MVP Features
- Dice roller (d4, d6, d8, d10, d12, d20, d100)
- d20 Oracle (yes/no with luck/chaos modifier)
- d100 Prompt table
- Dungeon name generator
- Character sheet (ShadowDark stats, HP, gear)
- Session journal (chat-style narrative log with inline roll results)

## Project Structure
```
soligavant-web/
├── src/
│   ├── SoliGavant.Api/          # C# .NET 8 Web API
│   └── SoliGavant.Tests/        # xUnit unit tests
├── client/                       # React + TypeScript frontend (Vite)
├── docs/                         # Sprint stories, Q&A, notes
├── docker-compose.yml            # Local stack (API + PostgreSQL)
└── CLAUDE.md
```

## Working Conventions
- One user story at a time — define, point, build, test, push, QA
- TDD where practical — write the test before or alongside the implementation
- Feature branches + PRs — no committing directly to main
- Each story should touch at least one test
- Commit message format: `type: short description` (e.g. `feat:`, `fix:`, `docs:`, `test:`)

## Reference
- Python terminal version: github.com/artswordgames/soligavant (reference for game logic/rules)
- SoloDark rules are a solo variant of ShadowDark — oracle, prompt tables, dungeon gen, core rules mods

## Healthcare Parallels (for learning context)
Draw these connections when building features — not for tooling/setup:
- Character sheet → patient record
- Session journal → clinical encounter notes
- Oracle / rules engine → clinical decision support logic
- User auth / saved campaigns → role-based access control
- Audit log → HIPAA audit trail
