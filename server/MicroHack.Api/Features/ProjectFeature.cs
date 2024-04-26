using System.Security.Claims;
using MicroHack.Domain;
using MicroHack.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroHack.Features;

[ApiController]
[Tags("Contract Group")] 
[Route("api/project")]
public class ProjectFeatures(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext Db = db;

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetProjectsAsync(
        [FromQuery] string? SearchPattern,
        [FromQuery] int? PageNumber,
        [FromQuery] int? PageSize)
    {
        if(PageSize is null) PageNumber = null;

        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await Db.Users
            .Include(u => u.Company)
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        if(user is null) return NotFound(new Error("User Not Found"));
        if(user.Company is null) return NotFound(new Error("User's Company Not Found"));

        // well, user info should let as perform more filterage considiring the role and permission, 
        // (ex. Manager can see all Projects of his company, Worker can see only the projects assained to him)
        // But I think this is out of the MVP scope
        IQueryable<Project> projects = Db.Projects.Where
            (p => p.ClientCompany.Id == user.Company.Id 
           ||
             p.ProviderCompany.Id == user.Company.Id);


        // this may look stupid if you did not enderstand how does IQuerable work,
        // It is better to use p.Content.Contains(SearchPattern, StringComparison.OrdinalIgnoreCase) 
        // instead of transfaring the full string to upper or lower losing time and memory, 
        // but IQuerable functions are not executed in memory but compose SQL-like querie that will transfer by the ORM (EF Core) to database real query
        // and EF core intell now can not transfer this to T-SQL/PL-SQL as I know
        if(SearchPattern is not null)
            projects = projects.Where(
                p => p.Content.ToLower().Contains(
                        SearchPattern.ToLower()));

        int TotalCount = projects.Count();

        if(PageSize is not null && PageNumber is not null)
            projects = projects
                .Skip(PageSize.Value * (PageNumber.Value -1))
                .Take(PageSize.Value);
        else if (PageSize is not null)
            projects = projects
                .Take(PageSize.Value);

        // I can use Mapper.ToDto here because select one of the functions that realy execute the code, then perform the mapping
        var usersResult = await projects
            .Select(u => Mapper.ToDto(u))
            .ToListAsync();

        return Ok(new GetProjecsListResponse
            (
            TotalCount,
            PageNumber??=1,
            PageSize??=TotalCount,
            PageNumber > 1,
            PageNumber * PageSize < TotalCount, 
            usersResult));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetProject(string id)
    {
        var contract = await Db.Projects
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
        
        System.Console.WriteLine("\n\n------ > userId : " + userId);
        var user = await Db.Users
            .Include(u => u.Company)
            .FirstOrDefaultAsync(u => u.Id == userId);
        System.Console.WriteLine("\n\n------ > user : " + user);

        if(user is null) return NotFound(new Error("User Not Found"));
        
        System.Console.WriteLine("\n\n------ > user.Company : " + user.Company);

        if(user.Company is null) return NotFound(new Error("User's Company Not Found"));
        
        System.Console.WriteLine("\n\n------ > user.Company.Id : " + user.Company.Id + "    contractDto.clientCompanyId : " + contractDto.clientCompanyId);

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
        
        Db.Projects.Add(contract);
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
