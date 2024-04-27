using System;
using System.Text;
using System.Text.Json;
using ChatGPT.Net;
using MicroHack;
using MicroHack.Domain;
using MicroHack.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    
});

builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddAuthentication(cfg => {
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"]!)
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<CompanyManager>();

JwtService.SetJwtSecret(builder.Configuration["ApplicationSettings:JWT_Secret"]!);
// JwtService.SetJwtSecret("dummy_secret_for_development_mode");

var app = builder.Build();

app.UseHsts();

// Handmade Global logging
app.Use((ctx,next)=>
{

    var start = DateTime.UtcNow;
    var task = next();
    var end = DateTime.UtcNow;

    var log = new RequestLog(
        ctx.Request.Path,
        ctx?.User?.Identity?.Name,
        ctx?.Response.StatusCode,
        (end-start).TotalMilliseconds);

    Log.Information("{log}",log);

   return task;

});

// Handmade Global Error Handling
app.Use(async (ctx,next)=>
{
    try{
        await next();
    }
    catch(Exception ex)
    {
        ctx.Response.StatusCode = 500;
        await ctx.Response.WriteAsJsonAsync(new Error(ex.Message));
    } 
});

app.UseSwagger();
app.UseSwaggerUI(o=>o.EnableFilter("Group"));

app.MapGet("/",()=> Results.Redirect("swagger/index.html"));

app.UseCors("AllowAll");

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// string apiKey = "fd2cd46f-5920-4388-ab45-4ff65bf4bf32";

// app.MapPost("Chat-Completions",async ([FromBody] string message)=>
// {
    
//     HttpClient client = new HttpClient();

//     client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

//     var payload = new PayLoad("Meta-Llama-3-8B-Instruct",new List<Message>(){new("user",message)});

//     var payloadAsJson = JsonSerializer.Serialize(payload);

//     HttpContent httpContent= new StringContent(payloadAsJson,Encoding.UTF8,"application/json");

//     var result = await client.PostAsync("https://api.awanllm.com/v1/chat/completions",httpContent);

//     return Results.Ok(result);
// });

// app.MapGet("ai", async () =>
// {


// });

app.Run();


public record PayLoad(string model, List<Message> messages);
public record Message(string role, string content);
public partial class Program { }