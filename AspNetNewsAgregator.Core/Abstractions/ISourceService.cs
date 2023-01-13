using AspNetNewsAgregator.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetNewsAgregator.Core.Abstractions
{
    public interface ISourceService
    {
        Task<List<SourceDto>> GetSourcesAsync();
        Task<SourceDto> GetSourceByIdAsync(Guid id);
        Task<int> CreateSourceAsync(SourceDto dto);
    }
}
