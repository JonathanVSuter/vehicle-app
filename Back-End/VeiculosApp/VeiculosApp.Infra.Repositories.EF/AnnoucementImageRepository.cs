using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class AnnoucementImageRepository : BaseRepository<AnnoucementImage>, IAnnouncementImageRepository
    {
        public AnnoucementImageRepository(AppVehiclesDbContext appVehiclesDbContext) : base(appVehiclesDbContext)
        {
        }
        public IList<AnnoucementImage> GetAllVehicleImages(int idVehicle)
        {
            var result = _appVehiclesDbContext.Set<AnnoucementImage>().Where(x => x.IdAnnouncement == idVehicle).ToList();

            return result;
        }
    }
}
