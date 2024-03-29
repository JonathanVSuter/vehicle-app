﻿using System;

namespace VeiculosApp.Core.Domain.Models
{
    public class BaseModel : IModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public void Remove() 
        {
            IsActive = false;
            UpdatedDate = DateTime.Now;
        }
    }
}
