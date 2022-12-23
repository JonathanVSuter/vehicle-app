using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Commands
{
    public class SaveUserCommand : ICommand
    {
        public User User { get; set; }
        public SaveUserCommand(User user)
        {
            if (user == null) throw new ArgumentNullException($"{nameof(user)} object could not be null.");
            if (user.Id > 0) throw new ArgumentOutOfRangeException($"{nameof(user.Id)} could not be greater than zero.");
            if (user.Name == string.Empty) throw new ArgumentException($"{nameof(user.Name)} could not be empty.");
            if (user.Name == null) throw new ArgumentNullException($"{nameof(user.Name)} could not be null.");
            if (user.Name == " ") throw new ArgumentException($"{nameof(user.Name)} could not be whitespace.");
            if (user.Email == string.Empty) throw new ArgumentException($"{nameof(user.Email)} could not be empty.");
            if (user.Email == null) throw new ArgumentNullException($"{nameof(user.Email)} could not be null.");
            if (user.Email == " ") throw new ArgumentException($"{nameof(user.Email)} could not be whitespace.");
            if (user.Password == string.Empty) throw new ArgumentException($"{nameof(user.Password)} could not be empty.");
            if (user.Password == null) throw new ArgumentNullException($"{nameof(user.Password)} could not be null.");
            if (user.Password == " ") throw new ArgumentException($"{nameof(user.Password)} could not be whitespace.");            

            User = user;
        }
    }
}
