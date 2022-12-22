using System.Collections.Generic;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Repositories
{
    public interface IAdvertisementRepository : IBaseRepository<Advertisement>
    {
        IEnumerable<Advertisement> GetByFromSpecificUser(string term, int idUser);
    }
}
