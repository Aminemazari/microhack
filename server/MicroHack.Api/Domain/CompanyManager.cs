using MicroHack.Util;
using Microsoft.EntityFrameworkCore;

namespace MicroHack.Domain;

public class CompanyManager(AppDbContext db)
{
    public readonly AppDbContext Db = db;

    public async Task<bool> AddUserToCompany(Guid userId, Guid companyId)
    {
        var user = await Db.Users.FirstOrDefaultAsync(u => u.Id == userId);
        
        if(user is null) return false;
        
        var company = await Db.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
        
        if(company is null) return false;

        company.Users.Add(user);
        user.Company = company;

        await Db.SaveChangesAsync();
        return true;
    }

    public bool ChangeCompanyName(Guid userId, Guid companyId, string newName)
    {
        var user = Db.Users
            .Include(u => u.Company)
            .FirstOrDefault(u => u.Id == userId);
        
        var company = Db.Companies
            .Include(c => c.Users)
            .FirstOrDefault(c => c.Id == companyId);
        
        if (user is null || company is null) return false;

        if(user.Company?.Id != company.Id) return false;

        if(user.Role != UserRole.Manager) return false;

        company.ChangeCompanyName(newName);

        return true;
    }
}
