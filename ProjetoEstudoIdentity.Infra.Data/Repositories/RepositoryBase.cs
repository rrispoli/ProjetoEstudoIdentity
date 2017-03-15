using ProjetoEstudoIdentity.Domain.Interfaces.Repositories;
using ProjetoEstudoIdentity.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetoEstudoIdentity.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ProjetoEstudoEntityContext Db = new ProjetoEstudoEntityContext();

        public void Add(TEntity item)
        {
            Db.Set<TEntity>().Add(item);
            Db.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public List<TEntity> List()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity item)
        {
            Db.Entry(item).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            Db.Set<TEntity>().Remove(item);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}