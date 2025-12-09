using Core.DomainObjects.Interfaces;
using Core.DomainObjects.Services;
using Core.Notifications.Interfaces;
using Core.Notifications.Service;
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
