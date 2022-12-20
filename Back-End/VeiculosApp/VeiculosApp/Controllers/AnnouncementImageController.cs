using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
            var commandRemove = new RemoveAdvertisementImageCommand(id);
            _commandDispatcher.Dispatch(commandRemove);
            return NoContent();
        }
        [HttpPut()]
        public IActionResult Update([FromBody] UpdateAnnouncementImageViewModel updateVehicleViewModel)
        {
            var vehicle = _mapper.Map<IList<AdvertisementImage>>(updateVehicleViewModel.AnnouncementImages);
            var command = new UpdateAdvertisementImageCommand(vehicle);
            _commandDispatcher.Dispatch(command);

            return NoContent();
        }
        [Authorize]
        [HttpPost()]
        public IActionResult Save([FromBody] SaveAnnouncementImageViewModel saveVehicleViewModel)
        {
            var vehicle = _mapper.Map<IList<AdvertisementImage>>(saveVehicleViewModel.VehicleImage);

            var command = new SaveAdvertisementImageCommand(vehicle);
            _commandDispatcher.Dispatch(command);

            return CreatedAtAction(nameof(AnnouncementImageController.Save), nameof(AnnouncementImageController));
        }
        [Authorize]
        [HttpGet()]
        [Route("getby")]
        public IActionResult GetBy([FromQuery] string term)
        {
            var query = new GetByTermAnnouncementImageQuery(term);

            var vehicles = _queryExecutor.Execute<GetByTermAnnouncementImageQuery, IList<AdvertisementImage>>(query);

            if (vehicles != null && vehicles.Any())
            {
                var result = _mapper.Map<IList<AdvertisementImageDto>>(vehicles);
                return Ok(new { result });
            }
            return NoContent();
        }
        [Authorize]
        [HttpGet()]
        public IActionResult GetAll()
        {
            var query = new GetAllAnnouncementImagesQuery();

            var vehicles = _queryExecutor.Execute<GetAllAnnouncementImagesQuery, IList<AdvertisementImage>>(query);

            if (vehicles != null && vehicles.Any())
            {
                var result = _mapper.Map<IList<AdvertisementImageDto>>(vehicles);

                return Ok(new { result });
            }
            return NoContent();
        }
        [Authorize]
        [HttpGet()]
        [Route("getbyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            var query = new GetByIdAnnouncementImageQuery(id);
            var vehicle = _queryExecutor.Execute<GetByIdAnnouncementImageQuery, AdvertisementImage>(query);

            if (vehicle != null)
            {
                var result = _mapper.Map<AdvertisementImageDto>(vehicle);
                return Ok(new { result });
            }
            return NoContent();
        }
    }
}
