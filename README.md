# FormacionIA — Formación de un día: IA para desarrolladores .NET y Angular

> Aprende a programar más rápido, con mejor documentación y código más seguro usando GitHub Copilot, OpenCode y SpecKit.

---

## Agenda del día

| Hora | Bloque | Herramienta |
|---|---|---|
| 09:00–09:30 | Intro: ¿Por qué IA en tu workflow? Anatomía del prompt perfecto | GitHub Copilot |
| 09:30–10:15 | **Lab 1 — Ask mode**: explorar y entender código con `@workspace`, `#file`, `/explain` | Copilot Ask |
| 10:15–10:30 | Descanso | |
| 10:30–11:15 | **Lab 2 — Edit mode**: refactor multi-archivo controlado | Copilot Edit |
| 11:15–12:00 | **Lab 3 — Agent mode**: añadir una feature completa desde cero | Copilot Agent |
| 12:00–13:00 | Comida | |
| 13:00–13:30 | **Demo — Plan mode**: diseña antes de codear | Copilot Plan |
| 13:30–14:30 | **Lab 4 — OpenCode**: agente IA en la terminal, Plan→Build, custom agents | OpenCode |
| 14:30–15:00 | **Demo — SpecKit**: desarrollo dirigido por especificaciones | SpecKit + Copilot |
| 15:00–15:15 | Descanso | |
| 15:15–15:45 | **Demo — Documentación**: `AGENTS.md`, plantillas `.md` con placeholders, XML docs | Copilot |
| 15:45–16:30 | **Demo — Código seguro**: code review de seguridad, license awareness | Copilot |
| 16:30–17:00 | Cierre, cheatsheet de prompts, Q&A | |

---

## Estructura del repositorio

```
FormacionIA/
├── README.md                    # Este archivo
├── PREREQUISITES.md             # Guía de instalación y configuración previa
├── resources.md                 # Links, herramientas, lectura recomendada
├── slides/                      # Diapositivas en Markdown (una por bloque)
├── sample-app/
│   ├── backend/                 # ASP.NET Core Web API — Task Manager
│   └── frontend/                # Angular app — Task Manager UI
├── labs/
│   ├── 01-ask-mode/             # Instrucciones y prompts del Lab 1
│   ├── 02-edit-mode/            # Instrucciones y prompts del Lab 2
│   ├── 03-agent-mode/           # Instrucciones y prompts del Lab 3
│   └── 04-opencode/             # Script de demo y lab de OpenCode
├── docs-templates/              # Plantillas de documentación con IA
│   ├── AGENTS.md                # Instrucciones Copilot a nivel de repositorio
│   ├── FEATURE_SPEC.md          # Plantilla de especificación con placeholders
│   └── .github/
│       └── pull_request_template.md
└── speckit-demo/
    └── README.md                # Walkthrough completo del flujo SpecKit
```

---

## Pre-requisitos

Antes del día de formación, asegurate de que tienes instalado todo lo descrito en [PREREQUISITES.md](./PREREQUISITES.md).

## Proyecto de práctica

Durante los labs trabajaremos sobre **TaskManager** — una API de gestión de tareas construida con ASP.NET Core + Angular. Tiene varios defectos intencionados que usaremos para practicar cada herramienta.

Ver `sample-app/` para el código fuente.
