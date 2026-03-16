# Lab 1 — Ask Actualizado: `#codebase`, `#file` y selección como contexto

**Duración**: 15 minutos  
**Herramienta**: GitHub Copilot Chat — modo **Ask**  
**IDE**: Visual Studio Code

---

## Objetivo

Practicar las nuevas formas de dar contexto a Copilot en modo Ask: las variables `#codebase`, `#file` y `#terminalLastCommand`, y la selección de código en el editor para referenciar fragmentos directamente en el chat.

Al final del lab deberías ser capaz de escribir prompts precisos que no necesitan `@workspace` y de usar la selección del editor como contexto sin pegar código manualmente.

---

## Preparación

1. Abre VS Code en la carpeta `sample-app/backend/TaskManager.Api`
2. Abre Copilot Chat (`Ctrl+Alt+I`) y selecciona modo **Ask**
3. Ejecuta `dotnet build` — debe pasar sin errores

---

## Ejercicio 1 — Arquitectura con `#codebase` (5 min)

### Paso 1: pregunta de arquitectura general

En Copilot Chat (modo Ask), escribe el siguiente prompt:

```
#codebase describe la arquitectura general de esta API:
- capas que existen (controllers, models, data)
- patrones usados
- cómo fluye una petición desde el endpoint hasta la base de datos
- dependencias entre componentes
Sé conciso, usa viñetas.
```

### Paso 2: profundiza con una pregunta de seguimiento

Sin borrar la conversación, añade:

```
#codebase ¿qué defectos o code smells detectas en el diseño actual?
Lista los 3 más importantes con el archivo y línea aproximada.
```

### Qué observar

- Copilot referencia archivos reales del proyecto (`TasksController.cs`, `TaskItem.cs`, etc.)
- La respuesta es coherente con la estructura real (no inventa capas que no existen)
- El token `#codebase` aparece resaltado en el campo de entrada — confirma que el contexto está activo

> **Antes / Ahora**: si en el taller anterior usabas `@workspace describe la arquitectura...`, ese prompt ahora fallaría con un error. El reemplazo exacto es `#codebase`.

---

## Ejercicio 2 — Selección como contexto sobre el método `Create` (5 min)

### Paso 1: abre `TasksController.cs`

En VS Code, abre `Controllers/TasksController.cs`.

### Paso 2: selecciona el método `Create`

Selecciona desde la firma del método hasta el cierre de llaves `}` del método `Create` (el endpoint `POST /api/tasks`, aproximadamente líneas 40–60).

### Paso 3: pide una explicación en el chat

Con el código seleccionado, abre Copilot Chat (`Ctrl+Alt+I`).  
El fragmento seleccionado aparecerá referenciado automáticamente en el campo de entrada.  
Escribe:

```
explica qué hace este método y qué podría mejorar
```

Copilot explica el método usando exactamente el fragmento que tienes seleccionado. Lee la explicación — fíjate en qué detecta y qué echa en falta.

### Paso 4: pide que genere tests

Mantén (o vuelve a hacer) la misma selección del método `Create` y abre de nuevo el chat.  
Escribe:

```
genera tests unitarios para este método
```

Copilot genera una clase de test con varios casos. **No aceptes los cambios todavía** — solo observa:

- ¿Qué casos edge incluye? (null, título vacío, ProjectId inválido)
- ¿Usa `xUnit` o `NUnit`? ¿Qué mock framework propone?
- ¿Compila tal cual o necesita ajustes?

### Qué observar

- No hace falta copiar ni pegar código: la selección es el contexto
- Cuanto más precisa sea la selección (un método, no todo el archivo), más útil será la respuesta
- Copilot conoce el tipo de retorno (`IActionResult`) y la inyección del `DbContext` porque ve el código seleccionado

---

## Ejercicio 3 — Validaciones faltantes con `#file` y corrección desde el chat (5 min)

### Paso 1: pregunta de revisión con `#file`

En Copilot Chat (modo Ask), escribe:

```
#TasksController.cs
Actúa como revisor de código senior.
¿Qué validaciones de entrada faltan en los endpoints POST y PUT?
Lista cada problema con: endpoint afectado, campo sin validar, riesgo.
```

> **Sintaxis**: escribe `#` y empieza a escribir el nombre del archivo — VS Code autocompleta la ruta. No hace falta la ruta completa, solo el nombre del archivo.

### Paso 2: identifica el problema más crítico

Copilot listará problemas como:
- `Title` puede ser `null` o vacío en el POST
- No hay validación de que `ProjectId` exista en la base de datos
- `Status` acepta cualquier cadena, no solo `"todo"`, `"in-progress"`, `"done"`

### Paso 3: pide la corrección desde el chat con la selección activa

1. En `TasksController.cs`, localiza el método `Create`
2. Selecciona la línea donde se hace `_context.Tasks.Add(task)` (antes de la validación)
3. Abre Copilot Chat — el fragmento seleccionado aparecerá como contexto
4. Escribe:

```
¿qué validaciones faltan antes de esta línea? propón la corrección
```

Copilot propondrá añadir validaciones. Revisa la propuesta — **no la aceptes si no te convence**.

### Qué observar

- `#file` es más preciso que `#codebase` cuando sabes exactamente en qué archivo está el problema
- La selección activa en el editor da contexto quirúrgico: Copilot ve exactamente la línea problemática
- La propuesta puede incluir atributos `[Required]` en el modelo o guards en el controller — ambas son válidas

---

## Puntos clave del lab

| Antes (taller completo) | Ahora |
|-------------------------|-------|
| `@workspace describe...` | `#codebase describe...` |
| Pegar código en el chat para explicar | Seleccionar en el editor → abrir chat → preguntar directamente |
| `/doc` para documentar | Clic derecho → *Copilot* → *Generate Docs* |
| Copiar error del terminal al chat | `#terminalLastCommand` |
| `#file:ruta/completa/archivo.cs` | `#NombreArchivo.cs` (autocomplete) |

---

## Bonus — `#terminalLastCommand` con error de compilación

Este ejercicio es opcional si sobra tiempo.

### Paso 1: introduce un error de compilación

Abre `Models/TaskItem.cs` y añade una línea con un tipo inválido:

```csharp
public InvalidType SomeProp { get; set; }
```

### Paso 2: ejecuta el build

```powershell
dotnet build
```

El build falla con un error de compilación.

### Paso 3: pide ayuda a Copilot

En Copilot Chat:

```
#terminalLastCommand
¿Cuál es la causa del error y cómo lo corrijo?
```

### Paso 4: deshaz el cambio

Después de ver cómo Copilot explica el error, elimina la línea que añadiste y comprueba que `dotnet build` vuelve a pasar.

### Qué observar

- `#terminalLastCommand` captura automáticamente la última salida del terminal integrado de VS Code
- No necesitas seleccionar ni copiar nada — Copilot lee el contexto directamente
- Útil para errores de build, fallos de tests, y errores de `dotnet run`

---

[← Novedades](../../slides/00-novedades.md) | [→ Lab 2: Plan Mode](../02-plan-mode/README.md)
