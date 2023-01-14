using AspNetNewsAgregator.Data.Abstractions.Repositories;
using AspNetNewsAgregator.DataBase;
using AspNetNewsAgregator.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetNewsAgregator.Data.Repositories
{
    public class ArticleRepository : IArticleRepository // CRUD operations with Articles Table in DB
    {
        private readonly GoodNewsAggregatorContext _database;
        
        public ArticleRepository(GoodNewsAggregatorContext database)
        {
            _database = database;
        }

        public async Task<Article?> GetArticleByIdAsync(Guid id)
        {
            return await _database.Articles
                .FirstOrDefaultAsync(article => article.Id.Equals(id));
        }
       
        //not for regular usage
        public IQueryable<Article> GetArticlesAsQueryable()
        {
            return _database.Articles;
        }
        public async Task<List<Article?>> GetAllArticlesAsync()
        {
            return await _database.Articles.ToListAsync();
        }
        public async Task AddArticleAsync(Article source)
        {
            await _database.Articles.AddRangeAsync(source);
        }
        public async Task AddArticleAsync(IEnumerable<Article> articles)
        {
            await _database.Articles.AddRangeAsync(articles);
            await _database.SaveChangesAsync();
        }
        public async Task RemoveArticleAsync(Article articles)
        {
            _database.Articles.Remove(articles);
            await _database.SaveChangesAsync();
        }
        public async Task UpdateArticle(Guid id, Article articles)
        {
            var entity = _database.Articles.FirstOrDefaultAsync(article => article.Id.Equals(id));

            if (entity != null)
            {

            }
            await _database.SaveChangesAsync();
        }
    }
}