using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  AutoMapper;
using AutoMapper.QueryableExtensions;
using OCine.Common.CommonRepository.Interface;

namespace OCine.Common.CommonService
{
  public abstract class BaseService
    {
      protected readonly IUnitOfWork Work;
      protected readonly IAutoMapperConfig MapperConfig;

      public BaseService(IUnitOfWork work, IAutoMapperConfig mapperConfig)
      {
          Work = work;
          MapperConfig = mapperConfig;
      }


      public void Insert<T>(T entity) where T : class
      {
          this.Work.Db.Set<T>().Add(entity);
      }

      public T SingleOrDefault<T>(object primaryKey) where T : class
      {
          return this.Work.Db.Set<T>().Find(primaryKey);
      }

      public IEnumerable<T1> GetAll<T1, T2>() where T1 : class where T2 : class
      {
          var list = Work.Db.Set<T2>().ProjectTo<T1>(MapperConfig).ToList();
          return list;
      }

      public bool Exists<T>(object primaryKey) where T : class
      {
          return SingleOrDefault<T>(primaryKey) != null;
      }

      public void Update<T>(T entity) where T : class
      {
          var entry = Work.Db.Entry<T>(entity);
          if (entry.State == EntityState.Detached) this.Work.Db.Set<T>().Attach(entity);
          entry.State = EntityState.Modified;
      }

      public void Delete<T>(T entity) where T : class
      {
          Work.Db.Set<T>().Remove(entity);
      }

   }
}
