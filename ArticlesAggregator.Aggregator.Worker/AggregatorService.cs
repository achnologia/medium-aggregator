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

    public async Task<int> LoadAndSaveAsync(ushort batchSize)
    {
        var articles = await _client.LoadAsync(batchSize);

        if (articles.Count == 0)
            return 0;
        
        var entities = articles.Select(x => x.ToEntity());

        var saved = await _dataContext.Save(entities);

        return saved;
    }
}