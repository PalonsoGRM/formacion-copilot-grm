# Notas del formador — Cierre (16:30–17:00)

## Objetivo del bloque
Consolidar el aprendizaje del día, dejar a los participantes con un artefacto concreto (cheatsheet) y una acción inmediata para el día siguiente.

---

## Timing orientativo

| Tiempo | Actividad |
|---|---|
| 16:30–16:40 | Repaso visual del día — "el mapa de los modos" |
| 16:40–16:50 | Cheatsheet de los 5 prompts más útiles |
| 16:50–17:00 | Compromiso personal + Q&A abierto |

---

## El mapa de los modos (dibuja esto en la pizarra)

```
¿Quiero ENTENDER?     → Ask mode + @workspace / #codebase
¿Quiero CAMBIAR poco? → Edit mode + working set explícito
¿Quiero DELEGAR?      → Agent mode (+ Plan mode para validar antes)
¿Quiero CLI/scripts?  → OpenCode
¿Quiero ESPECIFICAR?  → SpecKit
¿Quiero DOCUMENTAR?   → Smart Action + AGENTS.md + FEATURE_SPEC.md
¿Quiero REVISAR?      → Ask mode con rol de revisor de seguridad
```

---

## Los 5 prompts del cheatsheet (slide 08)

Repasa cada uno con un ejemplo real del proyecto que usaron hoy:

1. **Arquitectura**
   ```
   @workspace describe la arquitectura, capas y endpoints de este proyecto
   ```

2. **Documentar**
   ```
   #Controller.cs Añade comentarios de documentación XML a todos los métodos públicos
   ```

3. **Seguridad**
   ```
   @workspace actúa como revisor de seguridad. Busca inputs sin validar,
   endpoints sin autenticación y datos sensibles expuestos
   ```

4. **Refactor controlado**
   ```
   Working set: [lista de archivos]
   Reemplaza [patrón antiguo] por [patrón nuevo]. No modifiques ninguna otra lógica.
   ```

5. **AGENTS.md**
   ```
   @workspace genera un AGENTS.md completo con arquitectura, comandos,
   convenciones y advertencias para este repositorio
   ```

---

## Compromiso personal (dinámica de cierre)

Pide a cada participante que escriba en un post-it (o en el chat del grupo):

> "Mañana, en mi trabajo real, voy a usar Copilot para ___________"

Comparte en voz alta. Esto ancla el aprendizaje y crea accountability social.

---

## Recursos para llevarse

- `resources.md` — todos los enlaces y el cheatsheet
- `docs-templates/AGENTS.md` — plantilla para su próximo proyecto
- `docs-templates/FEATURE_SPEC.md` — plantilla para specs
- Repo completo en `C:\Users\palonso\source\repos\FormacionIA`

---

## Preguntas frecuentes del cierre

**"¿Dónde aprendo más?"**  
- https://docs.github.com/en/copilot — documentación oficial
- https://opencode.ai/docs — OpenCode docs
- https://github.com/github/spec-kit — SpecKit

**"¿Hay certificaciones de Copilot?"**  
GitHub tiene el examen "GitHub Copilot" en su programa de certificaciones: https://examregistration.github.com/

**"¿Cuándo sale la versión X de Copilot con la feature Y?"**  
Roadmap público en GitHub: https://github.com/orgs/github/projects/
Changelog de VS Code Copilot: notas de la extensión en el marketplace.

---

## Nota final para el formador

Termina con energía positiva. El día fue intenso — los participantes han sido expuestos a 6+ herramientas y flujos nuevos. El objetivo no es que dominen todo hoy, sino que bajen la barrera de entrada y tengan un mapa mental de cuándo usar qué.

El cheatsheet es su ancla. El repo es su referencia. El compromiso personal es su primer paso.
