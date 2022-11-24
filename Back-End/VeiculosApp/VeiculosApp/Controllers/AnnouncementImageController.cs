using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.ViewModels.AnnouncementImage;

namespace VeiculosApp.Controllers
{
    //TODO: how to send images to backend :https://www.youtube.com/watch?v=COAIN-Z3f4A
    [Route("[controller]")]
    [ApiController]
    public class AnnouncementImageController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public AnnouncementImageController(ICommandDispatcher commandDispatcher, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandDispatcher = commandDispatcher;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        [HttpDelete()]
        public IActionResult Remove([FromQuery] int id)
        {
            var commandRemove = new RemoveAnnouncementImageCommand(id);
            _commandDispatcher.Dispatch(commandRemove);
            return NoContent();
        }

        [HttpPut()]
        public IActionResult Update([FromBody] UpdateAnnouncementImageViewModel updateVehicleViewModel)
        {
            var vehicle = _mapper.Map<IList<AnnouncementImage>>(updateVehicleViewModel.AnnouncementImages);
            var command = new UpdateAnnoucementImageCommand(vehicle);
            _commandDispatcher.Dispatch(command);

            return CreatedAtAction(nameof(AnnouncementImageController.Update), nameof(AnnouncementImageController));
        }

        [HttpPost()]
        public IActionResult Save([FromBody] SaveAnnouncementImageViewModel saveVehicleViewModel)
        {
            var vehicle = _mapper.Map<IList<AnnouncementImage>>(saveVehicleViewModel.VehicleImage);

            var command = new SaveAnnouncementImageCommand(vehicle);
            _commandDispatcher.Dispatch(command);

            return CreatedAtAction(nameof(AnnouncementImageController.Save), nameof(AnnouncementImageController));
        }

        [HttpGet()]
        [Route("getby")]
        public IActionResult GetBy([FromQuery] string term)
        {
            var query = new GetByTermAnnouncementImageQuery(term);

            var vehicles = _queryExecutor.Execute<GetByTermAnnouncementImageQuery, IList<AnnouncementImage>>(query);

            if (vehicles != null && vehicles.Any())
            {
                var result = _mapper.Map<IList<AnnouncementImageDto>>(vehicles);
                return Ok(new { result });
            }
            return NoContent();
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var query = new GetAllAnnouncementImagesQuery();

            var vehicles = _queryExecutor.Execute<GetAllAnnouncementImagesQuery, IList<AnnouncementImage>>(query);

            if (vehicles != null && vehicles.Any())
            {
                var result = _mapper.Map<IList<AnnouncementImageDto>>(vehicles);

                return Ok(new { result });
            }
            return NoContent();
        }

        [HttpGet()]
        [Route("getbyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            var query = new GetByIdAnnouncementImageQuery(id);
            var vehicle = _queryExecutor.Execute<GetByIdAnnouncementImageQuery, AnnouncementImage>(query);

            if (vehicle != null)
            {
                var result = _mapper.Map<AnnouncementImageDto>(vehicle);
                return Ok(new { result });
            }
            return NoContent();
        }
    }
}
