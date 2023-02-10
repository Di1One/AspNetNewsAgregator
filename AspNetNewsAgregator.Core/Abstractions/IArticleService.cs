using AspNetNewsAgregator.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetNewsAgregator.Core.Abstractions
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetArticlesByPageNumberAndPageSizeAsync(int pageNumber, int pageSize);
        Task AggregateArticlesFromExternalSourcesAsync();
        Task<List<ArticleDto>> GetArticlesByNameAndSourcesAsync(string? name, Guid? sourceId);
        Task<ArticleDto> GetArticleByIdAsync(Guid id);
        Task<int> CreateArticleAsync(ArticleDto dto);
        Task<int> UpdateArticleAsync(Guid modelId, ArticleDto? patchList);
        Task AddArticleTextToArticlesAsync();
        Task DeleteArticleAsync(Guid id);
        Task GetAllArticleDataFromRssAsync();
        Task AddRateToArticlesAsync();
    }
}
