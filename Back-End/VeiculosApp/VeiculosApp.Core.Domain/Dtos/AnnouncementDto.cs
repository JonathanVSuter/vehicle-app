using System.Collections.Generic;

namespace VeiculosApp.Core.Domain.Dtos
{
    public class AnnouncementDto : BaseDto
    {
        public VehicleDto Vehicle { get; set; }        
        public UserDto User { get; set; }        
        public double AnnouncedValue { get; set; }
        public int IdUser { get; set; }
        public int IdVehicle { get; set; }
        public IList<AnnouncementImageDto> Images { get; set; }
    }
}
