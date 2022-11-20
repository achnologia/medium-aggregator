namespace ArticlesAggregator.Aggregator.Client.Medium.Dtos;

public class Post
{
    public Creator Creator { get; set; }
    public long FirstPublishedAt { get; set; }
    public string Title { get; set; }
    public double ReadingTime { get; set; }
    public string MediumUrl { get; set; }
}