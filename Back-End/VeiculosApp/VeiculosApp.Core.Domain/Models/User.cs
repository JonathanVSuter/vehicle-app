using System;
using System.Collections.Generic;

namespace VeiculosApp.Core.Domain.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public IList<Announcement> Announcements { get; set; }
        public void Update(User user) 
        {
            Name = user.Name;
            Email = user.Email;
            Role = user.Role;
            Password = user.Password;
            UpdatedDate = DateTime.Now;
        }
    }
}
