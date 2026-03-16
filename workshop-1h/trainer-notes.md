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
| Cierre + cheatsheet | 00:50 – 01:00 | 10 min | Discusión en grupo |

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

## Bloque 4: Cierre + Cheatsheet (00:50 – 01:00)

### Objetivo del bloque
Consolidar el aprendizaje, resolver dudas y dejar a los participantes con un recurso práctico para el día a día.

### Guion verbal

**00:50** — Abre `cheatsheet.md` en pantalla y dale un minuto al grupo para leerlo.

**00:51** — Repaso del árbol de decisión:

> "Este árbol es lo que necesitáis saber. Ask para entender, Plan para diseñar, Agent para implementar, selección en el editor para dar contexto rápido sin pegar código. El flujo completo es: Ask → Plan → Agent → Ask de nuevo para los tests."

**00:53** — Preguntas abiertas. Lanza estas si no hay preguntas espontáneas:

- "¿Cuál de los tres modos creéis que vais a usar más la semana que viene?"
- "¿Qué prompt del Lab 1 os ha parecido más útil?"

**00:56** — FAQs rápidas (ver sección siguiente).

**00:58** — Frase de cierre (ver al final del documento).

**01:00** — Fin.

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
