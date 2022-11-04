﻿using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Queries
{
    public class GetAllVehicleQuery : IQuery<IList<Vehicle>>
    {        
        public GetAllVehicleQuery(){}
    }
}
