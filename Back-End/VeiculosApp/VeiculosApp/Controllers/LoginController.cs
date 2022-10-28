namespace VeiculosApp.Controllers
{
    public class LoginController
    {
        //private readonly ICommandDispatcher _commandDispatcher;

        //public AuthController(ICommandDispatcher commandDispatcher)
        //{
        //    _commandDispatcher = commandDispatcher;
        //}

        //[AllowAnonymous]
        //[Route("login")]
        //[HttpPost]
        //public IActionResult Login([FromBody] UserViewModel userModel)
        //{
        //    var command = new LoginCommand(userModel.UserName, userModel.Password, userModel.Role, userModel.ApplicationName);
        //    var result = _commandDispatcher.Dispatch<LoginCommand, LoginResult>(command);
        //    return Ok(result);
        //}

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
