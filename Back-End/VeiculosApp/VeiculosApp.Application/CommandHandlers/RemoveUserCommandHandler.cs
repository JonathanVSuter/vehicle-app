using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.CommandHandlers
{
    public class RemoveUserCommandHandler : ICommandHandler<RemoveUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(RemoveUserCommand command)
        {
            var user = _userRepository.GetById(command.IdUser);

            if (user == null) throw new NotFoundUserException($"There's no user with Id = {command.IdUser}");

            user.Remove();
            _userRepository.Remove(user);
        }
    }
}
