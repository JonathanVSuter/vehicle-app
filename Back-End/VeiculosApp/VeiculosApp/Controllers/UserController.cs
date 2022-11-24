using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.ViewModels.User;

namespace VeiculosApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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
        [HttpDelete()]
        public IActionResult Remove([FromQuery] int id)
        {
            var commandRemove = new RemoveUserCommand(id);
            _commandDispatcher.Dispatch(commandRemove);
            return NoContent();
        }

        [HttpPut()]
        public IActionResult Update([FromBody] UpdateUserViewModel updateUserViewModel)
        {
            var user = _mapper.Map<User>(updateUserViewModel.User);
            var command = new UpdateUserCommand(user);
            _commandDispatcher.Dispatch(command);
            return CreatedAtAction(nameof(UserController.Update), nameof(UserController));
        }

        [HttpPost()]
        public IActionResult Save([FromBody] SaveUserViewModel saveUserViewModel)
        {
            var user = _mapper.Map<User>(saveUserViewModel.User);
            var command = new SaveUserCommand(user);
            _commandDispatcher.Dispatch(command);

            return CreatedAtAction(nameof(UserController.Save), nameof(UserController));
        }

        [HttpGet()]
        [Route("getby")]
        public IActionResult GetBy([FromQuery] string term)
        {
            //var query = new GetByTermAnnouncementImageQuery(term);

            //var vehicles = _queryExecutor.Execute<GetByTermAnnouncementImageQuery, IList<AnnouncementImage>>(query);

            //if (vehicles != null && vehicles.Any())
            //{
            //    var result = _mapper.Map<IList<AnnouncementImageDto>>(vehicles);
            //    return Ok(new { result });
            //}
            return NoContent();
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            //var query = new GetAllAnnouncementImagesQuery();

            //var vehicles = _queryExecutor.Execute<GetAllAnnouncementImagesQuery, IList<AnnouncementImage>>(query);

            //if (vehicles != null && vehicles.Any())
            //{
            //    var result = _mapper.Map<IList<AnnouncementImageDto>>(vehicles);

            //    return Ok(new { result });
            //}
            return NoContent();
        }

        [HttpGet()]
        [Route("getbyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            //var query = new GetByIdAnnouncementImageQuery(id);
            //var vehicle = _queryExecutor.Execute<GetByIdAnnouncementImageQuery, AnnouncementImage>(query);

            //if (vehicle != null)
            //{
            //    var result = _mapper.Map<AnnouncementImageDto>(vehicle);
            //    return Ok(new { result });
            //}
            return NoContent();
        }
    }
}
