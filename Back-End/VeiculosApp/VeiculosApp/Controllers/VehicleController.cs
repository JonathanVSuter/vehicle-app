using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;
using VeiculosApp.ViewModels.Vehicle;

namespace VeiculosApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehiclesRepository;
        public VehicleController(IVehicleRepository vehiclesRepository)
        {
            _vehiclesRepository = vehiclesRepository;
        }

        [HttpDelete()]
        public IActionResult Remove([FromQuery]int id)
        {
            var a = _vehiclesRepository.GetAll();

            return Ok(new { success = true, result = a });
        }

        [HttpPut()]
        public IActionResult Update([FromBody] UpdateVehicleViewModel updateVehicleViewModel)
        {
            var a = _vehiclesRepository.GetAll();

            return Ok(new { success = true, result = a });
        }

        [HttpPost()]
        public IActionResult Save([FromBody] SaveVehicleViewModel saveVehicleViewModel)
        {
            var vehicleDto = saveVehicleViewModel.Vehicle;

            var a = _vehiclesRepository.Add(new Vehicle() { Brand = vehicleDto.Brand, IsActive = true, Name = vehicleDto.Name, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });

            return Ok(new { success = true, result = a });
        }

        [HttpGet()]        
        public IActionResult GetBy([FromQuery]string term)
        {
            var a = _vehiclesRepository.GetBy(term);

            return Ok(new { success = true, result = a });
        }        
    }
}
