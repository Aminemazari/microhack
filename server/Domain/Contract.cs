namespace MicroHack.Domain;

public class Contract
{
    public Guid Id { get; private init; }
    public Company ClientCompany {get; private init;} = null!;
    public Company ProviderCompany { get; private init; } = null!;
    public bool? IsAccepted { get; private set; } = null;
    public string Content { get; private set; } = string.Empty;

    public Contract(Company clientCompany, Company providerCompany, string content)
    {
        Id = Guid.NewGuid();
        ClientCompany = clientCompany;
        ProviderCompany = providerCompany;
        Content = content;
    }

    private Contract() {}

    public void Accept()
    {
        IsAccepted = true;
    }

    public void Decline()
    {
        IsAccepted = false;
    }
}

