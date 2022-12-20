using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class SaveAnnoucementImageCommandHandler : ICommandHandler<SaveAdvertisementImageCommand>
    {
        public readonly IAdvertisementRepository _announcementRepository;
        public readonly IAdvertisementImageRepository _announcementImageRepository;

        public SaveAnnoucementImageCommandHandler(IAdvertisementRepository announcementRepository, IAdvertisementImageRepository vehicleImageRepository)
        {
            _announcementRepository = announcementRepository;
            _announcementImageRepository = vehicleImageRepository;
        }

        public void Handle(SaveAdvertisementImageCommand command)
        {            
            foreach (var image in command.AdvertisementImages)
            {
                var announcement = _announcementRepository.GetById(image.IdAdvertisement);

                if (announcement == null) throw new NotFoundAnnoucementException($"No announcement founded with informed Id: {image.IdAdvertisement}");
                
                _announcementImageRepository.Save(image);
            }
        }
    }
}
