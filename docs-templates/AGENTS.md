# AGENTS.md — TaskManager API

> Este archivo es leído por GitHub Copilot, OpenCode y otros agentes IA.
> Commiteado en el repositorio para que todo el equipo se beneficie del mismo contexto.

## Descripción del proyecto

**TaskManager.Api** es una API REST construida con ASP.NET Core 10 y EF Core (in-memory).
Gestiona proyectos, tareas y usuarios para un sistema de seguimiento de trabajo en equipo.

## Arquitectura

```
TaskManager.Api/
├── Controllers/       # Controladores REST (TasksController, ProjectsController, UsersController)
├── Models/            # Entidades del dominio (TaskItem, Project, User)
├── Data/              # DbContext con EF Core in-memory + seed data
└── Program.cs         # Configuración de la aplicación
```

**Patrón**: Controller → DbContext directo (sin capa de servicio en esta fase).  
**Persistencia**: EF Core in-memory — todos los datos se reinician al reiniciar la app.

## Comandos esenciales

```powershell
# Build
dotnet build

# Ejecutar (API en http://localhost:5000)
dotnet run

# Abrir Swagger UI
start http://localhost:5000/openapi/v1.json
```

## Convenciones de código

- Usa **`DateTimeOffset.UtcNow`** para todas las fechas, nunca `DateTime.Now`
- Los estados de tarea son constantes en `TaskStatus`: `Todo`, `InProgress`, `Done`
- Valida todos los inputs con **DataAnnotations** en los modelos
- Los controladores devuelven `IActionResult` — usa `Ok()`, `NotFound()`, `BadRequest()`, `CreatedAtAction()`
- Nombres de clases y métodos en **inglés**, comentarios XML en inglés
- Sin dependencias a Azure o servicios cloud externos

## Endpoints disponibles

| Método | Ruta | Descripción |
|---|---|---|
| GET | `/api/tasks` | Lista todas las tareas |
| GET | `/api/tasks/{id}` | Obtiene una tarea por ID |
| POST | `/api/tasks` | Crea una tarea nueva |
| PUT | `/api/tasks/{id}` | Actualiza una tarea |
| DELETE | `/api/tasks/{id}` | Elimina una tarea |
| GET | `/api/tasks/by-project/{projectId}` | Tareas de un proyecto |
| GET | `/api/projects` | Lista todos los proyectos |
| GET | `/api/projects/{id}` | Proyecto con sus tareas |
| POST | `/api/projects` | Crea un proyecto |
| DELETE | `/api/projects/{id}` | Elimina un proyecto |
| GET | `/api/users` | Lista todos los usuarios |
| GET | `/api/users/{id}` | Usuario con sus tareas asignadas |

## Modelos principales

```csharp
TaskItem { Id, Title, Description, Status, ProjectId, AssignedToUserId, CreatedAt, DueDate }
Project  { Id, Name, Description, CreatedAt, Tasks }
User     { Id, Name, Email, AssignedTasks }
```

## Problemas conocidos (a corregir en los labs)

- `DateTime.Now` en vez de `DateTimeOffset.UtcNow` en modelos y seed data
- Sin `DataAnnotations` de validación en los modelos
- Magic strings de estado en vez de constantes/enum
- Sin autenticación en endpoints destructivos (DELETE, PUT)
- CORS permisivo (`AllowAnyOrigin`) — no apto para producción

## Reglas para los agentes IA

- **No instales paquetes NuGet** sin preguntar al desarrollador
- **No cambies la interfaz de los endpoints** existentes sin confirmar
- **No elimines el seed data** de `TaskManagerContext.cs`
- Si añades un nuevo endpoint, sigue el patrón de los existentes
- Siempre verifica que `dotnet build` pasa después de tus cambios
