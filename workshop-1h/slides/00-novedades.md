# Novedades de GitHub Copilot — Refresher (5 min)

> Diapositivas de apoyo para el bloque inicial. El formador las usa como guion visual; los participantes las tienen como referencia escrita.

---

## Slide 1 — Lo que cambió: antes vs. ahora

| Antes | Ahora | Impacto |
|-------|-------|---------|
| `@workspace` en el chat | `#codebase` | Misma función, nueva sintaxis |
| Modo **Edit** | Modo **Agent** (GA) | Edit desaparece; Agent es más potente |
| Plan mode = workaround en Agent | **Plan mode GA** (modo propio) | Primero planifica, luego ejecuta |
| Sin contexto preciso de archivo | `#file`, `#selection`, `#terminalLastCommand` | Precisión quirúrgica en las preguntas |
| Copiar código en el chat manualmente | Seleccionar código en el editor → referencia automática en el chat | Copilot ve exactamente el fragmento que tienes seleccionado |

> **Mensaje clave**: la dirección es hacia más control del desarrollador, no menos.

---

## Slide 2 — Variables de contexto

Estas variables se añaden directamente en el prompt del chat para dar contexto preciso a Copilot.

| Variable | Qué hace | Ejemplo de uso |
|----------|----------|----------------|
| `#codebase` | Analiza todo el codebase indexado (reemplaza `@workspace`) | `#codebase ¿qué patrones de error handling se usan?` |
| `#file` | Adjunta un archivo específico al contexto | `#TasksController.cs ¿qué endpoints devuelven 404?` |
| `#selection` | Usa el texto seleccionado en el editor activo | Selecciona un método → `#selection explica la lógica de negocio` |
| `#terminalLastCommand` | Adjunta la última salida del terminal | Tras un error de build → `#terminalLastCommand ¿cómo lo corrijo?` |

### Cuándo usar cada una

```
Pregunta general sobre el proyecto   →  #codebase
Pregunta sobre un archivo concreto   →  #NombreArchivo.cs
Pregunta sobre código seleccionado   →  #selection  (selecciona en el editor, luego escríbelo en el chat)
Error en terminal                    →  #terminalLastCommand
```

---

## Slide 3 — Selección de código como contexto

Cuando tienes código seleccionado en el editor y abres Copilot Chat, ese fragmento se incluye automáticamente como contexto en el chat. No hace falta copiar ni pegar nada.

### Cómo funciona

```
1. Selecciona el código que te interesa en el editor
         ↓
2. Abre Copilot Chat (Ctrl+Alt+I) — el fragmento seleccionado
   aparece referenciado en el campo de entrada
         ↓
3. Escribe tu pregunta directamente:
       "explica qué hace este método"
       "¿puede lanzar una NullReferenceException?"
       "genera tests unitarios para esto"
```

> La selección es el contexto. Cuanto más precisa sea (un método, un bloque, una línea), más útil será la respuesta.

---

## Slide 4 — Los tres modos: recordatorio rápido

```
┌─────────────────────────────────────────────────────────────────┐
│                    MODOS DE GITHUB COPILOT                      │
├──────────────┬──────────────────────┬───────────────────────────┤
│   ASK        │   PLAN               │   AGENT                   │
│              │                      │                           │
│  Preguntas   │  Diseña el plan      │  Ejecuta cambios          │
│  Exploración │  antes de tocar      │  en múltiples archivos    │
│  Análisis    │  código              │  con autonomía            │
│              │                      │                           │
│  Solo lee    │  Solo propone        │  Lee + escribe + ejecuta  │
│  No modifica │  No modifica         │  Puede ejecutar terminal  │
├──────────────┴──────────────────────┴───────────────────────────┤
│  Flujo recomendado:  Ask → Plan → Agent → Ask (/tests)          │
└─────────────────────────────────────────────────────────────────┘
```

### Cuándo cambiar de modo

- **Ask**: entender, explorar, resolver dudas, revisar código
- **Plan**: antes de cualquier feature nueva o refactor significativo
- **Agent**: implementar lo que el plan ya definió

---

## Slide 5 — ¿Cuándo te ayuda en el día a día?

Cinco escenarios reales que verás en esta sesión:

### 1. Código legacy que nadie entiende
```
#codebase explica la arquitectura de TaskManager.Api:
capas, patrones usados y dependencias entre componentes
```
→ En 30 segundos tienes un mapa mental del proyecto.

### 2. Nueva funcionalidad con impacto desconocido
```
[Plan mode]
Quiero añadir paginación a GET /api/tasks.
Analiza los archivos afectados y dame un plan
paso a paso antes de escribir código.
```
→ Sabes exactamente qué va a tocar antes de que lo toque.

### 3. Revisión de código en PR
```
#TasksController.cs
Revisa este controller como si fuera una PR review:
busca problemas de validación, seguridad y consistencia.
```
→ Segunda opinión inmediata sin esperar a un compañero.

### 4. Generación de tests
```
[Selecciona el método Create() en TasksController.cs]
[Abre Copilot Chat]
"genera tests unitarios para este método"
```
→ Tests unitarios con casos edge en segundos, sin pegar código.

### 5. Error misterioso en el terminal
```
[Ejecutas dotnet build y falla]
#terminalLastCommand
¿Cuál es la causa del error y cómo lo corrijo?
```
→ Sin necesidad de copiar y pegar el stack trace manualmente.

---

[← Volver al índice](../README.md) | [→ Lab 1: Ask Actualizado](../labs/01-ask-actualizado/README.md)
