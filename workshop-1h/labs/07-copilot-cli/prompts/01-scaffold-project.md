# Prompt 01 — Scaffold de proyecto nuevo

> Usa este prompt en la **Parte 3** del lab. Cópialo entero en el CLI desde una carpeta vacía.
> El CLI ejecutará `dotnet new`, creará la estructura de carpetas, escribirá todos los archivos y verificará con `dotnet build`.

---

```
Crea un proyecto nuevo de API REST con ASP.NET Core (.NET 8) en esta carpeta.
El proyecto se llamará InventoryManager.Api y gestionará un inventario de productos.

Requisitos:
- Modelos: Product (Id, Name, Description, Price decimal, Stock int, CategoryId, CreatedAt DateTimeOffset), Category (Id, Name, Description, Products)
- DbContext con EF Core in-memory con seed data realista: 3 categorías (Electrónica, Ropa, Alimentación) y 8 productos distribuidos entre ellas
- ProductsController con CRUD completo: GET /api/products, GET /api/products/{id}, POST /api/products, PUT /api/products/{id}, DELETE /api/products/{id}
- CategoriesController con: GET /api/categories, GET /api/categories/{id} (incluye lista de productos), POST /api/categories, DELETE /api/categories/{id}
- Swagger/OpenAPI habilitado en desarrollo
- Usa DateTimeOffset.UtcNow para todas las fechas, nunca DateTime.Now
- DataAnnotations de validación: [Required], [MaxLength], [Range] donde corresponda
- Los controladores devuelven IActionResult y usan Ok(), NotFound(), BadRequest(), CreatedAtAction()
- Sin autenticación por ahora

Al terminar, ejecuta dotnet build para verificar que compila sin errores.
```

---

## Qué observar mientras el CLI trabaja

1. **Primera acción**: el CLI ejecuta `dotnet new webapi` — no se lo has pedido explícitamente, lo infiere del contexto
2. **Estructura**: crea carpetas `Models/`, `Controllers/`, `Data/` siguiendo convenciones ASP.NET Core
3. **Auto-corrección**: si `dotnet build` falla, el CLI lee el error y lo corrige sin que se lo pidas
4. **Seed data real**: los productos y categorías tienen nombres y precios coherentes, no "Test1", "Test2"

## Tiempo esperado

- Con aprobaciones manuales por cada herramienta: ~15-20 min
- Usando "Yes, approve for the rest of the session": ~8-12 min
- Con `--allow-all`: ~5-8 min (sin intervención manual)
