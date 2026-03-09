# Lab 1 — Ask Mode: Explorar y entender el proyecto

**Duración**: 20 minutos  
**Herramienta**: GitHub Copilot Chat — modo **Ask**  
**IDE**: Visual Studio Code o Visual Studio 2022

---

## Objetivo

Usar Copilot en modo Ask para explorar el proyecto `TaskManager` sin tocar ningún archivo. Al final del lab deberías ser capaz de explicar la arquitectura a un compañero.

---

## Preparación

1. Abre la carpeta `sample-app/backend/TaskManager.Api` en VS Code
2. Asegúrate de que el proyecto compila: `dotnet build`
3. Abre Copilot Chat: `Ctrl+Alt+I` (VS Code) o menú View → GitHub Copilot Chat (VS)

---

## Ejercicios

### Ejercicio 1 — Arquitectura general (5 min)

Escribe este prompt en el chat:

```
@workspace Describe la arquitectura de este proyecto:
- Capas y responsabilidades de cada una
- Modelos de datos y sus relaciones
- Endpoints disponibles y qué hacen
- ¿Qué dependencias externas usa?
```

**¿Qué observas?** ¿Menciona Copilot los defectos del proyecto?

---

### Ejercicio 2 — Explorar un controlador (5 min)

Abre `Controllers/TasksController.cs`. Selecciona todo el contenido (`Ctrl+A`) y escribe:

```
/explain
```

Luego pregunta:

```
#TasksController.cs ¿Qué mejoras de calidad de código harías en este controlador?
¿Qué problemas de diseño ves?
```

---

### Ejercicio 3 — Buscar problemas (5 min)

Sin abrir ningún archivo específico:

```
@workspace Analiza todos los modelos del proyecto. ¿Qué validaciones de datos
faltan? ¿Hay propiedades que podrían causar problemas en producción?
```

Prueba también:

```
@workspace ¿Hay magic strings en este proyecto que deberían ser un enum o constante?
¿Dónde están y cuáles son los valores?
```

---

### Ejercicio 4 — Generar documentación en preview (5 min)

Abre `Models/TaskItem.cs`. Para generar documentación XML tienes dos opciones:

**Opción A — Smart Action (recomendada en VS Code):**  
Click derecho sobre el código → **Copilot** → **Generate Docs**

**Opción B — Chat inline (`Ctrl+I` sobre el archivo):**
```
Add XML documentation comments to all public members of this class
```

Observa la documentación XML generada. **No la aceptes todavía** — la trabajaremos en el bloque de documentación de la tarde.

Ahora prueba en el chat:

```
#TaskItem.cs Genera un ejemplo de JSON válido para crear una tarea nueva
a través del endpoint POST /api/tasks.
```

---

## Puntos clave del lab

- Ask mode **no modifica nada** — es tu modo de exploración segura
- `@workspace` le da a Copilot contexto de todo el proyecto (requiere carpeta abierta e indexada)
- `#archivo.cs` ancla la pregunta a un archivo concreto; `#codebase` es el equivalente moderno a `@workspace`
- `/explain` es un atajo rápido para entender código; para documentación usa el Smart Action (click derecho → Copilot → Generate Docs) o instrucción natural en el chat

---

## Discusión (5 min en grupo)

- ¿Qué encontró Copilot que no habías notado?
- ¿En qué situación de tu trabajo real usarías esto primero?
