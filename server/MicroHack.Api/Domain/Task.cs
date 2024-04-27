namespace MicroHack.Domain;

public class Task
{
    public Guid Id { get; private init; }
    public string Content { get; private set; } = string.Empty;
    public Project Project { get; private set; } = null!;


    public Task(string content, Project project)
    {
        Id = Guid.NewGuid();
        Content = content;
        Project = project;
    }
    private Task() { }
}
