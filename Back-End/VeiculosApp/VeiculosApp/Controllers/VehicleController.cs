using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculosApp.Core.Domain.Repositories;

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

        [HttpGet]
        public IActionResult GetAll() 
        {
            var a = _vehiclesRepository.GetAll();

            return Ok(new { sucess = true, result = a});
        }
    }
}
