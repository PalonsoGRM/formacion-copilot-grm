# Feature Specification — {{FEATURE_NAME}}

> Plantilla para especificaciones de feature. Usa GitHub Copilot o OpenCode para rellenar los
> `{{placeholders}}` con el contexto de tu feature. Commiteala en la rama de la feature.
>
> **Cómo usar**: Copia este archivo a `.specify/specs/{{FEATURE_ID}}-{{feature-slug}}/spec.md`,
> rellena los placeholders con Copilot (/speckit.specify) o manualmente, y úsala como contexto
> para todos los prompts de la feature.

---

## Resumen

**Feature**: {{FEATURE_NAME}}  
**ID**: {{FEATURE_ID}}  
**Rama**: `{{BRANCH_NAME}}`  
**Estado**: `draft` | `ready` | `in-progress` | `done`  
**Autor**: {{AUTHOR}}  
**Fecha**: {{DATE}}

---

## Contexto

{{CONTEXT_DESCRIPTION}}
<!-- Explica por qué se necesita esta feature, qué problema resuelve y qué valor aporta al usuario. -->

---

## Objetivo

{{OBJECTIVE}}
<!-- Una sola frase que describe el resultado esperado. Empieza por verbo: "Permitir a los usuarios...", "Añadir la capacidad de..." -->

---

## Historias de usuario

<!-- Formato: Como [tipo de usuario], quiero [acción] para [beneficio]. -->

1. Como **{{USER_TYPE}}**, quiero **{{ACTION_1}}** para **{{BENEFIT_1}}**.
2. Como **{{USER_TYPE}}**, quiero **{{ACTION_2}}** para **{{BENEFIT_2}}**.
3. Como **{{USER_TYPE}}**, quiero **{{ACTION_3}}** para **{{BENEFIT_3}}**.

---

## Criterios de aceptación

<!-- Lista de condiciones verificables que deben cumplirse para considerar la feature completa. -->

- [ ] {{ACCEPTANCE_CRITERION_1}}
- [ ] {{ACCEPTANCE_CRITERION_2}}
- [ ] {{ACCEPTANCE_CRITERION_3}}
- [ ] Todos los endpoints nuevos tienen validación de input
- [ ] Existe al menos un test unitario por historia de usuario
- [ ] La documentación XML de los nuevos endpoints está completa

---

## Requisitos funcionales

### {{FUNCTIONAL_AREA_1}}

- {{REQUIREMENT_1}}
- {{REQUIREMENT_2}}

### {{FUNCTIONAL_AREA_2}}

- {{REQUIREMENT_3}}
- {{REQUIREMENT_4}}

---

## Requisitos NO funcionales

| Aspecto | Requisito |
|---|---|
| Rendimiento | {{PERFORMANCE_REQUIREMENT}} |
| Seguridad | {{SECURITY_REQUIREMENT}} |
| Compatibilidad | {{COMPATIBILITY_REQUIREMENT}} |
| Documentación | Endpoints documentados con XML docs y ejemplos Swagger |

---

## Modelo de datos

<!-- Nuevas entidades o cambios en las existentes. -->

```csharp
// {{NEW_OR_MODIFIED_MODEL}}
public class {{MODEL_NAME}}
{
    // {{PROPERTY_1}}: {{DESCRIPTION}}
    // {{PROPERTY_2}}: {{DESCRIPTION}}
}
```

---

## API Endpoints (si aplica)

| Método | Ruta | Descripción | Body / Parámetros |
|---|---|---|---|
| {{HTTP_METHOD}} | `/api/{{RESOURCE}}` | {{DESCRIPTION}} | `{{REQUEST_BODY}}` |

---

## Fuera del alcance

<!-- Explícitamente qué NO se incluye en esta feature para evitar scope creep. -->

- {{OUT_OF_SCOPE_1}}
- {{OUT_OF_SCOPE_2}}

---

## Preguntas abiertas

<!-- Ambigüedades o decisiones pendientes. Usa /speckit.clarify para resolverlas. -->

- [ ] {{OPEN_QUESTION_1}}
- [ ] {{OPEN_QUESTION_2}}

---

## Notas técnicas

{{TECHNICAL_NOTES}}
<!-- Stack, restricciones técnicas, decisiones de arquitectura específicas de esta feature. -->

---

## Prompt sugerido para Copilot Agent

Una vez rellena la spec, usa este prompt como punto de partida para Agent mode:

```
Lee el archivo FEATURE_SPEC.md de esta rama. Implementa la feature descrita
siguiendo los criterios de aceptación. Usa el stack existente (ASP.NET Core,
EF Core in-memory, Angular). No añadas dependencias externas. Verifica que
el proyecto compila y que los nuevos endpoints responden correctamente.
```
