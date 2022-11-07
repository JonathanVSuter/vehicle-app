using System;
using System.Collections.Generic;

namespace VeiculosApp.Core.Domain.Models
{
    public class Vehicle : BaseModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public IList<Announcement> Announcements { get; set; }
        public IList<VehicleImage> VehicleImages { get; set; }

        public void UpdateVehicle(Vehicle vehicle)
        {
            Brand = vehicle.Brand;
            Name = vehicle.Name;
            UpdatedDate = DateTime.Now;
            IsActive = vehicle.IsActive;
        }
        public void Remove()
        {
            IsActive = false;
            UpdatedDate = DateTime.Now;
        }
    }
}
