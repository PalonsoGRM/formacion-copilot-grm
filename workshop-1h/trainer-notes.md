# Notas del Formador — Workshop de Actualización GitHub Copilot (1 hora)

> Guion minuto a minuto. Léelo antes de la sesión, no durante. Marca los puntos clave con rotulador.

---

## Resumen del día

| Bloque | Hora | Duración | Formato |
|--------|------|----------|---------|
| Novedades | 00:00 – 00:05 | 5 min | Slides + explicación verbal |
| Lab 1 — Ask actualizado | 00:05 – 00:20 | 15 min | Hands-on individual |
| Lab 2 — Plan mode | 00:20 – 00:35 | 15 min | Hands-on individual |
| Lab 3 — Agent/Build | 00:35 – 00:50 | 15 min | Hands-on individual |
| Lab 4 — Frontend Angular | 00:50 – 01:05 | 15 min | Hands-on individual |
| Cierre + cheatsheet | 01:05 – 01:15 | 10 min | Discusión en grupo |

**Labs extra** (si queda tiempo después del cierre o sesión extendida):

| Lab | Duración | Tema |
|-----|----------|------|
| Lab 5 | 20–60 min | Copilot Instructions & poder del `.github` |
| Lab 6 | 30–90 min | Custom agents y prompt files |

---

## Bloque 0: Novedades (00:00 – 00:05)

### Objetivo del bloque
Que los participantes entiendan de un vistazo qué cambió desde el taller anterior y por qué importa.

### Guion verbal

**00:00** — Abre con una pregunta directa, sin presentación:

> "Mano arriba: ¿alguien ha intentado usar `@workspace` en el chat desde el taller y le ha fallado?"

Espera 3-5 segundos. Probablemente varias manos. Continúa:

> "Exacto. `@workspace` desapareció. Hoy vemos el reemplazo — y es mejor. Cinco minutos de novedades y luego manos a la obra."

**00:01** — Abre `slides/00-novedades.md`. Muestra el Slide 1 (tabla antes/después).

Cubre la tabla en 60 segundos. Énfasis en:
- `@workspace` → `#codebase`: cambio de sintaxis, misma idea
- Edit mode → Agent mode: Agent es más capaz, no solo un renombre
- `/doc` → clic derecho → *Generate Docs*: el comando del chat desaparece, la acción sigue en el menú contextual

**00:02** — Slide 2: variables de contexto. Demo en vivo de 30 segundos:

1. Abre Copilot Chat
2. Escribe `#` y pausa
3. Muestra el autocompletado: `#codebase`, archivos del proyecto, etc.
4. Di: "El autocompletado es tu guía — si ves el archivo en la lista, Copilot lo puede usar"

**00:03** — Slide 3: selección de código como contexto. Demo en vivo de 30 segundos:

1. Abre `TasksController.cs`
2. Selecciona 5 líneas de código
3. Abre Copilot Chat (`Ctrl+Alt+I`)
4. Muestra cómo el fragmento aparece referenciado automáticamente en el campo de entrada
5. Di: "La selección es el contexto — sin copiar, sin pegar"

**00:04** — Slide 4 y 5: modos y escenarios. Lee el diagrama de modos en voz alta. No entres en detalle — los labs son la explicación.

**00:05** — Cierre del bloque:

> "Todo esto lo vais a practicar en los próximos 45 minutos. Abrid el Lab 1."

### Pizarra / whiteboard

Escribe esto al inicio y déjalo visible toda la sesión:

```
@workspace  →  #codebase
Edit mode   →  Agent mode
/doc        →  clic derecho → Generate Docs
```

### Señales de éxito

- Los participantes asienten cuando explicas `@workspace` → `#codebase`
- Alguno menciona que ya notó el cambio en su trabajo diario

---

## Bloque 1: Lab 1 — Ask Actualizado (00:05 – 00:20)

### Objetivo del bloque
Que todos ejecuten con éxito los tres ejercicios: `#codebase`, selección como contexto (Explain/Tests), y `#file` + corrección desde el chat.

### Guion verbal

**00:05** — Lanza el lab:

