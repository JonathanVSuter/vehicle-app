using System.Collections.Generic;

namespace VeiculosApp.Core.Domain.Models
{
    public class Vehicle : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public byte[] Photo { get; set; }
        public IList<Announcement> Announcement { get; set; }
    }
}
