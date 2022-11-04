using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.QueryHandlers
{
    public class GetByVehicleQueryHandler : IQueryHandler<GetByVehicleQuery, IList<Vehicle>>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetByVehicleQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IList<Vehicle> Execute(GetByVehicleQuery query)
        {
            var result = _vehicleRepository.GetBy(query.Term).ToList();

            return result;
        }
    }
}
