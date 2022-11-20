namespace ArticlesAggregator.Aggregator.Contracts.Dtos;

public record ArticleDto(string Title, string Author, DateTime PostDate, double ReadTime, string Url);