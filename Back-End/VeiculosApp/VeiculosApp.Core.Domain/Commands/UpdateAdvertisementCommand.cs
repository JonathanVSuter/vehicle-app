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
            Advertisement = advertisement;
        }
    }
}
