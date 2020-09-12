using FluentValidation;
using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Domain.Filters;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Domain.Validations.Interfaces;
using System;

namespace ObrasBibliograficas.Domain.Validations
{
    public class BaseValidation<TEntity, TFilter, TRepository> : AbstractValidator<TEntity>, IBaseValidation<TEntity>
        where TEntity : BaseEntity
        where TFilter : BaseFilter
        where TRepository : IBaseRepository<TEntity, TFilter>
    {
        public readonly TRepository Repository;

        public BaseValidation(TRepository repository)
        {
            Repository = repository;
        }

        public void ValidatesBase()
        {
            throw new NotImplementedException();
        }
    }
}
