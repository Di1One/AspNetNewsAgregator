using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.DataBase.Entities;
using AutoMapper;

namespace AspNetNewsAgregator.Mappers.MappingProfiles
{
    public class SourceProfile : Profile
    {
        public SourceProfile()
        { 
            CreateMap<Source, SourceDto>();
            CreateMap<SourceDto, Source>();

            //CreateMap<SourceModel, SourceDto>();
            //CreateMap<SourceDto, SourceModel>();

            ////non good practice basically, but can used smt
            //CreateMap<CreateSourceModel, SourceDto>()
            //    .ForMember(dto => dto.Id, opt => opt.MapFrom(article => Guid.NewGuid()));
        }
    }
}
