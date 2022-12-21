using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace VeiculosApp.Core.Domain.Models
{
    public class User : IdentityUser<int>, IModel
    {
        public override string UserName { get { return Name; } }
        public string Name { get; set; }        
        public string Password { get; set; }
        public string Role { get; set; }
        public IList<Advertisement> Advertisements { get; set; }
        public DateTime CreatedDate { get ; set ; }
        public DateTime UpdatedDate { get; set ; }
        public bool IsActive { get; set; }
        public void Remove()
        {
            IsActive = false;
            UpdatedDate = DateTime.Now;
        }
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
