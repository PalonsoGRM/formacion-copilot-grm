# GitHub Copilot en el IDE (45 min)

> **Bloque**: 09:15 – 10:10 · Sesión formativa IA — 23/25 marzo 2026  
> **Asume**: extensión instalada y cuenta activa. Si no, ver [PREREQUISITES.md](../PREREQUISITES.md).

---

## Bloque 1 — La herramienta (15 min)

### ¿Qué es GitHub Copilot?

GitHub Copilot es un asistente de IA integrado en tu IDE que ayuda a escribir, entender, revisar y probar código. No es autocompletado tradicional — usa LLMs para entender el contexto de tu proyecto y generar código coherente con lo que ya tienes.

**Dónde vive Copilot:**

| Surface | Qué puedes hacer |
| ------- | ---------------- |
| **VS Code / IDE** | Completado inline, chat, agentes, revisión de código |
| **GitHub.com** | Code review en PRs, Copilot Workspace, chat en la web |
| **GitHub Pull Requests** | Revisión automática, sugerencias en el diff |
| **GitHub Mobile** | Chat desde el móvil |

---

### La extensión en VS Code

Una vez instalada, Copilot vive en la **barra de estado** (esquina inferior derecha). El icono te indica si está conectado y activo:

![Icono de Copilot en la barra de estado de VS Code](https://code.visualstudio.com/assets/docs/copilot/setup/setup-copilot-status-bar.png)

Desde ese mismo icono puedes activar o desactivar las sugerencias inline, pausarlas temporalmente ("Snooze"), o desactivarlas para un lenguaje concreto:

![Menú de Copilot en la barra de estado con opciones de activación y pausa](https://code.visualstudio.com/assets/docs/copilot/inline-suggestions/snooze-code-completions.png)

---

### Los modelos disponibles y qué significa 0x / 1x / 3x

En el selector de modelos del chat verás un multiplicador junto a cada nombre. Este número indica el **coste en "premium requests"** por cada interacción:

| Multiplicador | Significado |
| :-----------: | ----------- |
| **0x** | Gratuito — no consume cuota premium. Modelo base rápido, para tareas sencillas. |
| **1x** | 1 premium request por interacción. Equilibrio velocidad/calidad. |
| **3x** | 3 premium requests por interacción. Modelos de razonamiento profundo o mayor contexto. |

> En cuentas **Business o Enterprise** (como la vuestra) **no hay límite de premium requests** — el multiplicador es puramente informativo. Usad el modelo que mejor se adapte a la tarea.

**Recomendación práctica:**

- Día a día y tareas de código: modelos `1x` — rápidos y precisos
- Arquitectura, análisis complejo, planificación: modelos `3x`
- Completado inline (ghost text): usa un modelo a parte, configurable independientemente del chat

![Selector de modelos en el panel de chat de VS Code](https://code.visualstudio.com/assets/docs/copilot/chat/copilot-chat/chat-model-picker.png)

---

> **One Does Not Simply...** buscar en Stack Overflow 40 minutos cuando tienes `#codebase ¿qué patrón usa este código?`

---

## Bloque 2 — Funcionalidades básicas (15 min)

### Ghost Text — completado inline

Copilot sugiere código conforme escribes, como texto gris ("ghost text") que puedes aceptar o ignorar. No necesitas hacer nada para activarlo — aparece solo.

![Sugerencia inline clásica en JavaScript](https://code.visualstudio.com/assets/docs/copilot/inline-suggestions/js-suggest.png)

**Atajos clave:**

| Acción | Atajo |
| ------ | ----- |
| Aceptar toda la sugerencia | `Tab` |
| Aceptar palabra a palabra | `Ctrl+→` |
| Descartar | `Esc` |
| Ver sugerencias alternativas | Hover sobre el ghost text |

Con hover sobre el ghost text puedes navegar entre las alternativas que ha generado Copilot para la misma posición:

![Hover sobre sugerencia inline para ver alternativas](https://code.visualstudio.com/assets/docs/copilot/inline-suggestions/copilot-hover-highlight.png)

---

### Next Edit Suggestions (NES) — el siguiente edit, no solo el actual

NES va más allá del completado en cursor: **predice dónde vas a editar a continuación** y qué cambio deberías hacer, basándose en lo que estás modificando ahora mismo.

Una flecha en el gutter indica que hay una sugerencia de edición esperándote. `Tab` navega hasta ella y la acepta:

![Flecha en el gutter indicando una Next Edit Suggestion con menú expandido](https://code.visualstudio.com/assets/docs/copilot/inline-suggestions/gutter-menu-highlighted-updated.png)

**Casos de uso típicos:**

Renombraste una función → NES sugiere actualizar todas las referencias en cascada:

![NES sugiriendo actualizar un nombre de función en cascada](https://code.visualstudio.com/assets/docs/copilot/inline-suggestions/nes-rename.png)

Typo en una keyword → NES lo detecta y propone la corrección sin que lo pidas:

![NES corrigiendo un typo "conts" a "const"](https://code.visualstudio.com/assets/docs/copilot/inline-suggestions/nes-typo.png)

> **Activar NES**: `github.copilot.nextEditSuggestions.enabled = true` en Settings.

---

### Inline Chat — edita sin salir del editor

`Ctrl+I` abre un mini-chat embebido directamente en el editor, en la línea donde tienes el cursor. Describes el cambio y Copilot lo aplica en el mismo sitio, sin abrir el panel lateral.

Ideal para: refactors puntuales, añadir un `try/catch`, cambiar el tipo de retorno de un método, o pedir una explicación de una línea concreta.

---

### Smart Actions — sin prompt, clic derecho

Para las acciones más comunes no necesitas escribir nada. **Clic derecho → menú Copilot:**

![Sparkle icon y menú contextual de Copilot para Fix y Explain](https://code.visualstudio.com/assets/docs/copilot/copilot-smart-actions/copilot-code-action-fix.png)

| Acción | Cómo acceder |
| ------ | ------------ |
| **Explain** | Clic derecho → Copilot → Explain |
| **Fix** | Clic derecho → Fix, o sparkle ✨ junto a errores de compilación |
| **Generate Docs** | Clic derecho → Generate Code → Generate Docs |
| **Generate Tests** | Clic derecho → Generate Code → Generate Tests |
| **Review** | Clic derecho → Generate Code → Review |

Generar documentación XML directamente desde el clic derecho (reemplaza el antiguo `/doc` del chat):

![Inline chat generando documentación XML para una clase](https://code.visualstudio.com/assets/docs/copilot/copilot-smart-actions/inline-chat-doc-example.png)

Cuando un comando falla en el terminal, aparece un sparkle ✨ en el gutter — clic → explica el error y propone la corrección:

![Sparkle en el terminal tras un comando fallido con la opción Fix with Copilot](https://code.visualstudio.com/assets/docs/copilot/copilot-smart-actions/terminal-command-explanation.png)

Copilot también genera **commit messages** automáticamente basándose en los cambios del staging:

![Botón de generar commit message en Source Control](https://code.visualstudio.com/assets/docs/copilot/copilot-smart-actions/generate-commit-message.png)

---

### El Panel de Chat — interfaz completa

`Ctrl+Alt+I` abre el panel de chat completo. Desde aquí accedes a todas las capacidades: conversación multi-turno, selección de agente y modelo, y contexto explícito con `#`.

![Menú Chat en el Command Center de VS Code](https://code.visualstudio.com/assets/docs/copilot/chat/copilot-chat/copilot-chat-menu-command-center.png)

**Cuatro formas de abrir chat:**

| Superficie | Atajo | Para qué |
| ---------- | ----- | -------- |
| Chat view (panel) | `Ctrl+Alt+I` | Conversaciones largas, agentes, multi-archivo |
| Inline chat | `Ctrl+I` | Edición inline en el editor |
| Quick chat | `Ctrl+Shift+Alt+L` | Pregunta rápida sin cambiar de contexto |
| Terminal chat | `Ctrl+I` (en terminal) | Ayuda con comandos de terminal |

---

### Variables de contexto — dile a Copilot qué mirar

En lugar de pegar código en el chat, usa estas referencias directamente en el input:

| Variable | Cuándo usarla | Ejemplo |
| -------- | ------------- | ------- |
| `#codebase` | Pregunta sobre el proyecto en general | `#codebase ¿qué patrones de error handling se usan?` |
| `#NombreArchivo.cs` | Un archivo concreto (autocomplete con `#`) | `#TasksController.cs ¿qué endpoints no validan el input?` |
| `#selection` | Código seleccionado en el editor | Selecciona el método → abre chat → `¿puede lanzar NullReferenceException?` |
| `#terminalSelection` | Output del terminal seleccionado | `#terminalSelection explica el error y cómo lo corrijo` |

> **Truco**: selecciona código en el editor y **luego** abre el chat (`Ctrl+Alt+I`) — el fragmento aparece automáticamente como contexto, sin escribir nada.
>
> `@workspace` **ya no existe**. El reemplazo exacto es `#codebase`. Si usas `@workspace`, Copilot devuelve un error.

Ver la referencia completa en el [cheatsheet del workshop](../workshop-1h/cheatsheet.md).

---

> **One Does Not Simply...** pedirle algo a Copilot sin darle contexto. Cuanto más sabe, menos improvisa.

---

## Bloque 3 — Los tres modos (15 min)

El selector de **agentes** en el panel de chat es el punto de entrada a los tres modos:

![Selector de agentes en el panel de chat mostrando las opciones Ask, Plan y Agent](https://code.visualstudio.com/assets/docs/copilot/customization/chat-mode-dropdown.png)

| Modo | Qué hace | Toca archivos |
| ---- | -------- | :-----------: |
| **Ask** | Responde preguntas, revisa código, explica, analiza | ❌ |
| **Plan** | Genera un plan paso a paso, espera tu aprobación antes de implementar | ❌ hasta que apruebes |
| **Agent** | Implementa autónomamente: crea/edita archivos, ejecuta terminal, se autocorrige | ✅ |

**Árbol de decisión rápido:**

```text
¿Tienes una pregunta o quieres entender algo?        →  ASK
¿Quieres implementar algo que toca varios archivos?  →  PLAN → Agent
¿Es un cambio sencillo y sabes exactamente qué?      →  AGENT directamente
```

> **Esto lo practicamos en profundidad en el workshop** — aquí solo queremos que sepas que existen y dónde está el selector.

---

> **Expanding Brain:**
>
> <!-- markdownlint-disable-next-line MD028 -->
> 🧠 pequeño: `Tab` para completar una línea  
> 🧠 mediano: `Ctrl+I` para editar un método con Inline Chat  
> 🧠 grande: Agent mode para construir un endpoint desde cero  
> 🧠 galaxy: Plan → Agent para una feature completa con arquitectura revisada

---

## Tips & Tricks para llevarse a casa

| Situación | Qué hacer |
| --------- | --------- |
| `@workspace` falla | Usa `#codebase` — es el reemplazo exacto |
| Quiero documentar un método | Clic derecho → Generate Code → Generate Docs (ya no `/doc`) |
| Quiero que Copilot vea mi código | Selecciónalo en el editor → abre Chat → aparece automáticamente |
| Copilot no entiende mi proyecto | Crea `.github/copilot-instructions.md` — lo vemos en el Lab 05 |
| Quiero contexto del error del build | `#terminalSelection` con el output del terminal seleccionado |
| Sugerencias lentas o irrelevantes | Archivos abiertos = contexto activo: cierra los que no sean relevantes |

---

## Recursos

| Recurso | URL |
| ------- | --- |
| Inline suggestions | [ai-powered-suggestions](https://code.visualstudio.com/docs/copilot/ai-powered-suggestions) |
| Chat overview | [copilot-chat](https://code.visualstudio.com/docs/copilot/chat/copilot-chat) |
| Smart actions | [copilot-smart-actions](https://code.visualstudio.com/docs/copilot/copilot-smart-actions) |
| Agents overview | [agents/overview](https://code.visualstudio.com/docs/copilot/agents/overview) |
| Best practices | [best-practices](https://code.visualstudio.com/docs/copilot/best-practices) |

---

[← README principal](../README.md) | [→ Workshop práctico](../workshop-1h/README.md)