> "Lab 1, abrid `labs/01-ask-actualizado/README.md`. Tienen 15 minutos. Empezad por el Ejercicio 1 y avanzad a vuestro ritmo."

**00:07** — Camina por la sala. Observa:
- ¿Están en modo Ask? (selector inferior del chat)
- ¿`#codebase` aparece resaltado en el prompt?

Si alguien tiene `@workspace` en el campo: para en seco y muéstraselo al grupo.

**00:10** — Señal de ritmo:

> "Los que estéis en el Ejercicio 1, bien. Los que ya hayáis terminado el 2, genial — pasad al 3."

**00:13** — Demo en vivo del Ejercicio 2 si ves que el grupo no sabe cómo usar la selección como contexto:

1. Selecciona el método `Create()` en `TasksController.cs`
2. Abre Copilot Chat (`Ctrl+Alt+I`)
3. Muestra el fragmento referenciado automáticamente en el campo de entrada
4. Di: "¿Veis? Sin abrir el chat desde cero, sin pegar código. La selección es el contexto."

**00:17** — Ejercicio 3 con `#file`:

> "Para el Ejercicio 3, escribid `#` en el chat y empezad a teclear 'Tasks' — veréis `TasksController.cs` en el autocompletado. Seleccionadlo."

**00:19** — Wrap-up del lab:

> "Parad. ¿Qué diferencia notáis entre `#codebase` y `#file`?"

Espera respuestas. La correcta es: `#codebase` indexa todo el proyecto (más lento, más amplio); `#file` es quirúrgico sobre un archivo concreto (más rápido, más preciso).

### Pizarra

Añade bajo lo anterior:

```
#codebase  → proyecto completo
#archivo   → un archivo concreto
#selection → selección en editor (o se adjunta sola al abrir el chat)
```

### Señales de éxito del Lab 1

- Todos ven respuestas que referencian `TasksController.cs`, `TaskItem.cs` en el output de `#codebase`
- Al menos uno comenta que usar la selección como contexto es más cómodo que pegar código en el chat
- El Ejercicio 3 genera una lista de validaciones faltantes coherente con el código real

### Problemas comunes

**"La selección no aparece en el chat al abrirlo"**  
→ Comprueba que tienen código seleccionado en el editor *antes* de abrir el chat. Si ya estaba abierto, pueden escribir `#selection` manualmente en el campo de entrada.

**"`#codebase` no aparece en el autocompletado"**  
→ Probablemente el proyecto no está indexado. Pide que cierren y vuelvan a abrir VS Code con la carpeta `TaskManager.Api` (no la raíz del repo).

**"Generate Tests no compila"**  
→ Es esperado — el lab dice "no aceptes todavía". Si alguno aceptó, `git checkout .` y a seguir.

---

## Bloque 2: Lab 2 — Plan Mode (00:20 – 00:35)

### Objetivo del bloque
Que los participantes experimenten el ciclo completo: prompt de Plan → revisión del plan → aprobación → transición automática a Agent.

### Guion verbal

**00:20** — Lanza el lab:

> "Lab 2. Antes de abrirlo, una pregunta: ¿cuántos de vosotros habéis lanzado Agent y os ha tocado más archivos de los que esperabais?"

Pausa. Probablemente todos. Continúa:

> "Plan mode existe exactamente para eso. Abre el Lab 2."

**00:21** — Antes de que empiecen, dibuja el diagrama en la pizarra:

```
Sin Plan:   Prompt → Agent edita → ¿qué tocó?
Con Plan:   Prompt → Plan propone → Tú revisas → Apruebas → Agent ejecuta
```

**00:22** — Deja que trabajen solos en el Ejercicio 1 (10 min). Es el ejercicio más largo.

**00:25** — Check intermedio:

> "¿Alguien tiene ya el plan generado? ¿Qué archivos propone crear o modificar?"

Pide a alguien que lea su plan en voz alta. Preguntas para el grupo:
- "¿Propone crear un DTO separado o usa un tipo anónimo?"
- "¿Menciona validación de `pageNumber <= 0`?"

**00:28** — Si alguien no ve Plan mode, redirige al fallback antes de que pierdan tiempo:

