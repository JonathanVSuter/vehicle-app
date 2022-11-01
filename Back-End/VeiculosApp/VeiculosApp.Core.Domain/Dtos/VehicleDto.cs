using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Domain.Dtos
{
    public class VehicleDto : BaseDto
    {        
        public string Name { get; set; }
        public string Brand { get; set; }   
        public IList<VehicleImageDto> VehicleImages { get; set; }
    }
}
