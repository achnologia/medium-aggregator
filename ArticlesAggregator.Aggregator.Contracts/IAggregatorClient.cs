using ArticlesAggregator.Aggregator.Contracts.Dtos;

namespace ArticlesAggregator.Aggregator.Contracts;

public interface IAggregatorClient
{
    Task<IReadOnlyCollection<ArticleDto>> LoadBasePageAsync();
    Task<IReadOnlyCollection<ArticleDto>> LoadRecommendations(string url);
}