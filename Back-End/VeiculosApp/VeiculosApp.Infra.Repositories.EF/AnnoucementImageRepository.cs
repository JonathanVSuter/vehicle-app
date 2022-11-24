using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class AnnoucementImageRepository : BaseRepository<AnnouncementImage>, IAnnouncementImageRepository
    {
        public AnnoucementImageRepository(AppVehiclesDbContext appVehiclesDbContext) : base(appVehiclesDbContext)
        {
        }        

        public IList<AnnouncementImage> GetAllAnnoucementImagesByAnnoucementId(int idAnnoucement)
        {
            var result = _appVehiclesDbContext.Set<AnnouncementImage>().Where(x => x.IdAnnouncement == idAnnoucement).ToList();

            return result;
        }

        public IList<AnnouncementImage> GetAllAnnouncementImagesByTerm(string term)
        {
            var sql = @"SELECT [Id]
                          ,[Name]
                          ,[Description]
                          ,[Photo]
                          ,[IdAnnouncement]
                          ,[CreatedDate]
                          ,[UpdatedDate]
                          ,[IsActive]
                      FROM [dbo].[AnnouncementImages]
                      WHERE CONCAT(Id,Name,Description) like CONCAT('%',@term,'%')";

            var result = _appVehiclesDbContext.Set<AnnouncementImage>().FromSqlRaw(sql, new { term }).ToList();
            return result;
        }
    }
}
