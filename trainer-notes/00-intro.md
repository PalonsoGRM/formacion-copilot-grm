# Notas del formador — Bloque 0: Introducción (09:00–09:30)

## Objetivo del bloque
Establecer el tono del día, nivelar expectativas y asegurarse de que todos tienen Copilot funcionando antes de entrar al primer lab.

---

## Timing orientativo

| Tiempo | Actividad |
|---|---|
| 09:00–09:10 | Bienvenida, presentaciones rápidas (ronda de nombres + "¿qué modo de Copilot usas más?") |
| 09:10–09:20 | Slides 00-intro: visión general de modos y anatomía del prompt |
| 09:20–09:30 | Verificación técnica y troubleshooting grupal |

---

## Mensaje principal a transmitir

> "Hoy no aprendemos a usar Copilot para hacer lo mismo que hacemos ahora pero más rápido. Aprendemos a cambiar cómo trabajamos: Copilot no es un autocompletado glorificado, es un colaborador al que hay que dar contexto."

---

## Puntos clave de la slide de anatomía del prompt

Dibuja esto en pizarra o muéstralo en vivo:

```
[contexto] + [tarea] + [restricciones] + [formato]

Ejemplo:
"Eres un revisor de código senior en .NET.
Revisa este controlador y lista los problemas de seguridad
sin sugerir refactors de arquitectura.
Devuélvelo como una lista con severidad alta/media/baja."
```

Insiste en que **contexto** es la palanca más potente. Sin contexto, Copilot da respuestas genéricas.

---

## Verificación técnica (antes de empezar los labs)

Pide a todos que ejecuten:
1. `dotnet build` en `sample-app/backend/TaskManager.Api` → debe compilar sin errores
2. Abre VS Code en esa carpeta → debe aparecer el icono de Copilot en la barra inferior
3. Abre Copilot Chat (`Ctrl+Alt+I`) y escribe `hola` → debe responder

Si alguien tiene el icono en gris o rojo: revisar extensión, sesión de GitHub, licencia Business.

---

## Preguntas frecuentes que suelen surgir aquí

**"¿Copilot guarda mi código en los servidores de GitHub?"**  
Con Copilot Business, el código **no se usa para entrenar modelos**. Los snippets se envían al modelo para generar sugerencias pero no se retienen. Ver política en ajustes de organización.

**"¿Es lo mismo que ChatGPT?"**  
Mismo tipo de tecnología (LLM), diferente integración. Copilot tiene contexto del IDE, el archivo abierto y el workspace. ChatGPT no sabe nada de tu código a menos que lo pegues.

**"¿Visual Studio o VS Code?"**  
Para los labs de hoy, VS Code es más completo (Agent mode, OpenCode). Los que usen Visual Studio 2022 pueden seguir la mayoría de ejercicios pero Agent mode no está disponible ahí todavía.

---

## Energía y ritmo

- El grupo arranca frío a las 9:00 — pregunta abierta inicial: "¿Alguien tiene una anécdota de algo que Copilot hizo bien o mal esta semana?"
- Mantén la introducción ligera; lo importante es llegar al primer lab rápido — la gente aprende haciendo.