> "Si no ves Plan en el selector, el lab tiene un fallback en la sección 'Fallback' — úsalo, el resultado es equivalente."

**00:30** — Ejercicio 2: aprobación e implementación.

> "Ahora aprobad el plan. Observad el selector — ¿cambia de modo automáticamente?"

**00:33** — Wrap-up:

> "Parad antes de que Agent termine si no ha acabado. La pregunta clave es: ¿el plan que revisasteis era lo que necesitabais, o Agent habría hecho algo diferente si le hubierais pedido la implementación directamente?"

### Pizarra

Añade:

```
Plan mode: propone → revisas → apruebas → Agent ejecuta
```

### Señales de éxito del Lab 2

- El plan generado menciona al menos 3 archivos distintos (DTO, controller, posiblemente tests)
- Al menos uno de los participantes corrige el plan antes de aprobarlo
- La transición automática Plan → Agent se produce y es visible

### Problemas comunes

**"Plan mode no está en mi versión"**  
→ Usa el fallback del lab. No pierdas más de 1 minuto en diagnosticar la versión — el fallback es pedagógicamente equivalente.

**"Agent empezó a modificar código antes de que aprobara"**  
→ Puede pasar si el participante usó Agent directamente en lugar de Plan. Pídele que haga `git checkout .` y repita desde Plan mode.

**"El plan es demasiado corto / vago"**  
→ Sugiere añadir al prompt: "sé específico: nombre de archivos, nombre de clases, firma de métodos".

---

## Bloque 3: Lab 3 — Agent/Build (00:35 – 00:50)

### Objetivo del bloque
Que cada participante vea a Agent trabajar de forma autónoma en un ciclo completo: crear código → compilar → autocorregir si falla → verificar con `curl`.

### Guion verbal

**00:35** — Lanza el lab con urgencia:

> "Lab 3. Este es el más técnico. Leed el objetivo primero — 30 segundos — y luego empezad con el git commit del setup."

**00:36** — Mientras hacen el setup, escribe en la pizarra el endpoint que van a construir:

```
GET /api/tasks/stats
→ { total, completadas, pendientes, vencidas }
```

**00:38** — Deja que lancen el prompt de Agent. Camina por la sala y observa:

- ¿El working set tiene solo `TasksController.cs`? (correcto)
- ¿Agent propone crear un nuevo controller? (incorrecto — para eso está la restricción en el prompt)
- ¿Alguien ve a Agent ejecutar `dotnet build` automáticamente?

**00:41** — Si alguien tiene una propuesta de Agent que crea un nuevo controller:

> "Antes de aprobar: ¿el working set incluye un archivo nuevo que no debería existir? Cancelad y añadid al prompt 'no crees un nuevo controller'."

**00:44** — Comienza la fase de verificación. Ayuda a quien tenga problemas con el `curl`:

> "Si `dotnet run` muestra un puerto diferente al 5145, usad ese puerto en el curl."

**00:47** — Señal de verificación grupal:

> "¿Cuántos tienen el endpoint respondiendo? Levantad la mano."

Si menos de la mitad: detente y haz la demo en pantalla completa.

**00:49** — Wrap-up:

> "Parad el servidor con `Ctrl+C`."

### Pizarra

Añade:

```
Agent: propone → apruebas → ejecuta → verifica → repite si falla
```

### Señales de éxito del Lab 3

- El endpoint responde con JSON válido (aunque los números no sean exactamente los esperados)
- Al menos uno ve a Agent autocorregir un error de compilación sin intervención manual
- Ningún participante tiene cambios en `.csproj` o en la carpeta `Models/`

### Problemas comunes

**"El build falla tras aceptar los cambios de Agent"**  
→ Deja que Agent se autocorrija. Si no lo intenta automáticamente, escribe: `#terminalLastCommand el build falla tras tus cambios, corrígelo`. 

**"El endpoint devuelve 404"**  
→ Revisa que la ruta de la anotación es `[HttpGet("stats")]` y no `[HttpGet("[action]")]`. También verifica que el método está dentro de la clase `TasksController`.

**"Agent creó un archivo de migración"**  
→ No debería con el prompt del lab (la restricción explícita lo previene). Si ocurrió, `git checkout .` y añade al prompt: "no crees migraciones, no modifiques el esquema de datos".

