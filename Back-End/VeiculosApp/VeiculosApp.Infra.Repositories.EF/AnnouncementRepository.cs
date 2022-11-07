using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(AppVehiclesDbContext appVehiclesDbContext) : base(appVehiclesDbContext)
        {
        }
    }
}
