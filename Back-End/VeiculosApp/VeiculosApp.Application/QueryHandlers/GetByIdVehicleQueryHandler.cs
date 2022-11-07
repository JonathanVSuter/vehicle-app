using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Application.QueryHandlers
{
    public class GetByIdVehicleQueryHandler : IQueryHandler<GetByIdVehicleQuery, Vehicle>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetByIdVehicleQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle Execute(GetByIdVehicleQuery query)
        {
            var result = _vehicleRepository.GetById(query.Id);
            return result;
        }
    }
}
