using System.Collections.Generic;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Repositories
{
    public interface IVehicleImageRepository : IBaseRepository<VehicleImage>
    {
        IList<VehicleImage> GetAllVehicleImages(int idVehicle);
    }
}
