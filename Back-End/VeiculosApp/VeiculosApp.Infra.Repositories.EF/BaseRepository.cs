using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Repositories;

namespace VeiculosApp.Infra.Repositories.EF
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IModel
    {
        protected AppVehiclesDbContext _appVehiclesDbContext;
        public BaseRepository(AppVehiclesDbContext appVehiclesDbContext) 
        {
            _appVehiclesDbContext = appVehiclesDbContext;
        }
        public TEntity Add(TEntity model)
        {
            _appVehiclesDbContext.Set<TEntity>().Add(model);
            _appVehiclesDbContext.SaveChanges();
            return model;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var result =_appVehiclesDbContext.Set<TEntity>().ToList();
            return result;
        }

        public virtual IEnumerable<TEntity> GetBy(string term)
        {
            //trying to write an generic GetBy, joining all fields of in one clause
            //var listOfParams = new List<Func<PropertyInfo,bool>>();
            //foreach(var item in typeof(TEntity).GetProperties()) 
            //{
            //    listOfParams.Add(x=> item.GetValue(item).ToString().Contains(term));  
            //}            
            var result = _appVehiclesDbContext.Set<TEntity>().Where(x => x.Id == Convert.ToInt32(term));
            return result;
        }

        public TEntity GetById(int id)
        {
            var result = _appVehiclesDbContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            return result;
        }

        public bool Remove(TEntity model)
        {
            _appVehiclesDbContext.Set<TEntity>().Remove(model);
            _appVehiclesDbContext.SaveChanges();
            return true;
        }

        public TEntity Update(TEntity model)
        {
            _appVehiclesDbContext.Entry(model).State = EntityState.Modified;
            _appVehiclesDbContext.SaveChanges();
            return model;
        }
    }
}
