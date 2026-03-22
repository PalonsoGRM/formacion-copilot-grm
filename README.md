# FormacionIA — Sesión Formativa IA

<img width="546" height="268" alt="ROMEU" src="https://github.com/user-attachments/assets/9e734aa8-0dc3-47e7-8e26-87a50e099e2b" />


**Fechas**: 23 y 25 de marzo 2026 · **Horario**: 08:30 – 14:00

---

## Agenda

| Hora | Bloque | Responsable |
|---|---|---|
| 08:30 – 08:45 | Apertura y bienvenida | |
| 08:45 – 08:55 | **Introducción** (10 min): "La IA nos ha hecho JAQUE" — impacto, estadísticas de uso | Todos |
| 08:55 – 09:15 | **Fundamentos de IA** (20 min): LLM, Tokens, Context Window, modelos en Copilot Empresarial | Derek |
| 09:15 – 10:10 | **GitHub Copilot en el IDE** (45 min): herramienta, funcionalidades básicas, modos Ask/Plan/Agent | Todos |
| 10:10 – 10:40 | ☕ Descanso (30 min) | |
| 10:40 – 11:40 | **Workshop práctico** (60 min): ejercicio completo con los tres modos sobre app con fallos intencionados | Pablo |
| 11:40 – 12:25 | **Fundamentos Avanzados** (45 min): Custom Agents, ficheros `.md`, SpecKit / OpenSpec | |
| 12:25 – 13:25 | **Mejoras para el Developer** (60 min): nueva tabla tradicional vs IA, generación de tests, comparativa tiempos | Jero / Edu |
| 13:25 – 14:00 | **Foro abierto** — Preguntas y respuestas | Todos |

---

## Estructura del repositorio

```
FormacionIA/
├── README.md                    # Este archivo
├── PREREQUISITES.md             # Guía de instalación y configuración previa
├── resources.md                 # Links, herramientas, lectura recomendada
├── schedule.txt                 # Guion detallado de la sesión
├── .github/                     # Configuración de GitHub Copilot y automatización
│   ├── copilot-instructions.md  # Instrucciones globales de Copilot para este repo
│   ├── pull_request_template.md # Plantilla de PR lista para usar
│   ├── agents/                  # 🤖 Agentes personalizados (Lab 06)
│   │   ├── revisor.agent.md     # Revisor de código con estándares del equipo
│   │   ├── planificador.agent.md# Planificador de features con handoffs
│   │   └── tester.agent.md      # Especialista en tests xUnit + Moq
│   └── prompts/                 # 💬 Prompt files / slash commands (Lab 06)
│       └── nuevo-endpoint.prompt.md # /nuevo-endpoint — scaffold de endpoint
├── sample-app/
│   ├── backend/                 # ASP.NET Core Web API — Task Manager (con defectos intencionados)
│   └── frontend/                # Angular app — Task Manager UI
└── workshop-1h/                 # Workshop práctico (bloque de Pablo — ~1h 15min)
    ├── README.md                # Agenda y setup del workshop
    ├── cheatsheet.md            # Referencia rápida para llevarse a casa
    ├── trainer-notes.md         # Guion del formador
    ├── slides/
    │   └── 00-novedades.md      # Diapositivas: novedades de Copilot
    └── labs/
        ├── 01-ask-actualizado/  # Lab 1: Ask con #codebase, #file, selección
        ├── 02-plan-mode/        # Lab 2: Plan mode GA
        ├── 03-agent-build/      # Lab 3: Agent construye endpoint desde cero
        ├── 04-frontend/         # Lab 4: Angular — bugs + feature nueva
        ├── 05-copilot-instructions/ # ⭐ Extra: copilot-instructions.md + poder del .github
        ├── 06-custom-agents/    # ⭐ Extra: agentes y prompt files personalizados
        └── 07-copilot-cli/      # ⭐ Extra: CLI — carpeta vacía → API funcionando sin IDE
```

---

## Pre-requisitos

Antes del día de formación, asegurate de que tienes instalado todo lo descrito en [PREREQUISITES.md](./PREREQUISITES.md).

## Proyecto de práctica

Durante los labs trabajaremos sobre **TaskManager** — una API de gestión de tareas construida con ASP.NET Core + Angular. Tiene varios defectos intencionados que usaremos para practicar cada herramienta.

Ver `sample-app/` para el código fuente.

---

## Guía de contenidos

Sigue este orden durante la sesión:

| Paso | Material | Descripción |
|------|----------|-------------|
| 0 | [Pre-requisitos](./PREREQUISITES.md) | Instalación y configuración previa |
| 1 | [Copilot en el IDE](./copilot-ide-intro/README.md) | Fundamentos: ghost text, modos Ask/Plan/Agent |
| 2 | [Lab 1 — Ask Mode](./workshop-1h/labs/01-ask-mode/README.md) | `#codebase`, `#file`, selección como contexto |
| 3 | [Lab 2 — Plan Mode](./workshop-1h/labs/02-plan-mode/README.md) | Planifica antes de tocar código |
| 4 | [Lab 3 — Agent Mode](./workshop-1h/labs/03-agent-mode/README.md) | Construye un endpoint nuevo desde cero |
| 5 | [Lab 4 — Frontend](./workshop-1h/labs/04-frontend/README.md) | Bugs y nueva feature en Angular |
| 6 | [Lab 5 — Copilot Instructions](./workshop-1h/labs/05-copilot-instructions/README.md) | `.github/copilot-instructions.md` y el poder del `.github` |
| 7 | [Lab 6 — Custom Agents](./workshop-1h/labs/06-custom-agents/README.md) | Tus propios agentes y prompt files |
| 8 | [Lab 7 — Copilot CLI](./workshop-1h/labs/07-copilot-cli/README.md) | Carpeta vacía → API funcionando desde el terminal |
