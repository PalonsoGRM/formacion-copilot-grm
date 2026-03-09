# Slide deck: Documentación con IA

---

## ¿Por qué documentar con IA?

- La documentación siempre está desactualizada — la IA la regenera en segundos
- Copilot entiende el código y genera contexto real, no boilerplate
- Los ficheros `.md` en el repo son ciudadanos de primera clase: se versionan, se revisan en PR y se leen como prompt

---

## Tres niveles de documentación

| Nivel | Artefacto | Para quién |
|---|---|---|
| Método / clase | XML docs / JSDoc | El siguiente desarrollador |
| Proyecto | `README.md`, `AGENTS.md` | Equipo, IA agente |
| Feature | `FEATURE_SPEC.md` | PM, tech lead, Copilot |

---

## Nivel 1 — XML docs en C# / JSDoc en TypeScript

`/doc` fue eliminado de Copilot Chat. Las alternativas actuales son:

### Smart Action (VS Code)
1. Abre el archivo
2. Click derecho sobre la clase o método
3. **Copilot → Generate Docs**

### Chat inline (`Ctrl+I` sobre el archivo)
```
Add XML documentation comments to all public members of this class
```

### Chat con referencia de archivo
```
#TasksController.cs Añade comentarios de documentación XML a todos
los métodos públicos. Sigue el estilo de las clases de .NET BCL.
```

---

## Nivel 2 — `AGENTS.md`: el manual del agente

`AGENTS.md` en la raíz del repositorio es leído **automáticamente** por:
- GitHub Copilot en Agent mode
- OpenCode al arrancar en ese directorio
- Cualquier agente compatible con el estándar

### Qué incluir

```markdown
# AGENTS.md

## Arquitectura
...descripción de capas y responsabilidades...

## Comandos esenciales
- Build: `dotnet build`
- Test: `dotnet test`
- Dev: `dotnet run --project TaskManager.Api`

## Convenciones
- Fechas: siempre DateTimeOffset.UtcNow, nunca DateTime.Now
- IDs: Guid, nunca int auto-increment en modelos de dominio

## Lo que NO tocar
- `Data/TaskManagerContext.cs` — seed data de desarrollo, no modificar sin aviso
```

### Generar el primero con Copilot
```
@workspace Genera un AGENTS.md completo para este repositorio que incluya:
arquitectura, comandos de build/test/run, convenciones de código,
y advertencias sobre archivos sensibles.
```

---

## Nivel 2 — `README.md` entre branches

Los `.md` en el repo se pueden usar como documentación **viva** que evoluciona con el código:

- Cada feature branch puede llevar su propio `README` actualizado
- Las PRs incluyen la actualización del `.md` como parte del cambio
- Copilot puede resumir los cambios de la PR para actualizar el changelog

```
@workspace Resume los cambios de esta PR en 3-5 puntos concisos
para añadir al CHANGELOG.md
```

---

## Nivel 3 — `FEATURE_SPEC.md` con `{{placeholders}}`

Patrón: el PM o tech lead escribe la spec con huecos marcados como `{{placeholder}}`.  
Copilot (o el desarrollador guiado por Copilot) los rellena.

### Estructura del template

```markdown
# Feature: {{FEATURE_NAME}}

## Objetivo
{{OBJETIVO_EN_UNA_FRASE}}

## Criterios de aceptación
- [ ] {{AC_1}}
- [ ] {{AC_2}}

## Diseño técnico
### Endpoint propuesto
{{HTTP_METHOD}} {{PATH}}
Request: {{REQUEST_SCHEMA}}
Response: {{RESPONSE_SCHEMA}}

### Cambios en base de datos
{{DB_CHANGES}}
```

### Rellenar con Copilot
```
#FEATURE_SPEC.md Rellena todos los {{placeholders}} para implementar
un endpoint que permita filtrar tareas por fecha de vencimiento.
Usa los modelos y convenciones del proyecto existente.
```

---

## Demo en vivo

1. Abrir `Models/TaskItem.cs`
2. Demostrar **Smart Action**: click derecho → Copilot → Generate Docs
3. Abrir `docs-templates/AGENTS.md` — explicar la estructura
4. Abrir `docs-templates/FEATURE_SPEC.md` — mostrar los `{{placeholders}}`
5. Ejecutar en el chat:
   ```
   #FEATURE_SPEC.md Rellena los placeholders para una feature de
   filtrado de tareas por estado (Pending/InProgress/Done).
   ```
6. Mostrar el resultado y comparar con el template original

---

## Pull Request template

El archivo `.github/pull_request_template.md` hace que cada PR pida al autor que use Copilot para rellenar la descripción:

```markdown
## Descripción
<!-- Prompt: "@workspace Resume los cambios de esta PR en 3-5 puntos concisos." -->

## Cambios realizados
<!-- Prompt: "@workspace Lista los archivos modificados y el propósito de cada cambio." -->
```

Copilot rellena esto automáticamente cuando el autor abre la PR desde VS Code con Copilot activo.

---

## Resumen

| Herramienta | Cuándo |
|---|---|
| Smart Action / inline chat | XML docs de una clase o método |
| `AGENTS.md` | Configurar el agente una vez, reutilizar siempre |
| `FEATURE_SPEC.md` | Antes de empezar a codear: alinear equipo + prompt |
| PR template | En cada PR: autocompletar descripción con Copilot |
| `@workspace` + CHANGELOG | Tras la PR: mantener historial al día |
