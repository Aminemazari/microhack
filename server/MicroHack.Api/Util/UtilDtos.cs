using MicroHack.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace MicroHack.Util;

public record class Error(string error);

public record RequestLog(PathString Path, string Name, int? StatusCode, double TotalMilliseconds);

public class Mapper
{
    public static UserDto ToDto(User user)
    {
        if(user is null) return null!;

        return new ()
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            CompanyId = user.Company?.Id,
            CompanyName = user.Company?.Name
        };
    }

    public static CompanyDto ToDto(Company company)
    {
        if(company is null) return null!;
        
        return new
        (
            Name: company.Email,
            Id: company.Id,
            Users: company.Users.Select(ToDto).ToList()
        );
    }

    public static ProjectDto ToDto(Project project) => new ProjectDto
    (
        Id: project.Id,
        ClientCompany: ToDto(project.ClientCompany),
        ProviderCompany: ToDto(project.ProviderCompany),
        Content: project.Content,
        Status: project.Status.ToString(),
        Tasks: project.Tasks.Select(ToDto).ToList()
    );

    public static TaskDto ToDto(Domain.Task task) => new TaskDto
    (
        Id: task.Id,
        Content: task.Content,
        ProjectId: task.Project.Id
    );

}

public record TaskDto
(
    Guid Id,
    string Content,
    Guid ProjectId
);

public record ProjectDto
(
    Guid Id,
    CompanyDto ClientCompany,
    CompanyDto ProviderCompany,
    string Content,
    string Status,
    List<TaskDto> Tasks
);

public record CompanyDto(
    Guid Id,
    string Name,
    List<UserDto> Users
);
public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? CompanyName { get; set; } = string.Empty;
    public Guid? CompanyId { get; set; }
}


public record GetProjecsListResponse
(
    int TotalCount,
    int PageNumber,
    int PageSize,
    bool HasPreviousPage,
    bool HasNextPage,
    List<ProjectDto> Projects
);


public class Message
{
    public string role { get; set; }
    public string content { get; set; }
}

public class Choice
{
    public int index { get; set; }
    public Message message { get; set; }
    public object logprobs { get; set; }
    public string finish_reason { get; set; }
}

public class Usage
{
    public int prompt_tokens { get; set; }
    public int total_tokens { get; set; }
    public int completion_tokens { get; set; }
}

public class Root
{
    public string id { get; set; }
    public string @object { get; set; }
    public int created { get; set; }
    public string model { get; set; }
    public List<Choice> choices { get; set; }
    public Usage usage { get; set; }
}