using AspNetNewsAgregator.DataBase.Entities;

namespace AspNetNewsAgregator.Data.Abstractions.Repositories;

public interface ISourceRepository
{
    public Task<Source?> GetSourceByIdAsync(Guid id);
    //not for regular usage
    public IQueryable<Source> GetSourcesAsQueryable();
    public Task<List<Source?>> GetAllSourcesAsync();
    public Task AddSourceAsync(Source source);
    public Task AddSourceAsync(IEnumerable<Source> source);
    public Task RemoveSourceAsync(Source source);
    public Task UpdateSource(Guid id, Source source);
}