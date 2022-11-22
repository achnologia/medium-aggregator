namespace ArticlesAggregator.Aggregator.Contracts;

public interface IAggregatorService
{
    Task<int> LoadAndSaveAsync(ushort batchSize);
}