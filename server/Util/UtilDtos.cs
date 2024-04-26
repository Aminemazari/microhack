using MicroHack.Domain;

namespace MicroHack.Util;

public record class Error(string error);

public record RequestLog(PathString path, string? name, int? statusCode, double totalMilliseconds);

public class Mapper
{
    public static UserDto ToDto(User user) => new UserDto
    {
        Id = user.Id,
        Email = user.Email
    };


    public static CompanyDto ToDto(Company company) => new CompanyDto
    (
        Name: company.Email,
        Id: company.Id,
        Users: company.Users.Select(ToDto).ToList()
    );

    public static ContractDto ToDto(Project project) => new ContractDto
    (
        Id: project.Id,
        ClientCompany: ToDto(project.ClientCompany),
        ProviderCompany: ToDto(project.ProviderCompany),
        Content: project.Content,
        Status: project.Status.ToString()
    );

}

public record ContractDto
(
    Guid Id,
    CompanyDto ClientCompany,
    CompanyDto ProviderCompany,
    string Content,
    string Status
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
