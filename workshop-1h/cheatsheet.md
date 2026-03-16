# Cheatsheet — GitHub Copilot Refresher

> Referencia rápida para llevarte a casa. Imprime o abre en pantalla secundaria mientras trabajas.

---

## Árbol de decisión: ¿qué modo uso?

```
¿Qué necesito hacer?
│
├── Entender código, hacer preguntas, revisar, buscar bugs
│   └──► ASK mode
│
├── Planificar una feature nueva o refactor con impacto en varios archivos
│   └──► PLAN mode  (revisa el plan → aprueba → pasa a Agent automáticamente)
│
├── Implementar: crear/modificar archivos, ejecutar terminal, ciclo autónomo
│   └──► AGENT mode
│
└── Acción rápida sobre código seleccionado en el editor
    └──► Seleccionar código → abrir Copilot Chat → el fragmento aparece como contexto automáticamente
```

**Flujo recomendado para features nuevas**:

```
Ask (#codebase, entiende el contexto)
  → Plan (diseña, revisa, aprueba)
    → Agent (implementa)
      → Ask (/tests, genera tests para lo implementado)
```

---

## Variables de contexto

| Variable | Cuándo usarla | Ejemplo |
|----------|--------------|---------|
| `#codebase` | Preguntas sobre el proyecto en general | `#codebase ¿qué patrones de error handling se usan?` |
| `#NombreArchivo.cs` | Pregunta concreta sobre un archivo | `#TasksController.cs ¿qué endpoints no tienen validación?` |
| `#selection` | Código seleccionado en el editor activo | `#selection ¿este método puede lanzar una NullReferenceException?` |
| `#terminalLastCommand` | Último output del terminal integrado | `#terminalLastCommand explica el error y cómo lo corrijo` |

> **`@workspace` ya no existe.** Si lo escribes, Copilot devuelve un error. Usa `#codebase` en su lugar.

---

## Comandos de slash activos

| Comando | Qué hace | Modo |
|---------|----------|------|
| `/explain` | Explica el código seleccionado o pegado | Ask / Agent |
| `/fix` | Corrige un problema en el código | Ask / Agent |
| `/tests` | Genera tests unitarios | Ask / Agent |

> **`/doc` ha sido eliminado.** Alternativa:
> - Clic derecho en el editor → *Copilot* → *Generate Docs*

---

## Top 5 prompts para el día a día

Todos usan `#codebase` o `#file` — ninguno usa `@workspace`.

### 1. Entender un proyecto desconocido
```
#codebase describe la arquitectura: capas, patrones, flujo de una petición.
¿Qué deuda técnica evidente hay?
```

### 2. Revisión de código antes de hacer PR
```
#TasksController.cs
Revisa como senior developer: validación, manejo de errores,
seguridad, consistencia con el resto del codebase.
Dame una lista priorizada de problemas.
```

### 3. Feature nueva sin sorpresas
```
[Plan mode]
Quiero añadir [FEATURE]. Analiza los archivos afectados
y dame un plan paso a paso antes de escribir código.
```

### 4. Generar tests para código existente
```
[Selecciona el método en el editor]
[Abre Copilot Chat]
"genera tests unitarios para este método"
```
O con más detalle desde el chat:
```
#TasksController.cs
Genera tests unitarios para el método Create usando xUnit y Moq.
Incluye: caso feliz, título vacío, ProjectId inexistente, error de base de datos.
```

### 5. Depurar un error de terminal
```
[Ejecuta el comando que falla]
#terminalLastCommand
¿Cuál es la causa raíz y cuál es la corrección mínima?
```

---

## Selección de código como contexto

Cuando seleccionas código en el editor y abres Copilot Chat, el fragmento seleccionado aparece referenciado automáticamente en el campo de entrada. También puedes forzarlo escribiendo `#selection` en el chat.

| Acción | Cómo hacerlo |
|--------|-------------|
| Explicar un bloque de código | Seleccionar → abrir chat → "explica qué hace esto" |
| Encontrar un bug en la selección | Seleccionar → abrir chat → "¿hay algún problema en este código?" |
| Generar tests de un método | Seleccionar → abrir chat → "genera tests unitarios para este método" |
| Documentar un método | Seleccionar → clic derecho → *Copilot* → *Generate Docs* |

**Activar**: selecciona el código en el editor y abre Copilot Chat (`Ctrl+Alt+I`).

---

## Referencia de modos

| | Ask | Plan | Agent |
|--|-----|------|-------|
| Lee archivos | ✓ | ✓ | ✓ |
| Modifica archivos | ✗ | ✗ | ✓ |
| Ejecuta terminal | ✗ | ✗ | ✓ (con aprobación) |
| Paso de aprobación | N/A | Antes de implementar | Antes de cada cambio |
| Ideal para | Preguntar, explorar | Planificar features | Implementar |

---

[← Lab 3: Agent/Build](labs/03-agent-build/README.md) | [→ Volver al índice](README.md)
