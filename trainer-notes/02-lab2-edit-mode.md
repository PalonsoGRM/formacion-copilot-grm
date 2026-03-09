# Notas del formador — Lab 2: Edit Mode (10:30–11:15)

## Objetivo del bloque
Los participantes deben aprender a hacer cambios controlados y multi-archivo usando Edit mode, con un working set explícito y restricciones claras en el prompt.

---

## Timing orientativo

| Tiempo | Actividad |
|---|---|
| 10:30–10:40 | Intro a Edit mode + diferencias vs Ask (slide 02) |
| 10:40–11:00 | Ejercicios 1 y 2 (DateTime + magic strings) |
| 11:00–11:10 | Ejercicio 3 si el tiempo lo permite |
| 11:10–11:15 | Cierre y reflexión |

---

## Diferencia clave a enfatizar

> "Ask te dice qué hay que cambiar. Edit lo cambia. La diferencia es el working set."

Dibuja en pizarra o muestra en vivo:

```
Working set = los archivos que Copilot PUEDE modificar

Sin working set → Copilot modifica lo que quiera
Con working set → Copilot solo toca los archivos que tú le das
```

---

## Demo antes del Ejercicio 1

Muestra cómo añadir archivos al working set:
1. Abre Edit mode (icono del lápiz o `Ctrl+Shift+Alt+I` en VS Code)
2. Arrastra `Models/TaskItem.cs` y `Models/Project.cs` al panel del working set
3. Escribe el prompt:
   ```
   Replace all occurrences of DateTime.Now with DateTimeOffset.UtcNow.
   Do not change any other logic.
   ```
4. Muestra el diff — insiste en **revisar antes de aceptar**.

**Punto importante**: muestra que el diff tiene los cambios exactos prometidos y nada más. Eso es el working set funcionando.

---

## Señales de éxito en el lab

- Los participantes ven el diff y lo revisan antes de aceptar (no solo presionan "Accept all")
- Alguien nota que el cambio de DateTime afecta también al serializado JSON — buen debate
- En el Ejercicio 2 (magic strings → constantes), Copilot puede proponer un enum en lugar de constantes — déjales debatir cuál es mejor

---

## Errores comunes a vigilar

- **Working set vacío**: el participante escribe el prompt sin añadir archivos → Copilot o falla o toca archivos al azar. Recuérda les que arrastren los archivos primero.
- **Prompt demasiado vago** ("mejora este código") → Copilot hace refactors grandes que el participante no esperaba. Corrígelo en tiempo real: "más restrictivo en el prompt".

---

## Preguntas frecuentes

**"¿Puedo añadir toda la carpeta al working set?"**  
Técnicamente sí, pero no es recomendable para cambios quirúrgicos. Cuanto más grande el working set, más probable que Copilot toque algo inesperado. Para cambios globales, Agent mode es mejor.

**"¿Qué pasa si acepto algo que no quería?"**  
`Ctrl+Z` deshace los cambios de Copilot como cualquier otra edición. Y el proyecto usa git (al final del día) así que siempre hay red de seguridad.
