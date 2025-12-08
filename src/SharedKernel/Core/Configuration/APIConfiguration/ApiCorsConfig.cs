using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration.APIConfiguration
{
    public static class ApiCorsConfig
    {
        public static IServiceCollection AddApiCors(this IServiceCollection services)
        {
            services
               .AddCors(options =>
               {
                   options.AddPolicy("Development",
                       builder =>
                           builder
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());


                   options.AddPolicy("Production",
                       builder =>
                           builder
                               .WithMethods("GET")
                               .WithOrigins("")
                               .SetIsOriginAllowedToAllowWildcardSubdomains()
                               //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
                               .AllowAnyHeader());
               });

            return services;
        }
    }
}
