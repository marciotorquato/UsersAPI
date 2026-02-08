using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using UsersAPI.Application.AppServices;
using UsersAPI.Application.Interfaces;

namespace UsersAPI.IoC
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            return services;
        }
    }
}
