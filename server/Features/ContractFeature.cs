using System.Security.Claims;
using MicroHack.Domain;
using MicroHack.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroHack.Features;

[ApiController]
[Tags("Contract Group")] 
[Route("api/contract")]
public class ContractFeatures(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext Db = db;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContract(string id)
    {
        var contract = await Db.Contracts
            .Include(c => c.ClientCompany)
            .Include(c => c.ProviderCompany)
            .FirstOrDefaultAsync(c => c.Id.ToString() == id);

        if (contract is null)
        {
            return NotFound(new Error("Contract Not Found"));
        }

        return Ok(Mapper.ToDto(contract));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] ContractRequestDto contractDto)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        var user = await Db.Users
            .Include(u => u.Company)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if(user is null) return NotFound(new Error("User Not Found"));
        if(user.Company is null) return NotFound(new Error("User's Company Not Found"));
        
        if(user.Company.Id != contractDto.clientCompanyId) return Forbid();

        var client_company = Db.Companies
            .Include(c => c.Users)
            .FirstOrDefault(c => c.Id == contractDto.clientCompanyId);

        var provider_company = Db.Companies
            .Include(c => c.Users)
            .FirstOrDefault(c => c.Id == contractDto.providerCompanyId);

        if(provider_company is null || client_company is null) return NotFound(new Error("Provider or Client Company Not Found"));

        var contract = new Project 
        (
            client_company,
            provider_company,
            contractDto.content
        );
        
        Db.Contracts.Add(contract);
        await Db.SaveChangesAsync();

        return Created("/api/contract", contract.Id.ToString());
    }

    // [Authorize]
    // [HttpPost("{id}")]
    // public async Task<IActionResult> ResponseToContract([FromRoute] Guid id, [FromQuery] bool accepted)
    // {
    //     var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
    //     var user = await Db.Users
    //         .Include(u => u.Company)
    //         .FirstOrDefaultAsync(u => u.Id == userId);

    //     if(user is null) return NotFound(new Error("User Not Found"));
    //     if(user.Company is null) return NotFound(new Error("User's Company Not Found"));
        
    //     var contract = await Db.Contracts
    //         .Include(c => c.ClientCompany)
    //         .Include(c => c.ProviderCompany)
    //         .FirstOrDefaultAsync(c => c.Id == id);

    //     if(contract is null) return NotFound(new Error("Contract Not Found"));

    //     if(user.Company.Id != contract.ProviderCompany.Id) return Forbid();


    //     if(accepted) contract.Accept();
    //     else contract.Decline();

    //     await Db.SaveChangesAsync();

    //     return Ok(Mapper.ToDto(contract));
    // }

    public record ContractRequestDto(Guid clientCompanyId, Guid providerCompanyId,string content);

}
