﻿using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.DataBase.Entities;
using AutoMapper;

namespace AspNetNewsAgregator.Mappers.MappingProfiles
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
                .ForMember(article => article.ShortSummary, opt => opt.MapFrom(article => article.ShortSummary))
                .ForMember(article => article.SourceId, opt 
                => opt.MapFrom(article => new Guid("3C8DCCDC-F6F6-4E62-B711-D08FA4BAD2C0")));

           // CreateMap<ArticleDto, ArticleModel>().ReverseMap();
        }
    }
}