**"`curl` no reconocido en PowerShell"**  
→ En PowerShell, `curl` es alias de `Invoke-WebRequest`. Usa: `Invoke-WebRequest -Uri http://localhost:5145/api/tasks/stats | Select-Object -Expand Content`  
O instala `curl.exe` real, o usa la extensión REST Client de VS Code con el archivo `TaskManager.Api.http`.

---

## Bloque 4: Lab 4 — Frontend Angular (00:50 – 01:05)

### Objetivo del bloque
Que los participantes apliquen Ask y Agent en un contexto Angular: primero análisis estático de bugs, luego corrección y feature nueva.

### Guion verbal

**00:50** — Lanza el lab con contexto:

> "Cuarto y último lab obligatorio. Cambiamos de stack — salimos del backend .NET y entramos en el frontend Angular. Las herramientas son las mismas, el contexto es diferente."

**00:51** — Instrucción clave antes de empezar:

> "Para este lab necesitáis tener el frontend corriendo. `cd sample-app/frontend/taskmanager-ui` y `ng serve`. Mientras arranca, leed el objetivo del lab."

**00:53** — Ejercicio 1: análisis de bugs con Ask + `#file`.

> "El Ejercicio 1 es solo Ask — no toquéis código todavía. Queremos que Copilot encuentre los 3 bugs antes de que vosotros los veáis. Usad `#file:dashboard.ts` y `#file:task.ts` en el prompt."

**00:57** — Ejercicio 2: corrección con Agent.

> "¿Encontrasteis los 3 bugs? El Ejercicio 2 es corregirlos con Agent de una vez. Leed el prompt sugerido en el lab — tiene restricciones explícitas para que Agent no toque nada más."

**01:02** — Ejercicio 3: feature nueva con Agent.

> "Último ejercicio: activar el botón '+ New Project'. Este es un buen ejemplo de feature nueva desde cero con Agent — leed las restricciones del lab antes de lanzar el prompt."

**01:04** — Wrap-up:

> "Parad. ¿Qué diferencia notáis entre usar Copilot en TypeScript/Angular vs. C#/.NET?"

Respuesta esperada: Copilot funciona igual de bien — el contexto `#codebase` indexa ambos lenguajes. Las restricciones en el prompt son igual de importantes.

### Señales de éxito del Lab 4

- Los 3 bugs identificados en el Ejercicio 1 coinciden con la descripción del lab
- El badge de estado deja de estar en blanco tras el fix
- El contador "Open Tasks" deja de mostrar `Infinity`
- El Ejercicio 3 crea el formulario inline sin añadir Angular Material ni Bootstrap

### Problemas comunes

**"ng serve falla"**
→ Comprueba que Node.js 20 LTS está instalado (`node --version`) y que se ha ejecutado `npm install` en la carpeta del frontend.

**"Copilot modifica más archivos de los esperados en el Ejercicio 2"**
→ El prompt del lab tiene restricciones explícitas (`no cambies ningún otro comportamiento`). Si Agent propone cambios fuera de los 3 archivos esperados, cancela y añade esa restricción al prompt.

---

## Bloque 5: Cierre + Cheatsheet (01:05 – 01:15)

### Objetivo del bloque
Consolidar el aprendizaje, resolver dudas y dejar a los participantes con un recurso práctico para el día a día.

### Guion verbal

**01:05** — Abre `cheatsheet.md` en pantalla y dale un minuto al grupo para leerlo.

**01:06** — Repaso del árbol de decisión:

> "Este árbol es lo que necesitáis saber. Ask para entender, Plan para diseñar, Agent para implementar, selección en el editor para dar contexto rápido sin pegar código. El flujo completo es: Ask → Plan → Agent → Ask de nuevo para los tests."

**01:08** — Preguntas abiertas. Lanza estas si no hay preguntas espontáneas:

- "¿Cuál de los tres modos creéis que vais a usar más la semana que viene?"
- "¿Qué prompt del Lab 1 os ha parecido más útil?"

**01:11** — FAQs rápidas (ver sección siguiente).

**01:13** — Si hay tiempo: menciona el Lab 5 extra.

