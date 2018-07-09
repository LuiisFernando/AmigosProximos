using AmigoProximo.Domain.Interfaces.Repositories;
using AmiProximo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AmigoProximo.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        protected ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public TEntity Find(params object[] Keys)
        {
            return _repository.Find(Keys);
        }

        public async Task<TEntity> FindAsync(params object[] Keys)
        {
            return await _repository.FindAsync(Keys);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            return _repository.Find(where);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.Find(predicate, includeProperties);
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.FindAll(predicate, includeProperties);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where)
        {
            return _repository.FindAll(where);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _repository.FindAsync(where);
        }


        public bool Update(TEntity model)
        {
            return _repository.Update(model);
        }

        public async Task<bool> UpdateAsync(TEntity model)
        {
            return await _repository.UpdateAsync(model);
        }

        public bool Delete(params object[] Keys)
        {
            return _repository.Delete(Keys);
        }

        public async Task<bool> DeleteAsync(params object[] Keys)
        {
            return await _repository.DeleteAsync(Keys);
        }

        public TEntity Insert(TEntity model)
        {
            return _repository.Insert(model);
        }

        public async Task<TEntity> InsertAsync(TEntity model)
        {
            return await _repository.InsertAsync(model);
        }

        public bool Delete(TEntity model)
        {
            return _repository.Delete(model);
        }

        public async Task<bool> DeleteAsync(TEntity model)
        {
            return await _repository.DeleteAsync(model);
        }

        public bool Delete(Expression<Func<TEntity, bool>> where)
        {
            return _repository.Delete(where);
        }

        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _repository.DeleteAsync(where);
        }

        IQueryable<TEntity> IServiceBase<TEntity>.GetAll()
        {
            return _repository.Get();
        }

        IQueryable<TEntity> IServiceBase<TEntity>.GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.Get(includes);
        }
    }
}
