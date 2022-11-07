using System.Collections.Generic;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{
    public class SaveVehicleImageCommand : ICommand
    {
        public int IdVehicle { get; set; }
        public IList<VehicleImage> VehicleImages { get; set; }
        public SaveVehicleImageCommand(int idVehicle, IList<VehicleImage> vehicleImages)
        {
            IdVehicle = idVehicle;
            VehicleImages = vehicleImages;
        }
    }
}
