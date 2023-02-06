using AspNetNewsAgregator.Core;
using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregator.Data.Abstractions;
using AspNetNewsAgregator.Data.Abstractions.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AspNetNewsAgregator.DataBase.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Xml;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace AspNetNewsAgregator.Business.ServicesImplementations
{
    public class ArticleService : IArticleService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ArticleDto>> GetArticlesByPageNumberAndPageSizeAsync(int pageNumber, int pageSize)
        {
            try
            {
                var myApiKey = _configuration.GetSection("UserSecrets")["MyApiKey"];

                var list = await _unitOfWork.Articles
                    .Get()
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

        public async Task<List<ArticleDto>> GetArticlesByNameAndSourcesAsync(string? name, Guid? sourceId)
        {
            var list = new List<ArticleDto>();

            var entities = _unitOfWork.Articles.Get();

            if (!string.IsNullOrEmpty(name))
            {
                entities = entities.Where(dto => dto.Title.Contains(name));
            }

            if (sourceId!=null && !Guid.Empty.Equals(sourceId))
            {
                entities = entities.Where(dto => dto.SourceId.Equals(sourceId));
            }

            var result = (await entities.ToListAsync())
                .Select(ent => _mapper.Map<ArticleDto>(ent))
                .ToList();

            return result;
        }

        public async Task<ArticleDto> GetArticleByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Articles.GetByIdAsync(id);
            var dto = _mapper.Map<ArticleDto>(entity);

            return dto;
        }
        public async Task<int> CreateArticleAsync(ArticleDto dto)
        {
            var entity = _mapper.Map<Article>(dto);  

            if (entity != null)
            {
                await _unitOfWork.Articles.AddAsync(entity);
                var addingResult = await _unitOfWork.Commit();

                return addingResult;
            }
            else
            {
                throw new ArgumentException(nameof(dto));
            }
        }

        public async Task<int> UpdateArticleAsync(Guid id, ArticleDto? dto)
        {
            var sourceDto = await GetArticleByIdAsync(id);

            //should be sure that dto property is the same with entity property naming 
            var patchList = new List<PatchModel>();
            if (dto != null)
            {
                if (!dto.Title.Equals(sourceDto.Title))
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Title),
                        PropertyValue = dto.Title
                    });
                }
            }

            await _unitOfWork.Articles.PatchAsync(id, patchList);
            return await _unitOfWork.Commit();
        }

        public async Task DeleteArticleAsync(Guid id)
        {
            var entity = await _unitOfWork.Articles.GetByIdAsync(id);

            if (entity != null)
            {
                _unitOfWork.Articles.Remove(entity);

                await _unitOfWork.Commit();
            }
            else
            {
                throw new ArgumentException("Article for removing doesn't exist", nameof(id));
            }
        }

        public async Task GetAllArticleDataFromRssAsync(string? sourceRssUrl)
        {
            if (!string.IsNullOrEmpty(sourceRssUrl))
            {
                var list = new List<ArticleDto>();

                using (var reader = XmlReader.Create(sourceRssUrl))
                {
                    var feed = SyndicationFeed.Load(reader);

                    foreach (var item in feed.Items)
                    {
                        //should be checked for different rss sources
                        var articleDto = new ArticleDto()
                        {
                            Id = Guid.NewGuid(),
                            Title = item.Title.Text,
                            PublicationDate = item.PublishDate.UtcDateTime,
                            ShortSummary = item.Summary.Text,
                            Category = item.Categories.FirstOrDefault()?.Name,
                            SourceId = sourceId,
                            SourceUrl = item.Id
                        };

                        list.Add(articleDto);
                    }
                }
            }
        }
    }
}