using ProjetoEstudoIdentity.Domain.Interfaces.Repositories;
using ProjetoEstudoIdentity.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ProjetoEstudoIdentity.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity item)
        {
            _repository.Add(item);
        }

        public TEntity FindById(int id)
        {
            return _repository.FindById(id);
        }

        public List<TEntity> List()
        {
            return _repository.List();
        }

        public void Update(TEntity item)
        {
            _repository.Update(item);
        }

        public void Remove(TEntity item)
        {
            _repository.Remove(item);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}