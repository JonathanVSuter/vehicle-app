using System.Collections.Generic;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Repositories
{
    public interface IAdvertisementImageRepository : IBaseRepository<AdvertisementImage>
    {
        IList<AdvertisementImage> GetAllAdvertisementImagesByAdvertisementId(int idAdvertisement);
        IList<AdvertisementImage> GetAllAdvertisementImagesByTerm(string term);
    }
}
