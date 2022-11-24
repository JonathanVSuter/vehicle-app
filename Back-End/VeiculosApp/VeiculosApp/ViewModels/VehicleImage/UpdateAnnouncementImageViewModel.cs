using System.Collections.Generic;
using VeiculosApp.Core.Domain.Dtos;

namespace VeiculosApp.ViewModels.VehicleImage
{
    public class UpdateAnnouncementImageViewModel
    {
        public int Id { get; set;}
        public IList<AnnouncementImageDto> AnnouncementImages { get; set; }
    }
}
