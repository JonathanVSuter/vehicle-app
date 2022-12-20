using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{
    public class SaveAdvertisementCommand : ICommand
    {
        public Advertisement Advertisement { get; set; }
        public SaveAdvertisementCommand(Advertisement advertisement)
        {
            Advertisement = advertisement;
        }
    }
}
