using System.Collections.Generic;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Repositories
{
    public interface IAdvertisementImageRepository : IBaseRepository<AdvertisementImage>
    {
        IList<AdvertisementImage> GetAllAnnoucementImagesByAnnoucementId(int idAnnoucement);
        IList<AdvertisementImage> GetAllAnnouncementImagesByTerm(string term);
    }
}
