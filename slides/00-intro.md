# Slide deck: Introducción — ¿Por qué IA en tu workflow?

---

## ¿Qué vamos a ver hoy?

Un día completo para aprender a usar IA de forma **práctica y profesional** en tu día a día como desarrollador .NET / Angular.

No es magia. Es una herramienta. Y como toda herramienta, hay que saber usarla bien.

---

## El problema real

> "El 70% del tiempo de un desarrollador no se dedica a escribir código nuevo"

- Leer y entender código ajeno
- Escribir documentación (o no escribirla)
- Buscar bugs
- Revisar PRs
- Escribir tests

**La IA no te reemplaza. Te libera de lo repetitivo para que pienses en lo que importa.**

---

## Los cuatro modos de GitHub Copilot Chat

```
┌────────────────────────────────────────────────────────┐
│  ASK       Preguntar y explorar. No toca nada.         │
│  EDIT      Editar archivos concretos que tú defines.   │
│  PLAN      Planificar antes de tocar código.           │
│  AGENT     Ejecutar tareas complejas de forma autónoma.│
└────────────────────────────────────────────────────────┘
```

Hoy aprenderás cuándo usar cada uno.

---

## Anatomía de un buen prompt

### Malo
```
arregla esto
```

### Bueno
```
En el archivo TasksController.cs, el método CreateTask no valida
que el campo Title no esté vacío. Añade validación con
ModelState y devuelve un 400 Bad Request si falla.
No modifiques otros métodos.
```

**Clave: Contexto + objetivo + restricciones**

---

## Las tres palancas del contexto

| Palanca | Ejemplo | Para qué |
|---|---|---|
| `@workspace` | `@workspace explica la arquitectura` | Contexto de todo el proyecto |
| `#file` | `#TasksController.cs` | Anclar a un archivo concreto |
| `/comando` | `/explain`, `/doc`, `/fix`, `/tests` | Acción predefinida |

---

## Regla de oro

> **Revisa siempre lo que genera la IA antes de aceptarlo.**

Copilot comete errores. Usa Edit y Agent mode precisamente porque muestran los cambios antes de aplicarlos.

La IA es tu copiloto, no el piloto.

---

## Proyecto del día: TaskManager

Una API de tareas con ASP.NET Core + Angular.  
Tiene **defectos intencionados** que usaremos en cada lab.

```
sample-app/
├── backend/   ← ASP.NET Core Web API
└── frontend/  ← Angular
```

Clona o abre la carpeta en tu IDE antes de continuar.
