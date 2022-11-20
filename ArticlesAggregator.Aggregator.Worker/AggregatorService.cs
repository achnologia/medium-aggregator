using ArticlesAggregator.Aggregator.Contracts;
using MediumAggregator.DataAccess;

namespace MediumAggregator.Aggregator;

public class AggregatorService : IAggregatorService
{
    private readonly IAggregatorClient _client;
    private readonly IDataContext _dataContext;

    public AggregatorService(IAggregatorClient client, IDataContext dataContext)
    {
        _client = client;
        _dataContext = dataContext;
    }

    public async Task ScanAndSaveAsync()
    {
        var articles = await _client.LoadBasePageAsync();

        var entities = articles.Select(x => x.ToEntity());

        await _dataContext.Save(entities);
    }
}