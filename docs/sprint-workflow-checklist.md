# Sprint Workflow Checklist

## 1. Story Setup (GitHub)
- [ ] Create GitHub Issue (title, user story, acceptance criteria, points)
- [ ] Add issue to GitHub Projects board
- [ ] Move card to In Progress

## 2. Start Work (Terminal)
- [ ] `git checkout main` — make sure you're on main
- [ ] `git pull` — get latest from remote
- [ ] `git checkout -b type/short-description` — create feature branch
  - Branch prefixes: `feat/`, `fix/`, `test/`, `docs/`, `chore/`, `setup/`

## 3. Build It (VS Code + Terminal)
- [ ] Write the test first (TDD — it should fail)
- [ ] Write the code to make it pass
- [ ] `dotnet test` — confirm green locally
- [ ] `docker compose up` — confirm stack still runs

## 4. Commit (Terminal)
- [ ] `git status` — check what changed before staging
- [ ] `git add <specific files>` — stage deliberately, not blindly
- [ ] `git commit -m "type: short description"` — commit message format:
  - `feat:` new feature
  - `fix:` bug fix
  - `test:` adding tests
  - `docs:` documentation
  - `chore:` cleanup, config
  - `ci:` pipeline changes

## 5. Push + PR (Terminal → GitHub)
- [ ] `git push origin branch-name`
- [ ] Open PR on GitHub (banner or Pull Requests tab)
- [ ] Add title and description
- [ ] Add `Related to #X` or `Closes #X` in description
- [ ] Wait for CI — must be green before merging

## 6. Review (GitHub)
- [ ] Click Files Changed tab — review the diff
- [ ] Leave a comment if anything needs fixing
- [ ] Fix on branch if needed, push again, wait for CI

## 7. Merge (GitHub)
- [ ] Squash and merge
- [ ] Delete the branch
- [ ] Confirm PR is linked to issue

## 8. Sync Locals (Terminal — both machines)
- [ ] `git checkout main`
- [ ] `git pull`
- [ ] `git log --oneline` — confirm history looks right

## 9. Close Out (GitHub)
- [ ] Move GitHub Projects card to Done
- [ ] Confirm issue is closed
- [ ] Update dev-qa.md with any new questions from the session

---

## Quick Reference

| Command | What it does |
|---|---|
| `git status` | Show what's changed locally |
| `git branch` | Show current branch |
| `git log --oneline` | Show commit history |
| `git checkout main` | Switch to main |
| `git checkout -b name` | Create and switch to new branch |
| `git pull` | Sync local with remote |
| `git add <file>` | Stage a file |
| `git commit -m "msg"` | Commit staged files |
| `git push origin name` | Push branch to GitHub |
| `git restore <file>` | Discard local changes to a file |
| `git reset --soft HEAD~1` | Undo last commit, keep changes staged |
| `dotnet test` | Run all xUnit tests |
| `dotnet build` | Build the solution |
| `docker compose up` | Start full local stack |
| `docker compose down` | Stop full local stack |
