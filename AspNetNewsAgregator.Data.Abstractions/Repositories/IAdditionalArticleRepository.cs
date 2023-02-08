using AspNetNewsAgregator.DataBase.Entities;

namespace AspNetNewsAgregator.Data.Abstractions.Repositories;

public interface IAdditionalArticleRepository : IRepository<Article>
{
    Task UpdateArticleTextAsync(Guid id, string text);
}