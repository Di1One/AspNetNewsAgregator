using AspNetNewsAgregator.Data.Abstractions.Repositories;
using AspNetNewsAgregator.DataBase;
using AspNetNewsAgregator.DataBase.Entities;

namespace AspNetNewsAgregator.Data.Repositories;

public class ArticleGenericRepository : Repository<Article>, IAdditionalArticleRepository
{
    public ArticleGenericRepository(GoodNewsAggregatorContext database) 
        : base(database)
    {
    }

    public void DoCustomMethod()
    {
        throw new NotImplementedException();
    }
}