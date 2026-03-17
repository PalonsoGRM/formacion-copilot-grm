---
description: Scaffolding de un nuevo endpoint REST siguiendo los patrones del proyecto
agent: agent
tools: ['codebase', 'search', 'editFiles', 'runCommands']
argument-hint: "Describe el endpoint: qué hace, qué recurso gestiona, qué datos recibe y devuelve"
---

# Nuevo Endpoint REST

Vas a crear un nuevo endpoint en la TaskManager API. Sigue **exactamente** los patrones del proyecto existente.

## Proceso

1. **Analiza los endpoints existentes** en `Controllers/` para entender el patrón actual
2. **Revisa los modelos** en `Models/` para entender las entidades disponibles
3. **Implementa el endpoint** siguiendo las convenciones del proyecto
4. **Verifica que compila**: ejecuta `dotnet build` y corrige cualquier error antes de terminar

## Convenciones que SIEMPRE debes seguir

```csharp
// ✅ Correcto
[HttpGet("{id}")]
public IActionResult GetById(int id)
{
    var item = _context.Items.Find(id);
    if (item == null) return NotFound();
    return Ok(item);
}

// ❌ Incorrecto
[HttpGet("{id}")]
public TaskItem GetById(int id) // no IActionResult
{
    return _context.Items.Find(id); // sin manejo de null
}
```

- Usa `DateTimeOffset.UtcNow`, nunca `DateTime.Now`
- Devuelve siempre `IActionResult` (no tipos concretos)
- Maneja los casos: 200/201, 400 (validación), 404 (no encontrado)
- No instales paquetes NuGet sin preguntar

## Descripción del endpoint a crear

${input:endpoint_description:Ejemplo: "GET /api/tasks/overdue — devuelve tareas con DueDate anterior a hoy"}
