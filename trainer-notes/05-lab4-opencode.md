# Notas del formador — Lab 4: OpenCode (13:30–14:30)

## Objetivo del bloque
Los participantes deben instalar OpenCode, ejecutar `/init` en el proyecto, entender la diferencia entre Plan y Build mode, y crear un agente personalizado básico.

---

## Timing orientativo

| Tiempo | Actividad |
|---|---|
| 13:30–13:40 | Intro a OpenCode + slides 05 |
| 13:40–13:55 | Instalación y verificación (`opencode --version`) |
| 13:55–14:15 | Ejercicios 1–3 del lab (init, Plan/Build, custom agent) |
| 14:15–14:30 | Ejercicio 4 (agente doc-writer) + cierre |

---

## Pre-requisitos a verificar antes del lab

Pide a todos que ejecuten:
```
opencode --version
```

Si no está instalado:
- **npm**: `npm install -g opencode-ai`
- **Scoop (Windows)**: `scoop install opencode`

Ver `PREREQUISITES.md` para instrucciones detalladas.

---

## Demo de `/init`

```bash
cd sample-app/backend/TaskManager.Api
opencode
/init
```

OpenCode analiza el workspace y genera un `AGENTS.md` o actualiza el existente con:
- Estructura detectada del proyecto
- Comandos de build/test/run
- Convenciones inferidas del código

Muestra el resultado y compáralo con `docs-templates/AGENTS.md`. Di: "OpenCode hizo en 30 segundos lo que normalmente tarda medio sprint en documentarse."

---

## Plan mode vs Build mode

Cambia entre modos con `Ctrl+Shift+P → "OpenCode: Toggle Plan/Build mode"` o el indicador en la barra de estado.

| Plan mode | Build mode |
|---|---|
| Solo planifica, no ejecuta | Ejecuta cambios en archivos |
| Muestra razonamiento | Modo normal de trabajo |
| Útil para validar antes de actuar | Útil para tareas concretas |

Demo en vivo: crea una tarea en Plan mode, muestra el plan, cambia a Build mode, ejecuta.

---

## Ejercicio del agente doc-writer

El agente personalizado se crea en `.opencode/agents/doc-writer.md`. Ver `labs/04-opencode/README.md` para el contenido exacto.

Una vez creado, el participante puede invocarlo con:
```
/agent doc-writer
```

O desde la sesión de OpenCode con `@doc-writer`.

---

## Errores comunes

- **"opencode: command not found"**: npm no está en el PATH. Solución: reiniciar la terminal o añadir `%APPDATA%\npm` al PATH en Windows.
- **El `/init` no genera nada**: el directorio no tiene archivos reconocibles. Asegurarse de estar en la raíz del proyecto con `Program.cs` visible.
- **Plan mode no hace cambios aunque parece que los hizo**: correcto, es el comportamiento esperado. Cambiar a Build mode para que se apliquen.

---

## Preguntas frecuentes

**"¿OpenCode y GitHub Copilot son lo mismo?"**  
OpenCode es una herramienta de código abierto de la comunidad que funciona desde la terminal. Usa el mismo tipo de LLM pero no depende de la extensión de VS Code ni de una licencia Copilot (puede usar modelos de OpenAI, Anthropic, etc. configurados localmente).

**"¿Puedo usar OpenCode con mi propio modelo local?"**  
Sí. OpenCode soporta configurar un endpoint personalizado (LM Studio, Ollama) en la configuración. No es el foco del lab de hoy pero es una opción para entornos sin acceso a internet.
