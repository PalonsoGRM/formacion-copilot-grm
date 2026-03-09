using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// EF Core in-memory — no se necesita base de datos para la formación
builder.Services.AddDbContext<TaskManagerContext>(options =>
    options.UseInMemoryDatabase("TaskManagerDb"));

// CORS permisivo para desarrollo — DEFECTO INTENCIONAL para el bloque de seguridad
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Seed inicial de datos
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TaskManagerContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // DEFECTO INTENCIONAL: expone stack traces en desarrollo (y a veces en producción por descuido)
    app.UseDeveloperExceptionPage();
}

app.UseCors();
app.MapControllers();

app.Run();
