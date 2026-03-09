# Slide deck: Edit Mode — Refactor quirúrgico y controlado

---

## ¿Qué es Edit mode?

- Tú defines **exactamente qué archivos** puede tocar Copilot (el "working set")
- Copilot propone los cambios
- Tú revisas **archivo por archivo** y aceptas o descartas
- Control total. Sin sorpresas.

---

## Cuándo usar Edit (vs Agent)

| Edit mode | Agent mode |
|---|---|
| Sabes exactamente qué archivos cambiar | No sabes cuántos archivos afecta |
| Cambio acotado y bien definido | Tarea compleja multi-paso |
| Quieres revisar cada línea antes de aceptar | Confías en dejar que Copilot itere |
| Bajo riesgo | Mayor autonomía necesaria |

**Regla práctica:** si puedes listar los archivos a mano, usa Edit.

---

## Flujo de Edit mode

```
1. Abre Copilot Chat → selecciona modo "Edit" en el desplegable
2. Añade archivos al working set (botón "+" o arrastra desde el explorador)
3. Escribe el prompt describiendo el cambio
4. Copilot muestra diff por archivo
5. Acepta / Descarta cada cambio
6. Guarda
```

---

## Ejemplo práctico

### Contexto
La API usa `DateTime.Now` en varios sitios (patrón obsoleto — no respeta timezone).  
Queremos reemplazarlo por `DateTimeOffset.UtcNow` en todos los modelos y controladores.

### Working set
```
Models/TaskItem.cs
Models/Project.cs
Controllers/TasksController.cs
Controllers/ProjectsController.cs
```

### Prompt
```
Reemplaza todos los usos de DateTime.Now por DateTimeOffset.UtcNow
en los archivos del working set. Actualiza también los tipos de
las propiedades de fecha en los modelos para que sean DateTimeOffset.
No modifiques ninguna otra lógica.
```

---

## Tips para Edit mode

- Sé **específico** en el prompt: qué cambiar y qué NO cambiar
- Usa el working set para limitar el alcance intencionalmente
- Revisa los diffs con calma — Copilot a veces sobreactúa
- Puedes hacer varios rounds: acepta parte, ajusta el prompt, sigue

---

## Demo en vivo

1. Copilot Chat → modo **Edit**
2. Añadir `Models/TaskItem.cs` y `Controllers/TasksController.cs`
3. Prompt: reemplazar `DateTime.Now` → `DateTimeOffset.UtcNow`
4. Revisar diff, aceptar cambios
5. Verificar que el proyecto compila

---

## Ahora tú — Lab 2

Ver instrucciones en `labs/02-edit-mode/README.md`

Tiempo: **30 minutos**
