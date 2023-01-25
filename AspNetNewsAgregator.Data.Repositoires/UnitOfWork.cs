using AspNetNewsAgregator.Data.Abstractions;
using AspNetNewsAgregator.Data.Abstractions.Repositories;
using AspNetNewsAgregator.DataBase;
using AspNetNewsAgregator.DataBase.Entities;

namespace AspNetNewsAgregator.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly GoodNewsAggregatorContext _database;
    public IAdditionalArticleRepository Articles { get; }
    public IRepository<Source> Sources { get; }
    public IRepository<User> Users { get; }
    public IRepository<Role> Roles { get; }

    public UnitOfWork(GoodNewsAggregatorContext database,
        IAdditionalArticleRepository articleRepository,
        IRepository<Source> sourceRepository, 
        IRepository<User> users, IRepository<Role> roles)
    {
        _database = database;
        Articles = articleRepository;
        Sources = sourceRepository;
        Users = users;
        Roles = roles;
    }

    public async Task<int> Commit()
    {
        return await _database.SaveChangesAsync();
    }
}