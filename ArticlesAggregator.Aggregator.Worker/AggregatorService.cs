using ArticlesAggregator.Aggregator.Contracts;

namespace MediumAggregator.Aggregator;

public class AggregatorService : IAggregatorService
{
    private readonly IAggregatorClient _client;

    public AggregatorService(IAggregatorClient client)
    {
        _client = client;
    }
}