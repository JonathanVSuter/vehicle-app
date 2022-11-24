using System;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{
    public class UpdateUserCommand : ICommand
    {
        public User User { get; set; }
        public UpdateUserCommand(User user)
        {
            if (user.Id <= 0) throw new ArgumentOutOfRangeException($"UserId could not be less or equal zero.");
            if (user.Name == string.Empty) throw new ArgumentException($"User name could not be empty.");
            if (user.Name == null) throw new ArgumentNullException($"User name could not be null.");
            if (user.Name == " ") throw new ArgumentException($"User name could not be whitespace.");
            if (user.Email == string.Empty) throw new ArgumentException($"User e-mail could not be empty.");
            if (user.Email == null) throw new ArgumentNullException($"User e-mail could not be null.");
            if (user.Email == " ") throw new ArgumentException($"User e-mail could not be whitespace.");

            User = user;
        }
    }
}
