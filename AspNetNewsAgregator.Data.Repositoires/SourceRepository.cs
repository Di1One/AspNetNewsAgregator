using AspNetNewsAgregator.Data.Abstractions.Repositories;
using AspNetNewsAgregator.DataBase;
using AspNetNewsAgregator.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetNewsAgregator.Data.Repositories
{
    public class SourceRepository : ISourceRepository // CRUD operations with Articles Table in DB
    {
        private readonly GoodNewsAggregatorContext _database;
        
        public SourceRepository(GoodNewsAggregatorContext database)
        {
            _database = database;
        }

        public async Task<Source?> GetSourceByIdAsync(Guid id)
        {
            return await _database.Sources
                .FirstOrDefaultAsync(source => source.Id.Equals(id));
        }
       
        //not for regular usage
        public IQueryable<Source> GetSourcesAsQueryable()
        {
            return _database.Sources;
        }
        public async Task<List<Source?>> GetAllSourcesAsync()
        {
            return await _database.Sources.ToListAsync();
        }
        public async Task AddSourceAsync(Source source)
        {
            await _database.Sources.AddRangeAsync(source);
        }
        public async Task AddSourceAsync(IEnumerable<Source> source)
        {
            await _database.Sources.AddRangeAsync(source);
            await _database.SaveChangesAsync();
        }
        public async Task RemoveSourceAsync(Source source)
        {
            _database.Sources.Remove(source);
            await _database.SaveChangesAsync();
        }
        public async Task UpdateSource(Guid id, Source source)
        {
            var entity = _database.Sources.FirstOrDefaultAsync(source => source.Id.Equals(id));

            if (entity != null)
            {

            }

            await _database.SaveChangesAsync();
        }
    }
}