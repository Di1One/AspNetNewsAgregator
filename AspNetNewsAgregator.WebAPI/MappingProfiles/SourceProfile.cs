using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.DataBase.Entities;
using AutoMapper;

namespace AspNetNewsAgregatorMvcApp.MappingProfiles
{
    public class SourceProfile : Profile
    {
        public SourceProfile()
        { 
            CreateMap<Source, SourceDto>();
            CreateMap<SourceDto, Source>();
        }
    }
}
