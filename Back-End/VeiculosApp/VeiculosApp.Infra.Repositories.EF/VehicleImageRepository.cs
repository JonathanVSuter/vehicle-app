using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class VehicleImageRepository : BaseRepository<VehicleImage>, IVehicleImageRepository
    {
        public VehicleImageRepository(AppVehiclesDbContext appVehiclesDbContext) : base(appVehiclesDbContext)
        {
        }
    }
}
