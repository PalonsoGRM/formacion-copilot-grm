# Prompt 02 — Plan Mode: añadir endpoint de búsqueda

> Usa este prompt en la **Parte 4a** del lab.
> Activa Plan Mode primero con `Shift+Tab`, luego pega el prompt.

---

```
Añade un endpoint GET /api/products/search?name=X&minPrice=Y&maxPrice=Z 
que permita filtrar productos por nombre (parcial, case-insensitive) y rango de precios.
Los tres parámetros son opcionales — si no se pasan, devuelve todos los productos.
Dame el plan antes de implementar nada.
```

---

## Qué observar en Plan Mode

- El CLI lista exactamente **qué archivos** va a modificar (solo `ProductsController.cs`)
- Describe el **cambio concreto** antes de hacerlo
- **No toca nada** hasta que apruebas el plan

## Para aprobar e implementar

Después de revisar el plan, sal de Plan Mode con `Shift+Tab` y escribe:

```
El plan está bien. Impleméntalo.
```

## Comparación interesante

Prueba el mismo prompt **sin** Plan Mode. ¿El resultado es diferente? ¿Tardas más o menos en confiar en el output?
