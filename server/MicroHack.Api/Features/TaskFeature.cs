using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using MicroHack.Util;
using Microsoft.AspNetCore.Http.HttpResults;
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

        //

        // Replace "YOUR_API_KEY" with your actual API key
        string apiKey = "fd2cd46f-5920-4388-ab45-4ff65bf4bf32";

        // Set up HttpClient
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        // Prepare JSON payload
        string jsonPayload = @"{
            ""model"": ""Meta-Llama-3-8B-Instruct"",
            ""messages"": [
                {""role"": ""user"", ""content"": """ + " Write this project content as tasks, each task is a string in an array as json, do not add any other text do not try to formate the json to be readable (by adding \\n for example) your response must be only one line of json that can be deserialized to a list of strings : " + project.Content + @"""}
            ]
        }";

        // Set Content-Type header and convert JSON payload to StringContent
        StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        // Make the POST request
        HttpResponseMessage response = await client.PostAsync("https://api.awanllm.com/v1/chat/completions", content);

        // Check if the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read and display the response
            string responseBody = await response.Content.ReadAsStringAsync();
            // Console.WriteLine("Response:");
            // Console.WriteLine(responseBody);

            var ai_reponse = JsonSerializer.Deserialize<Root>(responseBody);

            var newTasks = ai_reponse.choices[0].message.content;


            newTasks = newTasks.Replace("\\\"", "\"");

            List<string> l = JsonSerializer.Deserialize<List<string>>(newTasks); 
            return Ok(l);
        }
        else
        {
            Console.WriteLine($"Failed to make request. Status code: {response.StatusCode}");
        }
    
        //

        return NoContent();
    }


    public record CreateTaskDto(string Content);
}
