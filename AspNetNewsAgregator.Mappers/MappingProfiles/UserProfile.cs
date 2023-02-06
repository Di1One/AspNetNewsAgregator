using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.DataBase.Entities;
using AutoMapper;

namespace AspNetNewsAgregator.Mappers.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.RoleName, opt => opt.MapFrom(entity => entity.Role.Name)); ;

            CreateMap<UserDto, User>()
                .ForMember(ent => ent.Id, opt => opt.MapFrom(dto => Guid.NewGuid()))
                .ForMember(ent => ent.RegistrationDate, opt => opt.MapFrom(dto => DateTime.Now)); ;

            //CreateMap<RegisterModel, UserDto>()
            //    .ForMember(dto => dto.PasswordHash, opt => opt.MapFrom(model => model.Password));


            //CreateMap<LoginModel, UserDto>();
            //CreateMap<UserDto, UserDataModel>();
        }
    }
}
