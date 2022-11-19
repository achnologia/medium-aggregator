using ArticlesAggregator.Aggregator.Contracts;

namespace MediumAggregator.Aggregator;

public class Worker
{
    private readonly IAggregatorService _aggregatorService;

    public Worker(IAggregatorService aggregatorService)
    {
        _aggregatorService = aggregatorService;
    }
}