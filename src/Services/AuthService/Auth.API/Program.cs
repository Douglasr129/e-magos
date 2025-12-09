using Asp.Versioning.ApiExplorer;
using Core.Configuration.APIConfiguration;
using Core.Notifications.Interfaces;
using Core.Notifications.Service;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT desta maneira: Bearer {seu token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    options.AddSecurityRequirement(docment => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", docment)] = [],
    });
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
