# Notas del formador — Lab 1: Ask Mode (09:30–10:15)

## Objetivo del bloque
Los participantes deben terminar este lab siendo capaces de usar Copilot Ask para orientarse en un proyecto desconocido sin tocar ningún archivo.

---

## Timing orientativo

| Tiempo | Actividad |
|---|---|
| 09:30–09:40 | Demo en vivo de Ask mode (slide 01) |
| 09:40–10:00 | Trabajo individual/en parejas en los 4 ejercicios |
| 10:00–10:10 | Puesta en común: ¿qué encontró Copilot? |
| 10:10–10:15 | Cierre y transición al break |

---

## Demo en vivo antes del lab

Abre `sample-app/backend/` en VS Code y ejecuta delante del grupo:

1. `@workspace describe la estructura de este proyecto`  
   → Copilot debe identificar: API REST, EF Core InMemory, 3 controladores, 3 modelos.

2. Navega a `TasksController.cs`, selecciona todo, escribe `/explain`  
   → Muestra que `/explain` es un atajo que funciona sin escribir un prompt largo.

3. Pregunta: `#TasksController.cs ¿qué validaciones faltan en los endpoints POST?`  
   → Copilot debe mencionar: sin `[Required]`, sin manejo de null, sin autenticación.

**Pausa antes de la pregunta 3** y di: "¿Alguien quiere adivinar qué va a responder?"  
Genera expectativa antes de ejecutar.

---

## Nota sobre `@workspace`

Antes de que los participantes empiecen, recuerda:
- Deben haber abierto la **carpeta** `TaskManager.Api` (no un archivo suelto)
- Si `@workspace` no devuelve respuestas sobre el proyecto, ejecutar: `Ctrl+Shift+P → "GitHub Copilot: Index Workspace"`
- La alternativa moderna es `#codebase` — funciona igual sin necesidad de indexar manualmente en las versiones más recientes

---

## Puntos a observar durante el lab

- **Ejercicio 1**: Copilot a veces no menciona los defectos (DateTime.Now, magic strings) espontáneamente — está bien, es el objetivo del Ejercicio 3.
- **Ejercicio 3**: Aquí es donde la mayoría "enciende" — Copilot encuentra los magic strings y las DateTime.Now sin que nadie se los diga explícitamente.
- **Ejercicio 4**: Algunos querrán aceptar los XML docs generados. Recuérda les que no: se revisará en el bloque de documentación de la tarde.

---

## Discusión de cierre (10 min)

Preguntas guía para la puesta en común:
- "¿Qué encontró Copilot que vosotros no habíais notado al ojear el código?"
- "¿En qué proyecto real de vuestro equipo haríais este análisis primero?"
- "¿Alguien consiguió que Copilot encontrara algo que no habíamos puesto como defecto intencionado?"  
  (A veces los participantes descubren problemas reales — celébralo.)

---

## Preguntas frecuentes

**"¿Por qué no usa el contexto completo? Solo responde sobre un archivo."**  
`@workspace` usa indexación semántica, no lee todos los archivos en cada prompt. Para preguntas sobre un archivo concreto, `#archivo.cs` es más preciso y eficiente.

**"¿Puedo usar esto con mi propio proyecto del trabajo?"**  
Sí. Cualquier carpeta que abran en VS Code con la extensión Copilot funciona igual. El contexto es local.
