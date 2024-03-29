﻿using System.Collections.Generic;

namespace VeiculosApp.Core.Domain.Models
{
    public class Advertisement : BaseModel
    {
        public int IdVehicle { get; set; }
        public Vehicle Vehicle { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public double AnnouncedValue { get; set; }
        public IList<AdvertisementImage> Images { get; set; }        
    }
}
