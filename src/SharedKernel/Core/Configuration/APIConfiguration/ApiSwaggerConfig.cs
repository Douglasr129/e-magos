using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;


namespace Core.Configuration.APIConfiguration
{
    public static class ApiSwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
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
            });

            return services;
        }
    }
}
