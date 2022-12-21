using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class UpdateAdvertisementImageCommandHandler : ICommandHandler<UpdateAdvertisementImageCommand>
    {        
        public readonly IAdvertisementImageRepository _advertisementImageRepository;

        public void Handle(UpdateAdvertisementImageCommand command)
        {
            foreach (var item in command.AdvertisementImages) 
            {
                var annoucementImage = _advertisementImageRepository.GetById(item.Id);

                if (annoucementImage == null) throw new NotFoundAnnoucementImageException($"There's no image with id = {item.Id}");

                item.UpdateImage(annoucementImage);

                _advertisementImageRepository.Update(item);
            }
        }
    }
}
