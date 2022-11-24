using System;

namespace VeiculosApp.Core.Domain.Models
{
    public class AnnouncementImage : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public int IdAnnouncement { get; set; }
        public Announcement Announcement { get; set; }

        public void UpdateImage(AnnouncementImage announcementImage) 
        {
            Name = announcementImage.Name;
            Description = announcementImage.Description;
            Photo = announcementImage.Photo;
            UpdatedDate = DateTime.Now;
        }
    }
}
