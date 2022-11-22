using ArticlesAggregator.Aggregator.Contracts.Dtos;

namespace ArticlesAggregator.Aggregator.Contracts;

public interface IAggregatorClient
{
    Task<IReadOnlyCollection<ArticleDto>> LoadAsync(ushort batchSize);
    Task<IReadOnlyCollection<ArticleDto>> LoadRecommendations(string url);
}