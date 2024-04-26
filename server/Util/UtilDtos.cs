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
            Name : company.Email,
            Id : company.Id,
            Users : company.Users.Select(ToDto).ToList()
        );
    }

    public static ContractDto ToDto(Contract user)
    {
        return new ContractDto
        (
            Id : user.Id,
            ClientCompany : ToDto(user.ClientCompany),
            ProviderCompany : ToDto(user.ProviderCompany),
            Content : user.Content,
            IsAccepted : user.IsAccepted
        );
    }

}

public record ContractDto
(
    Guid Id,
    CompanyDto ClientCompany,
    CompanyDto ProviderCompany,
    string Content,
    bool? IsAccepted
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
