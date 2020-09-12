using Microsoft.EntityFrameworkCore;
using ObrasBibliograficas.Domain.Entitties;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ObrasBibliograficas.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable
        where TEntity : BaseEntity
    {
        protected readonly ObrasBibliograficasContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(ObrasBibliograficasContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                entity.DataCadastro = DateTime.Now;
                DbSet.Add(entity);
                return SaveChanges() > 0 ? entity : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                DbSet.Remove(DbSet.Find(id));
                return SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return DbSet.AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                entity.DataAlteracao = DateTime.Now;
                Db.Entry(entity).State = EntityState.Detached;
                DbSet.Update(entity);
                return SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(true);
        }
    }
}
