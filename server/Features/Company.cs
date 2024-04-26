using System.ComponentModel.DataAnnotations;
using MicroHack.Domain;
using MicroHack.Util;
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
    public async Task<IActionResult> CreateCompany(CompanyCreateDto companyDto)
    {
        if (string.IsNullOrEmpty(companyDto.Name))
        {
            return BadRequest(new Error("Invalid company Name"));
        }

        if (Db.Companies.Any(c => c.Name == companyDto.Name))
        {
            return BadRequest(new Error("Company already exists"));
        }
        
        Db.Companies.Add(new Company(companyDto.Name));
        
        await Db.SaveChangesAsync();

        var company = await Db.Companies.Where(c=>c.Name == companyDto.Name).FirstOrDefaultAsync();

        if(company is null) return BadRequest(new Error("Failed to create company"));

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
        
        CompanyManager.AddUserToCompany(company);


    }
    public record CompanyCreateDto(string Name);
}
