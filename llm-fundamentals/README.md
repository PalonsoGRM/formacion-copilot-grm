# Fundamentos de IA (20 min)

> **Bloque**: 08:55 – 09:15 · Sesión formativa IA — 23/25 marzo 2026
> **Objetivo**: entender qué es un LLM, cómo procesa la información y por qué eso importa a la hora de usar GitHub Copilot.

---

## Contenidos

| # | Sección | En pocas palabras |
|---|---------|-------------------|
| 00 | [Panorama actual](#00--panorama-actual) | Proveedores, modelos en producción, IA en el IDE y en el CLI |
| 01 | [¿Qué es un LLM?](#01--qué-es-un-llm) | Qué hace, cómo funciona y sus límites |
| 02 | [Tokens](#02--tokens) | La unidad básica del LLM |
| 03 | [Prompts](#03--prompts) | Cómo hablarle al modelo para obtener lo que necesitas |
| 04 | [Context Window](#04--context-window) | El límite de lo que el modelo ve |
| 05 | [System Prompt](#05--system-prompt) | La instrucción oculta que configura el comportamiento |
| 06 | [Modelos disponibles en Copilot](#06--modelos-disponibles-en-copilot) | Qué modelo usar y cuándo |
| 07 | [Glosario](#07--glosario) | Repaso de los términos clave |

---

## 00 — Panorama actual

### Proveedores LLM — Situación marzo 2026

El mercado de modelos de lenguaje está dominado por tres grandes familias:

| Proveedor | Modelos principales (marzo 2026) |
|-----------|----------------------------------|
| **Anthropic** | Claude Opus 4.6 · Claude Sonnet 4.6 · Claude Haiku 4.5 |
| **OpenAI** | GPT-5.4 · GPT-5.3-Codex · GPT-4.1 |
| **Google** | Gemini 3.1 Pro · Gemini 3.1 Flash |

Todos estos modelos son accesibles desde GitHub Copilot Empresarial, con distintos multiplicadores de coste (ver [sección 06](#06--modelos-disponibles-en-copilot)).

### IA en el IDE

Los asistentes IA están integrados de forma nativa en los entornos de desarrollo:

- **GitHub Copilot** en VS Code, JetBrains, Visual Studio — completado inline, chat, agentes
- Soporte para Ask, Plan y Agent mode
- Contexto del proyecto cargado automáticamente

### IA en el CLI

La IA también vive fuera del IDE:

- **GitHub Copilot CLI** — traduce lenguaje natural a comandos shell, explica errores, ejecuta desde terminal
- Útil para equipos que trabajan con pipelines, scripts o entornos sin interfaz gráfica

---

## 01 — ¿Qué es un LLM?

Un **LLM** (Large Language Model, o Modelo de Lenguaje de Gran Tamaño) es una inteligencia artificial diseñada para entender, procesar y generar texto de manera similar a como lo haría un ser humano.

En términos sencillos, imagínalo como un **"autocompletar" superpotente**. Mientras que tu móvil predice la siguiente palabra de un mensaje, un LLM ha leído casi todo internet y puede predecir párrafos enteros, escribir ensayos o mantener una conversación coherente.

### ¿Cómo funciona?

> Imagina a un bibliotecario que ha leído millones de libros, artículos y chats. No "entiende" los sentimientos, pero conoce tan bien los patrones del lenguaje que sabe exactamente qué palabras suelen ir juntas.

Tres características clave:

- **Es "Grande"**: se entrena con volúmenes masivos de datos (libros, webs, código)
- **Es un "Modelo"**: es una estructura matemática que representa cómo funciona el lenguaje
- **Predice**: su trabajo principal es adivinar cuál es la siguiente palabra más probable en una frase, basándose en el contexto

### ¿Para qué sirve?

Gracias a esa capacidad de predecir y estructurar ideas, los LLM pueden:

| Capacidad | Ejemplo |
|-----------|---------|
| **Conversar** | Responder preguntas de forma natural (como ChatGPT) |
| **Traducir** | Pasar textos de un idioma a otro con gran fluidez |
| **Resumir** | Leer un texto largo y extraer lo más importante |
| **Crear** | Escribir desde poemas hasta código de programación |

---

## 02 — Tokens

### ¿Qué es un Token?

Un **token** es la unidad mínima de texto que un LLM procesa. No es una palabra completa, sino un fragmento — sílaba o subpalabra — en el que el modelo descompone el lenguaje para operar matemáticamente sobre él.

### 3 datos clave

1. **No siempre es una palabra**: un token puede ser una palabra entera, una sílaba, un solo carácter o incluso un espacio en blanco.

2. **La regla de oro**: en promedio, en español e inglés, **1.000 tokens equivalen a unas 750 palabras** — más o menos el espacio de una página y media de un documento.

3. **Es la "moneda" de la IA**: cuando usas herramientas como ChatGPT o Copilot, los límites de memoria (cuánto recuerda de la charla) y el coste del servicio se miden por cuántos tokens se procesan.

> **Recurso**: [GPT Tokenizer Playground](https://platform.openai.com/tokenizer) — pega cualquier texto y ve exactamente cómo lo divide el modelo en tokens.

---

## 03 — Prompts

### ¿Qué es un prompt?

El **prompt** es el punto de entrada: la instrucción o el texto que le enviamos al modelo para obtener una respuesta.

Un prompt puede ser un comentario de código, el nombre de una función que acabas de escribir, o una pregunta directa en el chat del IDE.

### La analogía del genio de la lámpara

> Imagina que tienes un genio que sabe hacer de todo, pero no tiene iniciativa propia. **El prompt es tu deseo.**
>
> - Si el prompt es **vago**: "Escríbeme algo" → el genio te dará algo genérico que quizá no te sirva.
> - Si el prompt es **específico**: "Escríbeme un cuento corto sobre un gato astronauta, en tono divertido y para un niño de 5 años" → el genio te dará exactamente lo que buscas.

### Consejos básicos de prompting

#### 1. Dale un Rol (¿Quién es la IA?)

No le preguntes a "la máquina"; asígnale una identidad. Esto ajusta el tono y el nivel de detalle.

| | Ejemplo |
|---|---------|
| **Mal** | "Explícame la fotosíntesis" |
| **Bien** | "Actúa como un profesor de ciencias de primaria. Explícame la fotosíntesis usando una analogía sencilla" |

#### 2. Contexto y Tarea (¿Qué y para qué?)

Cuantos más detalles des sobre la situación, menos "alucinará" o inventará la IA.

| | Ejemplo |
|---|---------|
| **Mal** | "Escribe un correo" |
| **Bien** | "Escribe un correo para mi jefe pidiéndole libre el próximo viernes porque tengo una cita médica. Que sea profesional pero cercano" |

#### 3. Establece el Formato (¿Cómo lo quieres?)

Dile exactamente cómo quieres que te entregue la información. Ahorra mucho tiempo de edición.

Ejemplos: `"Responde en una tabla"`, `"Usa bullet points"`, `"Que no ocupe más de 100 palabras"`, `"Escríbelo en formato de guion de vídeo"`.

#### 4. La técnica de "Paso a Paso"

Si la tarea es compleja, pídele que piense antes de responder. Esto reduce errores lógicos de forma significativa.

> **Truco**: añade al final de tu prompt la frase **"Piensa paso a paso antes de darme la respuesta final"**. Esto obliga a la IA a organizar sus tokens de forma más coherente.

> También sirve escribir **"¿Tienes preguntas?"** o **"Hazme todas las preguntas necesarias para aclarar dudas"**. Esto ayuda a resolver puntos sin cubrir o elementos sin detallar.

---

## 04 — Context Window

### ¿Qué es el context window?

Es la **"memoria a corto plazo"** del modelo durante una sesión.

| Aspecto | Descripción |
|---------|-------------|
| **Capacidad** | Cantidad máxima de tokens que el modelo puede "tener en mente" a la vez |
| **Qué incluye** | Tu prompt actual, el código que tienes abierto, el historial de la conversación y las instrucciones internas |
| **Limitación** | Si tu proyecto es muy grande y la ventana se llena, el modelo empezará a "olvidar" las primeras partes de la conversación |

### La analogía de la "pizarra"

> Imagina que el LLM tiene una pizarra frente a él donde escribe todo lo que tú le dices y todo lo que él te responde.
>
> - **Mientras quepa en la pizarra**: la IA recuerda perfectamente el contexto, los nombres que mencionaste y las instrucciones que diste al principio.
> - **Si la pizarra se llena**: para seguir escribiendo cosas nuevas, la IA tiene que borrar lo primero que se escribió arriba. En ese momento, "olvida" el inicio de la charla.

### 3 claves sobre la ventana de contexto

1. **Se mide en tokens**: no en minutos ni en páginas, sino en el número de tokens que caben en esa "pizarra".

2. **Varía según el modelo**: algunos modelos tienen ventanas pequeñas (como una nota adhesiva) y otros tienen ventanas gigantescas (como un libro entero de 500 páginas).

3. **Afecta la coherencia**: si un libro es muy largo y la ventana de contexto es pequeña, la IA no podrá resumir el capítulo 1 si ya vas por el capítulo 20, porque ya lo habrá "borrado" de su memoria activa.

---

## 05 — System Prompt

### ¿Qué es el system prompt?

Si el **prompt** es el "deseo" que le pides al genio, el **System Prompt son las reglas de la casa** — el "ADN" que define cómo debe comportarse ese genio antes de que tú siquiera abras la boca.

Es una instrucción oculta que se le da a la IA para configurar su personalidad, sus límites y su tono de forma permanente durante toda la sesión.

### La analogía del "Manual de Empleado"

> Imagina que contratas a un recepcionista. Antes de que llegue el primer cliente (tú), le entregas un manual de conducta:
>
> **Manual (System Prompt)**: "Eres un recepcionista de un hotel de lujo. Debes ser extremadamente educado, hablar siempre en español e inglés, y nunca dar información sobre la vida privada de los dueños."
>
> **Cliente (Tu Prompt)**: "Hola, ¿tienes habitación?"
>
> **Resultado**: el recepcionista te responderá con elegancia y en dos idiomas, porque su "configuración de fábrica" para ese día ya está establecida.

### 3 diferencias clave con el prompt normal

| Diferencia | Explicación |
|------------|-------------|
| **Jerarquía** | El System Prompt tiene "más autoridad". Si el sistema dice "Nunca uses emojis" y tú en el chat dices "Pon un emoji", la IA suele priorizar la regla del sistema. |
| **Persistencia** | Mientras que un prompt normal puede "olvidarse" si la conversación es muy larga (sale de la ventana de contexto), el System Prompt suele mantenerse "fijo" en la memoria de la IA. |
| **Invisibilidad** | Normalmente no ves el System Prompt en la interfaz de aplicaciones como ChatGPT, pero está ahí detrás definiendo que la IA sea "un asistente útil, inofensivo y honesto". |

> **Relevancia para Copilot**: el fichero `.github/copilot-instructions.md` actúa como un System Prompt para tu repositorio — define el contexto, las convenciones y las restricciones que Copilot tendrá en cuenta en todas las interacciones dentro del proyecto.

---

## 06 — Modelos disponibles en Copilot

### Tabla de modelos (marzo 2026)

| Categoría | Modelos | Multiplicador |
|-----------|---------|:-------------:|
| Modelos básicos — tareas sencillas | GPT-4.1 | **0x** |
| Modelo intermedio de generación de código | GPT-5.3-Codex | **1x** |
| Mejores modelos generalistas | Claude Sonnet 4.6 · Gemini 3.1 Flash | **1x** |
| Modelo más avanzado de generación de código | GPT-5.4 | **3x** |
| Modelo de máxima capacidad | Claude Opus 4.6 · Gemini 3.1 Pro | **3x** |

### ¿Qué significa el multiplicador?

El multiplicador indica el **coste en "premium requests"** por cada interacción:

- **0x** — Uso ilimitado, incluido en la suscripción base. Para tareas sencillas y documentación.
- **1x** — 1 premium request por interacción. Equilibrio velocidad/calidad.
- **3x** — 3 premium requests por interacción. Modelos de razonamiento profundo o mayor contexto.

### GitHub Copilot Empresarial (Corporate)

- Suscripción a modelos LLM para usar en el IDE.
- **Modelos 0x**: uso ilimitado incluido en la suscripción.
- **Modelos 1x en adelante**: uso con coste extra por premium request.
- Existen límites de consumo gestionados por dirección para evitar un consumo masivo accidental de tokens.

**Recomendación práctica:**

| Situación | Modelo recomendado |
|-----------|-------------------|
| Día a día, completado de código, refactors | `1x` — rápido y preciso |
| Arquitectura, análisis complejo, planificación | `3x` |
| Completado inline (ghost text) | Configurable independientemente del chat |

---

## 07 — Glosario

### Términos fundamentales

| Término | Definición |
|---------|-----------|
| **LLM** | *Large Language Model* — modelo de IA entrenado con muchos datos que tiene la capacidad de predecir la siguiente palabra. |
| **Token** | Unidad mínima de texto que entiende el LLM. Sirve también para medir consumo y coste. |
| **Context Window** | La memoria a "corto plazo" de la que dispone un LLM durante una sesión. |
| **Prompt** | El punto de entrada: el input, la acción o deseo que le damos al LLM. |
| **System Prompt** | Las instrucciones "ocultas" del modelo — perfilan su personalidad, estilo y comportamiento, y tienen máxima jerarquía dentro del contexto. |
| **Alucinación** | Cuando el modelo devuelve algo que no es coherente o no tiene sentido para el usuario. |
| **Tools** | Herramientas a disposición del LLM que le permiten realizar operaciones que por sí solo no podría (ejecutar código, buscar en internet, llamar APIs). |

### Términos avanzados

| Término | Definición |
|---------|-----------|
| **Prompt Engineering** | La práctica de diseñar y optimizar prompts para obtener mejores resultados del modelo, reduciendo errores y mejorando la precisión. |
| **RAG** | *(Retrieval Augmented Generation)* — técnica que combina un LLM con documentos o datos externos, permitiéndole responder basándose en información específica de la empresa y no solo en lo que aprendió durante el entrenamiento. |
| **Agente** | Sistema basado en un LLM que puede razonar, tomar decisiones y usar herramientas para cumplir un objetivo concreto, no solo responder texto. |
| **Zero-Shot** | Capacidad del modelo para realizar una tarea sin ejemplos previos, solo con la instrucción dada en el prompt. |
| **Few-Shot** | Técnica en la que se incluyen uno o varios ejemplos dentro del prompt para guiar mejor la respuesta del modelo. |
| **Chain of Thought** | Forma de razonar del modelo cuando descompone un problema en pasos intermedios antes de dar la respuesta final. |
| **Token Limit** | Número máximo de tokens permitidos por modelo en una petición o sesión. |

---

[← README principal](../README.md) | [→ GitHub Copilot en el IDE](../copilot-ide-intro/README.md)
