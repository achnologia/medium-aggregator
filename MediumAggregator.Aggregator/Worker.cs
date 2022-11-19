using MediumAggregator.Aggregator.Interfaces;

namespace MediumAggregator.Aggregator;

public class Worker
{
    private readonly IAggregatorService _aggregatorService;

    public Worker(IAggregatorService aggregatorService)
    {
        _aggregatorService = aggregatorService;
    }
}