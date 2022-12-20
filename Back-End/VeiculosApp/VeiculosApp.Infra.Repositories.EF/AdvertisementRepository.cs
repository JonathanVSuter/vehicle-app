using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(AppVehiclesDbContext appVehiclesDbContext) : base(appVehiclesDbContext)
        {
        }
    }
}
