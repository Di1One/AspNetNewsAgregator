using AspNetNewsAgregator.Data.Abstractions.Repositories;

namespace AspNetNewsAgregator.Data.Abstractions;

public interface IUnitOfWork
{
    IArticleRepository Articles { get; }
    ISourceRepository Sources{ get; }
    public Task<int> Commit(); //SaveChanges()
}