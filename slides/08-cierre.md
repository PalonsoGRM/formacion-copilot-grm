# Slide deck: Cierre — Lo que te llevas hoy

---

## Lo que aprendiste hoy

| Modo / Herramienta | Para qué |
|---|---|
| **Ask mode** | Explorar, entender, preguntar sin riesgo |
| **Edit mode** | Cambios quirúrgicos en archivos concretos |
| **Agent mode** | Tareas complejas multi-archivo de forma autónoma |
| **Plan mode** | Diseñar antes de implementar, exponer riesgos |
| **OpenCode** | Agente en terminal, agnóstico de IDE, undo/redo, agentes custom |
| **SpecKit** | Spec-Driven Development: especificación → plan → tareas → código |
| **Seguridad** | Copilot como revisor de seguridad permanente |
| **Documentación** | `AGENTS.md`, plantillas `.md`, XML docs auto-generados |

---

## Cheatsheet: cuándo usar qué

```
¿Quiero entender código?          → Ask mode + @workspace
¿Sé exactamente qué archivos?     → Edit mode
¿La tarea abarca varios archivos? → Agent mode
¿No sé bien el alcance?           → Plan mode primero
¿Trabajo desde terminal / CI?     → OpenCode
¿Feature nueva de cero?           → SpecKit
¿Revisión de seguridad?           → Ask con prompt de security review
¿Documentar API?                  → Ask + /doc sobre controladores
```

---

## Los 5 prompts más útiles del día

### 1. Explorar arquitectura
```
@workspace explica la arquitectura de este proyecto: capas, dependencias
entre proyectos y flujo principal de una petición HTTP.
```

### 2. Documentar controladores
```
#NombreController.cs /doc Genera documentación XML completa para todos
los endpoints públicos con descripción, parámetros y ejemplos de respuesta.
```

### 3. Security review
```
@workspace Actúa como revisor de seguridad. Lista todos los endpoints
sin validación de input y los que no tienen autenticación. Prioriza por riesgo.
```

### 4. Feature con SpecKit
```
specify init . --here --ai copilot --script ps
/speckit.specify [describe la feature]
/speckit.plan [describe el stack]
/speckit.implement
```

### 5. AGENTS.md para el equipo
```
@workspace Genera un AGENTS.md completo para este repositorio que incluya:
arquitectura, comandos de build y test, convenciones de código y reglas
de seguridad. Estilo conciso y directo para que lo use otro agente IA.
```

---

## Próximos pasos

1. **Esta semana**: usa Ask mode a diario en código nuevo o heredado
2. **Este mes**: adopta Edit mode en al menos un refactor real
3. **Cuando llegue la próxima feature**: prueba el flujo completo de SpecKit
4. **Añade `AGENTS.md` a tus repositorios** — el equipo entero se beneficia

---

## Recursos

Ver `resources.md` para links completos a documentación, repos y videos.

---

## Gracias

Repositorio de esta formación:
`C:\Users\palonso\source\repos\FormacionIA`

Feedback y preguntas: abre un issue en el repositorio o habla con el formador.
