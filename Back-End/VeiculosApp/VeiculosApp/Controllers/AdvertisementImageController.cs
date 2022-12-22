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
using VeiculosApp.ViewModels.AdvertisementImage;

namespace VeiculosApp.Controllers
{
    //TODO: how to send images to backend :https://www.youtube.com/watch?v=COAIN-Z3f4A
    [Route("[controller]")]
    [ApiController]
    public class AdvertisementImageController : CustomController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public AdvertisementImageController(ICommandDispatcher commandDispatcher, IQueryExecutor queryExecutor, IMapper mapper)
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
        public IActionResult Update([FromBody] UpdateAdvertisementImageViewModel updateVehicleViewModel)
        {
            var images = _mapper.Map<IList<AdvertisementImage>>(updateVehicleViewModel.AnnouncementImages);
            var command = new UpdateAdvertisementImageCommand(images);
            _commandDispatcher.Dispatch(command);

            return NoContent();
        }
        [Authorize]
        [HttpPost()]
        public IActionResult Save([FromBody] SaveAdvertisementImageViewModel saveVehicleViewModel)
        {
            var images = _mapper.Map<IList<AdvertisementImage>>(saveVehicleViewModel.AdvertisementImage);
            var command = new SaveAdvertisementImageCommand(images);
            _commandDispatcher.Dispatch(command);
            return Created(nameof(AdvertisementController.Save), images);
        }
        [Authorize]
        [HttpGet()]
        [Route("getby")]
        public IActionResult GetBy([FromQuery] string term)
        {
            var query = new GetByTermAdvertisementImageQuery(term);
            var vehicles = _queryExecutor.Execute<GetByTermAdvertisementImageQuery, IList<AdvertisementImage>>(query);
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
            var query = new GetByIdAdvertisementImageQuery(id);
            var vehicle = _queryExecutor.Execute<GetByIdAdvertisementImageQuery, AdvertisementImage>(query);

            if (vehicle != null)
            {
                var result = _mapper.Map<AdvertisementImageDto>(vehicle);
                return Ok(new { result });
            }
            return NoContent();
        }
    }
}
