using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Core.Extensions.APIExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Core.Configuration.APIConfiguration
{
    public static class ApiConfigExtensions
    {
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });
            builder.Services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            })
                .AddMvc()
                .AddApiExplorer(option =>
                {
                    option.GroupNameFormat = "'v'VVV";
                    option.SubstituteApiVersionInUrl = true;
                });
            //builder.Services.AddSwaggerConfig();

            builder.Services.AddCors(options =>
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
                            .WithOrigins("http://desenvolvedor.io")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
                            .AllowAnyHeader());
            });
            return builder;
        }

        public static WebApplication UseApiConfig(this WebApplication app)
        {
            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            if (app.Environment.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
                //app.UseSwaggerConfig(apiVersionDescriptionProvider);
            }
            else
            {
                app.UseCors("Production");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
           // app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllers();

            return app;
        }
    }
}
