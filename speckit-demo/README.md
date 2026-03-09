# SpecKit Demo — Spec-Driven Development con GitHub Copilot

**Duración**: 30 minutos  
**Herramienta**: SpecKit + GitHub Copilot Agent mode  
**Repo**: https://github.com/github/spec-kit

---

## ¿Qué vamos a hacer?

Añadir un sistema de **etiquetas (tags)** al TaskManager usando el flujo completo de SpecKit:

```
specify init → /speckit.constitution → /speckit.specify → /speckit.clarify
             → /speckit.plan → /speckit.tasks → /speckit.implement
```

Todo sin salir de VS Code, usando Copilot como el agente ejecutor.

---

## Pre-requisitos

```powershell
# Verifica que tienes specify instalado
specify --version

# Si no:
uv tool install specify-cli --from git+https://github.com/github/spec-kit.git
```

---

## Paso 1 — Inicializar SpecKit en el proyecto

```powershell
cd C:\Users\palonso\source\repos\FormacionIA\sample-app\backend\TaskManager.Api
specify init . --here --ai copilot --script ps
```

SpecKit creará la carpeta `.specify/` con:
- `memory/constitution.md` — principios del proyecto
- `templates/` — plantillas de spec, plan y tasks
- Comandos slash disponibles en Copilot Agent: `/speckit.*`

Abre VS Code en esta carpeta:
```powershell
code .
```

Verifica en Copilot Chat (modo Agent) que aparecen los comandos `/speckit.*`.

---

## Paso 2 — Principios del proyecto (`/speckit.constitution`)

En Copilot Chat (modo Agent):

```
/speckit.constitution
Define los principios de desarrollo para TaskManager.Api:
- Código limpio y legible como prioridad
- Todos los inputs deben validarse con DataAnnotations
- Fechas siempre con DateTimeOffset.UtcNow
- Sin magic strings: usa constantes o enums
- Todos los endpoints públicos deben tener documentación XML
- Tests unitarios para la lógica de negocio
- Sin dependencias a servicios cloud externos
```

Esto crea `.specify/memory/constitution.md` — un documento que Copilot leerá en cada paso posterior.

---

## Paso 3 — Especificar la feature (`/speckit.specify`)

```
/speckit.specify
Quiero añadir un sistema de etiquetas (tags) a las tareas del TaskManager.

Los usuarios pueden:
- Crear etiquetas con nombre y color (hexadecimal)
- Asignar múltiples etiquetas a una tarea
- Filtrar tareas por etiqueta
- Ver las etiquetas de cada tarea en la lista

Las etiquetas son globales (no pertenecen a un proyecto específico).
No hay login ni permisos: cualquiera puede crear y asignar etiquetas.
```

SpecKit crea:
- Una rama nueva (e.g., `001-tags-system`)
- `.specify/specs/001-tags-system/spec.md`

Abre `spec.md` y revísalo. ¿Capturó bien los requisitos?

---

## Paso 4 — Clarificar ambigüedades (`/speckit.clarify`)

```
/speckit.clarify
```

Copilot hará preguntas sobre puntos ambiguos, por ejemplo:
- ¿Cuántas etiquetas puede tener una tarea?
- ¿Se pueden eliminar etiquetas que están en uso?
- ¿El filtro por etiqueta es AND u OR cuando se filtran por varias?

Responde las preguntas. Esto actualiza `spec.md` con las aclaraciones.

---

## Paso 5 — Plan técnico (`/speckit.plan`)

```
/speckit.plan
Usa el stack existente:
- ASP.NET Core 10 con EF Core in-memory
- Relación muchos-a-muchos entre TaskItem y Tag usando tabla de unión
- Nuevos endpoints REST en un TagsController
- Endpoint de filtrado en TasksController: GET /api/tasks?tagId=X
- Sin cambiar la estructura de los endpoints existentes
```

SpecKit genera:
- `.specify/specs/001-tags-system/plan.md` — arquitectura técnica
- `.specify/specs/001-tags-system/data-model.md` — modelo de datos
- `.specify/specs/001-tags-system/research.md` — notas técnicas

Revisa `plan.md`. Valida que el stack es el correcto y que no añade dependencias que no quieras.

---

## Paso 6 — Lista de tareas (`/speckit.tasks`)

```
/speckit.tasks
```

Genera `.specify/specs/001-tags-system/tasks.md` con:
- Tareas ordenadas por dependencias
- Marcadores `[P]` para tareas que pueden ejecutarse en paralelo
- Rutas de archivo exactas para cada tarea

Revisa el archivo. ¿Tiene el orden correcto? ¿Falta algún paso?

---

## Paso 7 — Implementación (`/speckit.implement`)

```
/speckit.implement
```

Copilot Agent ejecuta todas las tareas en orden:
1. Crea el modelo `Tag` y la tabla de unión `TaskTag`
2. Actualiza `TaskManagerContext` con los nuevos DbSets
3. Crea `TagsController` con CRUD completo
4. Actualiza `TasksController` para soportar filtrado por tag
5. Actualiza el seed data con tags de ejemplo
6. Verifica que `dotnet build` pasa

Observa el proceso. Copilot va marcando tareas como completadas en `tasks.md`.

---

## Verificar el resultado

```powershell
dotnet build
dotnet run
```

Prueba los nuevos endpoints:
```powershell
# Obtener todas las etiquetas
curl http://localhost:5000/api/tags

# Filtrar tareas por etiqueta
curl http://localhost:5000/api/tasks?tagId=1
```

---

## ¿Qué aprendimos?

| Sin SpecKit | Con SpecKit |
|---|---|
| Prompt → código → más prompts → inconsistencias | Spec → plan → tareas → código coherente |
| La IA asume lo que no está claro | Preguntas explícitas antes de implementar |
| Difícil saber qué falta | Checklist de criterios de aceptación |
| Cada desarrollador entiende la feature diferente | La spec es el contrato compartido |

---

## Recursos

- Repo: https://github.com/github/spec-kit
- Docs: https://github.github.io/spec-kit/
- Walkthrough ASP.NET brownfield: https://github.com/mnriem/spec-kit-aspnet-brownfield-demo
- Video overview: https://www.youtube.com/watch?v=a9eR1xsfvHg
