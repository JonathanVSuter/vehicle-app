using AutoMapper;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Profiles
{
    public class VehicleImageProfile : Profile
    {
        public VehicleImageProfile()
        {
            CreateMap<AnnouncementImageDto, AnnouncementImage>()
               .ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
               .ForMember(x => x.IsActive, y => y.MapFrom(src => src.IsActive))
               .ForMember(x => x.CreatedDate, y => y.MapFrom(src => src.CreatedDate))
               .ForMember(x => x.UpdatedDate, y => y.MapFrom(src => src.UpdatedDate))
               .ForMember(x => x.Description, y => y.MapFrom(src => src.Description))
               .ForMember(x => x.IdAnnouncement, y => y.MapFrom(src => src.IdAnnouncement))
               .ForMember(x => x.Name, y => y.MapFrom(src => src.Name))
               .ForMember(x => x.Photo, y => y.MapFrom(src => src.Photo))
               .ReverseMap();
        }
    }
}
