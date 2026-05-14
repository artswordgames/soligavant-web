# Dev Setup Reference
Quick reference for setting up a new Mac dev machine for this project.

---

## 1. Check / Install Homebrew
```
brew --version
```
If not installed: https://brew.sh (paste the curl command from the site)

---

## 2. Check / Install Git
```
git --version
```
Usually pre-installed on Mac via Xcode CLI tools. If not:
```
xcode-select --install
```

---

## 3. Install Docker Desktop
Download from: https://www.docker.com/products/docker-desktop
- Choose Intel or Apple Silicon version to match your Mac
- Install like a normal Mac app, launch it, look for whale in menu bar

Verify:
```
docker --version
docker run hello-world
```

If `docker` command not found after install:
```
sudo ln -sf /Applications/Docker.app/Contents/Resources/bin/docker /usr/local/bin/docker
echo 'export PATH="/Applications/Docker.app/Contents/Resources/bin:$PATH"' >> ~/.zshrc
source ~/.zshrc
```

---

## 4. Install .NET 8 SDK
DO NOT use Homebrew — incompatible with macOS Sequoia. Use Microsoft's script:
```
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 8.0
```

Add to PATH (must prepend to win over older .NET versions):
```
echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.zshrc
echo 'export PATH=$HOME/.dotnet:$HOME/.dotnet/tools:$PATH' >> ~/.zshrc
source ~/.zshrc
```

Verify:
```
dotnet --version   # should say 8.x.x
which dotnet       # should say /Users/<you>/.dotnet/dotnet
```

---

## 5. Check Node.js
```
node --version
```
If not installed:
```
brew install node
```

---

## 6. Install VS Code
Download from: https://code.visualstudio.com

Add CLI to PATH (do this inside VS Code):
- `Cmd+Shift+P` → "Shell Command: Install 'code' command in PATH"

Verify:
```
code --version
```

Install extensions (Cmd+Shift+X):
- C# Dev Kit (Microsoft)
- Docker (Microsoft)
- GitLens (GitKraken)
- Prettier (Prettier)
- ESLint (Microsoft)
- Playwright Test (Microsoft)

---

## 7. Set Up SSH Key for Personal GitHub
Generate a new key (one per machine — never copy private keys between machines):
```
ssh-keygen -t ed25519 -C "artswordgames@gmail.com" -f ~/.ssh/id_ed25519_personal
```
Hit Enter twice for no passphrase.

Print public key and copy it:
```
cat ~/.ssh/id_ed25519_personal.pub
```

Add to GitHub: Settings → SSH and GPG keys → New SSH key → Authentication → paste → Save
Name it something machine-specific (e.g. "MacBook 2020" or "iMac 2019")

Add host entry to ~/.ssh/config:
```
echo 'Host github-personal
  HostName github.com
  User git
  IdentityFile ~/.ssh/id_ed25519_personal
  AddKeysToAgent yes' >> ~/.ssh/config
```

Test connection:
```
ssh -T git@github-personal
```
Expected: "Hi artswordgames! You've successfully authenticated..."

---

## 8. Clone the Repo
```
mkdir -p ~/apps
cd ~/apps
git clone git@github-personal:artswordgames/soligavant-web.git
cd soligavant-web
```

Verify:
```
git log --oneline
code .
```

---

## 9. Run the Stack
```
docker compose up
```
API will be available at: http://localhost:5283
Swagger UI at: http://localhost:5283/swagger

---

## Notes
- Repo location: ~/apps/soligavant-web
- Never commit directly to main — always use a feature branch + PR
- Branch naming: feat/, fix/, setup/, chore/, docs/
- Commit format: type: short description (e.g. feat: add dice roller)
