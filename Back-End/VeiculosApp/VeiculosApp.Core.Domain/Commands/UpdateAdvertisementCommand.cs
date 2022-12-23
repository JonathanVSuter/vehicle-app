using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{
    public class UpdateAdvertisementCommand : ICommand
    {
        public Advertisement Advertisement { get; set; }
        public UpdateAdvertisementCommand(Advertisement advertisement)
        {
            if (advertisement == null) throw new ArgumentNullException();
            if (advertisement.Id <= 0) throw new ArgumentOutOfRangeException($"{nameof(advertisement.Id)} could not be greater than zero.");
            if (advertisement.IdVehicle <= 0) throw new ArgumentOutOfRangeException($"{nameof(advertisement.IdVehicle)} could not be less or equal zero.");
            if (advertisement.IdUser <= 0) throw new ArgumentOutOfRangeException($"{nameof(advertisement.IdUser)} could not be less or equal zero.");
            if (advertisement.AnnouncedValue <= 0) throw new ArgumentOutOfRangeException($"{nameof(advertisement.AnnouncedValue)} could not be less or equal zero.");

            Advertisement = advertisement;
        }
    }
}
