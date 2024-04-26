using MicroHack.Domain;

namespace MicroHack.Util;

public record class Error(string error);

public record RequestLog(PathString path, string? name, int? statusCode, double totalMilliseconds);

public class Mapper
{
    public static UserDto ToDto(User user) => new()
    {
        Id = user.Id,
        Email = user.Email
    };

    public static CompanyDto ToDto(Company company) => new 
    (
        Name: company.Email,
        Id: company.Id,
        Users: company.Users.Select(ToDto).ToList()
    );

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
