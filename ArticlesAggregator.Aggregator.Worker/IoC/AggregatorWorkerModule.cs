using ArticlesAggregator.Aggregator.Client.Medium.IoC;
using ArticlesAggregator.Aggregator.Contracts;
using MediumAggregator.DataAccess.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace MediumAggregator.Aggregator.IoC;

public static class AggregatorWorkerModule
{
    public static IServiceCollection RegisterAggregatorWorker(this IServiceCollection services)
    {
        services.RegisterDataAccess();
        services.RegisterMediumClient();

        services.AddSingleton<IAggregatorService, AggregatorService>();
        
        return services;
    }
}