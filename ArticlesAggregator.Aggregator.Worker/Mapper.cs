using ArticlesAggregator.Aggregator.Contracts.Dtos;
using MediumAggregator.DataAccess.Entities;

namespace MediumAggregator.Aggregator;

public static class Mapper
{
    public static Article ToEntity(this ArticleDto dto)
    {
        var entity = new Article
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Author = dto.Author,
            PostDate = dto.PostDate,
            ReadTime = dto.ReadTime,
            Url = dto.Url
        };

        return entity;
    }
}