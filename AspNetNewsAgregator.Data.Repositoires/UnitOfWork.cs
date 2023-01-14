using AspNetNewsAgregator.Data.Abstractions;
using AspNetNewsAgregator.Data.Abstractions.Repositories;
using AspNetNewsAgregator.DataBase;

namespace AspNetNewsAgregator.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly GoodNewsAggregatorContext _database;
    public IArticleRepository Articles { get; }
    public ISourceRepository Sources { get; }

    public UnitOfWork(GoodNewsAggregatorContext database,
        IArticleRepository articleRepository,
        ISourceRepository sourceRepository)
    {
        _database = database;
        Articles = articleRepository;
        Sources = sourceRepository;
    }

    public async Task<int> Commit()
    {
        return await _database.SaveChangesAsync();
    }
}