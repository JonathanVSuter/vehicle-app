using System.Collections.Generic;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Queries
{
    public class GetAllVehicleQuery : IQuery<IList<Vehicle>>
    {
        public GetAllVehicleQuery() { }
    }
}
