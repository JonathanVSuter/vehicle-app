using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Queries
{
    public class GetByIdVehicleQuery : IQuery<Vehicle>
    {
        public int Id { get; set; }

        public GetByIdVehicleQuery(int id)
        {
            Id = id;
        }
    }
}
