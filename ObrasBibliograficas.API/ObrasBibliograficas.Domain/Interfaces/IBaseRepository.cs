using ObrasBibliograficas.Domain.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObrasBibliograficas.Domain.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(int id);

        IQueryable<TEntity> GetAll();

        int SaveChanges();
    }
}
