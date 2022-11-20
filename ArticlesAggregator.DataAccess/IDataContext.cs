using MediumAggregator.DataAccess.Entities;

namespace MediumAggregator.DataAccess;

public interface IDataContext
{
    public Task Save(IEnumerable<Article> articles);
    public Task Save(Article article);
}