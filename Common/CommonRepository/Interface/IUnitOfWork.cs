using System.Data.Entity;

namespace OCine.Common.CommonRepository.Interface
{
   public interface IUnitOfWork
    {
        DbContext Db { get; }
        int SaveChanges();
        DbContextTransaction StartTransaction();
    }
}
