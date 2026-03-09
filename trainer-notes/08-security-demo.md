# Notas del formador — Demo: Código seguro con IA (15:45–16:30)

## Objetivo del bloque
Mostrar cómo usar Copilot como revisor de seguridad (finding vulnerabilities) y como guardia de licencias/IP (evitar código con restricciones legales).

---

## Timing orientativo

| Tiempo | Actividad |
|---|---|
| 15:45–15:50 | Intro: dos dimensiones de seguridad (slide 07) |
| 15:50–16:10 | Demo revisión de seguridad de la API |
| 16:10–16:25 | Demo licencias y code referencing |
| 16:25–16:30 | Cierre y reflexión |

---

## Demo 1: Copilot como revisor de seguridad

### Prompt principal
```
@workspace Actúa como un revisor de seguridad senior especializado en APIs .NET.
Analiza todos los controladores y lista:
1. Endpoints sin autenticación que deberían tenerla
2. Inputs no validados que pueden causar excepciones o inyección
3. Datos sensibles expuestos en respuestas
4. Headers de seguridad que faltan
Prioriza cada hallazgo como Alto/Medio/Bajo.
```

### Qué debería encontrar en nuestra API

Los defectos intencionados del proyecto son:
- `TasksController`: sin `[Authorize]`, sin validación de null en POST, acepta cualquier `userId`
- `Program.cs`: CORS abierto a `*`, stack trace expuesto en desarrollo SIN un check de entorno explícito
- `UsersController`: contraseñas o datos sensibles potencialmente expuestos en el modelo `User`

Señala cada hallazgo y pregunta: "¿Alguien lo había visto durante el lab de esta mañana?"

### Prompt de seguimiento
```
#TasksController.cs Muestra cómo añadir validación de entrada al endpoint POST
usando Data Annotations y ModelState. No cambies la lógica de negocio.
```

---

## Demo 2: Copilot code referencing y licencias

### Activar code referencing (mostrar dónde está la configuración)

En VS Code: `Ctrl+Shift+P → "GitHub Copilot: Open Settings"` → sección "Code Referencing"

Cuando está activado, Copilot muestra un aviso si una sugerencia coincide con código público de un repositorio con licencia restrictiva.

### Mensaje a transmitir
> "Copilot no siempre sabe de dónde viene el código que sugiere. Code referencing añade una capa de trazabilidad. Para proyectos empresariales, activarlo es una buena práctica de due diligence."

### Prompt sobre licencias
```
@workspace ¿Qué dependencias NuGet usa este proyecto?
¿Hay alguna con licencia GPL o AGPL que podría ser problemática
para un producto comercial cerrado?
```

Copilot listará las dependencias y las licencias conocidas. Útil para auditorías de open source.

---

## Señales de éxito

- Alguien del grupo dice "esto es lo que hacemos en revisiones de PR pero tarda mucho más"
- Alguien pregunta si se puede automatizar en el pipeline de CI — sí, hay acciones de GitHub para Copilot security review

---

## Preguntas frecuentes

**"¿Copilot puede meter vulnerabilidades sin que nos demos cuenta?"**  
Sí, es posible. Por eso el flujo correcto es: Copilot sugiere → el desarrollador revisa → el equipo hace code review. Copilot no reemplaza la revisión humana de seguridad.

**"¿Code referencing bloquea las sugerencias?"**  
No las bloquea, las avisa. El desarrollador decide si aceptar o no. En algunos planes Enterprise se puede configurar para bloquear automáticamente.

**"¿Puedo pedirle a Copilot que genere un informe de seguridad exportable?"**  
Sí, añade al prompt: "Devuelve el resultado en formato Markdown con una tabla por severidad." Luego se puede copiar a Confluence, Notion, etc.
