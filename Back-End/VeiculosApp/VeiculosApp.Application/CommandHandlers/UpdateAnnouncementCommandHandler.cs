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

        public UpdateAnnouncementCommandHandler(IAnnouncementRepository announcementRepository, IAnnouncementImageRepository announcementImageRepository, IVehicleRepository vehicleRepository)
        {
            _announcementRepository = announcementRepository;
            _announcementImageRepository = announcementImageRepository;
            _vehicleRepository = vehicleRepository;
        }

        public void Handle(UpdateAnnouncementCommand command)
        {
            var announcement = _announcementRepository.GetById(command.Announcement.Id);
            if (announcement == null) throw new NotFoundAnnoucementException($"There's no Announcement with Id = {command.Announcement.Id}");

            var vehicle = _vehicleRepository.GetById(command.Announcement.IdVehicle);

            //continue annoucement's data validation.

            var images = _announcementImageRepository.GetAllAnnoucementImagesByAnnoucementId(command.Announcement.Id);

            if(images == null)
            {
                announcement.AnnouncementImages = new List<AnnouncementImage>();
                foreach (var image in command.Announcement.AnnouncementImages)
                {
                    if(image.Id <= 0) 
                        _announcementImageRepository.Save(image);
                    announcement.AnnouncementImages.Add(image);
                }
            }
            else
            {
                var imagesToRemove = command.Announcement.AnnouncementImages.Where(x=> announcement.AnnouncementImages.All(y=> y.Id != x.Id));
                foreach(var image in imagesToRemove) 
                {
                    _announcementImageRepository.Remove(image);
                }

                var imagesToAdd = announcement.AnnouncementImages.Where(x => announcement.AnnouncementImages.All(y => y.Id != x.Id));
                foreach(var image in imagesToAdd)
                {
                    _announcementImageRepository.Save(image);
                    announcement.AnnouncementImages.Add(image);
                }
            }
        }
    }
}
