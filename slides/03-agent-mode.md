# Slide deck: Agent Mode — Autonomía para tareas complejas

---

## ¿Qué es Agent mode?

- Copilot actúa de forma **autónoma**: decide qué leer, qué editar, qué comandos ejecutar
- Puede correr el terminal (con tu aprobación)
- Se auto-corrige si encuentra errores
- Un prompt → muchos pasos

---

## El flujo de Agent mode

```
Tú: "Añade autenticación JWT con middleware y tests"
         ↓
Copilot lee estructura del proyecto
         ↓
Propone plan de archivos a crear/modificar
         ↓
Ejecuta pasos: crea archivos, modifica existentes
         ↓
Detecta error de compilación → se corrige solo
         ↓
Ejecuta dotnet build / dotnet test
         ↓
Resultado final con resumen de cambios
```

---

## Cuándo usar Agent

| Situación | Ejemplo |
|---|---|
| Feature completa nueva | "Añade paginación a todos los endpoints GET" |
| Refactor amplio | "Migra la persistencia de in-memory a SQLite" |
| Scaffolding | "Crea un módulo Angular completo para la gestión de proyectos" |
| Setup inicial | "Añade Swagger, logging estructurado y health checks a la API" |

---

## Model Context Protocol (MCP)

Agent mode puede conectarse a **herramientas externas** via MCP:

```
Base de datos → Copilot puede leer esquemas reales
GitHub → puede leer issues, PRs, crear branches
File system → acceso a archivos fuera del workspace
APIs externas → documentación en vivo
```

En el lab veremos cómo conectar el MCP de GitHub para que Copilot lea el issue y lo implemente directamente.

---

## Precauciones con Agent mode

- Revisa los comandos de terminal antes de aprobarlos
- Agent puede tocar más archivos de los que esperas — comprueba el diff
- Haz **commit antes** de lanzar un agent task importante
- Si algo sale mal: `Ctrl+Z` o `git checkout .`

---

## Demo en vivo

**Tarea**: "Reemplaza los magic strings de estado de las tareas por un enum `TaskStatus`, actualiza todos los usos en la API y regenera la documentación Swagger."

1. Copilot Chat → modo **Agent**
2. Prompt completo con restricciones
3. Observar cómo Copilot navega el proyecto
4. Aprobar comandos de terminal
5. Revisar resultado final

---

## Ahora tú — Lab 3

Ver instrucciones en `labs/03-agent-mode/README.md`

Tiempo: **30 minutos**
