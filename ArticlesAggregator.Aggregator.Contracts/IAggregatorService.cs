namespace ArticlesAggregator.Aggregator.Contracts;

public interface IAggregatorService
{
    Task ScanAndSaveAsync();
}