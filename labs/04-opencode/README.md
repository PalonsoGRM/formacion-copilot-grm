# Lab 4 — OpenCode: Agente IA en la terminal

**Duración**: 30 minutos  
**Herramienta**: OpenCode  
**Terminal**: PowerShell o Windows Terminal

---

## Objetivo

Explorar OpenCode como alternativa a Copilot: un agente IA que vive en la terminal, independiente del IDE. Practicar el flujo Plan → Build y crear un agente custom en Markdown.

---

## Preparación

Verifica que tienes OpenCode instalado:

```powershell
opencode --version
```

Si no, instálalo:
```powershell
npm install -g opencode-ai
```

---

## Ejercicio 1 — Inicializar OpenCode en el proyecto (5 min)

```powershell
cd C:\Users\palonso\source\repos\FormacionIA\sample-app\backend\TaskManager.Api
opencode
```

La primera vez te pedirá el proveedor de modelos. Selecciona **GitHub Copilot**.

Una vez dentro del TUI, ejecuta:

```
/init
```

OpenCode analizará el proyecto y generará un archivo `AGENTS.md` con el contexto del repositorio. Ábrelo en tu editor y observa lo que generó.

---

## Ejercicio 2 — Plan mode → Build mode (15 min)

### Paso 1: Entrar en Plan mode

Pulsa **Tab** — el indicador en la parte superior debe cambiar a "Plan".

En Plan mode, OpenCode solo lee. No escribe nada.

### Paso 2: Planificar una tarea

```
Quiero añadir paginación al endpoint GET /api/tasks.
El endpoint debe aceptar parámetros ?page=1&pageSize=10 y devolver
un objeto con las tareas de esa página y metadatos de paginación
(totalCount, totalPages, currentPage).
Analiza el código actual y dime qué archivos necesitarías modificar
y qué pasos seguirías. No hagas ningún cambio todavía.
```

Lee el plan que genera. ¿Tiene sentido? ¿Hay algo que cambiarías?

### Paso 3: Cambiar a Build mode

Pulsa **Tab** de nuevo — el indicador cambia a "Build".

```
Implementa el plan que acabas de describir para añadir paginación
al endpoint GET /api/tasks. Sigue los pasos que planificaste.
```

### Paso 4: Verificar

```powershell
dotnet build
```

### Paso 5: Deshacer (opcional — para mostrar la potencia de /undo)

```
/undo
```

Observa cómo revierte todos los cambios de archivos y elimina el prompt del contexto.

---

## Ejercicio 3 — Agente custom de documentación (10 min)

### Crear el agente

Crea la carpeta y el archivo:

```powershell
mkdir .opencode\agents
```

Crea el archivo `.opencode/agents/doc-writer.md`:

```markdown
---
model: github-copilot/claude-sonnet-4.6
tools:
  - read
  - glob
  - grep
  - edit
---

Eres un experto en documentación técnica para APIs .NET.
Cuando se te pide documentar código:
1. Lee el archivo indicado completo
2. Genera comentarios XML (///) para todos los métodos y clases públicos
3. Sé conciso: una línea para <summary>, parámetros y return value
4. Usa terminología en inglés para los comentarios XML (convención .NET)
5. No modifiques la lógica del código, solo añade documentación
```

### Usar el agente

En OpenCode:

```
@doc-writer Documenta todos los métodos públicos de Controllers/TasksController.cs
con comentarios XML completos.
```

---

## Comandos útiles de OpenCode

| Comando | Qué hace |
|---|---|
| `/init` | Genera AGENTS.md del proyecto |
| `/undo` | Revierte cambios y elimina el prompt del contexto |
| `/redo` | Restaura los cambios revertidos |
| `/share` | Genera URL pública de la sesión |
| `Tab` | Alterna entre Plan mode y Build mode |
| `@nombre` | Invoca un agente custom |
| `@explore` | Subagente rápido para buscar archivos |

---

## Puntos clave del lab

- OpenCode funciona en **cualquier terminal**, sin IDE
- **Plan mode** (Tab) es fundamental: te muestra la intención antes de actuar
- Los **agentes custom en Markdown** son la herramienta más potente: un agente por responsabilidad
- **`/undo`** respaldado por Git — el safety net definitivo
- Compatible con múltiples modelos: si mañana hay uno mejor, cambias una línea
