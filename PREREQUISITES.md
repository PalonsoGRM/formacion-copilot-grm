# Pre-requisitos — FormacionIA

Completa esta guía **antes del día de formación**. Tiempo estimado: 20-30 minutos.

---

## 1. GitHub Copilot

Ya tienes la extensión instalada con licencia Business. Verifica que funciona:

- **Visual Studio 2022**: Menu → Extensions → Manage Extensions → busca "GitHub Copilot" → debe aparecer como instalado y activo.
- **VS Code**: Panel de extensiones (`Ctrl+Shift+X`) → busca "GitHub Copilot" → activo. Deberías ver el icono de Copilot en la barra de estado (abajo a la derecha).

Si el icono aparece con una X, haz clic en él e inicia sesión con tu cuenta de GitHub corporativa.

---

## 2. .NET 8 SDK

```powershell
dotnet --version
# Debe mostrar 8.x.x o superior
```

Si no está instalado:

```powershell
winget install Microsoft.DotNet.SDK.8
```

---

## 3. Node.js 20 LTS (necesario para Angular)

```powershell
node --version
# Debe mostrar v20.x.x o superior
```

Si no está instalado:

```powershell
winget install OpenJS.NodeJS.LTS
```

Cierra y abre la terminal después de instalar.

---

## 4. Angular CLI

```powershell
ng version
# Debe mostrar Angular CLI: 17.x o superior
```

Si no está instalado:

```powershell
npm install -g @angular/cli
```

---

## 5. GitHub Copilot CLI

GitHub Copilot CLI es una extensión de la GitHub CLI (`gh`) que te permite usar Copilot directamente desde la terminal para sugerir y explicar comandos de shell.

### 5.1 GitHub CLI (`gh`)

```powershell
gh --version
# Debe mostrar gh version 2.x.x o superior
```

Si no está instalado:

```powershell
winget install GitHub.cli
```

Autentica con tu cuenta corporativa:

```powershell
gh auth login
```

### 5.2 Extensión Copilot CLI

```powershell
gh extension install github/gh-copilot
gh copilot --version
```

### Comandos principales

```powershell
# Sugerir un comando de shell
gh copilot suggest "listar archivos modificados en los últimos 7 días"

# Explicar un comando
gh copilot explain "git rebase -i HEAD~3"
```

---

## 6. SpecKit — specify CLI

SpecKit necesita Python 3.11+ y `uv` (gestor de paquetes Python moderno).

### 6.1 Python 3.11+

```powershell
python --version
# Debe mostrar 3.11.x o superior
```

Si no está instalado:

```powershell
winget install Python.Python.3.11
```

### 6.2 uv

```powershell
winget install astral-sh.uv
# O con pip:
pip install uv
```

Verifica:

```powershell
uv --version
```

### 6.3 specify CLI

```powershell
uv tool install specify-cli --from git+https://github.com/github/spec-kit.git
specify --version
```

Si hay problemas de red corporativa (proxy/SSL):

```powershell
uv tool install specify-cli --from git+https://github.com/github/spec-kit.git --index-url https://pypi.org/simple/ 
```

---

## 7. Git

```powershell
git --version
```

Si no está instalado:

```powershell
winget install Git.Git
```

---

## Verificación final

Ejecuta este checklist en PowerShell:

```powershell
Write-Host "--- Verificacion FormacionIA ---"
dotnet --version
node --version
ng version --skip-git 2>$null | Select-String "Angular CLI"
gh copilot --version
python --version
uv --version
specify --version
git --version
Write-Host "--- OK si todos los comandos devolvieron version ---"
```

Si algún comando falla, consulta la sección correspondiente de esta guía o contacta al formador antes del día de sesión.

---

## Configuracion recomendada de VS Code

Instala estas extensiones si aún no las tienes:

```
GitHub Copilot
GitHub Copilot Chat
C# Dev Kit
Angular Language Service
GitLens
```

En VS Code, abre la paleta de comandos (`Ctrl+Shift+P`) y ejecuta:

```
GitHub Copilot: Sign In
```

Asegúrate de que el modo **Agent** está disponible en el panel de Copilot Chat (icono de agente en el selector de modo, junto al campo de texto).

---

[→ Siguiente: Copilot en el IDE](./copilot-ide-intro/README.md)
