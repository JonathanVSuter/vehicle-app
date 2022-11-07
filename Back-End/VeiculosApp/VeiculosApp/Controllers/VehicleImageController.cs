using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Query;

namespace VeiculosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleImageController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public VehicleImageController(ICommandDispatcher commandDispatcher, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandDispatcher = commandDispatcher;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        [HttpDelete()]
        public IActionResult Remove([FromQuery] int id)
        {
            //var commandRemove = new RemoveVehicleCommand(id);
            //_commandDispatcher.Dispatch(commandRemove);

            return NoContent();
        }

        [HttpPut()]
        public IActionResult Update([FromBody] UpdateVehicleViewModel updateVehicleViewModel)
        {
            //var vehicle = _mapper.Map<Vehicle>(updateVehicleViewModel.Vehicle);
            //var command = new UpdateVehicleCommand(vehicle);
            //_commandDispatcher.Dispatch(command);

            return CreatedAtAction(nameof(VehicleImageController.Update), nameof(VehicleImageController));
        }

        [HttpPost()]
        public IActionResult Save([FromBody] SaveVehicleViewModel saveVehicleViewModel)
        {
            var vehicle = _mapper.Map<Vehicle>(saveVehicleViewModel.Vehicle);
            var images = _mapper.Map<List<VehicleImage>>(saveVehicleViewModel.VehicleImages);

            var command = new SaveVehicleCommand(vehicle);
            var savedVehicle = _commandDispatcher.Dispatch<SaveVehicleCommand, Vehicle>(command);

            if (images.Any())
            {
                var commandSaveVehicleImages = new SaveVehicleImageCommand(savedVehicle.Id, images);
                _commandDispatcher.Dispatch(commandSaveVehicleImages);
            }

            return CreatedAtAction(nameof(VehicleController.Save), nameof(VehicleController));
        }

        [HttpGet()]
        [Route("getby")]
        public IActionResult GetBy([FromQuery] string term)
        {
            var query = new GetByVehicleQuery(term);

            var vehicles = _queryExecutor.Execute<GetByVehicleQuery, IList<Vehicle>>(query);

            if (vehicles != null && vehicles.Any())
            {
                var result = _mapper.Map<IList<VehicleDto>>(vehicles);
                return Ok(new { result });
            }
            return NoContent();
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var query = new GetAllVehicleQuery();

            var vehicles = _queryExecutor.Execute<GetAllVehicleQuery, IList<Vehicle>>(query);

            if (vehicles != null && vehicles.Any())
            {
                var result = _mapper.Map<IList<VehicleDto>>(vehicles);

                return Ok(new { result });
            }
            return NoContent();
        }

        [HttpGet()]
        [Route("getbyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            var query = new GetByIdVehicleQuery(id);
            var vehicle = _queryExecutor.Execute<GetByIdVehicleQuery, Vehicle>(query);

            if (vehicle != null)
            {
                var result = _mapper.Map<VehicleDto>(vehicle);
                return Ok(new { result });
            }
            return NoContent();
        }
    }
}
