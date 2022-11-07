using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class AddVehicleCommandHandler : ICommandHandlerWithResult<SaveVehicleCommand, Vehicle>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleImageRepository _vehicleImageRepository;

        public AddVehicleCommandHandler(IVehicleRepository vehicleRepository, IVehicleImageRepository vehicleImageRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleImageRepository = vehicleImageRepository;
        }

        public Vehicle Handle(SaveVehicleCommand command)
        {
            var result = _vehicleRepository.Add(command.Vehicle);

            return result;
        }
    }
}
