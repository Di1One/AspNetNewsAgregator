using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.DataBase.Entities;
using AspNetNewsAgregatorMvcApp.Models;
using AutoMapper;

namespace AspNetNewsAgregatorMvcApp.MappingProfiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();
            CreateMap<ArticleDto, ArticleModel>().ReverseMap();
        }
    }
}
