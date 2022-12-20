using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Authentication;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Services;
using VeiculosApp.ViewModels.Announcement;

namespace VeiculosApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AdvertisementController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AdvertisementController(ICommandDispatcher commandDispatcher, IQueryExecutor queryExecutor, IMapper mapper, ITokenService tokenService)
        {
            _commandDispatcher = commandDispatcher;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        [Authorize(Roles = "ADMIN,Normal")]
        [HttpDelete()]
        public IActionResult Remove([FromQuery] int id)
        {
            var commandRemove = new RemoveAdvertisementCommand(id);
            _commandDispatcher.Dispatch(commandRemove);
            return NoContent();
        }
        [Authorize(Roles = "ADMIN,Normal")]
        [HttpPut()]
        public IActionResult Update([FromBody] UpdateAdvertisementViewModel updateAnnoucementViewModel)
        {
            var announcement = _mapper.Map<Advertisement>(updateAnnoucementViewModel.Annoucement);
            var command = new UpdateAdvertisementCommand(announcement);
            _commandDispatcher.Dispatch(command);
            return NoContent();
        }
        [Authorize(Roles = "ADMIN,Normal")]
        [HttpPost()]
        public IActionResult Save([FromBody] SaveAdvertisementViewModel saveAnnoucementViewModel)
        {
            var announcement = _mapper.Map<Advertisement>(saveAnnoucementViewModel.Announcement);
            var command = new SaveAdvertisementCommand(announcement);
            _commandDispatcher.Dispatch(command);

            return Created(nameof(AdvertisementController.Save), nameof(AdvertisementController));
        }
        [Authorize(Roles = "ADMIN,Normal")]
        [HttpGet()]
        [Route("getby")]
        public IActionResult GetBy([FromQuery] string term)
        {
            var query = new GetByTermAdvertisementQuery(term);
            var annoucements = _queryExecutor.Execute<GetByTermAdvertisementQuery, IList<Advertisement>>(query);
            if (annoucements != null && annoucements.Any())
            {
                var result = _mapper.Map<IList<AdvertisementDto>>(annoucements);
                return Ok(new { result });
            }
            return NoContent();
        }

        //[HttpGet()]
        //public IActionResult GetAll()
        //{
        //    var query = new GetAllUsersQuery();

        //    var users = _queryExecutor.Execute<GetAllUsersQuery, IList<User>>(query);

        //    if (users != null && users.Any())
        //    {
        //        var result = _mapper.Map<IList<UserDto>>(users);

        //        return Ok(new { result });
        //    }
        //    return NoContent();
        //}

        //[HttpGet()]
        //[Route("getbyid")]
        //public IActionResult GetById([FromQuery] int id)
        //{
        //    var query = new GetByIdUserQuery(id);
        //    var user = _queryExecutor.Execute<GetByIdUserQuery, User>(query);

        //    if (user != null)
        //    {
        //        var result = _mapper.Map<UserDto>(user);
        //        return Ok(new { result });
        //    }
        //    use this for when a resource is not finded.
        //    return NotFound(new { message = $"There's no User with Id = {id}." });
        //}
    }
}
