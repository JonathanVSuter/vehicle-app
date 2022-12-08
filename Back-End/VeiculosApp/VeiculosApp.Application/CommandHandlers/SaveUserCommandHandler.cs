using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class SaveUserCommandHandler : ICommandHandler<SaveUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public SaveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(SaveUserCommand command)
        {
            var user = _userRepository.GetUserByEmail(command.User.Email);
            if (user != null) throw new EmailInUseException($"This e-mail is already in use by other user.");

            _userRepository.Save(command.User);
        }
    }
}
