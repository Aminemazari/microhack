

using MicroHack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

internal class ApplicationFactory : Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services=>
        {
            // services.RemoveAll(typeof(DbContextOptions<AppDbContext>));

            // services.AddDbContext<AppDbContext>(op=>{
            //     op.UseSqlite("Data Source=MicroHack-Testing");
            // });

            var db = CreateDbContext(services);
            db.Database.EnsureDeleted();

        });
    }

    private static AppDbContext CreateDbContext(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var scope = serviceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<AppDbContext>();
    }
}
