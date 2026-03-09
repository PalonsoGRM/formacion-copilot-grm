using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskManagerContext _context;

    public TasksController(TaskManagerContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _context.Tasks
            .Include(t => t.AssignedTo)
            .Include(t => t.Project)
            .ToListAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _context.Tasks
            .Include(t => t.AssignedTo)
            .Include(t => t.Project)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (task is null) return NotFound();
        return Ok(task);
    }

    // DEFECTO INTENCIONAL #4: sin validación de input (Title puede llegar vacío o nulo)
    // DEFECTO INTENCIONAL #5: sin autenticación
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaskItem task)
    {
        task.CreatedAt = DateTime.Now;   // DEFECTO: debería ser DateTimeOffset.UtcNow
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    // DEFECTO INTENCIONAL #5: sin autenticación — cualquiera puede actualizar cualquier tarea
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TaskItem updated)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task is null) return NotFound();

        task.Title = updated.Title;
        task.Description = updated.Description;
        task.Status = updated.Status;
        task.AssignedToUserId = updated.AssignedToUserId;
        task.DueDate = updated.DueDate;

        await _context.SaveChangesAsync();
        return Ok(task);
    }

    // DEFECTO INTENCIONAL #5: sin autenticación — cualquiera puede borrar
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task is null) return NotFound();

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("by-project/{projectId}")]
    public async Task<IActionResult> GetByProject(int projectId)
    {
        var tasks = await _context.Tasks
            .Where(t => t.ProjectId == projectId)
            .Include(t => t.AssignedTo)
            .ToListAsync();
        return Ok(tasks);
    }
}
