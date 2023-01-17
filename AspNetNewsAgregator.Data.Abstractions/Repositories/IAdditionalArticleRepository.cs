using AspNetNewsAgregator.DataBase.Entities;

namespace AspNetNewsAgregator.Data.Abstractions.Repositories;

public interface IAdditionalArticleRepository : IRepository<Article>
{
    void DoCustomMethod();
}