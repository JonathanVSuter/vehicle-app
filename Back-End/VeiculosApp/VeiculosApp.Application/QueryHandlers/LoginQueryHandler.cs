using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Exceptions;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;
using VeiculosApp.Core.Domain.Services;

namespace VeiculosApp.Application.QueryHandlers
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, LoginSucessDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginQueryHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public LoginSucessDto Execute(LoginQuery query)
        {
            var user = _userRepository.GetUserByEmail(query.Email);

            if (user == null) throw new NotFoundUserException($"There's no user with e-mail: {query.Email}");
            
            if (!user.Password.Equals(query.Password)) throw new IncorrectPasswordException($"User or password invalid.");

            var token = _tokenService.GenerateToken(user);

            return new LoginSucessDto() { Token = token };
        }
    }
}
