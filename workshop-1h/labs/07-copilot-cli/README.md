# Lab Extra 07 — GitHub Copilot CLI

> **Tipo**: Lab extra — realiza este lab después del Lab 06 o en una sesión dedicada.  
> **Duración**: ~40 min  
> **Herramienta**: GitHub Copilot CLI — terminal  
> **IDE**: No necesitas abrirlo 😎

---

## ¿Por qué un lab sobre el CLI?

Hasta ahora has usado Copilot **dentro del IDE**. Pero hay una versión que vive directamente en el terminal y que cambia completamente lo que puedes hacer — especialmente cuando estás arrancando un proyecto desde cero.

En este lab vamos a hacer algo que suele sorprender a los desarrolladores:

> **Partiremos de una carpeta completamente vacía y terminaremos con una API REST funcionando — sin abrir VS Code ni ningún IDE.**

---

## Parte 0 — Setup (3 min)

### Verifica la instalación

```powershell
copilot --version
```

Si el comando no se reconoce, instálalo:

```powershell
# Con npm (recomendado)
npm install -g @github/copilot-cli

# O descarga el binario desde:
# https://docs.github.com/en/copilot/how-tos/set-up/install-copilot-cli
```

### Arranca una sesión

Navega a cualquier carpeta de trabajo y ejecuta `copilot`. Al arrancar:

1. Te pregunta si confías en los archivos de la carpeta — selecciona **Yes, proceed**
2. Si no estás logueado, usa `/login` y sigue las instrucciones
3. Ya estás dentro — el prompt `>` indica que el CLI está listo

```
❯ copilot
✓ Welcome to GitHub Copilot CLI
> _
```

---

## Parte 1 — ¿Qué es el CLI? (5 min)

El CLI no es "Copilot con menos features". Es **Agent Mode que vive en el terminal**. Puede leer tu código, crear archivos, ejecutar comandos y verificar resultados — exactamente como el Agent Mode del IDE, pero sin necesitar VS Code abierto.

### Comandos y gestos esenciales

| Comando / Gesto | Qué hace |
|---|---|
| `Shift+Tab` | Activa / desactiva **Plan Mode** — planifica antes de tocar nada |
| `@ruta/al/archivo.cs` | Incluye el contenido del archivo en el contexto del prompt |
| `!git status` | Ejecuta un comando de shell **directamente**, sin pasar por el modelo |
| `/diff` | Muestra los cambios actuales del working tree (como `git diff`) |
| `/review` | Lanza el agente de code review sobre los cambios actuales |
| `--resume` | Al arrancar, selecciona una sesión anterior para continuar |
| `--continue` | Retoma automáticamente la última sesión cerrada |
| `/allow-all` | Habilita todos los permisos de herramientas para la sesión actual |
| `Ctrl+T` | Muestra / oculta el razonamiento interno del modelo |
| `Esc` | Cancela la operación en curso |

### Custom instructions y agentes

El CLI respeta los mismos archivos que ya conoces del Lab 05 y Lab 06:

- `.github/copilot-instructions.md` — instrucciones del proyecto
- `.github/agents/*.agent.md` — custom agents
- `.github/prompts/*.prompt.md` — prompt files / slash commands

Si has definido un agente `revisor` en el Lab 06, puedes invocarlo desde el CLI exactamente igual:

```
Use the revisor agent to review the changes in TasksController.cs
```

---

## Parte 2 — CLI vs IDE: cuándo usar cada uno (5 min)

No es una competencia. Son herramientas complementarias con casos de uso distintos.

| Aspecto | Copilot en IDE (VS Code) | Copilot CLI |
|---|---|---|
| Requiere IDE abierto | ✅ Sí | ❌ No |
| **Arrancar proyecto nuevo desde cero** | ⚠️ Tú creas la estructura primero | ✅ Lo scaffold todo desde el terminal |
| Ejecutar build/test/git integrado | ⚠️ Pide aprobación por terminal integrado | ✅ Nativo, sin fricciones |
| Ghost text / autocompletado inline | ✅ Sí | ❌ No |
| Ver errores del compilador inline | ✅ Sí | ⚠️ Solo vía output de terminal |
| Sesiones persistentes y resumibles | ❌ No | ✅ `--resume` / `--continue` |
| Modo autopiloto sin aprobaciones | ❌ No | ✅ `--allow-all` / `--yolo` |
| Funciona en servidor remoto / CI | ❌ No | ✅ Sí |
| Contexto visual del editor | ✅ Sí | ❌ No |

