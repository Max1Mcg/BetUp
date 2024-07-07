using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task Create(T entity);
        public Task CreateRange(IEnumerable<T> entity);
        public Task Update(T entity);
        public Task Delete(object id);
        public T? Get(object id);
        TEntity GetById<TEntity>(Guid id) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
    }
}