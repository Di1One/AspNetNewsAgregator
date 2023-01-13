using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregator.DataBase;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AspNetNewsAgregator.DataBase.Entities;

namespace AspNetNewsAgregator.Business.ServicesImplementations
{
    public class SourceService : ISourceService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly GoodNewsAggregatorContext _databaseContext;

        public SourceService(GoodNewsAggregatorContext databaseContext, IMapper mapper, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<List<SourceDto>> GetSourcesAsync()
        {
            return await _databaseContext.Sources
                .Select(source => _mapper.Map<SourceDto>(source))
                .ToListAsync();
        }

        public async Task<SourceDto> GetSourceByIdAsync(Guid id)
        {
            return _mapper.Map<SourceDto>(await _databaseContext.Sources
                .FirstOrDefaultAsync(source => source.Id.Equals(id)));
        }

        public async Task<int> CreateSourceAsync(SourceDto dto)
        {
            var entity = _mapper.Map<Source>(dto);
            await _databaseContext.Sources.AddAsync(entity);
            return await _databaseContext.SaveChangesAsync();
        }
    }
}
