using Microsoft.EntityFrameworkCore;
using Infoball.Shared.Models;
using Infoball.Server.Services;
using Infoball.Server.Services.Interfaces;
using Infoball.Server.Data;

//Load .env file
DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Get ConnectionString
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//Replace username and password in ConnectionString
var updatedConnectionString = connectionString
    .Replace("{DB_USERNAME}", Environment.GetEnvironmentVariable("DB_USERNAME"))
    .Replace("{DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD"));

builder.Configuration["ConnectionStrings:DefaultConnection"] = updatedConnectionString;

//Register database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(updatedConnectionString));

// Add services to the container
builder.Services.AddOpenApi();

// Add API controllers
builder.Services.AddControllers();

//Register services
builder.Services.AddScoped<ITeamService, TeamService>();

// Add Blazor WebAssembly hosting services
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}
else
{
    app.UseExceptionHandler("/Error");
}

// app.UseHttpsRedirection();

// Required middleware for serving the Blazor WebAssembly app
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// API endpoints
app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
