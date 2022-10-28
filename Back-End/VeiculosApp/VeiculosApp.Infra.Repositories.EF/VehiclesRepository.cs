using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly AppVehiclesDbContext _appVehiclesDbContext;
        public VehiclesRepository(AppVehiclesDbContext appVehiclesDbContext)
        {
            _appVehiclesDbContext = appVehiclesDbContext;
        }
        public Vehicle Add(Vehicle model)
        {
            _appVehiclesDbContext.Vehicles.Add(model);
            _appVehiclesDbContext.SaveChanges();
            return model;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            var res = _appVehiclesDbContext.Vehicles.ToList();
            return res;
        }

        public IEnumerable<Vehicle> GetBy(string term)
        {
            var res = _appVehiclesDbContext.Vehicles.Where(x => x.Brand.Contains(term) || x.Name.Contains(term) || x.Id.ToString().Contains(term));
            return res;
        }

        public Vehicle GetById(int id)
        {
            var res = _appVehiclesDbContext.Vehicles.FirstOrDefault(x => x.Id == id);
            return res;
        }

        public bool Remove(Vehicle model)
        {
            var res = _appVehiclesDbContext.Vehicles.Remove(model).State;
            if (res == Microsoft.EntityFrameworkCore.EntityState.Deleted) return true;
            return false;
        }

        public Vehicle Update(Vehicle model)
        {
            var res = _appVehiclesDbContext.Vehicles.Update(model);
            _appVehiclesDbContext.SaveChanges();
            return model;
        }
    }
}
