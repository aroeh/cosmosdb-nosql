using CosmosDb.NoSql.Infrastructure.DbService;
using CosmosDb.NoSql.Infrastructure.Repos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CosmosDb.NoSql.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureRepos(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IRestuarantRepo, RestuarantRepo>();
        services.AddTransient<ICosmosDbWrapper, CosmosDbWrapper>();

        return services;
    }
}
