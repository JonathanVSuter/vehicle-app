using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class RemoveVehicleCommandHandler : ICommandHandler<RemoveVehicleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IAnnouncementImageRepository _vehicleImageRepository;
        public RemoveVehicleCommandHandler(IVehicleRepository vehicleRepository, IAnnouncementImageRepository vehicleImageRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleImageRepository = vehicleImageRepository;
        }
        public void Handle(RemoveVehicleCommand command)
        {
            var vehicle = _vehicleRepository.GetById(command.Id);
            if (vehicle == null) throw new NotFoundVehicleException($"There's no vehicle registered with {command.Id}");
            
            vehicle.Remove();
            _vehicleRepository.Update(vehicle);           
        }
    }
}
