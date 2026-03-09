# Recursos — FormacionIA

## GitHub Copilot

| Recurso | URL |
|---|---|
| Documentación oficial | https://docs.github.com/en/copilot |
| Copilot en VS Code | https://code.visualstudio.com/docs/copilot/overview |
| Copilot en Visual Studio | https://learn.microsoft.com/en-us/visualstudio/ide/visual-studio-github-copilot-extension |
| Agent mode docs | https://code.visualstudio.com/docs/copilot/copilot-agent-mode |
| MCP en Copilot | https://code.visualstudio.com/docs/copilot/model-context-protocol |
| Prompt engineering guide | https://docs.github.com/en/copilot/using-github-copilot/prompt-engineering-for-github-copilot |

## OpenCode

| Recurso | URL |
|---|---|
| Web oficial | https://opencode.ai |
| Documentación | https://opencode.ai/docs |
| Repositorio | https://github.com/sst/opencode |
| Instalación | `npm install -g opencode-ai` |

## SpecKit

| Recurso | URL |
|---|---|
| Repositorio | https://github.com/github/spec-kit |
| Documentación | https://github.github.io/spec-kit/ |
| Metodología completa | https://github.com/github/spec-kit/blob/main/spec-driven.md |
| Video overview | https://www.youtube.com/watch?v=a9eR1xsfvHg |
| Demo .NET brownfield | https://github.com/mnriem/spec-kit-aspnet-brownfield-demo |
| Demo .NET CLI greenfield | https://github.com/mnriem/spec-kit-dotnet-cli-demo |

## agentic-factory-hack (referencia arquitectural)

| Recurso | URL |
|---|---|
| Repositorio | https://github.com/microsoft/agentic-factory-hack |
| Challenge 2 (.NET + Copilot agent) | https://github.com/microsoft/agentic-factory-hack/tree/main/challenges/challenge-2 |

## Seguridad

| Recurso | URL |
|---|---|
| OWASP Top 10 | https://owasp.org/www-project-top-ten/ |
| GitHub Secret Scanning | https://docs.github.com/en/code-security/secret-scanning |
| Copilot code referencing | https://docs.github.com/en/copilot/managing-copilot/managing-github-copilot-in-your-organization/managing-github-copilot-features-in-your-organization/managing-copilot-policies-as-an-administrator |

## Lectura recomendada

- [GitHub Blog: Spec-Driven Development](https://github.blog/ai-and-ml/github-copilot/how-to-use-github-copilot-for-spec-driven-development/)
- [GitHub Blog: Agent mode](https://github.blog/ai-and-ml/github-copilot/github-copilot-agent-mode-activated/)
- [Microsoft: Agentic AI patterns](https://learn.microsoft.com/en-us/azure/architecture/ai-ml/architecture/agentic-architecture)

## Herramientas mencionadas en la formación

```powershell
# OpenCode
npm install -g opencode-ai

# SpecKit CLI
uv tool install specify-cli --from git+https://github.com/github/spec-kit.git

# uv (gestor Python moderno)
winget install astral-sh.uv

# Python 3.11+
winget install Python.Python.3.11

# Node.js 20 LTS
winget install OpenJS.NodeJS.LTS
```

## Extensiones de VS Code recomendadas

```
ms-dotnettools.csdevkit          C# Dev Kit
angular.ng-template              Angular Language Service
github.copilot                   GitHub Copilot
github.copilot-chat              GitHub Copilot Chat
eamodio.gitlens                  GitLens
```

## Cheatsheet de prompts (para llevarte)

```
# Arquitectura
@workspace describe la arquitectura, capas y endpoints de este proyecto

# Documentar
#Controller.cs Añade comentarios de documentación XML a todos los métodos públicos

# Seguridad
@workspace actúa como revisor de seguridad. Busca inputs sin validar,
endpoints sin autenticación y datos sensibles expuestos

# Refactor controlado (Edit mode)
Working set: [lista de archivos]
Reemplaza [patrón antiguo] por [patrón nuevo]. No modifiques ninguna otra lógica.

# Feature completa (Agent mode)
Añade [feature]. Sigue el patrón existente. Verifica que dotnet build pasa.
No instales paquetes nuevos.

# AGENTS.md del repo
@workspace genera un AGENTS.md completo con arquitectura, comandos,
convenciones y reglas para agentes IA

# PR description
@workspace resume los cambios de esta PR en 3-5 puntos concisos
e incluye los pasos para probarla
```
