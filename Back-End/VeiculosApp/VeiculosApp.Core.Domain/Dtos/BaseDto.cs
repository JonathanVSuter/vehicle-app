using System;

namespace VeiculosApp.Core.Domain.Dtos
{
    public class BaseDto : IDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
