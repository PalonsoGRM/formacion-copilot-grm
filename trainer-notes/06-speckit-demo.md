# Notas del formador — Demo: SpecKit (14:30–15:00)

## Objetivo del bloque
Mostrar cómo SpecKit convierte un proyecto brownfield en un proyecto con especificaciones estructuradas que Copilot puede consumir y ejecutar como slash commands.

---

## Timing orientativo

| Tiempo | Actividad |
|---|---|
| 14:30–14:35 | Intro: qué es SpecKit y por qué (slide 06) |
| 14:35–14:55 | Demo en vivo: init + specify + plan + implement |
| 14:55–15:00 | Q&A y transición al break |

---

## Pre-requisitos para la demo

Verificar que `specify` está instalado:
```
specify --version
```

Si no: `pip install specify-cli` o `uv tool install specify-cli`

---

## Guion de la demo (paso a paso)

Ver `speckit-demo/README.md` para el guion completo. Resumen ejecutivo:

### Paso 1: Init
```
cd sample-app/backend/TaskManager.Api
specify init . --here --ai copilot --script ps
```

Esto genera:
- `.speckit/constitution.md` — los principios del proyecto
- Slash commands disponibles: `/speckit.constitution`, `/speckit.specify`, etc.

### Paso 2: Specify
En Copilot Chat con Agent mode:
```
/speckit.specify
```

SpecKit analiza el código y propone especificaciones para cada componente. Muestra cómo las specs generadas son legibles por humanos y consumibles por la IA.

### Paso 3: Plan
```
/speckit.plan Añadir sistema de etiquetas (tags) a las tareas
```

SpecKit descompone la feature en tareas ordenadas con dependencias.

### Paso 4: Tasks + Implement
```
/speckit.tasks
/speckit.implement
```

Copilot ejecuta la implementación tarea a tarea, con checkpoints revisables.

---

## Qué remarcar durante la demo

1. **El `constitution.md` es el AGENTS.md del futuro**: define las reglas del proyecto que todo agente debe respetar.
2. **SpecKit no reemplaza el diseño — lo captura**: el valor no es que la IA invente la arquitectura, sino que formaliza lo que ya existe para que la IA no lo rompa.
3. **Los slash commands son el pegamento**: `/speckit.plan` → `/speckit.tasks` → `/speckit.implement` es un flujo repetible para cualquier feature.

---

## Si algo falla durante la demo

SpecKit depende de que el workspace esté indexado. Si `/speckit.specify` devuelve resultados vacíos:
- Verificar que Agent mode está activado (no Ask mode)
- Ejecutar `Ctrl+Shift+P → "GitHub Copilot: Index Workspace"` primero

Si `specify init` falla en Windows:
- Usar PowerShell como administrador
- Verificar que Python 3.9+ está en el PATH

---

## Referencia útil

- Repo oficial: https://github.com/github/spec-kit
- Demo brownfield ASP.NET: https://github.com/mnriem/spec-kit-aspnet-brownfield-demo

---

## Preguntas frecuentes

**"¿SpecKit funciona con proyectos grandes con miles de archivos?"**  
Sí, pero `specify init` puede tardar más. SpecKit usa análisis incremental — no re-analiza lo que no ha cambiado.

**"¿Los archivos `.speckit/` van al repositorio?"**  
Sí. Ese es el punto: son artefactos del proyecto, versionados junto al código, actualizados cuando la arquitectura cambia.
