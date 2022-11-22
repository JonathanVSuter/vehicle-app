using System.Collections.Generic;

namespace VeiculosApp.Core.Domain.Models
{
    public class Announcement : BaseModel
    {
        public int IdVehicle { get; set; }
        public Vehicle Vehicle { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public double AnnouncedValue { get; set; }
        public IList<AnnoucementImage> AnnouncementImages { get; set; }
    }
}
