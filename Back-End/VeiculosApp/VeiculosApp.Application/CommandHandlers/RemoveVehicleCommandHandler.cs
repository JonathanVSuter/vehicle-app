using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class RemoveVehicleCommandHandler : ICommandHandler<RemoveVehicleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleImageRepository _vehicleImageRepository;
        public RemoveVehicleCommandHandler(IVehicleRepository vehicleRepository, IVehicleImageRepository vehicleImageRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleImageRepository = vehicleImageRepository;
        }
        public void Handle(RemoveVehicleCommand command)
        {
            var vehicle = _vehicleRepository.GetById(command.Id);

            if(vehicle == null) throw new NotFoundVehicleException($"There's no vehicle registed with {command.Id}");

            var images = _vehicleImageRepository.GetAllVehicleImages(command.Id);

            foreach (var image in images) 
            {
                _vehicleImageRepository.Remove(image);
            }

            _vehicleRepository.Remove(vehicle);
        }
    }
}
