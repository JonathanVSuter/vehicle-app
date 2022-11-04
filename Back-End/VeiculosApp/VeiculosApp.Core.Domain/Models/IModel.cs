using System;

namespace VeiculosApp.Core.Domain.Models
{
    public interface IModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
