using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Domain.Dtos
{
    public class AnnouncementDto : BaseDto
    {        
        public VehicleDto Vehicle { get; set; }        
        public UserDto IdUser { get; set; }        
        public double AnnouncedValue { get; set; }
        public IList<AnnouncementImageDto> AnnouncementImages { get; set; }
    }
}
