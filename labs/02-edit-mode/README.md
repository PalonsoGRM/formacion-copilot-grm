# Lab 2 — Edit Mode: Refactor multi-archivo controlado

**Duración**: 30 minutos  
**Herramienta**: GitHub Copilot Chat — modo **Edit**  
**IDE**: Visual Studio Code

---

## Objetivo

Usar Edit mode para corregir un patrón obsoleto (`DateTime.Now`) por el correcto (`DateTimeOffset.UtcNow`) en varios archivos a la vez, revisando cada cambio antes de aceptarlo.

---

## Preparación

1. Abre la carpeta `sample-app/backend/TaskManager.Api` en VS Code
2. Abre Copilot Chat y cambia al modo **Edit** (desplegable junto al campo de texto → "Edit")
3. Asegúrate de que el proyecto compila antes de empezar: `dotnet build`

---

## Contexto: ¿Por qué este cambio importa?

`DateTime.Now` devuelve la hora local del servidor — si el servidor está en un timezone diferente al usuario, las fechas quedan mal. `DateTimeOffset.UtcNow` devuelve siempre UTC con información de offset, lo que es correcto para APIs.

---

## Ejercicio 1 — Refactor de fechas (15 min)

### Paso 1: Definir el working set

En el panel de Edit mode, añade estos archivos (botón "+" o arrastrándolos desde el explorador):
- `Models/TaskItem.cs`
- `Models/Project.cs`
- `Data/TaskManagerContext.cs`
- `Controllers/TasksController.cs`
- `Controllers/ProjectsController.cs`

### Paso 2: Escribir el prompt

```
Reemplaza todos los usos de DateTime.Now por DateTimeOffset.UtcNow
en todos los archivos del working set.

Actualiza también los tipos de las propiedades de fecha en los modelos:
- TaskItem.CreatedAt y DueDate deben ser DateTimeOffset? y DateTimeOffset respectivamente
- Project.CreatedAt debe ser DateTimeOffset

No modifiques ninguna otra lógica ni añadas funcionalidad nueva.
```

### Paso 3: Revisar los diffs

- Lee cada cambio propuesto archivo por archivo
- Acepta los que son correctos, descarta los que no lo son
- Presta atención: ¿Copilot cambió algo que no debía?

### Paso 4: Verificar

```powershell
dotnet build
```

Debe compilar sin errores.

---

## Ejercicio 2 — Magic strings a constantes (15 min)

El proyecto usa `"todo"`, `"in-progress"` y `"done"` como strings directos. Vamos a centralizarlos.

### Working set
- `Models/TaskItem.cs`
- `Data/TaskManagerContext.cs`

### Prompt

```
En el modelo TaskItem, el campo Status usa magic strings ("todo", "in-progress", "done").

Crea una clase estática TaskStatus en el archivo Models/TaskItem.cs con constantes:
  public static class TaskStatus {
    public const string Todo = "todo";
    public const string InProgress = "in-progress";
    public const string Done = "done";
  }

Reemplaza todos los string literals de estado en TaskManagerContext.cs por
las constantes TaskStatus.Todo, TaskStatus.InProgress y TaskStatus.Done.

No cambies el tipo de la propiedad Status (sigue siendo string).
```

### Verificar

```powershell
dotnet build
```

---

## Puntos clave del lab

- El working set **te protege** de cambios en archivos que no quieres tocar
- Revisa siempre el diff antes de aceptar — Copilot puede sobre-actuar
- Puedes hacer múltiples rounds: acepta parcialmente y ajusta el prompt
- Edit mode es perfecto para refactors acotados que ya tienes claros

---

## Bonus (si sobra tiempo)

```
Working set: Controllers/TasksController.cs, Controllers/ProjectsController.cs

Añade el atributo [ProducesResponseType] a todos los métodos de los controladores
para documentar los códigos HTTP que pueden devolver.
No cambies la lógica de ningún método.
```
