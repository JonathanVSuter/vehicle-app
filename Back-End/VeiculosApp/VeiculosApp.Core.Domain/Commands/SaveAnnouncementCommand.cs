using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{
    public class SaveAnnouncementCommand : ICommand
    {
        public Announcement Announcement { get; set; }
        public SaveAnnouncementCommand(Announcement announcement)
        {
            Announcement = announcement;
        }
    }
}
