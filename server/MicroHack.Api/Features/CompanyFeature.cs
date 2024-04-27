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
public class CompanyFeature(AppDbContext Db) : ControllerBase
{
    private readonly AppDbContext Db = Db;
    private readonly CompanyManager CompanyManager = new CompanyManager(Db);
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await Db.Companies
            .Include(c => c.Users)
            .FirstOrDefaultAsync(c => c.Id == id);
            
        if (company is null)
        {
            return NotFound(new Error("CompanyFeature Not Found"));
        }

        return Ok(Mapper.ToDto(company));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    public async Task<IActionResult> GetCompanies(Guid id)
    {
        var companies = Db.Companies
            .Include(c => c.Users)
            .Select(c=> Mapper.ToDto(c));

        return Ok(companies);
    }


    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
    public async Task<IActionResult> CreateCompany(CompanyCreateDto companyDto)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await Db.Users.FirstOrDefaultAsync(u=>u.Id == userId);

        if(user is null) return NotFound(new Error("User Not Found"));

        if (string.IsNullOrEmpty(companyDto.Email))
        {
            return BadRequest(new Error("Invalid company Name"));
        }

        if (Db.Companies.Any(c => c.Email == companyDto.Email))
        {
            return BadRequest(new Error("Company already exists"));
        }
        
        var company = Db.Companies.Add(new Company(companyDto.Email)).Entity;
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
    public async Task<IActionResult> AddUserToCompanyFeature(Guid id, [Required][FromQuery] Guid userId)
    {
        var company = await Db.Companies
            .Include(c => c.Users)
            .FirstOrDefaultAsync(c => c.Id == id);
            
        if (company is null)
        {
            return NotFound(new Error("CompanyFeature Not Found"));
        }

        if(company.Users.Any(u=>u.Id == userId))
        {
            return BadRequest(new Error("User Already in CompanyFeature"));
        }
        
        await CompanyManager.AddUserToCompany(id, userId);

        await Db.SaveChangesAsync();

        return Ok(Mapper.ToDto(company));
    }
    public record CompanyCreateDto(string Email);
}
