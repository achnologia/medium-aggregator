namespace MediumAggregator.DataAccess.Entities;

public class Article
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Author { get; init; }
    public required DateTime PostDate { get; init; }
    public required double ReadTime { get; init; }
    public required string Url { get; init; }
}