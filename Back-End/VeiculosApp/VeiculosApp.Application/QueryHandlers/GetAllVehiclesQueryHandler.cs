using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.QueryHandlers
{
    public class GetAllVehiclesQueryHandler : IQueryHandler<GetAllVehicleQuery, IList<Vehicle>>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetAllVehiclesQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IList<Vehicle> Execute(GetAllVehicleQuery query)
        {
            var result = _vehicleRepository.GetAll().ToList();
            return result;
        }
    }
}
