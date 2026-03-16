# Workshop de Actualización — GitHub Copilot (1 hora)

> **Audiencia**: desarrolladores que asistieron al taller completo y necesitan ponerse al día con los cambios más recientes de GitHub Copilot.
> **Formato**: mínimas diapositivas, máximo tiempo hands-on.
> **App de ejemplo**: `sample-app/backend/TaskManager.Api` (ASP.NET Core 10 + EF Core In-Memory)

---

## ¿Por qué este refresher?

Desde el taller original han llegado varios cambios que afectan directamente a tu flujo diario:

- **`@workspace` ha desaparecido** → reemplazado por `#codebase`
- **Nuevas variables de contexto**: `#file`, `#selection`, `#terminalLastCommand`
- **Selección de código como contexto**: selecciona código en el editor → se referencia automáticamente en el chat al abrirlo
- **`/doc` eliminado del chat** → ahora: clic derecho → *Copilot* → *Generate Docs*
- **Plan mode es GA** (Generally Available): primer modo de planificación nativo, no un workaround

---

## Agenda

| Bloque | Hora | Actividad | Material |
|--------|------|-----------|----------|
| Novedades | 00:00 – 00:05 | Slides: qué ha cambiado | [slides/00-novedades.md](slides/00-novedades.md) |
| Lab 1 | 00:05 – 00:20 | Ask actualizado (`#codebase`, `#file`, selección como contexto) | [labs/01-ask-actualizado/README.md](labs/01-ask-actualizado/README.md) |
| Lab 2 | 00:20 – 00:35 | Plan mode (planifica primero, luego implementa) | [labs/02-plan-mode/README.md](labs/02-plan-mode/README.md) |
| Lab 3 | 00:35 – 00:50 | Agent/Build (nuevo endpoint `GET /api/tasks/stats`) | [labs/03-agent-build/README.md](labs/03-agent-build/README.md) |
| Cierre | 00:50 – 01:00 | Repaso + cheatsheet | [cheatsheet.md](cheatsheet.md) |

---

## Materiales

| Archivo | Descripción |
|---------|-------------|
| [slides/00-novedades.md](slides/00-novedades.md) | Diapositivas: antes/después, variables de contexto, modos |
| [labs/01-ask-actualizado/README.md](labs/01-ask-actualizado/README.md) | Lab 1: Ask con las nuevas referencias de contexto |
| [labs/02-plan-mode/README.md](labs/02-plan-mode/README.md) | Lab 2: Plan mode GA — planifica antes de tocar código |
| [labs/03-agent-build/README.md](labs/03-agent-build/README.md) | Lab 3: Agent construye un endpoint nuevo desde cero |
| [cheatsheet.md](cheatsheet.md) | Referencia rápida: árbol de decisión, variables, comandos |
| [trainer-notes.md](trainer-notes.md) | Guion minuto a minuto para el formador |

---

## Preparación antes de empezar

Completa estos pasos **antes** de que comience el taller:

### 1. Verificar que el proyecto compila

```powershell
cd sample-app/backend/TaskManager.Api
dotnet build
```

Debes ver `Build succeeded` sin errores ni warnings críticos.

### 2. Abrir VS Code en la carpeta correcta

```powershell
code sample-app/backend/TaskManager.Api
```

> Abre **sólo** la carpeta `TaskManager.Api`, no la raíz del repo. Así `#codebase` y los Smart Actions trabajan sobre el scope correcto.

### 3. Abrir Copilot Chat

- Atajo: `Ctrl+Alt+I`
- O: barra lateral izquierda → icono de Copilot Chat

Asegúrate de estar en modo **Ask** al empezar (selector en la parte inferior del chat).

### 4. Estado limpio de git

```powershell
git status
```

Debe mostrar `nothing to commit, working tree clean`.  
Si hay cambios pendientes del taller anterior:

```powershell
git add .
git stash
```

### 5. Verificar versión de la extensión Copilot

En VS Code: *Extensiones* → busca "GitHub Copilot" → versión ≥ 1.250.  
Asegúrate de estar autenticado con tu cuenta de GitHub (`Ctrl+Shift+P` → *GitHub Copilot: Sign In*).

---

## Estructura de carpetas

```
workshop-1h/
├── README.md                    ← este archivo
├── cheatsheet.md                ← referencia rápida para llevarte a casa
├── trainer-notes.md             ← guion del formador
├── slides/
│   └── 00-novedades.md
└── labs/
    ├── 01-ask-actualizado/
    │   └── README.md
    ├── 02-plan-mode/
    │   └── README.md
    └── 03-agent-build/
        └── README.md
```

---

[→ Empezar: Novedades](slides/00-novedades.md)
