using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;

namespace VeiculosApp.Core.Domain.Commands
{
    public class RemoveVehicleCommand : ICommand
    {
        public int Id { get; set; }
        public RemoveVehicleCommand(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException($"parameter {nameof(id)} not valid.");
            Id = id;
        }
    }
}
