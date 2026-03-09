namespace TaskManager.Api.Models;

// DEFECTO INTENCIONAL #1: usa DateTime en vez de DateTimeOffset
// DEFECTO INTENCIONAL #2: sin DataAnnotations (sin validación de longitud, sin [Required])
public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // DEFECTO INTENCIONAL #3: magic strings para el estado (debería ser un enum)
    public string Status { get; set; } = "todo";   // "todo" | "in-progress" | "done"

    public int ProjectId { get; set; }
    public int? AssignedToUserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;    // debería ser DateTimeOffset.UtcNow
    public DateTime? DueDate { get; set; }

    public Project? Project { get; set; }
    public User? AssignedTo { get; set; }
}
