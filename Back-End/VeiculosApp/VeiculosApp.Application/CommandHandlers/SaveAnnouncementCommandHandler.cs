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
    public class SaveAnnouncementCommandHandler : ICommandHandler<SaveAnnouncementCommand>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IAnnouncementImageRepository _announcementImageRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;

        public SaveAnnouncementCommandHandler(IAnnouncementRepository announcementRepository, IAnnouncementImageRepository announcementImageRepository, IVehicleRepository vehicleRepository, IUserRepository userRepository)
        {
            _announcementRepository = announcementRepository;
            _announcementImageRepository = announcementImageRepository;
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
        }

        public void Handle(SaveAnnouncementCommand command)
        {            
            var vehicle = _vehicleRepository.GetById(command.Announcement.IdVehicle);

            if (vehicle == null) throw new NotFoundVehicleException($"There's no Vehicle with Id = {command.Announcement.IdVehicle}");

            var user = _userRepository.GetById(command.Announcement.IdUser);

            if (user == null) throw new NotFoundUserException($"There's no User with Id = {command.Announcement.IdUser}");

            _announcementRepository.Save(command.Announcement);            
        }
    }
}
