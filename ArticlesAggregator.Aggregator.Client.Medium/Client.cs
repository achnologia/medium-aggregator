using ArticlesAggregator.Aggregator.Contracts;
using ArticlesAggregator.Aggregator.Contracts.Dtos;

namespace ArticlesAggregator.Aggregator.Client.Medium;

public class Client : IAggregatorClient
{
    public Task<IReadOnlyCollection<ArticleDto>> LoadBasePageAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<ArticleDto>> LoadRecommendations(string url)
    {
        throw new NotImplementedException();
    }
}