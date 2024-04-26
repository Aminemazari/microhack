using System.Security.Claims;
using MicroHack.Domain;
using MicroHack.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroHack.Features;

[ApiController]
[Route("api/auth")]
[Tags("Auth Group")]
public class AuthFeature(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext db = db;
    
    [Authorize]
    [HttpGet("currentUser")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CurrentUser()
    {
        Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var currentUser = await db.Users
            .FirstOrDefaultAsync(u => u.Id == userId);
            
        if(currentUser is null) return NotFound(new Error("User Not Found"));

        return Ok(Mapper.ToDto(currentUser));
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        if(db.Users.Any(u=>u.Email == registerDto.Email))
        {
            return BadRequest(new Error("email already in use"));
        }

        var newUser = new User(registerDto.Email, registerDto.Password);

        await db.Users.AddAsync(newUser);
        await db.SaveChangesAsync();

        return Ok(Mapper.ToDto(newUser));
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
    public IActionResult Login(LoginDto loginDto)
    {
        var user = db.Users.FirstOrDefault(u => u.Email == loginDto.Email);

        if (user is null)
            return NotFound(new Error("User Not Found"));
        
        if(!user.VerifyPassword(loginDto.Password))
            return BadRequest(new Error("Failed to login"));

        var token = JwtService.GenerateJWTToken(user);

        return Ok(new {Token = token});
    }

    public record RegisterDto(string Email, string Password);
    public record LoginDto(string Email, string Password);

}
