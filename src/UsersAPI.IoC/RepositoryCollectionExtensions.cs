using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using UsersAPI.Data.Repositories.Generic;
using UsersAPI.Domain.Interfaces.Generic;

namespace UsersAPI.IoC
{
    [ExcludeFromCodeCoverage]
    public static class RepositoryCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericEntityRepository<>), typeof(GenericEntityRepository<>));
            return services;
        }
    }
}
