namespace MicroHack.Domain;

public partial class Company
{
    public Guid Id { get; init; }
    public string Email { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public List<User> Users { get; set; } = [];

    public Company(string email)
    {
        Id = Guid.NewGuid();
        Email = email;
    }

    private Company() {}
}


partial class Company
{
    public override string ToString() => $"Company: {Id}, {Email}";

    internal void ChangeCompanyName(string newName)
    {
        if(string.IsNullOrEmpty(newName)) throw new ArgumentNullException(nameof(newName));
        Name = newName;
    }
}