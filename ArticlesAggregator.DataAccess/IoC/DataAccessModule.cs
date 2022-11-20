using Microsoft.Extensions.DependencyInjection;

namespace MediumAggregator.DataAccess.IoC;

public static class DataAccessModule
{
    public static IServiceCollection RegisterDataAccess(this IServiceCollection services)
    {
        services.AddSingleton<IDataContext, FileDataContext>();
        
        return services;
    }
}