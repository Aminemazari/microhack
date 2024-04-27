using MicroHack.Domain;
using MicroHack.Util;
using Microsoft.EntityFrameworkCore;

namespace MicroHack;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreatedAsync().Wait();
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Domain.Task> Tasks { get; set; }

    protected AppDbContext()
    {
        
    }
}
