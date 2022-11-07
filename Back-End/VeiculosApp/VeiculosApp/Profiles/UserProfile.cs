using AutoMapper;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
               .ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
               .ForMember(x => x.IsActive, y => y.MapFrom(src => src.IsActive))
               .ForMember(x => x.CreatedDate, y => y.MapFrom(src => src.CreatedDate))
               .ForMember(x => x.UpdatedDate, y => y.MapFrom(src => src.UpdatedDate))
               .ForMember(x => x.Name, y => y.MapFrom(src => src.Name))
               .ForMember(x => x.Password, y => y.MapFrom(src => src.Password))
               .ForMember(x => x.Role, y => y.MapFrom(src => src.Role))
               .ForMember(x => x.Email, y => y.MapFrom(src => src.Email))
               .ReverseMap();
        }
    }
}
