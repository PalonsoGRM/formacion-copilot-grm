using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly TaskManagerContext _context;

    public ProjectsController(TaskManagerContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _context.Projects
            .Include(p => p.Tasks)
            .ToListAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await _context.Projects
            .Include(p => p.Tasks)
            .ThenInclude(t => t.AssignedTo)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (project is null) return NotFound();
        return Ok(project);
    }

    // DEFECTO INTENCIONAL #4: sin validación de input
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Project project)
    {
        project.CreatedAt = DateTime.Now;  // DEFECTO: debería ser DateTimeOffset.UtcNow
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is null) return NotFound();

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
