using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class UpdateAnnouncementCommandHandler : ICommandHandler<UpdateAnnouncementCommand>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IAnnouncementImageRepository _announcementImageRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;

        public UpdateAnnouncementCommandHandler(IAnnouncementRepository announcementRepository, IAnnouncementImageRepository announcementImageRepository, IVehicleRepository vehicleRepository, IUserRepository userRepository)
        {
            _announcementRepository = announcementRepository;
            _announcementImageRepository = announcementImageRepository;
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
        }

        public void Handle(UpdateAnnouncementCommand command)
        {
            var announcement = _announcementRepository.GetById(command.Announcement.Id);
            if (announcement == null) throw new NotFoundAnnoucementException($"There's no Announcement with Id = {command.Announcement.Id}");

            var vehicle = _vehicleRepository.GetById(command.Announcement.IdVehicle);

            if (vehicle == null) throw new NotFoundVehicleException($"There's no Vehicle with Id = {command.Announcement.IdVehicle}");

            announcement.Vehicle = vehicle;

            var images = _announcementImageRepository.GetAllAnnoucementImagesByAnnoucementId(command.Announcement.Id);

            var user = _userRepository.GetById(command.Announcement.IdUser);

            if (user == null) throw new NotFoundUserException($"There's no User with Id = {command.Announcement.IdUser}");

            announcement.User = user;

            if(images == null)
            {
                announcement.Images = new List<AnnouncementImage>();
                foreach (var image in command.Announcement.Images)
                {
                    if(image.Id <= 0) 
                        _announcementImageRepository.Save(image);
                    announcement.Images.Add(image);
                }
            }
            else
            {
                var imagesToRemove = command.Announcement.Images.Where(x=> announcement.Images.All(y=> y.Id != x.Id));
                foreach(var image in imagesToRemove) 
                {
                    _announcementImageRepository.Remove(image);
                }

                var imagesToAdd = announcement.Images.Where(x => announcement.Images.All(y => y.Id != x.Id));
                foreach(var image in imagesToAdd)
                {
                    _announcementImageRepository.Save(image);
                    announcement.Images.Add(image);
                }
            }
            _announcementRepository.Save(announcement);
        }
    }
}
