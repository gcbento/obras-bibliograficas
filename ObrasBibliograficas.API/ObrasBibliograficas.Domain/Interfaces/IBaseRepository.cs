using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Domain.Filters;
using System.Linq;

namespace ObrasBibliograficas.Domain.Interfaces
{
    public interface IBaseRepository<TEntity, TFilter>
        where TEntity : BaseEntity
        where TFilter : BaseFilter
    {
        TEntity Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(int id);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(TFilter filter, int pageNumber = 1, int pageSize = 10, bool contains = false);

        int SaveChanges();
    }
}
