using System.Net.Http.Json;
using System.Text.Json;
using MicroHack.Domain;
using MicroHack.Features;
using MicroHack.Util;

namespace MicroHack.Tests.Integration;
public partial class FullStoiesTests
{
    [Fact]
    public async void TowUsersRegisterThenCreateTowCompaniesThenCreateProject()
    {
        // Arrange
        var application = new ApplicationFactory();

        var client = application.CreateClient();

        var registerDto1 = new AuthFeature.RegisterDto("houdaifa.bouamine@gmail.com","1234");

        // Act
        var response1 = await client.PostAsJsonAsync("api/auth/register", registerDto1);

        Assert.True(response1.IsSuccessStatusCode);


        // Arrange
        var registerDto2 = new AuthFeature.RegisterDto("h.bouamine@esi-sba.dz","1234");

        // Act
        var response2 = await client.PostAsJsonAsync("api/auth/register", registerDto2);

        Assert.True(response2.IsSuccessStatusCode);



        // login with both accounts
        var loginDto1 = new AuthFeature.LoginDto("houdaifa.bouamine@gmail.com","1234");
        var loginDto2 = new AuthFeature.LoginDto("h.bouamine@esi-sba.dz","1234");
        var authResult1 = await client.PostAsJsonAsync("api/auth/login", loginDto1);
        var authResult2 = await client.PostAsJsonAsync("api/auth/login", loginDto2);

        Assert.True(authResult1.IsSuccessStatusCode);
        Assert.True(authResult2.IsSuccessStatusCode);


        var tokenDto1 = await authResult1.Content.ReadFromJsonAsync<AuthFeature.TokenDto>();
        var tokenDto2 = await authResult2.Content.ReadFromJsonAsync<AuthFeature.TokenDto>();
        var token1 = tokenDto1.Token;
        var token2 = tokenDto2.Token;


        // create two companies



        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token1);
        var response3 = await client.PostAsJsonAsync("api/company", new CompanyFeature.CompanyCreateDto("admin@xpera.com"));
        Assert.True(response3.IsSuccessStatusCode);
        var content1 = await response3.Content.ReadFromJsonAsync<CompanyDto>();
    
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token2);       
        var response4 = await client.PostAsJsonAsync("api/company", new CompanyFeature.CompanyCreateDto("admin@esi-sba.dz"));
        Assert.True(response4.IsSuccessStatusCode);
        var content2 = await response4.Content.ReadFromJsonAsync<CompanyDto>();

        System.Console.WriteLine("---> content 1 : " + content1);
        System.Console.WriteLine("---> content 2 : " + content2);

        var projectRequest = new ProjectFeatures.ContractRequestDto
        (
            clientCompanyId : content1!.Id,
            providerCompanyId : content2!.Id,
            content : "wowoowowowowo content wow"
        );

        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token1);
        var projectResponse = await client.PostAsJsonAsync("api/project", projectRequest);

        Assert.True(projectResponse.IsSuccessStatusCode);
    }
}
