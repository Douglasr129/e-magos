using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration.APIConfiguration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
            services
                .AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });
            return services;
        }
    }
}
