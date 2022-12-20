using System.Collections.Generic;
using VeiculosApp.Core.Domain.Dtos;

namespace VeiculosApp.ViewModels.AnnouncementImage
{
    public class UpdateAnnouncementImageViewModel
    {
        public int Id { get; set;}
        public IList<AdvertisementImageDto> AnnouncementImages { get; set; }
    }
}
