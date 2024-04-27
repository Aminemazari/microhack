using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using MicroHack.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace MicroHack.Features;

[ApiController]
[Tags("Task Group")]
[Route("api/task")]
public class TaskFeature(AppDbContext db, IConfiguration configuration) : ControllerBase
{
    private readonly AppDbContext Db = db;
    private readonly IConfiguration Configuration = configuration;

    [HttpPost]
    [EndpointSummary("Add a new task to a project")]
    public async Task<IActionResult> AddTaskToProject([Required][FromQuery] Guid projectId, [FromBody] CreateTaskDto createTaskDto)
    {
        var project = await Db.Projects.Include(p=>p.Tasks).SingleOrDefaultAsync(p => p.Id == projectId);

        if(project is null ) return NotFound(new Error("Project Not Found"));

        var newTask = new Domain.Task(createTaskDto.Content, project);
        project.Tasks.Add(newTask);    
        
        await Db.SaveChangesAsync();

        return Ok(Mapper.ToDto(newTask));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask([Required][FromRoute] Guid id, [FromBody] UpdateTaskDto updateTaskDto)
    {
        var task = await Db.Tasks
            .Include(t => t.Project)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (task is null)
        {
            return NotFound(new Error("Task Not Found"));
        }

        task.UpdateContent(updateTaskDto.Content);

        return Ok(Mapper.ToDto(task));
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks([Required][FromQuery] Guid projectId)
    {
        var project = await Db.Projects
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == projectId);

        if (project is null)
        {
            return NotFound(new Error("Project Not Found"));
        }

        return Ok(project.Tasks.Select(Mapper.ToDto));
    }

    [HttpGet("ai-generated")]
    public async Task<IActionResult> GenerateTasks([Required][FromQuery] Guid projectId)
    {
        var project = await Db.Projects
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == projectId);

        if (project is null)
        {
            return NotFound(new Error("Project Not Found"));
        }

        string? apiKey = Configuration["AI_ApiKey"] ?? throw new Exception("Api key Not Found");

        HttpClient client = new();
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        string jsonPayload = @"{
            ""model"": ""Meta-Llama-3-8B-Instruct"",
            ""messages"": [
                {""role"": ""user"", ""content"": """ + " Write this project content as tasks, each task is a string in an array as json, do not add any other text do not try to formate the json to be readable (by adding \\n for example) your response must be only one line of json that can be deserialized to a list of strings : " + project.Content + @"""}
            ]
        }";

        StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://api.awanllm.com/v1/chat/completions", content);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            var ai_reponse = JsonSerializer.Deserialize<Root>(responseBody);

            var newTasks = ai_reponse.choices[0].message.content;


            newTasks = newTasks.Replace("\\\"", "\""); // fix the json

            List<string>? l = JsonSerializer.Deserialize<List<string>>(newTasks) ?? throw new Exception("Failed to deserialize AI result to a list of tasks");
            
            return Ok(l);
        }
        else
        {
            Log.Error($"Failed to make request. Status code: {response.StatusCode}");
        }

        return NoContent();
    }

    public record ProjectSummaryDto(string Content);

    [HttpPost("ai-generated")]
    [EndpointSummary("Not for production use. For testing purposes only.")]
    public async Task<IActionResult> GenerateTasksFromString([FromBody] ProjectSummaryDto summay)
    {

        string? apiKey = Configuration["AI_ApiKey"] ?? throw new Exception("Api key Not Found");

        HttpClient client = new();
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        string jsonPayload = @"{
            ""model"": ""Meta-Llama-3-8B-Instruct"",
            ""messages"": [
                {""role"": ""user"", ""content"": """ + " Write this project content as tasks, each task is a string in an array as json, do not add any other text do not try to formate the json to be readable (by adding \\n for example) your response must be only one line of json that can be deserialized to a list of strings : " + summay.Content + @"""}
            ]
        }";

        StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://api.awanllm.com/v1/chat/completions", content);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            var ai_reponse = JsonSerializer.Deserialize<Root>(responseBody);

            var newTasks = ai_reponse.choices[0].message.content;


            newTasks = newTasks.Replace("\\\"", "\"");

            List<string> l = JsonSerializer.Deserialize<List<string>>(newTasks); 
            return Ok(l);
        }
        else
        {
            Log.Error($"Failed to make request. Status code: {response.StatusCode}");
        }

        return NoContent();
    }


    public record CreateTaskDto(string Content);
}

public record UpdateTaskDto(string Content);