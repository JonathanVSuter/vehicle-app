using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {

        public AdvertisementRepository(AppVehiclesDbContext appVehiclesDbContext) : base(appVehiclesDbContext)
        {
        }

        public IEnumerable<Advertisement> GetByFromSpecificUser(string term, int idUser)
        {
            var sql = @"SELECT [Id]
                          ,[IdVehicle]
                          ,[IdUser]
                          ,[AnnouncedValue]
                          ,[CreatedDate]
                          ,[UpdatedDate]
                          ,[IsActive]
                      FROM [dbo].[Advertisements]
                      WHERE CONCAT(IdVehicle,AnnouncedValue,CreatedDate,UpdatedDate) like CONCAT('%',@term,'%')
                            AND IdUser = @idUser";
            var parameters = new object []
            {
                new SqlParameter("@term", term),
                new SqlParameter("@idUser", idUser)
            };

            var result = _appVehiclesDbContext.Set<Advertisement>().FromSqlRaw(sql, parameters).ToList();
            return result;
        }
        public override IEnumerable<Advertisement> GetBy(string term)
        {
            var sql = @"SELECT [Id]
                          ,[IdVehicle]
                          ,[IdUser]
                          ,[AnnouncedValue]
                          ,[CreatedDate]
                          ,[UpdatedDate]
                          ,[IsActive]
                      FROM [dbo].[Advertisements]
                      WHERE CONCAT(IdVehicle,AnnouncedValue,CreatedDate,UpdatedDate) like CONCAT('%',@term,'%')";
            var parameters = new object[]
            {
                new SqlParameter("@term", term)                
            };

            var result = _appVehiclesDbContext.Set<Advertisement>().FromSqlRaw(sql, parameters).ToList();
            return result;
        }
    }
}
