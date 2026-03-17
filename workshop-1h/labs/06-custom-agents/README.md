# Lab Extra 06 — Tus Propios Agentes y Comandos de Copilot

> **Tipo**: Lab extra — realiza este lab después del Lab 05 o en una sesión dedicada.  
> **Duración**: 30 min (agentes y prompt files) · hasta 90 min (con extensión TypeScript)  
> **Modo**: Agent / Ask  
> **IDE**: VS Code  

---

## ¿Por qué crear tus propios agentes?

Copilot tiene tres modos integrados: Ask, Plan, Agent. Funcionan bien en general. Pero **tu equipo no es general** — tiene estándares específicos, arquitecturas concretas, flujos de trabajo propios.

¿Qué pasaría si pudieras tener:
- Un **revisor de código** que conoce exactamente tus estándares y los aplica en cada revisión
- Un **planificador** que analiza el impacto de una feature antes de tocar código — y luego pasa el plan al implementador
- Un **especialista en tests** que siempre usa xUnit + Moq, con el naming correcto y los casos que vuestro equipo exige

Todo esto sin instalar nada. Solo archivos Markdown en tu repositorio.

---

## Los tres niveles de extensión

| Nivel | Mecanismo | Cómo se invoca | Para qué sirve |
|-------|-----------|----------------|----------------|
| **1** | Prompt files (`.prompt.md`) | `/nombre` en el chat | Tareas puntuales repetitivas |
| **2** | Custom agents (`.agent.md`) | Selector de agentes en el chat | Personas persistentes con herramientas y encadenamiento |
| **3** | Chat Participant (TypeScript) | `@nombre` en el chat | Control total del flujo — para distribuir en el Marketplace |

---

## Parte 1 — Prompt Files: tus slash commands (10 min)

Los **prompt files** son el equivalente a los slash commands de Copilot, pero definidos por tu equipo. Son archivos `.prompt.md` que aparecen en el chat cuando escribes `/`.

Los prompt files también tienen dos ámbitos:
- **Proyecto**: `.github/prompts/` — compartidos con el equipo via git
- **Usuario**: `C:\Users\{tuUsuario}\.copilot\prompts\` — disponibles en todos tus proyectos

### Cómo funcionan

Crea el archivo en `.github/prompts/nombre.prompt.md`. La próxima vez que escribas `/` en Copilot Chat, aparecerá en el autocompletado.

### Ejemplo: `/nuevo-endpoint`

El repositorio ya incluye una plantilla en `docs-templates/.github/prompts/`. Actívala:

```powershell
$dest = "sample-app\backend\TaskManager.Api\.github\prompts"
New-Item -ItemType Directory -Force $dest | Out-Null
Copy-Item .github\prompts\nuevo-endpoint.prompt.md $dest -Force
```

Ahora pruébalo en el chat:

```
/nuevo-endpoint GET /api/tasks/overdue — devuelve tareas con DueDate anterior a hoy
```

Observa cómo el agente:
1. Analiza los endpoints existentes para seguir el patrón
2. Implementa el endpoint con `IActionResult`, `DateTimeOffset.UtcNow`, manejo de 404
3. Ejecuta `dotnet build` para verificar que compila

### Escribe tu propio prompt file

Un prompt file es solo Markdown con un header YAML opcional:

```markdown
---
description: Genera la documentación XML de un método seleccionado
agent: ask
---

Genera comentarios de documentación XML completos para el método o clase
que se describe a continuación. Incluye: <summary>, <param>, <returns>, <exception>.
Sigue el estilo de comentarios existente en el proyecto.

