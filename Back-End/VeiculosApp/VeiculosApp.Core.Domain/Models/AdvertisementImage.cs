using System;

namespace VeiculosApp.Core.Domain.Models
{
    public class AdvertisementImage : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public int IdAdvertisement { get; set; }
        public Advertisement Advertisement { get; set; }

        public void UpdateImage(AdvertisementImage announcementImage) 
        {
            Name = announcementImage.Name;
            Description = announcementImage.Description;
            Photo = announcementImage.Photo;
            UpdatedDate = DateTime.Now;
        }
    }
}
