using System.Collections.Generic;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Mapping;

namespace VeiculosApp.Core.Domain.Models
{
    public class User : BaseModel
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public IList<Announcement> Announcements { get; set; }
    }
}
