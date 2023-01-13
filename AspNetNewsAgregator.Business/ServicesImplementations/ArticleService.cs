using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregator.DataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AspNetNewsAgregator.DataBase.Entities;
using System.Collections.Generic;

namespace AspNetNewsAgregator.Business.ServicesImplementations
{
    public class ArticleService : IArticleService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly GoodNewsAggregatorContext _databaseContext;

        public ArticleService(GoodNewsAggregatorContext databaseContext, IMapper mapper, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<List<ArticleDto>> GetArticlesByPageNumberAndPageSizeAsync(int pageNumber, int pageSize)
        {
            try
            {
                var myApiKey = _configuration.GetSection("UserSecrets")["MyApiKey"];
                var passwordSalt = _configuration["UserSecrets:PasswordSalt"];

                var list = await _databaseContext.Articles
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .Select(article => _mapper.Map<ArticleDto>(article))
                    .ToListAsync();

                return list;
            }
            catch (Exception)
            {
                // add logger here
                throw;
            }
        }
        public async Task<List<ArticleDto>> GetNewArticlesFromExternalSourcesAsync()
        {
            var list = new List<ArticleDto>();

            return list;
        }
        public async Task<ArticleDto> GetArticleByIdAsync(Guid id)
        {
            var entity = await _databaseContext.Articles.FirstOrDefaultAsync(article => article.Id.Equals(id));
            var dto = _mapper.Map<ArticleDto>(entity);

            return dto;
        }
        public async Task<int> CreateArticleAsync(ArticleDto dto)
        {
            var entity = _mapper.Map<Article>(dto);  

            if (entity != null)
            {
                await _databaseContext.Articles.AddAsync(entity);
                var addingResult = await _databaseContext.SaveChangesAsync();
                return addingResult;
            }
            else
            {
                throw new ArgumentException(nameof(dto));
            }
        }
    }
}
