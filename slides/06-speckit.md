# Slide deck: SpecKit — Desarrollo dirigido por especificaciones

---

## El problema del "vibe coding"

> Prompt → código → prompt → código → ... → spaghetti

Sin especificación, cada prompt añade capas sin coherencia.  
El resultado: código que funciona pero nadie entiende ni mantiene.

**Spec-Driven Development** invierte el orden:

```
Especificación → Plan técnico → Tareas → Implementación
```

---

## ¿Qué es SpecKit?

- Toolkit open source de GitHub (75k ⭐)
- Repositorio: https://github.com/github/spec-kit
- CLI `specify` que scaffoldea la estructura de especificación
- Slash commands para cada fase del proceso
- Compatible con GitHub Copilot, OpenCode, Claude Code y más

---

## Los slash commands del flujo

```
/speckit.constitution  → principios del proyecto (code quality, tests, UX...)
/speckit.specify       → qué quieres construir (no el cómo)
/speckit.clarify       → preguntas de clarificación antes de planificar
/speckit.plan          → plan técnico con el stack que eliges
/speckit.analyze       → validación cruzada spec ↔ plan
/speckit.tasks         → lista de tareas accionable y ordenada
/speckit.implement     → implementación de todas las tareas
```

---

## Estructura que genera SpecKit

```
.specify/
├── memory/
│   └── constitution.md       ← principios del proyecto
├── specs/
│   └── 001-mi-feature/
│       ├── spec.md           ← qué se construye
│       ├── plan.md           ← cómo se construye
│       ├── tasks.md          ← lista de tareas
│       ├── research.md       ← investigación técnica
│       └── data-model.md     ← modelo de datos
└── templates/
    ├── spec-template.md
    ├── plan-template.md
    └── tasks-template.md
```

---

## Flujo completo en 6 pasos

### 1. Instalar y bootstrapear
```powershell
# En la carpeta del proyecto
specify init . --here --ai copilot --script ps
```

### 2. Establecer principios
```
/speckit.constitution Define principios de calidad, tests unitarios obligatorios,
convenciones .NET 8, y seguridad en todos los endpoints.
```

### 3. Especificar la feature (el QUÉ, no el CÓMO)
```
/speckit.specify Añadir un sistema de comentarios a las tareas. Los usuarios
pueden añadir, editar y borrar sus propios comentarios. Los comentarios
se muestran ordenados por fecha en la vista de detalle de tarea.
```

### 4. Planificar (el CÓMO)
```
/speckit.plan Usa ASP.NET Core 8 con EF Core in-memory. Angular 17 para
el frontend con componentes standalone. REST API con validación FluentValidation.
```

### 5. Generar tareas
```
/speckit.tasks
```

### 6. Implementar
```
/speckit.implement
```

---

## SpecKit para brownfield (código existente)

SpecKit funciona también sobre proyectos que ya existen.  
Hay un walkthrough oficial para ASP.NET:  
https://github.com/mnriem/spec-kit-aspnet-brownfield-demo

Flujo brownfield:
```
specify init . --here --ai copilot --script ps --force
/speckit.specify  (describe la feature NUEVA sobre el proyecto existente)
/speckit.plan
/speckit.tasks
/speckit.implement
```

---

## Demo en vivo

Sobre el `sample-app/` de la formación:

1. `specify init . --here --ai copilot --script ps`
2. `/speckit.constitution` — principios del Task Manager
3. `/speckit.specify` — añadir sistema de etiquetas (tags) a las tareas
4. `/speckit.clarify` — resolver ambigüedades
5. `/speckit.plan` — ASP.NET Core + Angular
6. `/speckit.tasks` — ver la lista generada
7. (Demo de `/speckit.implement` o dejar como ejercicio)
