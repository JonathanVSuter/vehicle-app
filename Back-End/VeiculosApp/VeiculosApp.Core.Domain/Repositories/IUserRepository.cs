using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
