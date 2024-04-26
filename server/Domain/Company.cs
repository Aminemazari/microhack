namespace MicroHack.Domain;

public partial class Company
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public List<User> Users { get; set; } = [];

    public Company(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    private Company() { }

}


partial class Company
{
    public override string ToString() => $"Company: {Id}, {Name}";

    internal void ChangeCompanyName(string newName)
    {
        if(string.IsNullOrEmpty(newName)) throw new ArgumentNullException(nameof(newName));
        Name = newName;
    }
}