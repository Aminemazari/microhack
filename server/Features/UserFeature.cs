using System.Security.Claims;
using MicroHack.Domain;
using MicroHack.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroHack.Features;

[ApiController]
[Route("api/user")]
[Tags("User Group")]

public class UserFeature(AppDbContext db) : ControllerBase
{
    public AppDbContext Db { get; set; } = db;
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    public async Task<IActionResult> GetUserData(Guid id)
    {
        var user = await Db.Users.FirstOrDefaultAsync(u=>u.Id == id);
        if(user is null)
        {
            return NotFound(new Error("User Not Found"));
        }

        return Ok(Mapper.ToDto(user));
    }

    [Authorize]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto userDto)
    {
        var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var existingUser = await Db.Users.FindAsync(id);
        if (existingUser is null)
        {
            return NotFound(new Error("User Not Found"));
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(new Error("Invalid user data"));
        }

        existingUser.UpdateUser(
            userDto.Email,
            userDto.Name);

        await Db.SaveChangesAsync();

        return Ok(Mapper.ToDto(existingUser));
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
    public async Task<IActionResult> DeleteUser()
    {
        var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = await Db.Users.FindAsync(id);
        if (user is null)
        {
            return NotFound(new Error("User Not Found"));
        }

        Db.Users.Remove(user);
        await Db.SaveChangesAsync();

        return NoContent();
    }

    public record UserUpdateDto(string Email, string Name);
}