> "Si queréis profundizar, hay un Lab 5 extra en el repositorio sobre cómo configurar Copilot para que siempre respete los estándares de vuestro equipo — y mucho más que puede hacer la carpeta `.github` de vuestros proyectos. Está en `workshop-1h/labs/05-copilot-instructions/`."

**01:14** — Frase de cierre (ver al final del documento).

**01:15** — Fin.

---

## FAQs actualizadas — respuestas preparadas

### "¿`@workspace` va a volver?"

No. `#codebase` es el reemplazo definitivo. La diferencia no es solo de nombre — `#codebase` usa el índice semántico del workspace de forma más eficiente. Actualiza tus snippets y prompts guardados.

### "¿Edit mode ha desaparecido del todo?"

Sí, en las versiones actuales el selector solo muestra Ask, Plan y Agent. Agent mode reemplaza y supera Edit: puede editar múltiples archivos, ejecutar el terminal y autocorregirse. Si ves documentación antigua que menciona "Edit mode", está desactualizada.

### "Plan mode no me aparece en VS Code, ¿qué hago?"

Comprueba la versión de la extensión GitHub Copilot (≥ 1.250) y de VS Code (≥ 1.95). Si sigues sin verlo, Plan mode podría estar en rollout gradual — usa el fallback del Lab 2 (Agent + "planifica sin implementar"). El comportamiento es idéntico, solo falta el botón de aprobación explícito.

### "¿Puedo usar estos prompts en código de producción real en lugar de la app de ejemplo?"

Sí, y es lo recomendable. Los prompts del taller son intencionadamente genéricos (`#codebase describe la arquitectura`) para que funcionen en cualquier proyecto. La app de ejemplo existe para que tengáis un terreno seguro donde experimentar sin miedo a romper nada.

### "¿Copilot envía mi código a Microsoft/GitHub?"

El código se envía a los servidores de GitHub para procesar el prompt y generar la respuesta. Si tu organización tiene contrato enterprise, los datos no se usan para entrenar modelos. Si tienes dudas sobre la política de datos de tu empresa, consulta a tu equipo de seguridad antes de usar `#codebase` con código sensible. Para esta sesión de formación, la app de ejemplo no contiene datos reales.

---

## Frase de cierre

> "GitHub Copilot no escribe código por vosotros — os da velocidad en la parte que menos valor aporta: la sintaxis. La arquitectura, las decisiones, la revisión: eso sigue siendo vuestro trabajo. Lo que cambia es que ahora podéis llegar a esa parte más rápido."

---

## Checklist pre-sesión (para el formador)

Verifica esto 30 minutos antes:

- [ ] VS Code abierto en `sample-app/backend/TaskManager.Api` (no en la raíz)
- [ ] `dotnet build` pasa sin errores
- [ ] Extensión GitHub Copilot versión ≥ 1.250
- [ ] Autenticado en GitHub Copilot
- [ ] Plan mode visible en el selector de modo del chat
- [ ] Terminal integrado abierto y limpio
- [ ] `git status` muestra estado limpio
- [ ] Pantalla duplicada o compartida lista para demos
- [ ] `cheatsheet.md` abierto en una pestaña del navegador para el cierre
- [ ] Pizarra/rotuladores disponibles para los diagramas

---

## Extra Labs — Guion para sesiones ampliadas

Usa esta sección si quedan ≥ 20 minutos después del Bloque 5, o en una sesión separada de seguimiento.

### Lab 5 — Copilot Instructions & el poder del `.github`

**Material**: `labs/05-copilot-instructions/README.md`  
**Duración**: 20 min (ejercicios básicos) · hasta 60 min (con sección avanzada)

#### Gancho de apertura

> "¿Os ha pasado que Copilot genera código que no sigue vuestros estándares? `DateTime.Now` en lugar de `DateTimeOffset.UtcNow`, propone instalar paquetes que no queréis... Hay una solución que tarda 5 minutos en configurarse y beneficia a todo el equipo. Abrid el Lab 5."

#### Estructura del lab (versión 20 min)