El código a documentar:
${input:code:Pega aquí el método o clase}
```

Guárdalo como `.github/prompts/documentar.prompt.md` y prueba con `/documentar`.

---

## Parte 2 — Custom Agents: personas especializadas (20 min)

Los **custom agents** son personas persistentes que aparecen en el selector de agentes del chat. Cada uno tiene:
- **Instrucciones específicas** sobre cómo debe comportarse
- **Herramientas disponibles** (puedes restringirlo a solo lectura, por ejemplo)
- **Handoffs** — botones al final de la respuesta para pasar a otro agente

### Dónde viven los agentes — tres ámbitos

| Ámbito | Ubicación | Cuándo usarlo |
|--------|-----------|---------------|
| **Proyecto** | `.github/agents/` en la raíz del repo | Agentes específicos del proyecto — se comparten con todo el equipo via git |
| **Usuario** | `C:\Users\{tuUsuario}\.copilot\agents\` | Agentes personales — disponibles en TODOS tus proyectos sin necesidad de commitearlos |
| **Perfil VS Code** | Carpeta `agents/` del perfil activo de VS Code | Por perfil de VS Code (útil si tienes perfiles para distintos tipos de proyecto) |

> **💡 Caso de uso típico**: pon `revisor` y `planificador` en el repo (`.github/agents/`) para que todo el equipo los tenga. Pon tus agentes personales de productividad en `~/.copilot/agents/` para tenerlos siempre contigo en cualquier proyecto.

#### Cambiar las rutas de búsqueda

Si quieres apuntar a una carpeta diferente, configúralo en VS Code Settings:

```json
// .vscode/settings.json (para el workspace)
// o settings.json de usuario (para todos los proyectos)
{
  "chat.agentFilesLocations": [
    ".github/agents",
    "my-team/shared-agents"
  ]
}
```

O desde la paleta de comandos: `Ctrl+Shift+P` → *Preferences: Open Settings (JSON)* → añade `chat.agentFilesLocations`.

### Activar los agentes de ejemplo

Los agentes ya están en este repositorio, en `.github/agents/`. Para usarlos en el proyecto **sample-app**, cópialos:

```powershell
$dest = "sample-app\backend\TaskManager.Api\.github\agents"
New-Item -ItemType Directory -Force $dest | Out-Null
Copy-Item .github\agents\* $dest -Force
```

Reinicia VS Code (o usa `Developer: Reload Window`) para que detecte los nuevos agentes.

---

### Agente 1: `revisor` — Revisor de Código

**Archivo**: `docs-templates/.github/agents/revisor.agent.md`

**¿Qué hace?**  
Revisa el código buscando vulnerabilidades de seguridad y desviaciones de los estándares del equipo. Es **solo lectura** — no modifica nada. Al terminar, ofrece un botón para pasar al agente de implementación con las correcciones pendientes.

**Pruébalo:**

1. Selecciona `revisor` en el selector de agentes del chat
2. Escribe:

```
Revisa TasksController.cs en busca de problemas de seguridad y calidad
```

3. Observa el informe estructurado con severidades 🔴/🟡/🟢
4. Si hay problemas, pulsa el botón **"🔧 Corregir problemas encontrados"** — el contexto pasa automáticamente al agente `copilot`

**Por qué motiva a los desarrolladores:**  
> "Antes de abrir un PR, ejecuto `revisor` y sé exactamente qué va a comentar el tech lead. Llego a la revisión ya habiendo corregido el 80% de los comentarios habituales."

---

### Agente 2: `planificador` — Planificador de Features

**Archivo**: `docs-templates/.github/agents/planificador.agent.md`

**¿Qué hace?**  
Analiza el impacto de una feature nueva antes de escribir código. Lista exactamente qué archivos se crearán y modificarán, qué endpoints nuevos habrá, qué efectos secundarios puede haber. Luego ofrece dos handoffs: implementar o revisar primero.

**Pruébalo:**

1. Selecciona `planificador` en el selector de agentes
2. Escribe:

```
Quiero añadir la posibilidad de asignar prioridad (Alta/Media/Baja) a las tareas.
Dame el plan completo antes de implementar nada.
```

3. Lee el plan generado. ¿Propone cambiar los archivos correctos? ¿Ha detectado los efectos secundarios?
4. Pulsa **"🚀 Implementar este plan"** para pasar la implementación al agente `copilot` con el contexto completo

**Por qué motiva a los desarrolladores:**  
> "En mi equipo, cualquier feature que toque más de 3 archivos tiene que tener un plan aprobado. Antes tardábamos 30 minutos en diseñarlo. Ahora `planificador` lo hace en 2 minutos y nosotros solo revisamos."

---

### Agente 3: `tester` — Especialista en Tests

**Archivo**: `docs-templates/.github/agents/tester.agent.md`

**¿Qué hace?**  
Genera tests unitarios exhaustivos siguiendo las convenciones del equipo: xUnit, Moq, naming `Método_Escenario_Resultado`, sin dependencias externas. Siempre cubre caso feliz, 404, 400 y edge cases.

**Pruébalo:**

1. Selecciona `tester` en el selector de agentes
2. Escribe:

```
Genera tests completos para el endpoint GET /api/tasks/{id} del TasksController
```

3. Compara la calidad con lo que obtendrías usando el agente `copilot` directamente con el mismo prompt

**Por qué motiva a los desarrolladores:**  
> "El mayor dolor de los tests es que cada desarrollador los escribe diferente. Con `tester`, todos los tests del equipo siguen la misma estructura desde el primer día."

---

## Parte 3 — Encadenamiento de agentes (5 min)

La magia real de los custom agents está en los **handoffs**. Puedes diseñar flujos de trabajo completos:

```
planificador  →  revisor  →  copilot (implementa)
                                ↓
                            tester (genera tests)
