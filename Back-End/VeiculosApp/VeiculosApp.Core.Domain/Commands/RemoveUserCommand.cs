using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{
    public class RemoveUserCommand: ICommand
    {
        public int IdUser { get; set; }
        public RemoveUserCommand(int idUser)
        {
            if (idUser <= 0) throw new ArgumentOutOfRangeException($"Parameter {nameof(idUser)} could not be less or equal zero.");

            IdUser = idUser;
        }
    }
}
