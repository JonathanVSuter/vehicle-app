using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;

namespace VeiculosApp.Core.Domain.Commands
{
    public class RemoveAnnouncementImageCommand : ICommand
    {
        public int Id { get; set; }
        public RemoveAnnouncementImageCommand(int id)
        {
            if (id <= 0) throw new ArgumentException();
            Id = id;
        }
    }
}
