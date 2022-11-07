namespace VeiculosApp.Core.Domain.Models
{
    public class VehicleImage : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public int? IdVehicle { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
