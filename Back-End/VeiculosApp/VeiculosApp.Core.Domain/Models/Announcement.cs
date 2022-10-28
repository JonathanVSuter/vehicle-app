namespace VeiculosApp.Core.Domain.Models
{
    public class Announcement : IModel
    {
        public int Id { get; set; }
        public int IdVehicle { get; set; }
        public Vehicle Vehicle { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public double AnnouncedValue { get; set; }
    }
}
