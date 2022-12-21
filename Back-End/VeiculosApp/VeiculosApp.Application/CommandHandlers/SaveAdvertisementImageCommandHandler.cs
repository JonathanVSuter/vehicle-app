using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class SaveAdvertisementImageCommandHandler : ICommandHandler<SaveAdvertisementImageCommand>
    {
        public readonly IAdvertisementRepository _advertisementRepository;
        public readonly IAdvertisementImageRepository _advertisementImageRepository;

        public SaveAdvertisementImageCommandHandler(IAdvertisementRepository announcementRepository, IAdvertisementImageRepository vehicleImageRepository)
        {
            _advertisementRepository = announcementRepository;
            _advertisementImageRepository = vehicleImageRepository;
        }

        public void Handle(SaveAdvertisementImageCommand command)
        {            
            foreach (var image in command.AdvertisementImages)
            {
                var announcement = _advertisementRepository.GetById(image.IdAdvertisement);

                if (announcement == null) throw new NotFoundAdvertisementException($"No announcement founded with informed Id: {image.IdAdvertisement}");
                
                _advertisementImageRepository.Save(image);
            }
        }
    }
}
