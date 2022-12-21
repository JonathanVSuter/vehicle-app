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
    public class UpdateAdvertisementCommandHandler : ICommandHandler<UpdateAdvertisementCommand>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IAdvertisementImageRepository _advertisementImageRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;

        public UpdateAdvertisementCommandHandler(IAdvertisementRepository advertisementRepository, IAdvertisementImageRepository advertisementImageRepository, IVehicleRepository vehicleRepository, IUserRepository userRepository)
        {
            _advertisementRepository = advertisementRepository;
            _advertisementImageRepository = advertisementImageRepository;
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
        }

        public void Handle(UpdateAdvertisementCommand command)
        {
            var announcement = _advertisementRepository.GetById(command.Advertisement.Id);
            if (announcement == null) throw new NotFoundAdvertisementException($"There's no Announcement with Id = {command.Advertisement.Id}");

            var vehicle = _vehicleRepository.GetById(command.Advertisement.IdVehicle);

            if (vehicle == null) throw new NotFoundVehicleException($"There's no Vehicle with Id = {command.Advertisement.IdVehicle}");

            announcement.Vehicle = vehicle;

            var images = _advertisementImageRepository.GetAllAdvertisementImagesByAdvertisementId(command.Advertisement.Id);

            var user = _userRepository.GetById(command.Advertisement.IdUser);

            if (user == null) throw new NotFoundUserException($"There's no User with Id = {command.Advertisement.IdUser}");

            announcement.User = user;

            if(images == null)
            {
                announcement.Images = new List<AdvertisementImage>();
                foreach (var image in command.Advertisement.Images)
                {
                    if(image.Id <= 0) 
                        _advertisementImageRepository.Save(image);
                    announcement.Images.Add(image);
                }
            }
            else
            {
                var imagesToRemove = command.Advertisement.Images.Where(x=> announcement.Images.All(y=> y.Id != x.Id));
                foreach(var image in imagesToRemove) 
                {
                    _advertisementImageRepository.Remove(image);
                }

                var imagesToAdd = announcement.Images.Where(x => announcement.Images.All(y => y.Id != x.Id));
                foreach(var image in imagesToAdd)
                {
                    _advertisementImageRepository.Save(image);
                    announcement.Images.Add(image);
                }
            }
            _advertisementRepository.Save(announcement);
        }
    }
}
