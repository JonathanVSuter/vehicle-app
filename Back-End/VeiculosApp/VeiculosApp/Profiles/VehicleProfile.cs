using AutoMapper;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
                .ForMember(x => x.Brand, y => y.MapFrom(src => src.Brand))
                .ForMember(x => x.Name, y => y.MapFrom(src => src.Name))
                .ForMember(x => x.UpdatedDate, y => y.MapFrom(src => src.UpdatedDate))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(src => src.CreatedDate))
                //.ForMember(x => x.VehicleImages, y => y.MapFrom(src => src.VehicleImages))
                .ForMember(x => x.IsActive, y => y.MapFrom(src => src.IsActive))
                .ReverseMap();
        }
    }
}