```

### Flujo de trabajo completo para una feature nueva

```
1. Selecciona el agente "planificador"
2. Describe la feature
3. Revisa el plan → pulsa "🔍 Revisar antes de implementar"
4. Revisa el informe del revisor → pulsa "🚀 Implementar este plan"
5. Al terminar la implementación, selecciona el agente "tester"
6. Pide tests para los endpoints nuevos
```

> Este flujo completo — plan, revisión, implementación, tests — con un agente humano llevaba horas. Con agentes personalizados encadenados, es cuestión de minutos, con puntos de control donde TÚ apruebas cada paso.

---

## Parte 4 (opcional avanzado) — Chat Participants con TypeScript (~30-60 min)

Los custom agents son perfectos para el 90% de los casos. Pero si necesitas:
- **Control total** del flujo de conversación (gestionar historial, respuestas estructuradas)
- **Integración profunda con VS Code** (acceder a archivos, terminal, breakpoints, diagnósticos)
- **Distribución en el VS Code Marketplace** para que otros instalen tu agente

...entonces necesitas construir una **extensión VS Code** con la Chat Participant API.

### ¿Qué construirías?

Un `@nombre` que aparece en el chat igual que `@workspace` o `@terminal`. Por ejemplo:
- `@security-audit` — análisis de seguridad integrado con los diagnósticos de VS Code
- `@db-helper` — asistente de base de datos que consulta tu schema en tiempo real
- `@changelog` — generador de changelogs que lee tu historial de git

### Cómo empezar — Tutorial paso a paso

Sigue el tutorial oficial de VS Code (30 min):

```
https://code.visualstudio.com/api/extension-guides/ai/chat-tutorial
```

Construirás un `@tutor` de código con slash commands (`/teach`, `/exercise`). Los conceptos que aprenderás son directamente transferibles a cualquier agente personalizado.

### Estructura básica de una Chat Participant

```typescript
// extension.ts
const handler: vscode.ChatRequestHandler = async (
  request: vscode.ChatRequest,
  context: vscode.ChatContext,
  stream: vscode.ChatResponseStream,
  token: vscode.CancellationToken
) => {
  // Detecta el comando (/teach, /review, etc.)
  if (request.command === 'review') {
    // Lógica específica para /review
  }

  // Construye el prompt con contexto del proyecto
  const messages = [
    vscode.LanguageModelChatMessage.User(YOUR_SYSTEM_PROMPT),
    // Historial de conversación
    ...context.history.map(h => /* ... */),
    // Mensaje actual del usuario
    vscode.LanguageModelChatMessage.User(request.prompt)
  ];

  // Envía la petición al modelo y hace streaming de la respuesta
  const response = await request.model.sendRequest(messages, {}, token);
  for await (const fragment of response.text) {
    stream.markdown(fragment);
  }
};

