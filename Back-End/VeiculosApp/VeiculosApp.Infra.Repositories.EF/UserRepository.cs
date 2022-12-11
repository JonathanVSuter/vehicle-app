using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppVehiclesDbContext appVehiclesDbContext) : base(appVehiclesDbContext) { }

        public override IEnumerable<User> GetBy(string term)
        {
            var sql = @"SELECT [Id]
                            ,[Name]
                            ,[Email]
                            ,[Password]
                            ,[Role]
                            ,[CreatedDate]
                            ,[UpdatedDate]
                            ,[IsActive]
                        FROM[veiculosapp.dev].[dbo].[Users]
                        WHERE CONCAT(Id, Name, Email, Role, IsActive) like CONCAT('%',@term,'%')";

            var result = _appVehiclesDbContext.Set<User>().FromSqlRaw(sql, new SqlParameter("@term", term));
            return result;
        }

        public User GetUserByEmail(string email)
        {
            var result = _appVehiclesDbContext.Set<User>().FirstOrDefault(x=> x.Email == email);
            return result;
        }
    }
}
