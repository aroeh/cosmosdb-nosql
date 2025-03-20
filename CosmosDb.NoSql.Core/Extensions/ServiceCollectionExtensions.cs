using CosmosDb.NoSql.Core.Orchestrations;
using Microsoft.Extensions.DependencyInjection;

namespace CosmosDb.NoSql.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreOrchestrations(this IServiceCollection services)
    {
        services.AddTransient<IRestuarantOrchestration, RestuarantOrchestration>();

        return services;
    }
}