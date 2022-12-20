using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class SaveVehicleCommandHandler : ICommandHandlerWithResult<SaveVehicleCommand, Vehicle>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IAdvertisementImageRepository _vehicleImageRepository;

        public SaveVehicleCommandHandler(IVehicleRepository vehicleRepository, IAdvertisementImageRepository vehicleImageRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleImageRepository = vehicleImageRepository;
        }

        public Vehicle Handle(SaveVehicleCommand command)
        {
            var result = _vehicleRepository.Save(command.Vehicle);

            return result;
        }
    }
}
