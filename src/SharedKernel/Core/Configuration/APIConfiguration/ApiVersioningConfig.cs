using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration.APIConfiguration
{
    public static class ApiVersioningConfig
    {
        public static IServiceCollection AddCoreApiVersioning(this IServiceCollection services)
        {
            services
                .AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV"; // v1, v2
                    options.SubstituteApiVersionInUrl = true;
                });

            return services;
        }
        public static IApplicationBuilder UseCoreApiVersioning(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            //app.UseMiddleware<SwaggerAuthorizedMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            $"API {description.GroupName.ToUpperInvariant()}");
                    }
                    options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); // Controla a expansão dos docs
                    options.DisplayRequestDuration(); // Exibe o tempo de resposta nas solicitações

                });
            return app;
        }
    }

}
