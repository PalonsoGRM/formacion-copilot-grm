# Notas del formador — Lab 3: Agent Mode (11:15–12:00)

## Objetivo del bloque
Los participantes deben experimentar la diferencia entre dar una instrucción de alto nivel a Agent mode y ver cómo Copilot razona, navega el código y ejecuta pasos encadenados de forma autónoma.

---

## Timing orientativo

| Tiempo | Actividad |
|---|---|
| 11:15–11:25 | Intro a Agent mode (slide 03) — qué lo diferencia de Edit |
| 11:25–11:50 | Ejercicios del lab (endpoint de vencidas + README) |
| 11:50–12:00 | Puesta en común y cierre |

---

## Mensaje principal

> "En Edit mode tú controlas el working set. En Agent mode, Copilot decide qué archivos tocar. El precio de esa autonomía es que debes dar un prompt más preciso y revisar el resultado con más cuidado."

---

## Demo antes del lab

Abre Agent mode en VS Code (icono del robot o `Ctrl+Shift+Alt+I` → cambia a Agent).

Escribe en vivo:
```
Add a new GET endpoint /api/tasks/overdue that returns all tasks
where DueDate is in the past and Status is not Done.
Follow the existing patterns in TasksController.cs.
Do not modify any existing endpoints.
```

Deja que Copilot ejecute. Comenta en voz alta:
- "Está buscando los modelos para entender la estructura"
- "Ahora está leyendo el controlador existente para seguir el patrón"
- "Propone el nuevo método — lo reviso antes de aceptar"

**Punto a remarcar**: Agent mode puede pedir permiso para ejecutar comandos de terminal (`dotnet build`). Muestra que aparece un cuadro de confirmación y que el formador decide si aprobar o no.

---

## Ejercicio 2: README con Agent mode

El segundo ejercicio (generar el README del proyecto con Agent mode) suele sorprender a los participantes porque el resultado es un documento largo y bastante preciso con muy poco esfuerzo.

Prompt guía:
```
Generate a README.md for this project that includes:
- Project description and purpose
- Architecture overview (layers, key components)
- Setup and run instructions
- Available API endpoints with example requests
- Known limitations and TODOs
```

Después del lab, muestra el README generado y pide al grupo: "¿Qué cambiaríais o añadiríais?"

---

## Señales de éxito

- Alguien nota que Agent mode también puede romper cosas — buen momento para hablar de tests
- El grupo empieza a discutir qué nivel de autonomía es cómodo para su equipo

---

## Preguntas frecuentes

**"¿Agent mode tiene acceso a internet o bases de datos?"**  
Por defecto, no. Solo tiene acceso al workspace local, terminal y las herramientas del IDE. Se puede ampliar con MCP servers, pero eso no es parte del lab de hoy.

**"¿Cómo sé que no ha roto algo?"**  
Buena pregunta — la respuesta profesional es: con tests. Por eso el siguiente paso natural después de Agent mode es pedirle que genere tests para el código que acaba de escribir.

**"¿Es lo mismo que GitHub Copilot Workspace?"**  
No. Copilot Workspace (github.com) trabaja a nivel de issues/PR en el navegador. Agent mode en VS Code trabaja sobre tu workspace local con acceso al terminal.
