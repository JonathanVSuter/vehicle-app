using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class RemoveAnnouncementImageCommandHandler : ICommandHandler<RemoveAdvertisementImageCommand>
    {
        private readonly IAdvertisementImageRepository _announcementImageRepository;

        public RemoveAnnouncementImageCommandHandler(IAdvertisementImageRepository announcementImageRepository)
        {
            _announcementImageRepository = announcementImageRepository;
        }

        public void Handle(RemoveAdvertisementImageCommand command)
        {
            var image = _announcementImageRepository.GetById(command.Id);

            if (image == null) throw new NotFoundAnnoucementImageException($"There's no announcement image with Id ={command.Id}");

            _announcementImageRepository.Remove(image);
        }
    }
}
