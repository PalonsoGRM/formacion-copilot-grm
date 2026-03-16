# FormacionIA — Sesión Formativa IA

> **Fechas**: 23 y 25 de marzo 2026 · **Horario**: 08:30 – 14:00

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
├── sample-app/
│   ├── backend/                 # ASP.NET Core Web API — Task Manager (con defectos intencionados)
│   └── frontend/                # Angular app — Task Manager UI
├── workshop-1h/                 # 🆕 Workshop práctico (bloque de Pablo — 60 min)
│   ├── README.md                # Agenda y setup del workshop
│   ├── slides/                  # Diapositivas: novedades de Copilot
│   ├── labs/                    # Labs de Ask, Plan y Agent mode
│   ├── cheatsheet.md            # Referencia rápida para llevarse a casa
│   └── trainer-notes.md        # Guion del formador
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
