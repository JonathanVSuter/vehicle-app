using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Mapping;

namespace VeiculosApp.Core.Domain.Models
{
    public class VehicleImage : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; } 
        public int? IdVehicle { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
