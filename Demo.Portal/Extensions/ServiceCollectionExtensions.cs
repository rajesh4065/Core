using Demo.Portal.Common.Models;
using Demo.Portal.Repositories;
using Demo.Portal.Services.Implementation;
using Demo.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Portal.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>Registers any necessary services for authentication.</summary>
        /// <param name="services">The services collection.</param>
        /// <returns>The service collection.<see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            return services;
        }

        /// <summary>Registers the logic layer services with the di container.</summary>
        /// <param name="services">The services collection.</param>
        /// <returns>The service collection.<see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
           
            services.AddTransient<IStudentService, StudentService>();
          
            return services;
        }

        /// <summary>Registers the data layer repositories with the di container.</summary>
        /// <param name="services">The services collection.</param>
        /// <param name="configuration">The current configuration.</param>
        /// <returns>The service collection.<see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            // Provide the orchestrator api settings object via the di container.
            services.Configure<ApiClientSettings>(configuration.GetSection("ApiSettings"));
            services.AddHttpClient<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}
