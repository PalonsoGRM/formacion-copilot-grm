# Workshop — GitHub Copilot (1 hora)

> **App de ejemplo**: `sample-app/backend/TaskManager.Api` (ASP.NET Core 10 + EF Core In-Memory)

---

## Agenda

| Bloque | Hora | Actividad | Material |
|--------|------|-----------|----------|
| Novedades | 00:00 – 00:05 | Slides: qué ha cambiado | [slides/00-novedades.md](slides/00-novedades.md) |
| Lab 1 | 00:05 – 00:20 | Ask Mode (`#codebase`, `#file`, selección como contexto) | [labs/01-ask-mode/README.md](labs/01-ask-mode/README.md) |
| Lab 2 | 00:20 – 00:35 | Plan Mode (planifica primero, luego implementa) | [labs/02-plan-mode/README.md](labs/02-plan-mode/README.md) |
| Lab 3 | 00:35 – 00:50 | Agent Mode (nuevo endpoint `GET /api/tasks/stats`) | [labs/03-agent-mode/README.md](labs/03-agent-mode/README.md) |
| Lab 4 | 00:50 – 01:05 | Frontend Angular: bugs + feature nueva | [labs/04-frontend/README.md](labs/04-frontend/README.md) |
| Cierre | 01:05 – 01:15 | Repaso + cheatsheet | [cheatsheet.md](cheatsheet.md) |

**Labs extra** (si queda tiempo):

| Lab | Material |
|-----|----------|
| Lab 5 — Copilot Instructions y el poder del `.github` | [labs/05-copilot-instructions/README.md](labs/05-copilot-instructions/README.md) |
| Lab 6 — Custom agents y prompt files | [labs/06-custom-agents/README.md](labs/06-custom-agents/README.md) |
| Lab 7 — GitHub Copilot CLI: carpeta vacía → API funcionando | [labs/07-copilot-cli/README.md](labs/07-copilot-cli/README.md) |

---

## Setup rápido

```powershell
cd sample-app/backend/TaskManager.Api
dotnet build        # debe mostrar Build succeeded
git status          # debe estar limpio
```

Abre VS Code en la carpeta `TaskManager.Api` (no en la raíz del repo) y arranca Copilot Chat con `Ctrl+Alt+I`.

---

[← Copilot en el IDE](../copilot-ide-intro/README.md) | [→ Lab 1: Ask Mode](labs/01-ask-mode/README.md)
