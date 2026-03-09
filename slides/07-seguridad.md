# Slide deck: Código seguro con IA

---

## IA para escribir código más seguro

Copilot no es solo para escribir código nuevo — es un revisor disponible 24/7.

Dos ángulos hoy:
1. **Security review**: detectar vulnerabilidades con Copilot Chat
2. **License & IP awareness**: saber qué genera Copilot y cuándo importa

---

## Security review con Copilot Chat

### Prompt de revisión general
```
@workspace Actúa como un revisor de seguridad senior especializado en APIs .NET.
Analiza todos los controladores y busca:
- Endpoints sin validación de input
- Posibles inyecciones (SQL, NoSQL, command injection)
- Datos sensibles expuestos en respuestas
- Endpoints que deberían requerir autenticación
- Configuraciones inseguras
Devuelve una lista priorizada con ejemplos de código corregido.
```

### Prompt focalizado en un archivo
```
#TasksController.cs Revisa este controlador en busca de vulnerabilidades
de seguridad. Para cada problema encontrado, explica el riesgo y propón
el código corregido siguiendo OWASP Top 10.
```

---

## Defectos de seguridad en el sample-app

El `TaskManager` tiene estos problemas intencionados para practicar:

| Problema | Archivo | Riesgo |
|---|---|---|
| Sin validación de input en POST | `TasksController.cs` | Datos corruptos / inyección |
| Title puede ser null o vacío | `TaskItem.cs` | NullReferenceException en producción |
| Sin límite de longitud en campos | `TaskItem.cs` | Buffer overflow / DoS |
| Sin autenticación en endpoints de borrado | `TasksController.cs` | Cualquiera puede borrar tareas |
| Mensajes de error con stack traces | `Program.cs` | Exposición de información interna |

---

## Demo: detectar y corregir

### Paso 1 — Detectar
```
@workspace Analiza los controladores de la API y lista todos
los endpoints que no tienen validación de entrada.
```

### Paso 2 — Corregir con Edit mode
```
Working set: TasksController.cs, TaskItem.cs
Prompt: Añade validación de modelo con DataAnnotations en TaskItem.
Asegúrate de que Title no puede ser nulo ni vacío y tiene máximo
200 caracteres. Devuelve 400 Bad Request si la validación falla.
```

### Paso 3 — Generar tests de seguridad
```
#TasksController.cs /tests Genera tests unitarios que validen que
los endpoints POST y PUT devuelven 400 cuando los datos son inválidos.
```

---

## License y IP awareness

### ¿Qué genera Copilot?

GitHub Copilot Business tiene activado por defecto el **filtro de código duplicado**:
- Bloquea sugerencias idénticas o casi idénticas a código público indexado
- Muestra referencias si el código sugerido tiene origen conocido

### Verificar en VS Code
```
Settings → GitHub Copilot → Suggestions matching public code → Block
```

### Cuándo preocuparse
- Copilot sugiere un algoritmo muy específico → pregunta de dónde viene
- Código de seguridad o criptografía → revisa doble

### Pregunta útil
```
El siguiente código fue sugerido por Copilot: [pega el código].
¿Tiene este código algún problema de licencia conocido o viene
de una librería específica que debería importar explícitamente?
```

---

## Agente custom de seguridad para OpenCode

Ver `docs-templates/AGENTS.md` — incluye un agente `security-reviewer` listo para usar.

---

## Resumen: checklist de seguridad con IA

```
[ ] Revisé todos los endpoints con @workspace security review
[ ] Todos los modelos tienen DataAnnotations o FluentValidation
[ ] Los endpoints destructivos (DELETE, PUT) tienen autenticación
[ ] No hay secrets en el código (Copilot secret scanning en GitHub)
[ ] El filtro de código duplicado está activado en Copilot Business
[ ] Los errores no exponen stack traces en producción
```
