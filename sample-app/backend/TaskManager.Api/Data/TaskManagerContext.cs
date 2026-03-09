using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Models;

namespace TaskManager.Api.Data;

public class TaskManagerContext : DbContext
{
    public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options) { }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Ana García", Email = "ana@empresa.com" },
            new User { Id = 2, Name = "Carlos López", Email = "carlos@empresa.com" },
            new User { Id = 3, Name = "María Fernández", Email = "maria@empresa.com" }
        );

        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Name = "Portal de Clientes", Description = "Rediseño del portal web", CreatedAt = DateTime.Now },
            new Project { Id = 2, Name = "API de Pagos", Description = "Integración con pasarela de pago", CreatedAt = DateTime.Now }
        );

        modelBuilder.Entity<TaskItem>().HasData(
            new TaskItem { Id = 1, Title = "Diseño de pantallas", Description = "Crear mockups en Figma", Status = "done", ProjectId = 1, AssignedToUserId = 1, CreatedAt = DateTime.Now },
            new TaskItem { Id = 2, Title = "Componente de login", Description = "Angular login component", Status = "in-progress", ProjectId = 1, AssignedToUserId = 2, CreatedAt = DateTime.Now },
            new TaskItem { Id = 3, Title = "Tests de regresión", Description = "Cubrir flujo de autenticación", Status = "todo", ProjectId = 1, CreatedAt = DateTime.Now },
            new TaskItem { Id = 4, Title = "Integrar Stripe", Description = "Webhook de pagos", Status = "todo", ProjectId = 2, AssignedToUserId = 3, CreatedAt = DateTime.Now },
            new TaskItem { Id = 5, Title = "Documentar endpoints", Description = "Swagger + README", Status = "todo", ProjectId = 2, CreatedAt = DateTime.Now }
        );
    }
}
