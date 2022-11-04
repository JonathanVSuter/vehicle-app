using AutoMapper;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Profiles
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<AnnouncementDto, Announcement>()
               .ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
               .ForMember(x => x.IsActive, y => y.MapFrom(src => src.IsActive))
               .ForMember(x => x.CreatedDate, y => y.MapFrom(src => src.CreatedDate))
               .ForMember(x => x.UpdatedDate, y => y.MapFrom(src => src.UpdatedDate))
               //.ForMember(x => x.Vehicle, y => y.MapFrom(src => src.Vehicle))
               .ForMember(x => x.AnnouncedValue, y => y.MapFrom(src => src.AnnouncedValue))
               //.ForMember(x => x.User, y => y.MapFrom(src => src.User))
               .ForMember(x => x.IdUser, y => y.MapFrom(src => src.IdUser))
               .ForMember(x => x.IdVehicle, y => y.MapFrom(src => src.IdVehicle))
               .ReverseMap();
        }
    }
}