// Registra el participante
const participant = vscode.chat.createChatParticipant('my-ext.my-agent', handler);
participant.iconPath = vscode.Uri.joinPath(context.extensionUri, 'icon.png');
```

### Prerrequisitos

```powershell
node --version  # v20+
npm install -g yo generator-code  # Yeoman + generador de extensiones VS Code
```

### Recursos adicionales

| Recurso | URL |
|---------|-----|
| Tutorial: Code Tutor Chat Participant | https://code.visualstudio.com/api/extension-guides/ai/chat-tutorial |
| Chat Participant API docs | https://code.visualstudio.com/api/extension-guides/chat |
| Language Model Tools API | https://code.visualstudio.com/api/extension-guides/ai/tools |
| Chat sample en GitHub | https://github.com/microsoft/vscode-extension-samples/tree/main/chat-sample |
| MS Learn: Configure & Customize Copilot in VS Code | https://learn.microsoft.com/en-us/training/modules/configure-customize-github-copilot-visual-studio-code/ |

---

## Crea tu propio agente ahora mismo

Antes de terminar el lab, diseña un agente para un problema real de tu equipo.

### Template de arranque

Decide primero dónde guardar tu agente:
- **Solo para este proyecto** → `.github/agents/mi-agente.agent.md`
- **Para todos tus proyectos** → `C:\Users\TU_USUARIO\.copilot\agents\mi-agente.agent.md`

```markdown
---
description: [Una frase que describe para qué sirve este agente]
tools: ['codebase', 'search']   # añade 'editFiles', 'runCommands' si necesita modificar código
handoffs:
  - label: "➡️ Siguiente paso"
    agent: copilot
    prompt: "Continúa el trabajo anterior."
    send: false
---

# [Nombre del agente]

[Describe en 1-2 frases qué rol desempeña este agente.]

## Proceso

1. [Primer paso que siempre debe hacer]
2. [Segundo paso...]

## Reglas

- [Regla 1 específica de tu proyecto]
- [Regla 2...]

## Restricciones

- [Lo que este agente NO debe hacer]
```

### Ideas para empezar

- **`@documentador`** — genera comentarios XML para métodos sin documentar
- **`@migrador`** — asiste en migraciones de versiones de frameworks
- **`@optimizador`** — identifica N+1 queries y problemas de rendimiento en EF Core
- **`@auditor-api`** — verifica que todos los endpoints siguen el estándar REST
- **`@onboarding`** — explica el proyecto a desarrolladores nuevos que se incorporan

---

## El mensaje clave

> Los custom agents son la diferencia entre "Copilot que genera código genérico" y "Copilot que trabaja exactamente como trabaja tu equipo". No requieren código, no requieren despliegue, no requieren permisos especiales. Solo un archivo Markdown en `.github/agents/` y todo el equipo tiene disponible el mismo especialista.

---

## Recursos

| Recurso | URL |
|---------|-----|
| Custom agents (`.agent.md`) | https://code.visualstudio.com/docs/copilot/customization/custom-agents |
| Prompt files (slash commands) | https://code.visualstudio.com/docs/copilot/customization/prompt-files |
| Extensibilidad AI en VS Code | https://code.visualstudio.com/docs/copilot/copilot-extensibility-overview |
| MS Learn: Configure & Customize Copilot | https://learn.microsoft.com/en-us/training/modules/configure-customize-github-copilot-visual-studio-code/ |
| Awesome Copilot (ejemplos comunidad) | https://github.com/github/awesome-copilot |

---

[← Lab 05: Copilot Instructions](../05-copilot-instructions/README.md) | [→ Volver al índice](../../README.md)
