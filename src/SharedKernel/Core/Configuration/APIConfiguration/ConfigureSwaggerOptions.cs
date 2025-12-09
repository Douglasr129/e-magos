using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Configuration.APIConfiguration
{
    public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {


                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                options.UseAllOfToExtendReferenceSchemas(); // Garante compatibilidade com OpenAPI 3.0

            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {

                Title = "KitEasy - Api",
                Version = $"v{description.ApiVersion}",
                Description = "API para gestão de imóveis de alugueis.",
                Contact = new OpenApiContact
                {
                    Name = "Douglas Rodrigues",
                    Email = "douglas.r129@outlook.com"
                },
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }

            };
            if (description.IsDeprecated)
            {
                info.Description += " Esta versão está obsoleta!";
            }

            return info;
        }
    }
}
