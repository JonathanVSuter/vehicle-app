using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class RemoveAdvertisementImageCommandHandler : ICommandHandler<RemoveAdvertisementImageCommand>
    {
        private readonly IAdvertisementImageRepository _advertisementImageRepository;

        public RemoveAdvertisementImageCommandHandler(IAdvertisementImageRepository announcementImageRepository)
        {
            _advertisementImageRepository = announcementImageRepository;
        }

        public void Handle(RemoveAdvertisementImageCommand command)
        {
            var image = _advertisementImageRepository.GetById(command.Id);

            if (image == null) throw new NotFoundAnnoucementImageException($"There's no announcement image with Id ={command.Id}");

            _advertisementImageRepository.Remove(image);
        }
    }
}
