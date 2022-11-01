using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {        
        public VehicleRepository(AppVehiclesDbContext appVehiclesDbContext):base(appVehiclesDbContext){}
        public override IEnumerable<Vehicle> GetBy(string term)
        {
            var res = _appVehiclesDbContext.Vehicles.Where(x => x.Brand.Contains(term) || x.Name.Contains(term) || x.Id.ToString().Contains(term));
            return res;
        }
    }
}
