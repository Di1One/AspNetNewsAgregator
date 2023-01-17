using AspNetNewsAgregator.Data.Abstractions.Repositories;
using AspNetNewsAgregator.DataBase.Entities;

namespace AspNetNewsAgregator.Data.Abstractions;

public interface IUnitOfWork
{
    IAdditionalArticleRepository Articles { get; }
    IRepository<Source> Sources{ get; }
    public Task<int> Commit(); //SaveChanges()
}