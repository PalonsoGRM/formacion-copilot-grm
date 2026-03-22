# Prompt 03 — Modo autopiloto: tests unitarios con --allow-all

> Usa este prompt en la **Parte 4c** del lab.
> Lánzalo desde el terminal, **fuera** de una sesión interactiva del CLI.

---

## ⚠️ Lee esto antes de ejecutar

`--allow-all` elimina todas las confirmaciones manuales. El CLI creará archivos, instalará paquetes y ejecutará comandos **sin pedirte permiso**. Es seguro cuando:

- ✅ Estás en una rama limpia (`git status` sin cambios críticos)
- ✅ El prompt está bien acotado y describes exactamente qué quieres
- ✅ El proyecto es de práctica / no hay datos reales en juego

---

## Comando completo

```powershell
copilot --allow-all --prompt "Añade tests unitarios para ProductsController usando xUnit. Crea un proyecto de tests separado llamado InventoryManager.Api.Tests, añade las referencias y dependencias necesarias (xUnit, Moq, Microsoft.AspNetCore.Mvc.Testing), y escribe tests para: GET /api/products (lista todos), GET /api/products/{id} con id válido, GET /api/products/{id} con id inexistente (debe devolver 404), POST /api/products con modelo válido, POST /api/products con modelo inválido (debe devolver 400). Al terminar ejecuta los tests con dotnet test y muéstrame el resultado."
```

---

## Qué observar

- El CLI crea el proyecto de tests, añade el `.csproj`, instala paquetes NuGet — todo encadenado
- No te pide confirmación en ningún paso
- Al final ejecuta `dotnet test` y reporta el resultado
- Si algún test falla, intenta corregirlo por sí mismo

## Alias alternativo: `--yolo`

```powershell
copilot --yolo --prompt "..."
```

`--yolo` y `--allow-all` son equivalentes. `--yolo` es el alias más corto, `--allow-all` es más explícito para usar en scripts o documentación de equipo.
