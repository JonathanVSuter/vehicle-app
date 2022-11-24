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
            if (string.IsNullOrWhiteSpace(vehicle.Name)) throw new ArgumentNullException($"parameter {nameof(vehicle.Name)} could not be null or empty.");
            if (string.IsNullOrWhiteSpace(vehicle.Brand)) throw new ArgumentNullException($"parameter {nameof(vehicle.Brand)} could not be null or whitespace.");
            if (string.IsNullOrWhiteSpace(vehicle.Name)) throw new ArgumentNullException($"parameter {nameof(vehicle.Name)} could not be null or empty.");
            if (string.IsNullOrEmpty(vehicle.Brand)) throw new ArgumentNullException($"parameter {nameof(vehicle.Brand)} could not be null or empty.");

            Vehicle = vehicle;
        }
    }
}
