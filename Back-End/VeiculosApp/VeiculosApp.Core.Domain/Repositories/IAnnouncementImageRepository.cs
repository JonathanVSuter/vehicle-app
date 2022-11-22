using System.Collections.Generic;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Repositories
{
    public interface IAnnouncementImageRepository : IBaseRepository<AnnoucementImage>
    {
        IList<AnnoucementImage> GetAllVehicleImages(int idVehicle);
    }
}
