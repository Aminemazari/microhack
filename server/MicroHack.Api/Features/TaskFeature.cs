using System.ComponentModel.DataAnnotations;
using MicroHack.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroHack.Features;

[ApiController]
[Tags("Task Group")]
[Route("api/task")]
public class TaskFeature(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext Db = db;

    // add task to project
    [HttpPost]
    public async Task<IActionResult> AddTaskToProject([Required][FromQuery] Guid projectId, [FromBody] CreateTaskDto createTaskDto)
    {
        var project = await Db.Projects.Include(p=>p.Tasks).SingleOrDefaultAsync(p => p.Id == projectId);

        if(project is null ) return NotFound(new Error("Project Not Found"));

        var newTask = new Domain.Task(createTaskDto.Content, project);
        project.Tasks.Add(newTask);    
        
        await Db.SaveChangesAsync();

        return Ok(Mapper.ToDto(newTask));
    }

    public record CreateTaskDto(string Content);
}
