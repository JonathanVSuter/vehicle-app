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
    public class SaveAnnouncementCommandHandler : ICommandHandler<SaveAdvertisementCommand>
    {
        private readonly IAdvertisementRepository _announcementRepository;
        private readonly IAdvertisementImageRepository _announcementImageRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;

        public SaveAnnouncementCommandHandler(IAdvertisementRepository announcementRepository, IAdvertisementImageRepository announcementImageRepository, IVehicleRepository vehicleRepository, IUserRepository userRepository)
        {
            _announcementRepository = announcementRepository;
            _announcementImageRepository = announcementImageRepository;
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
        }

        public void Handle(SaveAdvertisementCommand command)
        {            
            var vehicle = _vehicleRepository.GetById(command.Advertisement.IdVehicle);

            if (vehicle == null) throw new NotFoundVehicleException($"There's no Vehicle with Id = {command.Advertisement.IdVehicle}");

            var user = _userRepository.GetById(command.Advertisement.IdUser);

            if (user == null) throw new NotFoundUserException($"There's no User with Id = {command.Advertisement.IdUser}");

            _announcementRepository.Save(command.Advertisement);            
        }
    }
}
