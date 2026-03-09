# Notas del formador — Demo: Documentación con IA (15:15–15:45)

## Objetivo del bloque
Mostrar el flujo completo de documentación asistida por IA: XML docs de clase, AGENTS.md generado, FEATURE_SPEC.md con placeholders rellenados, y PR template en acción.

---

## Timing orientativo

| Tiempo | Actividad |
|---|---|
| 15:15–15:20 | Intro: los tres niveles de documentación (slide 09) |
| 15:20–15:30 | Demo XML docs + AGENTS.md |
| 15:30–15:42 | Demo FEATURE_SPEC.md + PR template |
| 15:42–15:45 | Cierre y reflexión |

---

## Demo 1: XML docs con Smart Action

1. Abre `Models/TaskItem.cs`
2. Click derecho → **Copilot → Generate Docs**
3. Muestra los XML docs generados en el diff
4. Acepta y compara con la versión original

Luego muestra la alternativa en chat inline (`Ctrl+I`):
```
Add XML documentation comments to all public members of this class
```

**Punto a remarcar**: estos docs generados son el contexto que el siguiente desarrollador (y la próxima sesión de Copilot) tiene disponible. Documentar bien = promptear mejor.

---

## Demo 2: AGENTS.md generado

Abre una sesión de Copilot Chat y ejecuta:
```
@workspace Genera un AGENTS.md completo para este repositorio que incluya:
arquitectura, comandos de build/test/run, convenciones de código,
y advertencias sobre archivos sensibles.
```

Compara el resultado con `docs-templates/AGENTS.md`. Señala:
- Lo que Copilot infirió correctamente del código
- Lo que hay que añadir manualmente (contexto de negocio, convenciones de equipo)

**Mensaje**: "El 80% lo genera Copilot en 30 segundos. El 20% de contexto de negocio lo añade el equipo. Juntos hacen un AGENTS.md útil."

---

## Demo 3: FEATURE_SPEC.md con placeholders

1. Abre `docs-templates/FEATURE_SPEC.md`
2. Muestra los `{{placeholders}}`
3. En el chat:
   ```
   #FEATURE_SPEC.md Rellena los placeholders para una feature de
   filtrado de tareas por estado (Pending/InProgress/Done).
   Usa los modelos y convenciones del proyecto existente.
   ```
4. Muestra el resultado rellenado — Copilot infiere el endpoint, el schema de request/response, y los criterios de aceptación del código existente.

---

## Demo 4: PR template en acción

Abre `.github/pull_request_template.md` y muestra los comentarios con prompts sugeridos.

Si hay tiempo, simula abrir una PR ficticia y usa el prompt del template:
```
@workspace Resume los cambios de esta PR en 3-5 puntos concisos
```

---

## Preguntas frecuentes

**"¿Dónde pongo el AGENTS.md en un monorepo?"**  
En la raíz del monorepo (se aplica a todo) y/o en la raíz de cada servicio/paquete (contexto específico). Copilot y OpenCode los leen de forma acumulativa.

**"¿El FEATURE_SPEC.md reemplaza a Jira/Azure DevOps?"**  
No reemplaza el sistema de tickets, lo complementa. El spec vive en el repo junto al código que implementa; el ticket en el sistema de gestión enlaza al spec.
