using System.Collections.Generic;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Repositories
{
    public interface IBaseRepository<T> where T : IModel
    {
        T Add(T model);
        T Update(T model);
        bool Remove(T model);
        IEnumerable<T> GetAll();
        T GetById(int id);
        abstract IEnumerable<T> GetBy(string term);
    }
}
