using Asp.Versioning.ApiExplorer;
using Auth.Infrastructure.Data;
using Core.Configuration.APIConfiguration;
using Core.DomainObjects.Models;
using Core.Notifications.Interfaces;
using Core.Notifications.Service;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// EF Core
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

// Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var config = builder.Configuration.GetConnectionString("Redis") ?? "localhost:6379";
    return ConnectionMultiplexer.Connect(config);
});

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerConfig(new IdentitySettings
{
    JwtSecret = builder.Configuration["IdentitySettings:JwtSecret"] ?? string.Empty,
    ValidIssuer = builder.Configuration["IdentitySettings:ValidIssuer"] ?? string.Empty,
    ValidAudience = builder.Configuration["IdentitySettings:ValidAudience"] ?? string.Empty,
    Expires = int.Parse(builder.Configuration["IdentitySettings:Expires"] ?? "0")
});
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddScoped<INotifier, Notifier>();

builder.Services.AddControllers();
builder.Services.AddApiCors();
builder.Services.AddCoreApiVersioning();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseCoreApiVersioning(apiVersionDescriptionProvider);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
