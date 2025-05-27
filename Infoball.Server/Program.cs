using Microsoft.EntityFrameworkCore;
using Infoball.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add API controllers
builder.Services.AddControllers();

//Register database context
builder.Services.AddDbContext<LeagueContext>(opt =>
    opt.UseInMemoryDatabase("LeagueList"));

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
