using Microsoft.Extensions.DependencyInjection;
using ViaCep.Example.Core.Services;

namespace ViaCep.Example.Core.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IViaCepService, ViaCepService>();
        }
    }
}