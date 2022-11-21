using MediumAggregator.DataAccess.Entities;

namespace MediumAggregator.DataAccess;

public interface IDataContext
{
    public Task<int> Save(IEnumerable<Article> articles);
    public Task<bool> Save(Article article);
}