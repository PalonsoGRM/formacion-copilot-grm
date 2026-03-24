# Lab 2 — Plan Mode: Planifica Antes de Tocar Código

**Duración**: 15 minutos  
**Herramienta**: GitHub Copilot Chat — modo **Plan**  
**IDE**: Visual Studio Code

---

## Objetivo

Usar Plan mode para diseñar un cambio significativo (paginación en `GET /api/tasks`) antes de ejecutar ninguna modificación. Entender la diferencia entre planificar con Copilot y lanzarse a implementar directamente.

Al final del lab deberías ser capaz de generar un plan detallado, revisarlo, y transicionarlo a implementación con Agent mode.

---

## ¿Por qué planificar primero?

```
SIN PLAN                          CON PLAN
────────────────────────          ────────────────────────
Tú:  "añade paginación"           Tú:  "planifica paginación"
       ↓                                 ↓
Copilot empieza a editar          Copilot analiza:
archivos inmediatamente             • qué archivos cambian
       ↓                             • qué rompe
Modifica TasksController,           • qué hay que crear
Program.cs, TaskItem,               • orden de pasos
a veces el modelo…                       ↓
       ↓                          Tú revisas el plan
Te preguntas qué tocó                    ↓
       ↓                          Apruebas o corriges
Revisas diff de 8 archivos               ↓
durante 10 minutos                Copilot implementa
                                  exactamente lo acordado
```
<img width="458" height="570" alt="shaki" src="https://github.com/user-attachments/assets/8422cf25-ac85-48df-a327-9dad0ab70952" />


**Plan mode GA** formaliza este flujo. Ya no es un workaround ("dime el plan pero no implementes"). Es un modo con su propio paso de aprobación.

---

## Preparación

1. VS Code abierto en `sample-app/backend/TaskManager.Api`
2. `dotnet build` pasa sin errores
3. Copilot Chat abierto (`Ctrl+Alt+I`)
4. Selector de modo (parte inferior del chat) → selecciona **Plan**

