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
    public class SaveAdvertisementCommandHandler : ICommandHandler<SaveAdvertisementCommand>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IAdvertisementImageRepository _advertisementImageRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;

        public SaveAdvertisementCommandHandler(IAdvertisementRepository advertisementRepository, IAdvertisementImageRepository advertisementImageRepository, IVehicleRepository vehicleRepository, IUserRepository userRepository)
        {
            _advertisementRepository = advertisementRepository;
            _advertisementImageRepository = advertisementImageRepository;
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
        }

        public void Handle(SaveAdvertisementCommand command)
        {            
            var vehicle = _vehicleRepository.GetById(command.Advertisement.IdVehicle);

            if (vehicle == null) throw new NotFoundVehicleException($"There's no Vehicle with Id = {command.Advertisement.IdVehicle}");

            var user = _userRepository.GetById(command.Advertisement.IdUser);

            if (user == null) throw new NotFoundUserException($"There's no User with Id = {command.Advertisement.IdUser}");

            _advertisementRepository.Save(command.Advertisement);            
        }
    }
}