### Cuándo usar el CLI

- ⭐ Al **iniciar un proyecto nuevo** — es donde más brilla
- Cuando trabajas en **SSH / servidor remoto** sin GUI
- Para tareas largas y autónomas donde confías en el resultado
- Para explorar una codebase que acabas de clonar sin abrir el IDE

### Cuándo usar el IDE

- Trabajo iterativo del día a día sobre código existente
- Cuando necesitas contexto visual (hover de errores, navegación por símbolos)
- Ghost text mientras escribes código nuevo

> **La regla rápida**: IDE para *trabajar dentro* de un proyecto. CLI para *arrancar* o *automatizar* un proyecto.

---

## Parte 3 — ⭐ WOW MOMENT: Nuevo proyecto desde cero (20 min)

### La situación

Imagina que te asignan a un proyecto nuevo. El repositorio existe en Azure DevOps, lo acabas de clonar, la carpeta está vacía. Normalmente: `dotnet new`, configurar EF Core, crear modelos, controllers, seed data... 30-40 minutos de scaffold aburrido.

**Con el CLI: un prompt bien escrito y 15 minutos de supervisión.**

### Paso 1: Crea la carpeta del proyecto

En tu terminal (fuera del repo de formación):

```powershell
# En cualquier ubicación de tu máquina
mkdir C:\dev\inventory-demo
cd C:\dev\inventory-demo
```

> No crees esta carpeta dentro del repo de formación — es un proyecto independiente, como sería en tu día a día real.

### Paso 2: Arranca el CLI en esa carpeta

```powershell
copilot
```

Selecciona **Yes, proceed** cuando pregunte si confías en la carpeta.

### Paso 3: Lanza el prompt de scaffold

Copia el siguiente prompt exactamente como está (o ábrelo desde [`prompts/01-scaffold-project.md`](prompts/01-scaffold-project.md)):

```
Crea un proyecto nuevo de API REST con ASP.NET Core (.NET 8) en esta carpeta.
El proyecto se llamará InventoryManager.Api y gestionará un inventario de productos.

Requisitos:
- Modelos: Product (Id, Name, Description, Price decimal, Stock int, CategoryId, CreatedAt DateTimeOffset), Category (Id, Name, Description, Products)
- DbContext con EF Core in-memory con seed data realista: 3 categorías (Electrónica, Ropa, Alimentación) y 8 productos distribuidos entre ellas
- ProductsController con CRUD completo: GET /api/products, GET /api/products/{id}, POST /api/products, PUT /api/products/{id}, DELETE /api/products/{id}
- CategoriesController con: GET /api/categories, GET /api/categories/{id} (incluye lista de productos), POST /api/categories, DELETE /api/categories/{id}
- Swagger/OpenAPI habilitado en desarrollo
- Usa DateTimeOffset.UtcNow para todas las fechas, nunca DateTime.Now
- DataAnnotations de validación: [Required], [MaxLength], [Range] donde corresponda
- Los controladores devuelven IActionResult y usan Ok(), NotFound(), BadRequest(), CreatedAtAction()
- Sin autenticación por ahora

Al terminar, ejecuta dotnet build para verificar que compila sin errores.
```

### Paso 4: Supervisa y aprueba

El CLI irá pidiendo permiso para ejecutar herramientas. Elige la opción **"Yes, and approve for the rest of the session"** para cada tipo de herramienta — así no tendrás que aprobar cada paso individual:

- `dotnet new webapi` — crea el proyecto
- `mkdir` / creación de carpetas — estructura del proyecto
- Escritura de archivos `.cs` — modelos, controllers, DbContext
- `dotnet build` — verificación final

### Paso 5: Observa el resultado

Cuando el CLI termine, comprueba lo que ha creado:

```powershell
# Ver la estructura generada
Get-ChildItem -Recurse -Name "*.cs"

# Arrancar la API
dotnet run
```

Abre en el navegador: `http://localhost:5000/swagger`

