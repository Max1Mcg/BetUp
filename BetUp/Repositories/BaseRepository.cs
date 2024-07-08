using BetUp.CommonInterfaces;
using BetUp.DbContexts;
using BetUp.Logger.Interfaces;
using MarketPlace.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseObject
    {
        protected readonly BetUpContext _context;
        protected readonly DbSet<T> _set;
        private readonly ILoggerActions _loggerActions;
        public BaseRepository(BetUpContext context,
            ILoggerActions logger)
        {
            _context = context;
            _set = _context.Set<T>();
            _loggerActions = logger;
        }

        public async Task Create(T entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.ModifiedOn = DateTime.UtcNow;
            _context.Add(entity);
            await _context.SaveChangesAsync();
            _loggerActions.LogOperation("Create", typeof(T).ToString(), entity.Id);
        }

        public async Task CreateRange(IEnumerable<T> entityCollection)
        {
            entityCollection = entityCollection.Select(entity => { entity.CreatedOn = DateTime.UtcNow; entity.ModifiedOn = DateTime.UtcNow; return entity; });
            _context.AddRange(entityCollection);
            await _context.SaveChangesAsync();
            _loggerActions.LogOperation("CreateRange", typeof(T).ToString(), Guid.Empty);
        }

        public async Task Update(T entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            _loggerActions.LogOperation("Update", typeof(T).ToString(), entity.Id);
        }

        public async Task Delete(object id)
        {
            _set.Remove(await _set.FindAsync(id));
            await _context.SaveChangesAsync();
            _loggerActions.LogOperation("Delete", typeof(T).ToString(), (Guid)id);
        }

        public T? Get(object id)
        {
            var item = _set.Find(id);
            return item;
        }

        public TEntity GetById<TEntity>(Guid id) where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}