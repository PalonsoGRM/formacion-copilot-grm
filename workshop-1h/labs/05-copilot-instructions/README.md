# Lab Extra 05 — Copilot Instructions & el Poder de la Carpeta `.github`

> **Tipo**: Lab extra — realiza este lab si quedan ≥ 20 minutos después del Lab 04.  
> **Duración**: 20 min (ejercicios básicos) · hasta 60 min (con sección avanzada)  
> **Modo**: Agent / Ask  
> **IDE**: VS Code  
> **App**: `sample-app/backend/TaskManager.Api`

---

## ¿Por qué este lab?

Copilot genera código genérico si no sabe nada de tu proyecto. Existe un archivo que cambia todo: `.github/copilot-instructions.md`. Una vez creado y commiteado, **todo el equipo recibe el mismo contexto en cada sugerencia, en todos los IDEs**.

Este lab tiene dos partes:

1. **Copilot Instructions** — configurar el archivo y ver el efecto inmediato en las sugerencias
2. **Más allá de Copilot** — todo lo que la carpeta `.github` puede hacer por tu proyecto

---

## Motivación — El problema en 2 minutos

Antes de crear el archivo, prueba este prompt en Copilot Chat (modo **Ask**):

```
Añade un nuevo campo `CompletedAt` de tipo fecha a `TaskItem`.
Actualiza el seed data en TaskManagerContext.cs con valores de ejemplo.
```

Observa la respuesta. Probablemente Copilot:
- Usa `DateTime CompletedAt` en lugar de `DateTimeOffset`
- Usa `DateTime.Now` en el seed data en lugar de `DateTimeOffset.UtcNow`
- Puede que proponga instalar un paquete NuGet innecesario

> Copilot no conoce vuestros estándares de equipo... a menos que se los digas explícitamente.

---

## Ejercicio 1 — Crear `copilot-instructions.md` (5 min)

El repositorio ya incluye una plantilla preparada en `docs-templates/.github/`.

### Paso 1: Copia la plantilla al proyecto

```powershell
# Desde la raíz del repositorio
$dest = "sample-app\backend\TaskManager.Api\.github"
New-Item -ItemType Directory -Force -Path $dest | Out-Null
Copy-Item docs-templates\.github\copilot-instructions.md $dest\copilot-instructions.md -Force
```

### Paso 2: Lee el archivo (2 min)

Abre `.github/copilot-instructions.md` y observa la estructura:

| Sección | Para qué sirve |
|---------|----------------|
| **Descripción del proyecto** | Le dice a Copilot qué es esta app y su stack |
| **Arquitectura** | Muestra la estructura de carpetas y el patrón usado |
| **Comandos esenciales** | Los comandos de build/run que Agent puede ejecutar |
| **Convenciones de código** | Reglas que SIEMPRE debe seguir (`DateTimeOffset.UtcNow`, etc.) |
| **Endpoints disponibles** | Evita que "invente" endpoints que ya existen |
| **Problemas conocidos** | Bugs intencionales que NO debe corregir (son los ejercicios del taller) |
| **Reglas para Copilot** | Restricciones explícitas: no instalar NuGet, no borrar seed data |

> **Ámbito del archivo**: funciona en VS Code, Visual Studio, JetBrains, Eclipse, Xcode y GitHub.com. Un commit → todo el equipo se beneficia automáticamente.

### Paso 3 (opcional): Genera el tuyo con Copilot Coding Agent

