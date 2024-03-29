﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class AdvertisementImageRepository : BaseRepository<AdvertisementImage>, IAdvertisementImageRepository
    {
        public AdvertisementImageRepository(AppVehiclesDbContext appVehiclesDbContext) : base(appVehiclesDbContext)
        {
        }        

        public IList<AdvertisementImage> GetAllAdvertisementImagesByAdvertisementId(int idAdvertisement)
        {
            var result = _appVehiclesDbContext.Set<AdvertisementImage>().Where(x => x.IdAdvertisement == idAdvertisement).ToList();

            return result;
        }

        public IList<AdvertisementImage> GetAllAdvertisementImagesByTerm(string term)
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

            var result = _appVehiclesDbContext.Set<AdvertisementImage>().FromSqlRaw(sql, new SqlParameter("@term", term)).ToList();
            return result;
        }
    }
}
