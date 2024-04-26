using MicroHack.Domain;
using MicroHack.Util;
using Microsoft.EntityFrameworkCore;

namespace MicroHack;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Database.EnsureCreatedAsync().Wait();

        Company com1;
{
        com1 = new Company("smart.electron@gmail.com");
        Companies.Add(com1);

        var user = new User("smart.electron@gmail.com","1234");
        com1.Users.Add(user);

        var com2 = new Company("teamup@gmail.com");
        Companies.Add(com2);

        var user1 = new User("teamup@gmail.com","1234");
        com1.Users.Add(user);

        var project = new Project(com1, com2, "test project");
/// <summary>
/// 
/// </summary>
/// <param name="1""></param>
/// <returns></returns>
        var t1 = new Domain.Task("Manufacturing and Production: Setting up manufacturing processes and facilities to mass-produce electrical products efficiently and cost-effectively.",project);
        project.Tasks.Add(t1);

        var t2 = new Domain.Task("Integration with Smart Technologies: Integrating electrical systems with smart technologies such as IoT (Internet of Things), home automation, or industrial automation to enable remote monitoring, control, and optimization.",project);
        project.Tasks.Add(t2);

        var t3 = new Domain.Task("Product Development: Designing and developing innovative electrical products such as electronic devices, components, or systems.",project);
        project.Tasks.Add(t3);
}
{

        var com2 = new Company("admin@MechanoWorks.com");
        Companies.Add(com2);

        var user = new User("admin@MechanoWorks.com","1234");
        com2.Users.Add(user);

        var project = new Project(com1, com2, "test2 project");
        
/// <summary>
/// 
/// </summary>
/// <param name="1""></param>
/// <returns></returns>
        var t1 = new Domain.Task("Precision Engineering and Machining: Utilizing advanced machining techniques and precision engineering principles to manufacture mechanical components with tight tolerances and high accuracy. This could involve tasks such as CNC machining, milling, turning, grinding, and fabrication of complex mechanical parts for various industries such as automotive, aerospace, or industrial machinery.",project);
        project.Tasks.Add(t1);

        var t2 = new Domain.Task("Mechanical System Design and Analysis: Providing expertise in designing and analyzing mechanical systems to optimize performance, reliability, and efficiency. This could involve tasks such as computer-aided design (CAD) modeling, finite element analysis (FEA), simulation, and prototyping of mechanical systems such as engines, pumps, gearboxes, or robotic systems.",project);
        project.Tasks.Add(t2);
        
}
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=microhack.db");
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Domain.Task> Tasks { get; set; }
}
