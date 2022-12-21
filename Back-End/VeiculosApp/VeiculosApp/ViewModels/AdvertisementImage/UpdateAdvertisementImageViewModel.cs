using System.Collections.Generic;
using VeiculosApp.Core.Domain.Dtos;

namespace VeiculosApp.ViewModels.AdvertisementImage
{
    public class UpdateAdvertisementImageViewModel
    {
        public int Id { get; set;}
        public IList<AdvertisementImageDto> AnnouncementImages { get; set; }
    }
}
