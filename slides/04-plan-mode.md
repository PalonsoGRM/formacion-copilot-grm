# Slide deck: Plan Mode — Diseña antes de codear

---

## ¿Qué es Plan mode?

- Agente de **solo lectura**: analiza, pero no toca nada
- Genera un plan estructurado con pasos, preguntas abiertas y riesgos
- Cuando apruebas el plan → lo pasa a Agent mode para implementar
- Ideal para tareas grandes donde quieres entender el alcance antes de comprometerte

---

## Plan mode vs Agent mode directo

| Plan mode | Agent mode directo |
|---|---|
| Primero planifica, luego pregunta | Empieza a implementar directamente |
| Expone ambigüedades antes de actuar | Puede hacer asunciones silenciosas |
| Menor riesgo de sorpresas | Más rápido para tareas pequeñas |
| Ideal para features grandes o refactors amplios | Ideal para tareas bien definidas y acotadas |

---

## Flujo de Plan mode

```
1. Copilot Chat → selecciona modo "Plan"
2. Describe la tarea en lenguaje natural
3. Copilot explora el codebase (solo lectura)
4. Genera plan con:
   - Lista de archivos a crear/modificar
   - Pasos ordenados
   - Preguntas sobre ambigüedades
   - Posibles riesgos
5. Tú revisas el plan y contestas las preguntas
6. "Start Implementation" → pasa a Agent mode
```

---

## Ejemplo

### Prompt
```
Quiero añadir un sistema de notificaciones para avisar a los usuarios
cuando se les asigna una tarea. Necesito un endpoint en la API,
persistencia y un componente Angular que muestre las notificaciones
en tiempo real. Planifica el trabajo antes de implementar nada.
```

### Lo que Plan mode devuelve
- Lista de cambios necesarios en backend y frontend
- Preguntas: "¿SignalR o polling? ¿Persistes en base de datos o solo en memoria?"
- Estimación de archivos afectados
- Posibles conflictos con el código existente

---

## Relación con OpenCode

OpenCode tiene el mismo concepto con el toggle **Plan / Build**:

```
Tab → alterna entre Plan mode (solo lectura) y Build mode (escribe código)
```

Lo veremos en detalle en el bloque de tarde.

---

## Demo en vivo

**Tarea**: Planificar la migración del repositorio in-memory de TaskManager a una base de datos real con EF Core + SQLite.

1. Plan mode → prompt de migración
2. Revisar el plan generado
3. Responder las preguntas de Copilot
4. Observar cómo el plan se refina
5. (Opcional) Start Implementation → Agent mode
