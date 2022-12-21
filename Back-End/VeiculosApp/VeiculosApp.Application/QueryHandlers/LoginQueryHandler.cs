using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;
using VeiculosApp.Core.Domain.Services;

namespace VeiculosApp.Application.QueryHandlers
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, Task<LoginSucessDto>>
    {        
        private readonly ITokenService _tokenService;                
        private readonly UserManager<User> _userManager;

        public LoginQueryHandler(ITokenService tokenService, UserManager<User> userManager)
        {            
            _tokenService = tokenService;            
            _userManager = userManager;
        }

        public async Task<LoginSucessDto> Execute(LoginQuery query)
        {
            var user = await _userManager.FindByEmailAsync(query.Email).ConfigureAwait(true);

            if (user == null) throw new NotFoundUserException($"There's no user with e-mail: {query.Email}");

            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, query.Password);

            if(result == PasswordVerificationResult.Failed) throw new IncorrectPasswordException($"Invalid password.");

            var token = _tokenService.GenerateToken(user);

            return new LoginSucessDto() { Token = token };
        }
    }
}
