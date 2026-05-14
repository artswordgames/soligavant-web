# Dev Q&A — Running Study Reference

---

## Session 1 — Environment Setup / Sprint 0

**Q: What is PATH, and why does it matter?**
When you type a command in the terminal, the shell doesn't search your whole computer — it only looks in a specific list of directories. That list is $PATH. If a tool's binary isn't in one of those directories, the command doesn't exist as far as your shell is concerned.

**Q: What is the difference between `git add` and `git commit`?**
`git add` stages a file — it says "I want to include this in my next commit."
`git commit` takes everything staged and saves it as a permanent snapshot in git history.
The staging area exists so you can be deliberate about what goes into each commit.

**Q: What is Docker and why use it?**
Docker lets you package your app and its environment into a container. The app, the database, the runtime — all bundled together. On any machine with Docker installed, it runs the same way. One `docker compose up` starts your whole local stack.

**Q: What is a solution file (.sln)?**
A container for projects. It doesn't hold config — it lists which projects belong together. Lets you build or test everything at once with a single command at the root. VS Code uses it to understand project relationships.

**Q: What is the difference between a linter and a formatter?**
Linter (ESLint): checks code quality — unused variables, potential bugs, bad patterns. Can catch real bugs.
Formatter (Prettier): purely cosmetic — indentation, spacing, quotes, line length. Makes code consistent. Cannot catch bugs.
You run both. They do different jobs.

**Q: What is an SSH key and why use it instead of a password?**
SSH key pairs have two parts: a private key (stays on your machine, never shared) and a public key (safe to share — you give it to GitHub). When you push, SSH proves your identity using the private key without ever transmitting it. GitHub matches it against your public key on file.

**Q: What is the difference between an Authentication key and a Signing key in GitHub?**
Authentication key: proves your identity when connecting — what git push/pull uses.
Signing key: cryptographically signs your commits so GitHub can verify you wrote them.
Some shops require signing keys so every commit has a verified author.

**Q: What is CORS and why does it matter?**
Cross-Origin Resource Sharing. A browser security rule: a web page can only call APIs on the same origin (domain + port) it was loaded from. Different port = different origin = browser blocks it.
Example: React on port 5173 calling our API on port 5283 = CORS error unless the API explicitly allows it.
`curl` bypasses CORS because it's not a browser.

**Q: What does `depends_on` do in docker-compose.yml?**
Controls start order. The API service won't start until the db service has started. It does not guarantee the database is fully ready to accept connections — just that the container is running.

**Q: What is a multi-stage Docker build?**
A Dockerfile with two stages: a build stage (uses the full SDK to compile the app) and a runtime stage (copies only the compiled output into a smaller image). Result: a smaller, leaner container that doesn't include the build tools — only what's needed to run.

**Q: What is story pointing and why does the conversation matter more than the number?**
Story points are relative estimates of complexity and effort. The number itself matters less than the conversation it forces: "I said 3, you said 5 — what are you seeing that I'm not?" That discussion surfaces hidden complexity and shared understanding before work starts.

**Q: Why not remove .NET 3.1 before installing .NET 8?**
You don't know what else on the machine depends on it. Multiple .NET versions coexist by design — each project specifies which version it targets. Remove old runtimes only after confirming nothing depends on them.

---

*Add new questions at the bottom of each session.*
