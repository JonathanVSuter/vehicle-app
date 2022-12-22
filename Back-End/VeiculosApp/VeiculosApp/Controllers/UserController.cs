using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.ViewModels.User;

namespace VeiculosApp.Controllers
{
    [Route("[controller]")] 
    [Authorize]
    [ApiController]
    public class UserController : CustomController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public UserController(ICommandDispatcher commandDispatcher, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandDispatcher = commandDispatcher;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete()]
        public IActionResult Remove([FromQuery] int id)
        {
            var commandRemove = new RemoveUserCommand(id);
            _commandDispatcher.Dispatch(commandRemove);
            return NoContent();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPut()]
        public IActionResult Update([FromBody] UpdateUserViewModel updateUserViewModel)
        {
            var user = _mapper.Map<User>(updateUserViewModel.User);
            var command = new UpdateUserCommand(user);
            _commandDispatcher.Dispatch(command);
            return NoContent();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost()]
        public async Task<IActionResult> Save([FromBody] SaveUserViewModel saveUserViewModel)
        {
            var user = _mapper.Map<User>(saveUserViewModel.User);
            var command = new SaveUserCommand(user);
            await _commandDispatcher.DispatchAsync(command).ConfigureAwait(true);

            return CreatedAtAction(nameof(UserController.Save), nameof(UserController));
        }
        [Authorize(Roles = "ADMIN")]
        [HttpGet()]
        [Route("getby")]
        public IActionResult GetBy([FromQuery] string term)
        {
            var query = new GetByTermUserQuery(term);
            var users = _queryExecutor.Execute<GetByTermUserQuery, IList<User>>(query);
            if (users != null && users.Any())
            {
                var result = _mapper.Map<IList<User>>(users);
                return Ok(new { result });
            }
            return NoContent();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpGet()]
        public IActionResult GetAll()
        {
            var query = new GetAllUsersQuery();

            var users = _queryExecutor.Execute<GetAllUsersQuery, IList<User>>(query);

            if (users != null && users.Any())
            {
                var result = _mapper.Map<IList<UserDto>>(users);

                return Ok(new { result });
            }
            return NoContent();
        }
        [Authorize(Roles = "ADMIN,Normal")]
        [HttpGet()]
        [Route("getbyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            var query = new GetByIdUserQuery(id);
            var user = _queryExecutor.Execute<GetByIdUserQuery, User>(query);

            if (user != null)
            {
                var result = _mapper.Map<UserDto>(user);
                return Ok(new { result });
            }
            //use this for when a resource is not finded.
            return NotFound(new { message = $"There's no User with Id = {id}." });
        }
    }
}
