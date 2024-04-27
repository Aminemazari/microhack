using MicroHack.Util;

namespace MicroHack.Domain;

public class Task
{
    public Guid Id { get; private init; }
    public string Content { get; private set; } = string.Empty;
    public Project Project { get; private set; } = null!;
    public Status Status { get; private set; }
    public List<User> Employees { get; private init; } = [];


    public Task(string content, Project project)
    {
        Id = Guid.NewGuid();
        Content = content;
        Project = project;
        Status = Status.Pending;
    }

    public void Done()
    {
        Status = Status.Done;
    }

    public void Cancel()
    {
        if(Status == Status.Pending)
            Status = Status.Declined;
        else if(Status == Status.InProgress)
            Status = Status.Canceled;

        else throw new Exception("Task can't be canceled, because it is " + Status);
    }

    public void Start()
    {
        if(Status == Status.Pending)
            Status = Status.InProgress;

        else throw new Exception("Task can't be started, because it is " + Status);
    }

    internal void Assign(User user)
    {
        Employees.Add(user);
    }

    public void UpdateContent(string content)   
    {
        if(string.IsNullOrEmpty(content)) throw new ArgumentNullException(nameof(content));
        Content = content;
    }
    private Task() { }
}
