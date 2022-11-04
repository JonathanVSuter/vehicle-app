using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Queries
{
    public class GetByVehicleQuery : IQuery<IList<Vehicle>>
    {
        public string Term { get; set; }

        public GetByVehicleQuery(string term)
        {
            Term = term;
        }
    }
}
