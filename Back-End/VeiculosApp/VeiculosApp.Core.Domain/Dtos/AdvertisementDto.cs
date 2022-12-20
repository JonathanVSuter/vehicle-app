using System.Collections.Generic;

namespace VeiculosApp.Core.Domain.Dtos
{
    public class AdvertisementDto : BaseDto
    {        
        public double AnnouncedValue { get; set; }
        public int IdUser { get; set; }
        public int IdVehicle { get; set; }
        public IList<AdvertisementImageDto> Images { get; set; }
    }
}
