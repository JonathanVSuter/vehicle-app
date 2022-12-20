using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class RemoveAnnouncementCommandHandler : ICommandHandler<RemoveAdvertisementCommand>
    {
        private readonly IAdvertisementRepository _announcementRepository;

        public RemoveAnnouncementCommandHandler(IAdvertisementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public void Handle(RemoveAdvertisementCommand command)
        {
            var annoucement = _announcementRepository.GetById(command.Id);
            if (annoucement == null) throw new NotFoundAnnoucementException($"There's no annoucement with Id = {command.Id}");
            _announcementRepository.Remove(annoucement);
        }
    }
}