Deberías ver una API completamente funcional con todos los endpoints documentados y datos de prueba cargados.

### ¿Qué ha pasado?

Marca lo que has visto mientras el CLI trabajaba:

- [ ] Ejecutó `dotnet new` sin que se lo pidieras explícitamente
- [ ] Creó la estructura de carpetas (`Models/`, `Controllers/`, `Data/`)
- [ ] Escribió múltiples archivos en una sola sesión
- [ ] Ejecutó `dotnet build` por iniciativa propia para verificar
- [ ] Si algo falló al compilar, lo detectó y lo corrigió solo
- [ ] Todo sin abrir el IDE ni una sola vez

---

## Parte 4 — Flujos avanzados (7 min)

Todavía dentro de la sesión del CLI en tu carpeta `inventory-demo`, prueba estas funcionalidades:

### 4a. Plan Mode — añade un endpoint sin sorpresas

Pulsa `Shift+Tab` para activar Plan Mode (verás el indicador en el prompt).

```
Añade un endpoint GET /api/products/search?name=X&minPrice=Y&maxPrice=Z 
que permita filtrar productos por nombre (parcial) y rango de precios.
Dame el plan antes de implementar nada.
```

Observa cómo en Plan Mode el CLI:
1. Lista exactamente qué archivos va a modificar
2. Describe los cambios antes de hacerlos
3. Espera tu aprobación explícita

Pulsa `Shift+Tab` de nuevo para volver al modo normal y aprobar la implementación.

---

### 4b. `/review` — análisis instantáneo de cambios

Después de que el CLI haya hecho cambios:

```
/review
```

Compara la calidad de este análisis con el agente `revisor` del Lab 06. ¿Detecta los mismos problemas?

---

### 4c. `--allow-all` (modo autopiloto) — úsalo con criterio

Cierra la sesión actual con `Ctrl+D`. Ahora lanza una tarea compleja de una sola vez:

```powershell
copilot --allow-all --prompt "Añade tests unitarios para ProductsController usando xUnit. Crea el proyecto de tests, añade las dependencias necesarias y ejecuta los tests para verificar que pasan."
```

> ⚠️ **Disclaimer**: `--allow-all` (alias: `--yolo`) elimina todas las aprobaciones manuales. El CLI puede crear, modificar y ejecutar archivos sin pedirte confirmación. Úsalo cuando:
> - Confías completamente en el prompt que has escrito
> - Estás en una rama limpia con git para deshacer si algo va mal
> - La tarea está bien acotada y no hay riesgo de borrar datos
>
> **Nunca** uses `--allow-all` en producción o con acceso a datos reales.

---

### 4d. Sesiones persistentes — retoma donde lo dejaste

Una de las funcionalidades más útiles del CLI: las sesiones se guardan.

```powershell
# Retoma la última sesión cerrada (el historial de conversación se restaura)
copilot --continue

# O selecciona entre varias sesiones anteriores
copilot --resume
```

Muy útil cuando:
- Llevas una hora trabajando con el CLI y tienes que parar
- Retomas al día siguiente — el contexto sigue ahí
- Cambias de máquina (si sincronizas `~/.copilot/`)

---

## El mensaje clave

> El CLI no reemplaza al IDE para el trabajo diario. Pero para **arrancar proyectos desde cero**, es dramáticamente más eficiente. Un developer que domina el CLI puede tener el scaffold de una API REST nueva en 15 minutos — con modelos, controllers, seed data y build verificado — mientras otros desarrolladores todavía están configurando el proyecto base.

---

## Recursos

| Recurso | URL |
|---------|-----|
| Documentación oficial Copilot CLI | https://docs.github.com/en/copilot/how-tos/use-copilot-agents/use-copilot-cli |
| Instalación | https://docs.github.com/en/copilot/how-tos/set-up/install-copilot-cli |
| Custom instructions para CLI | https://docs.github.com/en/copilot/how-tos/copilot-cli/add-custom-instructions |
| Custom agents | https://docs.github.com/en/copilot/how-tos/use-copilot-agents/coding-agent/create-custom-agents |

---

[← Lab 06: Custom Agents](../06-custom-agents/README.md) | [→ Volver al índice](../../README.md)
