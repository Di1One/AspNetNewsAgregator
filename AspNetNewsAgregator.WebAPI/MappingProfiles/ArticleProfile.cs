using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.DataBase.Entities;
using AutoMapper;

namespace AspNetNewsAgregatorMvcApp.MappingProfiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(article => article.Id))
                .ForMember(dto => dto.Text, opt => opt.MapFrom(article => article.Text))
                .ForMember(dto => dto.ShortSummary, opt => opt.MapFrom(article => article.ShortSummary));

            CreateMap<ArticleDto, Article>()
                .ForMember(dto => dto.Text, opt => opt.MapFrom(article => article.Text))
                .ForMember(dto => dto.Text, opt => opt.MapFrom(article => article.Text))
                .ForMember(article => article.ShortSummary, opt => opt.MapFrom(article => article.ShortSummary));
        }
    }
}
