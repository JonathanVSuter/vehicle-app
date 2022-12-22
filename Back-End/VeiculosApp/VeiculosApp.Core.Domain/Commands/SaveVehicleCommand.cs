using System;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{
    public class SaveVehicleCommand : ICommand
    {
        public Vehicle Vehicle { get; set; }
        public SaveVehicleCommand(Vehicle vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException($"parameter {nameof(vehicle)} is null.");
            if (vehicle.Id > 0) throw new ArgumentOutOfRangeException($"parameter {nameof(vehicle)} could not be more than zero.");
            if (vehicle.Name == null) throw new ArgumentNullException($"parameter {nameof(vehicle.Name)} could not be null");
            if (vehicle.Name == string.Empty) throw new ArgumentException($"parameter {nameof(vehicle.Name)} could not be empty.");
            if (vehicle.Name == " ") throw new ArgumentException($"parameter {nameof(vehicle.Name)} could not be whitespace.");
            if (vehicle.Brand == null) throw new ArgumentNullException($"parameter {nameof(vehicle.Brand)} could not be null");
            if (vehicle.Brand == string.Empty) throw new ArgumentException($"parameter {nameof(vehicle.Brand)} could not be empty");
            if (vehicle.Brand == " ") throw new ArgumentException($"parameter {nameof(vehicle.Brand)} could not be whitespace");
            
            Vehicle = vehicle;
        }
    }
}

