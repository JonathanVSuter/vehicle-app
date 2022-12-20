using System.Collections.Generic;
using VeiculosApp.Core.Domain.Dtos;

namespace VeiculosApp.ViewModels.Vehicle
{
    public class SaveVehicleViewModel
    {
        public VehicleDto Vehicle { get; set; }
        public IList<AdvertisementImageDto> VehicleImages { get; set; }
    }
}
