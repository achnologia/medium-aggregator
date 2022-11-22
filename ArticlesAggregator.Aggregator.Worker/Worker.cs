using ArticlesAggregator.Aggregator.Contracts;

namespace MediumAggregator.Aggregator;

public class Worker
{
    private readonly IAggregatorService _aggregatorService;
    
    private const byte MaxEmptySaves = 5;

    public Worker(IAggregatorService aggregatorService)
    {
        _aggregatorService = aggregatorService;
    }

    public async Task Run()
    {
        var breakCounter = 0;
        ushort batchSize = 25;

        while (true)
        {
            var saved = await _aggregatorService.LoadAndSaveAsync(batchSize);

            if (saved == 0)
                breakCounter++;

            if (breakCounter == MaxEmptySaves)
                break;

            await Task.Delay(1500);
        }
    }
}