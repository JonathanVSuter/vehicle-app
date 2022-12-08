using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class SaveAnnoucementImageCommandHandler : ICommandHandler<SaveAnnouncementImageCommand>
    {
        public readonly IAnnouncementRepository _announcementRepository;
        public readonly IAnnouncementImageRepository _announcementImageRepository;

        public SaveAnnoucementImageCommandHandler(IAnnouncementRepository announcementRepository, IAnnouncementImageRepository vehicleImageRepository)
        {
            _announcementRepository = announcementRepository;
            _announcementImageRepository = vehicleImageRepository;
        }

        public void Handle(SaveAnnouncementImageCommand command)
        {            
            foreach (var image in command.AnnouncementImages)
            {
                var announcement = _announcementRepository.GetById(image.IdAnnouncement);

                if (announcement == null) throw new NotFoundAnnoucementException($"No announcement founded with informed Id: {image.IdAnnouncement}");
                
                _announcementImageRepository.Save(image);
            }
        }
    }
}
