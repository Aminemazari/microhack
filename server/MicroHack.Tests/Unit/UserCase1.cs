// using MicroHack.Features;
// using MicroHack.Util;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace MicroHack.Tests.Integration;

// public class UserCase1
// {
//     [Fact]
//     public async void TowUsersRegisterThenCreateTowCompaniesThenCreateProject()
//     {
//         var dbOptionsBuilder = new DbContextOptionsBuilder();
//         dbOptionsBuilder.UseSqlite("Data Source=TestingDatabase.db");
//         var db = new AppDbContext(dbOptionsBuilder.Options);
//         var authFeature = new AuthFeature(db);

//         var registerDto1 = new AuthFeature.RegisterDto("houdaifa.bouamine@gmail.com","1234");
//         await authFeature.Register(registerDto1);

//         var registerDto2 = new AuthFeature.RegisterDto("h.bouamine@esi-sba.dz","1234");
//         await authFeature.Register(registerDto2);

//         // login both users
//         var loginDto1 = new AuthFeature.LoginDto("houdaifa.bouamine@gmail.com","1234");
//         var authResult1 = Assert.IsType<OkObjectResult> (authFeature.Login(loginDto1));
//         var tokenDto1 = Assert.IsType<AuthFeature.TokenDto>(authResult1.Value);
//         var token1 = tokenDto1.Token;

//         var loginDto2 = new AuthFeature.LoginDto("h.bouamine@esi-sba.dz","1234");
//         var authResult2 = Assert.IsType<OkObjectResult> (authFeature.Login(loginDto2));
//         var tokenDto2 = Assert.IsType<AuthFeature.TokenDto>(authResult2.Value);
//         var token2 = tokenDto2.Token;
        
//         // create two companies
        
//         var httpContext1 = new DefaultHttpContext();
//         System.Console.WriteLine("\n\n-----> token : " + token1);
//         httpContext1.Request.Headers.Authorization = "Bearer " + token1;
        
//         var companiesFeature1 = new CompanyFeature(db)
//         { 
//             ControllerContext = new ControllerContext()
//             {
//                 HttpContext = httpContext1
//             }
//         };

//         var createCompanyDto1 = new CompanyFeature.CompanyCreateDto("admin@esi-sba.dz");
//         var okresponse1 = Assert.IsType<OkObjectResult>(await companiesFeature1.CreateCompany(createCompanyDto1));
//         var companyDto1 = Assert.IsType<CompanyDto>(okresponse1.Value);


//         var httpContext2 = new DefaultHttpContext();
//         httpContext2.Request.Headers.Authorization = "Bearer " + token2;
        
//         var companiesFeature2 = new CompanyFeature(db)
//         {
//             ControllerContext = new ControllerContext()
//             {
//                 HttpContext = httpContext1
//             }
//         };
        
//         var createCompanyDto2 = new CompanyFeature.CompanyCreateDto("admin@esi-sba.dz");
//         var okresponse2 = Assert.IsType<OkObjectResult>(await companiesFeature2.CreateCompany(createCompanyDto2));
//         var companyDto2 = Assert.IsType<CompanyDto>(okresponse2.Value);

//         // // create project
//         // var projectsFeature = new ProjectFeatures(db);
//         // var createProjectDto = projectsFeature.CreateProject(companyDto1.Id,companyDto2.Id);
//         // var okresponse = Assert.IsType<OkObjectResult>(projectsFeature.CreateProject(createProjectDto));
//         // var projectDto = Assert.IsType<ProjectDto>(okresponse.Value);
        
//     }
// }
