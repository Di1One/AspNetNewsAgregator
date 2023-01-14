using AspNetNewsAgregator.DataBase.Entities;

namespace AspNetNewsAgregator.Data.Abstractions.Repositories;

public interface IArticleRepository
{
    public Task<Article?> GetArticleByIdAsync(Guid id);
    //not for regular usage
    public IQueryable<Article> GetArticlesAsQueryable();
    public Task<List<Article?>> GetAllArticlesAsync();
    public Task AddArticleAsync(Article articles);
    public Task AddArticleAsync(IEnumerable<Article> articles);
    public Task RemoveArticleAsync(Article articles);
    public Task UpdateArticle(Guid id, Article articles);
}