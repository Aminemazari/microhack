using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using MicroHack.Domain;
using MicroHack.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroHack.Features;

[ApiController]
[Tags("Company Group")]
[Route("api/company")]
public class CompanyFeature(AppDbContext db,CompanyManager companyManager) : ControllerBase
{
    private readonly AppDbContext Db = db;
    private readonly CompanyManager CompanyManager = companyManager;
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    public async Task<IActionResult> GetCompanyData(Guid id)
    {
        var company = await Db.Companies
            .Include(c => c.Users)
            .FirstOrDefaultAsync(c => c.Id == id);
            
        if (company is null)
        {
            return NotFound(new Error("Company Not Found"));
        }

        return Ok(Mapper.ToDto(company));
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
    public async Task<IActionResult> CreateCompany(CompanyCreateDto companyDto)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        var user = await Db.Users.FirstOrDefaultAsync(u=>u.Id == userId);

        if(user is null) return NotFound(new Error("User Not Found"));

        if (string.IsNullOrEmpty(companyDto.Name))
        {
            return BadRequest(new Error("Invalid company Name"));
        }

        if (Db.Companies.Any(c => c.Name == companyDto.Name))
        {
            return BadRequest(new Error("Company already exists"));
        }
        
        var company = Db.Companies.Add(new Company(companyDto.Name)).Entity;
        company.Users.Add(user);

        await Db.SaveChangesAsync();

        return Ok(Mapper.ToDto(company));
    }

    /// <summary>
    /// Add user to company
    /// </summary>
    /// <param name="Name"></param> <summary>
    /// 
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    [HttpPost("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
    public async Task<IActionResult> AddUserToCompany(Guid id, [Required][FromQuery] Guid userId)
    {
        var company = await Db.Companies
            .Include(c => c.Users)
            .FirstOrDefaultAsync(c => c.Id == id);
            
        if (company is null)
        {
            return NotFound(new Error("Company Not Found"));
        }

        if(company.Users.Any(u=>u.Id == userId))
        {
            return BadRequest(new Error("User Already in Company"));
        }
        
        await CompanyManager.AddUserToCompany(id, userId);

        await db.SaveChangesAsync();

        return Ok(Mapper.ToDto(company));
    }
    public record CompanyCreateDto(string Name);
}
