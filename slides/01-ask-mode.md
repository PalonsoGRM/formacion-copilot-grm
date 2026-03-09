# Slide deck: Ask Mode — Explorar y entender código

---

## ¿Qué es Ask mode?

- Conversación con Copilot sobre tu código
- **No modifica ningún archivo**
- Ideal para entender, explorar, aprender y planear
- Soporta `@workspace`, `#file`, `/slash commands`

---

## Cuándo usar Ask

| Situación | Prompt |
|---|---|
| Llego a un proyecto nuevo | `@workspace explica la arquitectura general` |
| No entiendo un método | `#TasksController.cs /explain el método CreateTask` |
| Quiero saber qué hace una clase | `#TaskRepository.cs ¿qué patrón de diseño usa esta clase?` |
| Busco un bug | `@workspace ¿dónde se podría producir un NullReferenceException?` |
| Quiero mejorar código | `#TasksController.cs ¿qué mejorarías en este controlador?` |

---

## Participantes especiales

### `@workspace`
Copilot analiza **todos los archivos indexados del proyecto**.  
Perfecto para preguntas de arquitectura y navegación.

> **Requisito previo**: abre la carpeta raíz del proyecto (no un archivo suelto).  
> Si Copilot no "ve" todos los archivos, ejecuta:  
> `Ctrl+Shift+P → "GitHub Copilot: Index Workspace"`  
> Equivalente moderno con variable `#`: usa **`#codebase`** en lugar de `@workspace`.

```
@workspace ¿qué endpoints expone la API y qué modelos usan?
```

### `@github`
Accede a búsqueda de repositorios, PRs, issues de GitHub.

```
@github busca ejemplos de middleware de autenticación en este repo
```

---

## Slash commands más útiles

| Comando | Qué hace |
|---|---|
| `/explain` | Explica el código seleccionado o el archivo |
| `/fix` | Sugiere corrección para un error |
| `/tests` | Propone tests unitarios |
| `/help` | Muestra ayuda de Copilot |

> **Nota sobre `/doc`**: este comando fue eliminado de Copilot Chat.  
> Para generar documentación XML/JSDoc usa:  
> - Click derecho sobre el archivo → **Copilot → Generate Docs** (Smart Action)  
> - O en el chat inline: `Add XML documentation comments to all public members`

---

## Demo en vivo

1. Abrir `sample-app/backend/` en VS Code
2. Abrir Copilot Chat (`Ctrl+Alt+I`)
3. Ejecutar: `@workspace describe la estructura de este proyecto`
4. Navegar a `TasksController.cs` y ejecutar `/explain`
5. Preguntar: `¿qué validaciones faltan en los endpoints POST?`

---

## Ahora tú — Lab 1

Ver instrucciones en `labs/01-ask-mode/README.md`

Tiempo: **20 minutos**
