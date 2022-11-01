using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppVehiclesDbContext appVehiclesDbContext) : base(appVehiclesDbContext) { }

        public override IEnumerable<User> GetBy(string term)
        {
            var result = _appVehiclesDbContext.Set<User>().Where(x=> x.Email.Contains(term) || x.Name.Contains(term) || x.Role.Contains(term));
            return result;
        }

    }
}
