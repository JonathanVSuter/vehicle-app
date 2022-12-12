using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.ViewModels.Login;

namespace VeiculosApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IQueryExecutor _queryExecutor;

        public LoginController(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        [AllowAnonymous]        
        [HttpPost()]
        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {
            var query = new LoginQuery(loginViewModel.Login.Email, loginViewModel.Login.Password);
            var result = _queryExecutor.Execute<LoginQuery, LoginSucessDto>(query);
            return Ok(result);
        }

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
