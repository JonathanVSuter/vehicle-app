using VeiculosApp.Core.Domain.Mapping;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Dtos
{
    public class AnnouncementDto : BaseDto
    {        
        //public VehicleDto Vehicle { get; set; }        
        //public UserDto User { get; set; }        
        public double AnnouncedValue { get; set; }    
        public int IdUser { get; set; }
        public int IdVehicle { get; set; }
    }
}
