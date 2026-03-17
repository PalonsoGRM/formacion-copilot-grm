## Descripción

<!-- Copilot: rellena esta sección resumiendo los cambios de esta PR basándote en el diff. -->
<!-- Prompt: "@workspace Resume los cambios de esta PR en 3-5 puntos concisos." -->

{{PR_SUMMARY}}

---

## Tipo de cambio

- [ ] Nueva feature
- [ ] Corrección de bug
- [ ] Refactor (sin cambios de comportamiento)
- [ ] Documentación
- [ ] Configuración / infraestructura
- [ ] Tests

---

## Cambios incluidos

<!-- Lista de archivos principales modificados y por qué. -->
<!-- Prompt: "@workspace Lista los archivos modificados en esta PR y explica brevemente el propósito de cada cambio." -->

| Archivo | Cambio |
|---|---|
| {{FILE_1}} | {{CHANGE_DESCRIPTION_1}} |
| {{FILE_2}} | {{CHANGE_DESCRIPTION_2}} |

---

## Cómo probar

<!-- Pasos para verificar que los cambios funcionan correctamente. -->

1. `dotnet build` — debe compilar sin errores
2. `dotnet run` — debe arrancar en `http://localhost:5000`
3. {{TEST_STEP_3}}
4. {{TEST_STEP_4}}

---

## Checklist

- [ ] El código compila sin errores ni warnings
- [ ] Los nuevos endpoints tienen validación de input
- [ ] Se han añadido o actualizado los tests correspondientes
- [ ] La documentación XML está completa en los métodos públicos nuevos
- [ ] No hay `DateTime.Now` — solo `DateTimeOffset.UtcNow`
- [ ] No hay magic strings de estado — solo constantes `TaskStatus.*`
- [ ] No hay secrets ni credenciales en el código
- [ ] El AGENTS.md sigue siendo válido (actualiza si añades endpoints o cambias convenciones)

---

## Feature spec relacionada

<!-- Link al archivo FEATURE_SPEC.md de la rama si existe. -->

{{FEATURE_SPEC_LINK}}

---

## Notas para el revisor

{{REVIEWER_NOTES}}
