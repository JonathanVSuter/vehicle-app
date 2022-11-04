using VeiculosApp.Core.Domain.Mapping;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Dtos
{
    public class VehicleImageDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; } 
        public bool IsPrincipal { get; set; }  
        public int? IdVehicle { get; set; }
    }
}
