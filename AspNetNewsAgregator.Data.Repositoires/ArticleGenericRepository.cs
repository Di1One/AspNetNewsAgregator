using AspNetNewsAgregator.Data.Abstractions.Repositories;
using AspNetNewsAgregator.DataBase;
using AspNetNewsAgregator.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetNewsAgregator.Data.Repositories;

public class ArticleGenericRepository : Repository<Article>, IAdditionalArticleRepository
{
    public ArticleGenericRepository(GoodNewsAggregatorContext database) 
        : base(database)
    {
    }

    public async Task UpdateArticleTextAsync(Guid id, string text)
    {
        var article = await DbSet.FirstOrDefaultAsync(a => a.Id.Equals(id));

        if (article != null)
        {
            article.Text = text;
        }
    }
}