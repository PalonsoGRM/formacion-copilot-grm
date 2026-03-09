# Lab 3 — Agent Mode: Añadir una feature completa

**Duración**: 30 minutos  
**Herramienta**: GitHub Copilot Chat — modo **Agent**  
**IDE**: Visual Studio Code

---

## Objetivo

Usar Agent mode para que Copilot añada una feature nueva de principio a fin, tomando decisiones de forma autónoma sobre qué archivos crear y modificar.

---

## Preparación

1. Haz un commit del estado actual antes de empezar (por seguridad):
   ```powershell
   git add . && git commit -m "estado inicial lab 3"
   ```
2. Abre Copilot Chat → modo **Agent**
3. Abre una terminal integrada en VS Code

---

## Ejercicio 1 — Endpoint de tareas vencidas (20 min)

### Prompt

```
En el proyecto TaskManager.Api, añade un nuevo endpoint:
GET /api/tasks/overdue

Este endpoint debe devolver todas las tareas cuya DueDate es anterior
a la fecha actual y cuyo Status NO es "done".

Requisitos:
- Sigue el mismo patrón que los endpoints existentes en TasksController.cs
- Devuelve 200 con la lista (vacía si no hay tareas vencidas)
- Añade datos de prueba en TaskManagerContext.cs: al menos 2 tareas con DueDate
  en el pasado para que el endpoint devuelva datos reales
- Asegúrate de que el proyecto compila y responde al endpoint

No instales paquetes nuevos. No modifiques la estructura de la base de datos.
```

### Observa mientras Copilot trabaja

- ¿Qué archivos decide tocar?
- ¿Propone ejecutar comandos de terminal? ¿Cuáles?
- ¿Se auto-corrige si encuentra algún error?

### Prueba el resultado

```powershell
dotnet run --project TaskManager.Api
```

En otra terminal:
```powershell
curl http://localhost:5000/api/tasks/overdue
```

---

## Ejercicio 2 — README del proyecto (10 min)

El proyecto no tiene README. Vamos a generarlo:

```
Genera un README.md completo para el proyecto TaskManager.Api en la raíz
del proyecto. Debe incluir:
- Descripción del proyecto
- Lista de endpoints con método HTTP, ruta, descripción y ejemplo de respuesta JSON
- Instrucciones para arrancar el proyecto localmente (dotnet run)
- Requisitos (.NET versión, dependencias)
- Sección de "Defectos conocidos" listando los problemas de validación
  que tiene actualmente el API

Usa Markdown con formato claro y secciones bien definidas.
```

---

## Puntos clave del lab

- Agent mode decide **por su cuenta** qué archivos tocar — tú supervisas
- Aprueba los comandos de terminal solo si entiendes qué hacen
- Si algo sale mal: `git checkout .` vuelve al estado inicial
- Ideal para tareas donde no sabrías ni por dónde empezar a mano

---

## Discusión

- ¿En qué se diferencia el resultado de lo que habrías hecho tú?
- ¿Modificó algún archivo que no esperabas?
- ¿Cuándo usarías Agent vs Edit en tu trabajo real?
