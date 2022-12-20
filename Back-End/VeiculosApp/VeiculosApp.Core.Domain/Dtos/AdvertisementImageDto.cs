namespace VeiculosApp.Core.Domain.Dtos
{
    public class AdvertisementImageDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public bool IsPrincipal { get; set; }
        public int IdAdvertisement { get; set; }
    }
}
