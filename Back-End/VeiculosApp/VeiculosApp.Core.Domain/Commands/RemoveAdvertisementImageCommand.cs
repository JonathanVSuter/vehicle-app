﻿using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;

namespace VeiculosApp.Core.Domain.Commands
{
    public class RemoveAdvertisementImageCommand : ICommand
    {
        public int Id { get; set; }
        public RemoveAdvertisementImageCommand(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException($"");
            Id = id;
        }
    }
}