En [github.com/copilot/agents](https://github.com/copilot/agents), selecciona tu repositorio y usa este prompt:

```
Your task is to "onboard" this repository to Copilot coding agent by adding
a .github/copilot-instructions.md file with information describing how a
coding agent seeing it for the first time can work most efficiently.
Instructions must be no longer than 2 pages and must not be task-specific.
```

---

## Ejercicio 2 — Ver el efecto (5 min)

### Paso 1: Confirma que VS Code ha cargado el archivo

En Copilot Chat (modo **Ask**), escribe:

```
#codebase ¿Tienes instrucciones de repositorio activas para este proyecto?
```

Deberías ver que Copilot confirma el contexto del archivo `copilot-instructions.md`.

### Paso 2: Repite el prompt de la motivación

```
Añade un nuevo campo `CompletedAt` de tipo fecha a `TaskItem`.
Actualiza el seed data en TaskManagerContext.cs con valores de ejemplo.
```

Compara con la respuesta anterior:

| Sin instrucciones | Con instrucciones |
|-------------------|-------------------|
| `DateTime CompletedAt` | ✅ `DateTimeOffset CompletedAt` |
| `DateTime.Now` en seed | ✅ `DateTimeOffset.UtcNow` en seed |
| Puede sugerir NuGet | ✅ Sin dependencias nuevas |

### Paso 3: Prueba una regla de arquitectura

```
Crea un endpoint que devuelva estadísticas de usuarios:
cuántas tareas tienen asignadas por estado.
```

Copilot debería seguir el patrón `Controller → DbContext` directo (sin service layer) y devolver `IActionResult`, exactamente como dicen las instrucciones.

---

## Ejercicio 3 (opcional) — Instrucciones por ruta (5 min)

Para partes del código con reglas distintas (tests vs. producción, frontend vs. backend), puedes usar **path-specific instructions**. Se crean en `.github/instructions/` y se activan solo cuando Copilot trabaja en archivos que coincidan con el patrón `applyTo`.

### Crear instrucciones para tests

Crea el archivo `.github/instructions/tests.instructions.md`:

```markdown
---
applyTo: "**/*.Tests/**/*.cs"
---

# Instrucciones para archivos de test

- Usa **xUnit** como framework de tests.
- Usa **Moq** para mocks — no crees implementaciones stub a mano.
- Cada test debe tener el formato `Método_Escenario_ResultadoEsperado`.
- Usa `Assert.Equal`, no `Assert.True(a == b)`.
- No uses `Thread.Sleep` — usa `Task.Delay` o mocks de tiempo.
- Los tests no deben tener dependencias externas (base de datos, red, sistema de archivos).
```

### Probar el efecto

Abre (o crea) un archivo dentro de una carpeta `*.Tests/` y pide:

```
Genera tests unitarios para el método GetById del TasksController.
```

Compara con el mismo prompt desde un archivo fuera de esa carpeta — las instrucciones solo se aplican cuando el contexto coincide con el patrón `applyTo`.

---

## Más allá de Copilot — El poder del `.github` (10 min)

La carpeta `.github` no es solo para Copilot. Es el **panel de control de tu repositorio en GitHub**. Todo lo que configures aquí se aplica automáticamente para todo el equipo.

### Mapa completo de lo que puedes configurar

```
.github/
├── copilot-instructions.md          ← instrucciones globales para Copilot (este lab)
├── instructions/                    ← instrucciones path-specific para Copilot
│   └── *.instructions.md
├── workflows/                       ← GitHub Actions: CI/CD, linting, deploy...
│   └── ci.yml
├── ISSUE_TEMPLATE/                  ← formularios estructurados al crear issues
│   ├── bug_report.yml
│   └── feature_request.yml
├── pull_request_template.md         ← plantilla automática al abrir un PR
├── CODEOWNERS                       ← revisores automáticos por área del código
├── CODE_OF_CONDUCT.md               ← código de conducta del proyecto
├── CONTRIBUTING.md                  ← guía para contribuidores externos
└── SECURITY.md                      ← cómo reportar vulnerabilidades
```

---

### PR Template — tienes uno listo

El repositorio ya incluye una plantilla en `docs-templates/.github/pull_request_template.md`. Para activarla en el proyecto:

```powershell
Copy-Item docs-templates\.github\pull_request_template.md `
  sample-app\backend\TaskManager.Api\.github\pull_request_template.md -Force
```

Una vez en `.github/`, GitHub la carga automáticamente cada vez que alguien abre un PR — sin configuración adicional. Todos los PRs tienen la misma estructura desde el primer día.

---

### CODEOWNERS — revisores automáticos por código

El archivo `CODEOWNERS` asigna revisores automáticos según la ruta de los archivos modificados en un PR:

```gitignore
# Cualquier archivo → el equipo completo
* @my-org/backend-team

# Solo los controllers → el tech lead
/Controllers/ @tech-lead-username

# Solo los workflows de GitHub Actions
/.github/workflows/ @devops-team
```

Cuando alguien abre un PR que toca `/Controllers/`, GitHub solicita la revisión de `@tech-lead-username` automáticamente. Sin que nadie tenga que acordarse.

---

### GitHub Actions — CI automático en cada PR

Los workflows en `.github/workflows/` se ejecutan en respuesta a eventos. Para este proyecto:

```yaml
# .github/workflows/ci.yml
name: CI
on:
  pull_request:
    branches: [main]

jobs:
  build-and-test:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '8.x'
      - run: dotnet build
      - run: dotnet test
```

> **Combinación poderosa**: `copilot-instructions.md` le dice a Copilot "asegúrate de que `dotnet build` pasa". El workflow de CI verifica que realmente pasa en cada PR. Son complementarios — el primero guía, el segundo valida.

---

### El repositorio especial `.github` (nivel organización)

En GitHub puedes crear un repositorio llamado exactamente `.github` en tu organización. Actúa como **fallback para todos los repositorios** de la organización que no tengan su propia carpeta `.github`:

- Plantillas de issues y PRs compartidas por defecto
- Código de conducta a nivel de organización
- Si un repo tiene su propio `.github/`, ese tiene prioridad sobre el fallback

---

## Jerarquía de instrucciones para Copilot

Cuando varias fuentes de instrucciones coexisten, esta es la prioridad (de mayor a menor):

| Nivel | Fuente | Ámbito |
|-------|--------|--------|
| 1 (mayor) | Instrucciones personales | Solo tú, en GitHub.com |
| 2 | `.github/instructions/*.instructions.md` | Archivos que coincidan con `applyTo` |
| 3 | `.github/copilot-instructions.md` | Todo el repositorio |
| 4 (menor) | Instrucciones de organización | Toda la organización (Enterprise, preview) |

Todas las instrucciones aplicables se combinan y se pasan a Copilot. Solo hay conflicto si se contradicen.

---

## Resumen

| Herramienta | Beneficio inmediato |
|-------------|---------------------|
| `copilot-instructions.md` | Copilot respeta TUS estándares en todos los IDEs del equipo |
| `instructions/*.instructions.md` | Reglas específicas por tipo de archivo (tests, frontend, etc.) |
| `pull_request_template.md` | PRs consistentes sin esfuerzo |
| `CODEOWNERS` | Revisores correctos asignados automáticamente |
| `workflows/ci.yml` | Build y tests verificados en cada PR |

> Un solo commit en `.github/` puede mejorar la calidad del código generado por Copilot para todo el equipo, automatizar la gestión de PRs, y asegurar que el CI pase — sin que nadie tenga que recordarlo.

---

## Recursos

| Recurso | URL |
|---------|-----|
| Instrucciones de repositorio | https://docs.github.com/en/copilot/how-tos/configure-custom-instructions/add-repository-instructions |
| Soporte por IDE y feature | https://docs.github.com/en/copilot/reference/custom-instructions-support |
| Ejemplos de instrucciones | https://docs.github.com/en/copilot/tutorials/customization-library/custom-instructions |
| Instrucciones de organización | https://docs.github.com/en/copilot/how-tos/configure-custom-instructions/add-organization-instructions |
| Repositorio especial `.github` | https://docs.github.com/en/communities/setting-up-your-project-for-healthy-contributions/creating-a-default-community-health-file |
| CODEOWNERS | https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/about-code-owners |
| GitHub Actions | https://docs.github.com/en/actions/learn-github-actions/understanding-github-actions |

---

[← Lab 04: Frontend](../04-frontend/README.md) | [→ Volver al índice](../../README.md)
