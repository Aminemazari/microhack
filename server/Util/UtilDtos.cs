using MicroHack.Domain;

namespace MicroHack.Util;

public record class Error(string error);

public record RequestLog(PathString path, string? name, int? statusCode, double totalMilliseconds);

public class Mapper
{
    public static UserDto ToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email
        };
    }


    public static CompanyDto ToDto(Company company)
    {
        return new CompanyDto
        (
            Name : company.Name,
            Id : company.Id,
            Users : company.Users.Select(ToDto).ToList()
        );
    }


}

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
