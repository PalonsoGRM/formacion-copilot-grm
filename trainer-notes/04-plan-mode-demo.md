# Notas del formador — Demo: Plan Mode (13:00–13:30)

## Objetivo del bloque
Mostrar cómo Plan mode permite a Copilot descomponer una tarea compleja en pasos revisables antes de ejecutar ningún cambio en el código.

---

## Timing orientativo

| Tiempo | Actividad |
|---|---|
| 13:00–13:05 | Reencuadre post-lunch: qué vimos esta mañana, qué viene esta tarde |
| 13:05–13:25 | Demo de Plan mode en vivo |
| 13:25–13:30 | Preguntas y transición a Lab 4 |

---

## Contexto post-lunch

Empieza con un recordatorio rápido:
- Mañana: Ask (leer), Edit (cambio quirúrgico), Agent (autónomo)
- Tarde: Plan (planificar antes de hacer), OpenCode (CLI), SpecKit, Docs, Seguridad

---

## Guion de la demo

### Escenario
"Quiero añadir autenticación básica a la API. Es un cambio que toca varios archivos. Antes de que Copilot toque nada, quiero ver el plan."

### Pasos en VS Code

1. Abre Copilot Chat en modo **Plan** (si está disponible como modo separado en tu versión) o usa Agent mode con un prompt que pida el plan primero:

```
Before making any changes, create a detailed plan for adding
JWT Bearer authentication to this ASP.NET Core API.
Include: which files to modify, what NuGet packages to add,
the order of changes, and potential risks.
Do NOT make any changes yet — only provide the plan.
```

2. Muestra el plan generado. Señala:
   - Copilot lista los pasos en orden lógico
   - Identifica dependencias entre pasos
   - Menciona riesgos (breaking changes en endpoints existentes)

3. Di: "Ahora puedo revisar este plan con mi equipo antes de ejecutar nada."

4. Si hay tiempo, acepta el plan y muestra cómo Copilot ejecuta paso a paso con confirmaciones.

---

## Mensaje principal

> "Plan mode es el modo 'muéstrame primero, haz después'. Es especialmente valioso cuando el cambio es grande, cuando hay que coordinarlo con el equipo, o cuando el coste de un error es alto."

---

## Señales de éxito

- Alguien del grupo dice "esto es lo que necesitaba para confiar más en Agent mode"
- Alguien pregunta si el plan se puede guardar como archivo — sí, se puede copiar/pegar en un `PLAN.md`

---

## Nota si Plan mode no está disponible en la versión instalada

Algunos builds de Copilot no tienen Plan mode como tab separado. En ese caso, simula el comportamiento con Agent mode y el prompt "only plan, do not execute". El resultado es equivalente para la demo.