| Parte | Min | Qué hace el formador |
|-------|-----|----------------------|
| Motivación | 2 | Demo en vivo: mismo prompt sin/con instrucciones, resultado diferente |
| Ejercicio 1 | 5 | Camina por la sala, ayuda a copiar la plantilla |
| Ejercicio 2 | 5 | Para al grupo cuando alguien ve la diferencia — la muestra en pantalla |
| Más allá (mapa) | 8 | Explica el mapa del `.github` en pantalla, señala lo que ya tienen (PR template) |

#### Estructura del lab (versión 60 min)

Añade el Ejercicio 3 (instrucciones path-specific, 10 min) y profundiza en cada elemento del mapa `.github` con demos en vivo:
- Activa el `pull_request_template.md` del repo en una demo en GitHub.com
- Muestra un `CODEOWNERS` real de un proyecto conocido
- Enseña el workflow de CI (`workflows/ci.yml`) y conecta con el `dotnet build` de copilot-instructions

#### Puntos de debate para el grupo

- "¿Qué reglas de vuestro equipo llevaríais al `copilot-instructions.md`?"
- "¿Quién debería ser el dueño de este archivo? ¿Uno solo o todo el equipo?"
- "¿Cómo combinaríais esto con vuestro proceso de code review actual?"

#### Cierre del Lab 5

> "Un solo archivo, commiteado en el repo, que hace que Copilot conozca vuestros estándares, que los PRs tengan siempre la misma estructura, y que los revisores correctos sean asignados automáticamente. El `.github` no es burocracia — es la memoria de vuestro equipo."

---

### Lab 6 — Custom Agents & Prompt Files

**Material**: `labs/06-custom-agents/README.md`  
**Duración**: 30 min (agentes + prompt files) · hasta 90 min (con extensión TypeScript)

#### Gancho de apertura

> "El Lab 5 le enseñó a Copilot vuestros estándares. El Lab 6 va un paso más allá: vais a crear vuestros propios agentes especializados. Un revisor de código que conoce exactamente vuestras reglas. Un planificador que analiza el impacto antes de tocar código. Un especialista en tests que siempre usa xUnit y Moq. Nada de código TypeScript — solo archivos Markdown."

#### Estructura del lab (versión 30 min)

| Parte | Min | Qué hace el formador |
|-------|-----|----------------------|
| Nivel 1: Prompt files | 10 | Demo de `/nuevo-endpoint` — activa la plantilla, prueba en vivo |
| Nivel 2: 3 agentes | 15 | Activa los agentes, demuestra `revisor` → handoff → `copilot` |
| Encadenamiento | 5 | Muestra el flujo completo: `planificador` → `revisor` → `copilot` |

#### Puntos clave para enfatizar

- **Sin código**: todo son archivos `.md` en `.github/agents/` y `.github/prompts/`
- **Handoffs**: el contexto pasa automáticamente entre agentes — el desarrollador solo aprueba cada paso
- **Herramientas**: puedes restringir qué puede hacer cada agente (leer/escribir/ejecutar)
- **Portable**: se comparte con todo el equipo via git, como cualquier otro archivo

#### Demo estrella: el flujo completo

Muestra este flujo en pantalla completa:

```
1. [planificador] "Añadir campo Priority a las tareas"
2. → Lee el plan → pulsa "Implementar"
3. [copilot] Implementa → builds OK
4. [tester] "Tests para los cambios de Priority"
5. → Tests generados con naming correcto y casos completos
```

Total: ~5 minutos de trabajo real. "En un equipo sin Copilot, esto son 2 horas."

#### Actividad para los participantes (10 min al final)

> "Tenéis 10 minutos para diseñar vuestro propio agente usando el template del lab. Pensad en un problema real de vuestro equipo — un tipo de revisión que siempre hacéis, una tarea repetitiva, un check que os olvidáis... Escribidlo. Al final, quien quiera lo comparte."

#### Cierre del Lab 6

> "Los custom agents son la diferencia entre 'Copilot que genera código genérico' y 'Copilot que trabaja exactamente como trabaja vuestro equipo'. No requieren código, no requieren despliegue. Solo un archivo Markdown en `.github/agents/` — y todo el equipo tiene el mismo especialista disponible desde el primer `git pull`."
