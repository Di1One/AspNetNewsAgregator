﻿using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregator.Data.Abstractions;
using AspNetNewsAgregator.Data.Abstractions.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AspNetNewsAgregator.DataBase.Entities;

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
                var passwordSalt = _configuration["UserSecrets:PasswordSalt"];

                var list = await _unitOfWork.Articles
                    .GetArticlesAsQueryable()
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
            var entity = await _unitOfWork.Articles.GetArticleByIdAsync(id);
            var dto = _mapper.Map<ArticleDto>(entity);

            return dto;
        }
        public async Task<int> CreateArticleAsync(ArticleDto dto)
        {
            var entity = _mapper.Map<Article>(dto);  

            if (entity != null)
            {
                await _unitOfWork.Articles.AddArticleAsync(entity);
                var addingResult = await _unitOfWork.Commit();

                return addingResult;
            }
            else
            {
                throw new ArgumentException(nameof(dto));
            }
        }
        public async Task Do()
        {
            await _unitOfWork.Articles.AddArticleAsync(new Article());
            await _unitOfWork.Sources.AddSourceAsync(new Source());

            await _unitOfWork.Commit();
        }
    }
}
