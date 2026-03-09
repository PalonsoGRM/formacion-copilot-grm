namespace TaskManager.Api.Models;

// DEFECTO INTENCIONAL #1: usa DateTime en vez de DateTimeOffset
// DEFECTO INTENCIONAL #2: sin DataAnnotations
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;    // debería ser DateTimeOffset.UtcNow

    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}
