using MicroHack.Util;

namespace MicroHack.Domain;

public partial class User
{
    public Guid Id { get; private init; }
    public string Email { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string HashedPassword { get; private set; } = string.Empty;
    public UserRole Role { get; private set; } = UserRole.Worker;
    public Company? Company { get; set; } = null;
    protected User() {} // used by EF Core ORM for mapping

    public User(string Email, string Password)
    {
        Id = Guid.NewGuid();
        this.Email = Email;
        HashedPassword = HashPassword(Password);
    }

    public void ModifyUserRole(User userToModify, UserRole role)
    {
        if(userToModify.Role == UserRole.Manager)
        {
            throw new Exception("Can not modify manager role");
        }

        if(role != UserRole.Manager)
        {
            throw new Exception("Can not modify a worker role, without manager privilage");
        }

        userToModify.Role = role;
    }
}

partial class User
{
    public bool VerifyPassword(string Password) => PasswordHashingService.VerifyPassword(Password, this.HashedPassword);
    private static string HashPassword(string Password) => PasswordHashingService.HashPassword(Password);
    public override string ToString() => $"{Id} {Email}";

    public void UpdateUser(string Email, string Name)
    {
        this.Email = Email;
        this.Name = Name;
    }
}