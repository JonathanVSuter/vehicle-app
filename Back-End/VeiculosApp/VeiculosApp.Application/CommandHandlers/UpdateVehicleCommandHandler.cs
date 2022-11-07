using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class UpdateVehicleCommandHandler : ICommandHandler<UpdateVehicleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void Handle(UpdateVehicleCommand command)
        {
            var vehicle = _vehicleRepository.GetById(command.Vehicle.Id);

            if (vehicle == null) throw new NotFoundVehicleException($"There's no vehicle registed with {command.Vehicle.Id}");

            vehicle.UpdateVehicle(command.Vehicle);

            _vehicleRepository.Update(vehicle);
        }
    }
}
