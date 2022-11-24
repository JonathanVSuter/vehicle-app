using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class RemoveAnnouncementImageCommandHandler : ICommandHandler<RemoveAnnouncementImageCommand>
    {
        private readonly IAnnouncementImageRepository _announcementImageRepository;

        public RemoveAnnouncementImageCommandHandler(IAnnouncementImageRepository announcementImageRepository)
        {
            _announcementImageRepository = announcementImageRepository;
        }

        public void Handle(RemoveAnnouncementImageCommand command)
        {
            var image = _announcementImageRepository.GetById(command.Id);

            if (image == null) throw new NotFoundAnnoucementImageException($"There's no announcement image with Id ={command.Id}");

            _announcementImageRepository.Remove(image);
        }
    }
}
