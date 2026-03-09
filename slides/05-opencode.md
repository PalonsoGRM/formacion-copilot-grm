# Slide deck: OpenCode — El agente IA que vive en tu terminal

---

## ¿Qué es OpenCode?

- Agente IA **open source** que corre en la terminal
- Independiente del IDE — funciona en cualquier proyecto
- Compatible con múltiples modelos: GitHub Copilot, OpenAI, Anthropic, Gemini, Ollama local...
- Escrito por Anomaly (https://opencode.ai)

```
# Instalación
npm install -g opencode-ai

# Uso
cd mi-proyecto
opencode
```

---

## ¿Por qué OpenCode además de Copilot?

| Aspecto | GitHub Copilot | OpenCode |
|---|---|---|
| IDE | VS / VS Code (extensión) | Terminal — cualquier editor |
| Modelos | Modelos de GitHub | Cualquier proveedor + local |
| Control de permisos | Por configuración del IDE | Por agente, por comando, por glob |
| Undo/redo | Ctrl+Z del editor | `/undo` atómico (Git-backed) |
| Agentes custom | Custom instructions | Agentes `.md` con herramientas propias |
| Compartir sesión | No | `/share` genera URL pública |

---

## Conceptos clave de OpenCode

### Plan mode ↔ Build mode (toggle con Tab)

```
Plan mode  → lee y analiza, no escribe nada
Build mode → escribe código, ejecuta comandos
```

**Flujo recomendado**: empieza en Plan, revisa, cambia a Build.

### AGENTS.md
Archivo comprometido en el repositorio que le dice al agente:
- Arquitectura del proyecto
- Convenciones de código
- Comandos de build/test
- Restricciones y reglas

```markdown
# AGENTS.md
## Architecture
This is an ASP.NET Core 8 Web API using EF Core in-memory...
## Build
Run: dotnet build TaskManager.Api
## Test
Run: dotnet test
## Conventions
- Use DateTimeOffset.UtcNow, never DateTime.Now
- Validate all inputs with FluentValidation
```

---

## Agentes custom en Markdown

Crea un agente especializado en `.opencode/agents/security-reviewer.md`:

```markdown
---
model: github-copilot/claude-sonnet-4.6
tools:
  - read
  - glob
  - grep
---

Eres un revisor de seguridad especializado en APIs .NET.
Cuando analices código, busca:
- Inputs sin validar
- SQL injection
- Secrets en el código
- Endpoints sin autenticación
Solo lees, nunca modificas archivos.
```

Invocación: `@security-reviewer revisa el controlador de usuarios`

---

## Undo/redo con respaldo en Git

```
/undo  → revierte los cambios de archivos Y elimina el prompt del contexto
/redo  → restaura los cambios
/share → genera URL pública de la sesión para compartir con el equipo
```

---

## Demo en vivo

1. `cd sample-app/backend && opencode`
2. Ejecutar `/init` — genera `AGENTS.md` del proyecto automáticamente
3. Demostrar toggle Plan mode → Build mode (Tab)
4. Prompt: "Añade un endpoint `GET /api/tasks/overdue` que devuelva tareas con fecha de vencimiento pasada"
5. Observar Plan → aprobar → Build
6. `/undo` para revertir
7. `/share` para mostrar la sesión

---

## Ahora tú — Lab 4

Ver instrucciones en `labs/04-opencode/README.md`

Tiempo: **30 minutos**
