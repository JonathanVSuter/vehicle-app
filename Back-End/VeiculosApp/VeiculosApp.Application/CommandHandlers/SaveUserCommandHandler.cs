using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Web.Mvc;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Application.CommandHandlers
{
    public class SaveUserCommandHandler : ICommandHandlerAsync<SaveUserCommand>
    {        
        private readonly UserManager<User> _userManager;   
        public SaveUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;            
        }
        public async Task HandleAsync(SaveUserCommand command)
        {
            var user = await _userManager.FindByEmailAsync(command.User.Email).ConfigureAwait(true);

            if (user != null) throw new EmailInUseException($"This e-mail is already in use by other user.");

            await _userManager.CreateAsync(command.User, command.User.Password).ConfigureAwait(true);
        }
    }
}
