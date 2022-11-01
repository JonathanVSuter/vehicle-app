using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Domain.Dtos
{
    public class AnnouncementImageDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; } 
        public bool IsPrincipal { get; set; }        
    }
}
