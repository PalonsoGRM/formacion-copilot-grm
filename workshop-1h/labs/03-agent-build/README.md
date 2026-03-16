# Lab 3 — Agent/Build: Nuevo Endpoint `GET /api/tasks/stats`

**Duración**: 15 minutos  
**Herramienta**: GitHub Copilot Chat — modo **Agent**  
**IDE**: Visual Studio Code

---

## Objetivo

Usar Agent mode para construir desde cero un endpoint nuevo siguiendo los patrones existentes del proyecto, sin instalar paquetes nuevos ni modificar el esquema de datos.

Al final del lab deberías tener un endpoint funcional `GET /api/tasks/stats` respondiendo con estadísticas reales de la base de datos en memoria.

---

## Preparación

### Paso 1: confirma estado limpio de git

```powershell
git status
```

Debe mostrar `nothing to commit, working tree clean`. Si hay cambios del lab anterior:

```powershell
git add .
git stash
```

### Paso 2: crea un commit de punto de partida

```powershell
git add .
git commit -m "estado inicial lab 3"
```

Esto te da un punto de retorno claro si quieres repetir el ejercicio.

### Paso 3: verifica que el proyecto compila

```powershell
dotnet build
```

Debe pasar sin errores.

### Paso 4: cambia a Agent mode

En Copilot Chat (`Ctrl+Alt+I`), selecciona modo **Agent** en el selector inferior.

---

## La tarea

### Paso 1: escribe el prompt para Agent

```
Añade un nuevo endpoint al proyecto TaskManager.Api:

GET /api/tasks/stats

El endpoint debe devolver un objeto JSON con:
{
  "total": <número total de tareas>,
  "completadas": <tareas con Status == "done">,
  "pendientes": <tareas con Status == "todo" o "in-progress">,
  "vencidas": <tareas con DueDate < DateTime.Now y Status != "done">
}

Restricciones:
- Sigue exactamente los mismos patrones del TasksController existente
  (inyección de DbContext, async/await, IActionResult, misma estructura de ruta)
- No instales paquetes NuGet nuevos
- No cambies el modelo TaskItem ni la base de datos
- No crees un nuevo controller si el endpoint encaja en TasksController
- Usa operaciones asíncronas de EF Core (.CountAsync, .AnyAsync, etc.)
```

### Paso 2: supervisa los cambios propuestos

Agent mostrará los archivos que quiere modificar. Antes de aprobar cada uno, verifica:

**En `TasksController.cs`**:
- [ ] El nuevo método se llama `GetStats()` o similar — nombre coherente con los demás
- [ ] Tiene la anotación `[HttpGet("stats")]`
- [ ] Usa `_context.Tasks` (el mismo DbContext inyectado)
- [ ] Las consultas son `async` con `await`
- [ ] El cálculo de `vencidas` comprueba tanto `DueDate.HasValue` como `DueDate < DateTime.Now` y `Status != "done"`
- [ ] Devuelve `Ok(new { total, completadas, pendientes, vencidas })`

**No debe crear**:
- [ ] Ningún archivo de migración de base de datos
- [ ] Ningún paquete NuGet nuevo en el `.csproj`
- [ ] Ningún modelo nuevo en la carpeta `Models/`

### Paso 3: aprueba los cambios

Acepta los cambios propuestos. Si Copilot pide ejecutar comandos en el terminal (como `dotnet build` para verificar), **apruébalos**.

---

## Verificación

### Paso 1: compila

```powershell
dotnet build
```

Debe pasar sin errores.

### Paso 2: arranca la aplicación

```powershell
dotnet run
```

Espera hasta ver el mensaje:

```
Now listening on: http://localhost:5145
```

### Paso 3: llama al endpoint

Abre otro terminal o usa la extensión REST Client de VS Code:

```powershell
curl http://localhost:5145/api/tasks/stats
```

#### Respuesta esperada

La base de datos se inicializa con datos de prueba en `TaskManagerContext.cs`. Con los datos semilla, la respuesta debe ser:

```json
{
  "total": 5,
  "completadas": 1,
  "pendientes": 4,
  "vencidas": 0
}
```

> `vencidas` es 0 porque las tareas semilla no tienen `DueDate` anterior a la fecha de hoy (o no tienen `DueDate`).  
> Para probarlo con un valor real, añade temporalmente una tarea con `DueDate` pasada en `TaskManagerContext.cs`.

### Paso 4: para la aplicación

```
Ctrl+C
```

---

## Qué observar durante la ejecución de Agent

Marca lo que veas mientras Agent trabaja:

- [ ] **Working set**: Copilot lista los archivos que va a tocar antes de modificarlos
- [ ] **Aprobación por archivo**: cada cambio requiere tu confirmación (no edita silenciosamente)
- [ ] **Auto-corrección**: si el build falla, Agent detecta el error y propone una corrección sin que se lo pidas
- [ ] **Respeto de patrones**: el código generado usa la misma estructura que `GetAll()` y `GetById()` existentes
- [ ] **Sin nuevas dependencias**: el `.csproj` no cambia
- [ ] **Terminal awareness**: si apruebas la ejecución del terminal, Copilot usa la salida para validar su trabajo

---

## Puntos clave del lab

- Agent mode trabaja en **ciclos**: propone → apruebas → ejecuta → verifica → repite si hay error
- El **working set** es tu contrato con el agente — si ves un archivo que no debería cambiar, cancela y corrige el prompt
- La calidad del output depende de la calidad del prompt: cuantas más restricciones explícitas, menos sorpresas
- Agent puede ejecutar `dotnet build` por sí mismo si se lo permites — úsalo para validar en el momento
- `git diff` antes de hacer commit es siempre una buena idea aunque Agent haya "verificado"

---

## Bonus — Comparar Agent directo vs Plan → Agent

Si sobra tiempo, prueba la misma tarea con Plan mode primero:

### Paso 1: desecha los cambios del lab

```powershell
git checkout .
```

### Paso 2: cambia a Plan mode y planifica

```
[Plan mode]
Añade GET /api/tasks/stats que devuelva {total, completadas, pendientes, vencidas}.
Sigue los patrones de TasksController. No crees paquetes ni modelos nuevos.
Dame el plan antes de tocar código.
```

### Paso 3: compara

- ¿El plan de Plan mode es más detallado que lo que propuso Agent directamente?
- ¿El resultado final del código es diferente?
- ¿Tardaste más o menos?

**Conclusión esperada**: para un endpoint sencillo con patrones claros, Agent directo es suficiente. Para features más complejas o con impacto en varios archivos, Plan mode primero evita sorpresas.

---

[← Lab 2: Plan Mode](../02-plan-mode/README.md) | [→ Cheatsheet](../../cheatsheet.md)
