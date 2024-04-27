using MicroHack.Util;

namespace MicroHack.Domain;

public class Project
{
    public Guid Id { get; private init; }
    public Company ClientCompany {get; private init;} = null!;
    public Company ProviderCompany { get; private init; } = null!;
    public  ProjectStatus Status { get; private set; } = ProjectStatus.Pending;
    public string Content { get; private set; } = string.Empty;
    public List<Task> Tasks { get; private set; } = [];

    public Project(Company clientCompany, Company providerCompany, string content)
    {
        Id = Guid.NewGuid();
        ClientCompany = clientCompany;
        ProviderCompany = providerCompany;
        Content = content;
    }

    private Project() {}

}

