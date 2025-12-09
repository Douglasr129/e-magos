using Core.DomainObjects.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;


namespace Core.Configuration.APIConfiguration
{
    public static class ApiSwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services, IdentitySettings identitySettings)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(docment => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference("Bearer", docment)] = [],
                });
            })
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(identitySettings.JwtSecret)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = identitySettings.ValidAudience,
                    ValidIssuer = identitySettings.ValidIssuer,
                };
            });

            return services;
        }
    }
}
