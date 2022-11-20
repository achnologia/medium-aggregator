using ArticlesAggregator.Aggregator.Client.Medium.Dtos;
using ArticlesAggregator.Aggregator.Contracts.Dtos;

namespace ArticlesAggregator.Aggregator.Client.Medium;

public static class Mapper
{
    public static ArticleDto ToDto(this Post post)
    {
        var postDate = new DateTime(1970, 1, 1) + TimeSpan.FromMilliseconds(post.FirstPublishedAt);
        
        var dto = new ArticleDto(post.Title, post.Creator.Name, postDate, post.ReadingTime, post.MediumUrl);

        return dto;
    }
}