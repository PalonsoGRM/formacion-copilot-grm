# Lab 4 — Frontend: Bugs & New Feature en el Dashboard Angular

**Duración**: 15 minutos  
**Herramienta**: GitHub Copilot Chat — modo **Ask** y **Agent**  
**IDE**: Visual Studio Code

---

## Objetivo

Usar Copilot para detectar y corregir tres bugs reales en un dashboard Angular, y después usar Agent mode para activar el botón **New Project** con funcionalidad completa.

Al final del lab tendrás el dashboard funcional y el botón \"+ New Project\" abriendo un formulario inline real.

---

## Preparación

### Paso 1: verifica que el frontend está arrancado

```powershell
cd sample-app/frontend/taskmanager-ui
npm start
```

Abre [http://localhost:4200](http://localhost:4200). Deberías ver el dashboard con una barra de stats, tabla de Tasks y tabla de Projects.

### Paso 2: crea un commit de punto de partida

```powershell
git add .
git commit -m "estado inicial lab 4 - dashboard con bugs"
```

---

## Los bugs que hay que encontrar

Antes de abrir Copilot, observa el dashboard en el navegador e identifica visualmente qué está roto. Hay exactamente **tres bugs**:

| # | Síntoma visible | Pista |
|---|----------------|-------|
| 🔴 Bug 1 | Una fila de la tabla Tasks tiene el badge de Status **en blanco** | El dato está mal escrito en el servicio mock |
| 🔴 Bug 2 | El stat card \"Open Tasks\" muestra **`Infinity`** | ¿Por qué? Sigue leyendo 👇 |
| 🔴 Bug 3 | El botón **⟳ Refresh** no hace nada al pulsarlo | Llama a un método que existe pero no recarga datos |

> **Frontend joke del día** 🐛
>
> En Java, C# o Python, dividir por cero lanza una excepción y explota todo.
> En JavaScript, `2 / 0` devuelve `Infinity` con total naturalidad. Sin avisar. Sin disculparse.
>
> ```js
> console.log(2 / 0);  // Infinity  ← el runtime: "¿problema? ¿cuál problema?"
> ```
>
> Es el equivalente programático del meme *"This is fine"* — el perrito sentado
> en la habitación en llamas tomando café. El código sigue ejecutándose,
> el número aparece en pantalla, y nadie se entera de que algo fue mal.
>
> Bug 2 es exactamente eso: un `/0` accidental que hace que \"Open Tasks\" muestre
> `Infinity` en lugar de `2`. Copilot lo detecta sin ejecutar el código. 🔥☕

---

## Ejercicio 1 — Detectar los bugs con Ask mode (5 min)

### Paso 1: cambia a Ask mode

En Copilot Chat (`Ctrl+Alt+I`), selecciona modo **Ask**.

### Paso 2: detecta los bugs con contexto de archivos

Abre `dashboard.ts` y `task.ts` en el editor, luego escribe en el chat:

```
#file:src/app/components/dashboard/dashboard.ts
#file:src/app/services/task.ts

Analiza estos dos archivos del dashboard Angular y busca:
1. Bugs que causen que datos no se muestren correctamente en la UI
2. Botones que llamen a métodos inexistentes o que no hagan lo esperado
3. Cálculos matemáticos incorrectos en las estadísticas

Para cada bug: indica archivo, línea aproximada, causa y cómo corregirlo.
```

### Paso 3: analiza la respuesta

Copilot debería identificar los tres bugs. ¿Detectó el `/0` sin ejecutar el código?

> **Qué observar**: el análisis estático de Copilot es suficiente para detectar bugs
> de runtime como la división por cero. Especialmente útil cuando reproducir el bug
> en un entorno real es costoso o lento.

---

## Ejercicio 2 — Corregir los tres bugs con Agent mode (5 min)

### Paso 1: cambia a Agent mode

En el selector de modo del chat, elige **Agent**.

### Paso 2: prompt de corrección

```
Corrige los tres bugs del dashboard Angular:

1. En src/app/services/task.ts hay un typo en el nombre de una propiedad
   en los datos mock que hace que una fila muestre el status en blanco.

2. En src/app/components/dashboard/dashboard.ts el cálculo de stats.open
   devuelve Infinity porque hay una división por cero. Corrígelo para que
   cuente correctamente las tareas con status 'Open'.

3. El botón Refresh en dashboard.html llama a un método que no recarga datos.
   Corrígelo para que llame al método correcto.

No cambies ningún otro comportamiento. Solo corrige los tres bugs.
```

### Paso 3: verifica en el navegador

Tras aplicar los cambios de Copilot, comprueba en [http://localhost:4200](http://localhost:4200):

- [ ] Todas las filas de Tasks tienen badge de status visible
- [ ] El stat card \"Open Tasks\" muestra `2` (no `Infinity`)
- [ ] El botón ⟳ Refresh muestra el spinner brevemente y recarga los datos

---

## Ejercicio 3 — Nueva feature: activar \"+ New Project\" (5 min)

El botón **+ New Project** actualmente hace `alert('coming soon!')`. Vamos a activarlo.

### Paso 1: mantente en Agent mode

### Paso 2: prompt de la feature

```
En el dashboard Angular (src/app/components/dashboard/), implementa la
funcionalidad del botón \"+ New Project\":

Al pulsar el botón debe aparecer un formulario inline debajo del header
de la tabla Projects con dos campos: \"Name\" (requerido) y \"Description\".
Incluye un botón \"Create\" y un botón \"Cancel\".

Al hacer clic en \"Create\":
- Valida que el campo Name no esté vacío (muestra mensaje de error si lo está)
- Añade el nuevo proyecto al array projectList con un id autoincremental
- Actualiza el contador stats.projects
- Cierra el formulario y muestra el nuevo proyecto en la tabla

Al hacer clic en \"Cancel\": cierra el formulario sin hacer nada.

Restricciones:
- No uses módulos externos (no Bootstrap, no Angular Material)
- Usa solo CommonModule y FormsModule (ya disponibles en Angular standalone)
- El formulario debe tener estilos consistentes con el resto del dashboard (dashboard.css)
- No hagas llamadas HTTP reales, trabaja solo en memoria
```

### Paso 3: revisa el plan antes de aprobar

Si Agent mode muestra un plan de cambios antes de ejecutar, revísalo:

- ¿Añade `FormsModule` al array `imports` del componente?
- ¿Usa `[(ngModel)]` para binding bidireccional en los inputs?
- ¿Gestiona un booleano `showNewProjectForm` para mostrar/ocultar el formulario?
- ¿Añade estilos al `dashboard.css` para el formulario?

### Paso 4: verifica el resultado

- [ ] El botón \"+ New Project\" muestra el formulario inline sin navegar a otra página
- [ ] Intentar crear con Name vacío muestra un mensaje de error bajo el campo
- [ ] Crear un proyecto nuevo → aparece en la tabla y el contador de stats sube
- [ ] Cancel → cierra el formulario sin modificar nada

---

## Checkpoint final

Al terminar el lab deberías poder:

1. ✅ Usar Copilot **Ask** con `#file` para análisis estático de bugs sin ejecutar código
2. ✅ Usar **Agent** mode para aplicar correcciones precisas y acotadas
3. ✅ Usar **Agent** mode para implementar una feature nueva con estado, formularios y validación

---

## Referencia de archivos clave

| Archivo | Propósito |
|---------|-----------|
| `src/app/components/dashboard/dashboard.ts` | Lógica del componente, métodos, estado |
| `src/app/components/dashboard/dashboard.html` | Template: tablas, botones, formulario |
| `src/app/components/dashboard/dashboard.css` | Estilos del dashboard |
| `src/app/services/task.ts` | Datos mock y métodos de acceso a datos |

---

## Fallback — si el servidor no arranca o hay error de compilación

```powershell
# Desde la carpeta del frontend
cd sample-app/frontend/taskmanager-ui
npm start

# Si hay errores de módulo tras el ejercicio 3, verifica que FormsModule
# esté importado en dashboard.ts:
#   imports: [CommonModule, FormsModule]
```

---

[← Lab 3: Agent Mode](../03-agent-mode/README.md) | [→ Lab 5: Copilot Instructions](../05-copilot-instructions/README.md)
