using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;

namespace VeiculosApp.Core.Domain.Commands
{
    public class RemoveAdvertisementCommand : ICommand
    {
        public int Id { get; set; }
        public RemoveAdvertisementCommand(int id)
        {
            if(id<=0) throw new ArgumentOutOfRangeException($"Parameter {nameof(id)} could not be less or equal zero.");
            Id = id;
        }
    }
}
