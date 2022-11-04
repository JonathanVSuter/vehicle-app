using System.Collections.Generic;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Mapping;

namespace VeiculosApp.Core.Domain.Models
{
    public class Vehicle : BaseModel
    {       
        public string Name { get; set; }
        public string Brand { get; set; }        
        public IList<Announcement> Announcements { get; set; }
        public IList<VehicleImage> VehicleImages { get; set; }
    }
}
