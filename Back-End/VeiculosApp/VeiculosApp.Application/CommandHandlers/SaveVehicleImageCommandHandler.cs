using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class SaveVehicleImageCommandHandler : ICommandHandler<SaveVehicleImageCommand>
    {
        public readonly IVehicleRepository _vehicleRepository;
        public readonly IVehicleImageRepository _vehicleImageRepository;

        public SaveVehicleImageCommandHandler(IVehicleRepository vehicleRepository, IVehicleImageRepository vehicleImageRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleImageRepository = vehicleImageRepository;
        }

        public void Handle(SaveVehicleImageCommand command)
        {
            var vehicle = _vehicleRepository.GetById(command.IdVehicle);

            if (vehicle == null)
                throw new NotFoundVehicleException($"There's no vehicle registed with {command.IdVehicle}");

            foreach (var image in command.VehicleImages) 
            {
                image.IdVehicle = command.IdVehicle;
                _vehicleImageRepository.Add(image);
            }
        }
    }
}
