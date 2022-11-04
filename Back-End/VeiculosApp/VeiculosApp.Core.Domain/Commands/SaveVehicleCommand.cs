using System;
using System.Collections.Generic;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{
    public class SaveVehicleCommand : ICommand
    {
        public Vehicle Vehicle { get; set; }        
        public SaveVehicleCommand(Vehicle vehicle) 
        {
            if (vehicle == null) throw new ArgumentNullException($"parameter {nameof(vehicle)} is null");
            if (string.IsNullOrWhiteSpace(vehicle.Name)) throw new ArgumentNullException($"parameter {nameof(vehicle.Name)} is null or whitespace");
            if (string.IsNullOrWhiteSpace(vehicle.Brand)) throw new ArgumentNullException($"parameter {nameof(vehicle.Brand)} is null or whitespace");
            if (string.IsNullOrWhiteSpace(vehicle.Name)) throw new ArgumentNullException($"parameter {nameof(vehicle.Name)} is null or empty");
            if (string.IsNullOrEmpty(vehicle.Brand)) throw new ArgumentNullException($"parameter {nameof(vehicle.Brand)} is null or empty");

            Vehicle = vehicle;
        }        
    }
}
