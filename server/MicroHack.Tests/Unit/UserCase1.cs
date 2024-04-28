using MicroHack;
using MicroHack.Domain;
using MicroHack.Features;
using MicroHack.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using static MicroHack.Features.UserFeature;
public class UserFeatureTests
{
    private Mock<AppDbContext> _mockDb;
    private UserFeature _userFeature;

    public UserFeatureTests()
    {
        _mockDb = new Mock<AppDbContext>();
        _userFeature = new UserFeature(_mockDb.Object);
    }

    // [Fact]
    // public async System.Threading.Tasks.Task UpdateUser_ShouldReturnBadRequest_WhenModelStateIsInvalid()
    // {
    //     // Arrange
    //     _userFeature.ControllerContext = new ControllerContext();
    //     _userFeature.ModelState.AddModelError("Email", "Invalid email format");
    //     var userDto = new UserUpdateDto ( Email : "invalidEmail", Name :"John Doe" );

    //     // Act
    //     var result = await _userFeature.UpdateUser(userDto);

    //     // Assert
    //     Assert.IsType<BadRequestObjectResult>(result);
    //     var badRequestResult = result as BadRequestObjectResult;
    //     Assert.NotNull(badRequestResult);
    //     Assert.IsType<Error>(badRequestResult.Value);
    // }

}


// I find it hard to unit test this project because of the lean architecture so, integration testing should be better place to inverst in 