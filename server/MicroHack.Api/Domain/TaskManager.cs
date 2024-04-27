using Microsoft.EntityFrameworkCore;
using Serilog;

namespace MicroHack.Domain;

public class TaskManager(AppDbContext db)
{
    private readonly AppDbContext db = db;

    public async Task<bool> AssignTaskToUser(Guid taskId, Guid userId)
    {
        var task = await db.Tasks.Include(t=>t.Employees).FirstOrDefaultAsync(t=>t.Id == taskId);
        if(task is null) return false;

        var user = await db.Users.FindAsync(userId);
        if(user is null) return false;

        if(task.Employees.Any(t=>t.Id == userId))
        {
            Log.Information("User already assigned to task", taskId, userId);
            return false;;
        }
        task.Employees.Add(user);

        Log.Information("User assigned to task", taskId, userId);
        await db.SaveChangesAsync();
        return true;
    }
}