> Si no ves **Plan** en el selector, consulta la sección [Fallback](#fallback-si-plan-mode-no-está-disponible) al final del lab.

---

## Ejercicio 1 — Generar el plan de paginación (10 min)

### Paso 1: cambia a Plan mode

En la parte inferior del panel de Copilot Chat, haz clic en el selector de modo y elige **Plan**.

### Paso 2: escribe el prompt de planificación

```
Quiero añadir paginación al endpoint GET /api/tasks.

Requisitos:
- El endpoint debe aceptar parámetros de query: pageNumber (default 1) y pageSize (default 10)
- La respuesta debe cambiar de un array plano a un objeto con:
  {
    "tasks": [...],
    "totalCount": 25,
    "totalPages": 3,
    "currentPage": 1
  }
- No cambiar el modelo TaskItem ni la base de datos
- Mantener compatibilidad con el endpoint GET /api/tasks/by-project/{projectId}

Analiza el codebase y dame un plan paso a paso con:
1. Qué archivos hay que crear o modificar
2. Qué cambios concretos en cada uno
3. Orden de implementación
4. Qué podría romperse y cómo mitigarlo
```

### Paso 3: lee el plan generado

Copilot generará un plan estructurado. Comprueba que menciona:

- [ ] Creación de una clase `PagedResult<T>` o similar (DTO de respuesta)
- [ ] Modificación de `TasksController.cs` → método `GetAll()`
- [ ] Parámetros `pageNumber` y `pageSize` con valores por defecto
- [ ] Uso de `.Skip()` y `.Take()` en la query de EF Core
- [ ] Cálculo de `totalCount` con `.CountAsync()`
- [ ] Posible impacto en tests (si los hay)

### Paso 4: evalúa el plan críticamente

Hazte estas preguntas mientras lees:

- ¿Propone crear un DTO separado o reutilizar algo existente?
- ¿Menciona qué pasa si `pageNumber` es 0 o negativo?
- ¿Habla del impacto en `GET /api/tasks/by-project/{projectId}`?
- ¿El orden de pasos tiene sentido (no intenta usar algo antes de crearlo)?

Si algo no te convence, **escríbelo como respuesta** antes de aprobar:

```
El plan está bien pero:
- pageSize máximo debería ser 50 para evitar queries gigantes
- hay que validar que pageNumber >= 1
Ajusta el plan con estas restricciones.
```

**No implementes todavía — el objetivo de este ejercicio es el plan, no el código.**

---

## Bonus previo — Exportar el plan como Markdown
<img width="485" height="398" alt="bob2" src="https://github.com/user-attachments/assets/6bd144f7-1469-4ab2-988d-960a6cd86ce5" />

> **¿Dónde queda mi plan? ¿Lo puedo exportar o documentar?**
>
> El plan existe solo en el chat — no se guarda en ningún archivo automáticamente. Si cierras la conversación, lo pierdes. Aquí te explicamos cómo exportarlo antes de seguir.

Antes de aprobar la implementación, puedes exportar el plan a un archivo `.md` para compartirlo o usarlo como descripción de PR.

> **Importante**: Plan mode **no tiene permisos para crear ni modificar archivos**. Solo puede razonar, analizar y generar texto en el chat. Para crear el documento, haz clic en el botón **"Open in Editor"** que aparece en el panel de Plan mode — esto cambia automáticamente a **Agent mode**, que sí tiene permisos de escritura.

Usa este prompt antes de hacer clic en **"Open in Editor"**:

```
#createFile the plan as is into an untitled file (`untitled:plan-${camelCaseName}.prompt.md` without frontmatter) for further refinement.
```

Al ejecutarse en Agent mode, el archivo se crea con el contenido del plan, listo para:

- Compartir con el equipo antes de implementar
- Usarlo como descripción de PR
- Tener trazabilidad de decisiones de arquitectura

---

## Ejercicio 2 — Aprobar e iniciar la implementación (5 min)

### Paso 1: aprueba el plan

Cuando estés satisfecho con el plan, busca el botón **Start Implementation** (o **Approve and Implement**, dependiendo de la versión) en el panel de Plan mode.

Haz clic en él.

### Paso 2: observa el cambio de modo

Al aprobar, Copilot **cambia automáticamente a Agent mode** y empieza a implementar el plan.

Observa:
- El selector de modo ahora muestra **Agent**
- Copilot pide confirmación antes de crear o editar cada archivo
- El working set (archivos que va a tocar) se muestra en el panel lateral
- Los cambios se van aplicando en el orden que indicó el plan

### Paso 3: supervisa la implementación

Para cada archivo que Copilot quiera modificar, **revisa el diff** antes de aprobar:

- ¿Los parámetros tienen los defaults correctos (`pageNumber = 1`, `pageSize = 10`)?
- ¿El `.Skip()` y `.Take()` son correctos matemáticamente? (`Skip((pageNumber-1) * pageSize)`)
- ¿La respuesta incluye los cuatro campos acordados?

### Paso 4: verifica que compila

```powershell
dotnet build
```

Si hay errores, usa el chat (en modo Ask) para resolverlos:

```
#terminalLastCommand
El build falla después de implementar paginación. ¿Qué hay que corregir?
```

---

## Fallback: si Plan mode no está disponible

Si tu versión de VS Code / extensión Copilot no muestra la opción **Plan** en el selector de modo, usa este workaround con **Agent mode**:

```
[Modo Agent]

IMPORTANTE: Solo analiza y planifica. No modifiques ningún archivo todavía.

Quiero añadir paginación a GET /api/tasks con respuesta:
{ tasks, totalCount, totalPages, currentPage }

Analiza el codebase y responde SOLO con:
1. Lista de archivos a crear/modificar
2. Cambios concretos en cada uno
3. Orden de implementación

Espera mi aprobación antes de hacer cualquier cambio.
```

Cuando el plan te convenza, escribe:

```
El plan está aprobado. Procede con la implementación.
```

---

## Puntos clave del lab

- **Plan mode GA** no es "Agent con instrucciones extra" — tiene un paso de aprobación explícito antes de tocar código
- Plan mode **no modifica archivos** hasta que apruebes: puedes iterar el plan libremente
- Al aprobar, la transición a Agent es automática — no necesitas cambiar el modo manualmente
- Un buen plan menciona qué puede romperse, no solo qué va a crear
- Si el plan no te convence, corrígelo en el chat antes de aprobar — es mucho más barato que deshacer código

---

## Bonus — Guardar el plan como documento

> **Pro tip:** consulta el apartado [Bonus previo — Exportar el plan como Markdown](#bonus-previo--exportar-el-plan-como-markdown) para ver cómo hacerlo usando el botón **"Open in Editor"** y el prompt `#createFile`.

---

[← Lab 1: Ask Mode](../01-ask-mode/README.md) | [→ Lab 3: Agent Mode](../03-agent-mode/README.md)
