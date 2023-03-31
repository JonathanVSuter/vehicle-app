using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.ViewModels.Login;

namespace VeiculosApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : CustomController
    {
        private readonly IQueryExecutor _queryExecutor;

        public LoginController(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        [AllowAnonymous]        
        [HttpPost()]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            var query = new LoginQuery(loginViewModel.Login.Email, loginViewModel.Login.Password);
            var result = await _queryExecutor.ExecuteAsync<LoginQuery, LoginSucessDto>(query).ConfigureAwait(true);
                                    
            return Ok(result);
        }

        //TODO: refresh token
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("refresh")]
        //public IActionResult Refresh([FromBody] RefreshTokenViewModel refreshModel)
        //{
        //    var command = new RefreshTokenCommand(refreshModel.AccessToken, refreshModel.RefreshToken);
        //    var result = _commandDispatcher.Dispatch<RefreshTokenCommand, GeneratedAccessToken>(command);
        //    return Ok(result);
        //}
    }
}
