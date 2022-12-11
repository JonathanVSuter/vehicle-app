﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Services;
using VeiculosApp.ViewModels.Announcement;

namespace VeiculosApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AnnouncementController(ICommandDispatcher commandDispatcher, IQueryExecutor queryExecutor, IMapper mapper, ITokenService tokenService)
        {
            _commandDispatcher = commandDispatcher;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpDelete()]
        public IActionResult Remove([FromQuery] int id)
        {
            var commandRemove = new RemoveAnnouncementCommand(id);
            _commandDispatcher.Dispatch(commandRemove);
            return NoContent();
        }

        [HttpPut()]
        public IActionResult Update([FromBody] UpdateAnnoucementViewModel updateAnnoucementViewModel)
        {
            var announcement = _mapper.Map<Announcement>(updateAnnoucementViewModel.Annoucement);
            var command = new UpdateAnnouncementCommand(announcement);
            _commandDispatcher.Dispatch(command);
            return NoContent();
        }

        [HttpPost()]
        public IActionResult Save([FromBody] SaveAnnoucementViewModel saveAnnoucementViewModel)
        {
            var announcement = _mapper.Map<Announcement>(saveAnnoucementViewModel.Announcement);
            var command = new SaveAnnouncementCommand(announcement);
            _commandDispatcher.Dispatch(command);

            return Created(nameof(AnnouncementController.Save), nameof(AnnouncementController));
        }

        //[HttpGet()]
        //[Route("getby")]
        //public IActionResult GetBy([FromQuery] string term)
        //{
        //    var query = new GetByTermUserQuery(term);
        //    var users = _queryExecutor.Execute<GetByTermUserQuery, IList<User>>(query);
        //    if (users != null && users.Any())
        //    {
        //        var result = _mapper.Map<IList<User>>(users);
        //        return Ok(new { result });
        //    }
        //    return NoContent();
        //}

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
