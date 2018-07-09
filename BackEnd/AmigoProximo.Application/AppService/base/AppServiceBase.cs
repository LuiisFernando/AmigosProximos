using AmigoProximo.Application.AppService.Interfaces;
using AmiProximo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmigoProximo.Application.AppService
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _service;

        protected AppServiceBase(IServiceBase<TEntity> AppService)
        {
            _service = AppService;
        }

        public TEntity Find(params object[] Keys)
        {
            return _service.Find(Keys);
        }

        public async Task<TEntity> FindAsync(params object[] Keys)
        {
            return await _service.FindAsync(Keys);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            return _service.Find(where);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _service.Find(predicate, includeProperties);
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _service.FindAll(predicate, includeProperties);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _service.FindAsync(where);
        }

        public bool Update(TEntity model)
        {
            return _service.Update(model);
        }

        public async Task<bool> UpdateAsync(TEntity model)
        {
            return await _service.UpdateAsync(model);
        }

        public bool Delete(params object[] Keys)
        {
            return _service.Delete(Keys);
        }

        public async Task<bool> DeleteAsync(params object[] Keys)
        {
            return await _service.DeleteAsync(Keys);
        }

        public TEntity Insert(TEntity model)
        {
            return _service.Insert(model);
        }

        public async Task<TEntity> InsertAsync(TEntity model)
        {
            return await _service.InsertAsync(model);
        }

        public bool Delete(TEntity model)
        {
            return _service.Delete(model);
        }

        public async Task<bool> DeleteAsync(TEntity model)
        {
            return await _service.DeleteAsync(model);
        }

        public bool Delete(Expression<Func<TEntity, bool>> where)
        {
            return _service.Delete(where);
        }

        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _service.DeleteAsync(where);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where)
        {
            return _service.FindAll(where);
        }

        IQueryable<TEntity> IAppServiceBase<TEntity>.GetAll()
        {
            return _service.GetAll();
        }

        IQueryable<TEntity> IAppServiceBase<TEntity>.GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return _service.GetAll(includes);
        }

    }
}
