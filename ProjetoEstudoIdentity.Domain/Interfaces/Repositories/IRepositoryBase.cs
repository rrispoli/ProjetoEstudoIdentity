using System;
using System.Collections.Generic;

namespace ProjetoEstudoIdentity.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        TEntity FindById(int id);
        List<TEntity> List();
        void Update(TEntity item);
        void Remove(TEntity item);
        void Dispose();
    }
}