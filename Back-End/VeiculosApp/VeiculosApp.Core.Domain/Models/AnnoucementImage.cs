namespace VeiculosApp.Core.Domain.Models
{
    public class AnnoucementImage : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public int? IdAnnouncement { get; set; }
        public Announcement Announcement { get; set; }
    }
}
