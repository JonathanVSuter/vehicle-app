using System.Collections.Generic;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Repositories
{
    public interface IAnnouncementImageRepository : IBaseRepository<AnnouncementImage>
    {
        IList<AnnouncementImage> GetAllAnnoucementImagesByAnnoucementId(int idAnnoucement);
        IList<AnnouncementImage> GetAllAnnouncementImagesByTerm(string term);
    }
}
