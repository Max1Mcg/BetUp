using BetUp.DbContexts;
using MarketPlace.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly BetUpContext _context;
        protected readonly DbSet<T> _set;
        public BaseRepository(BetUpContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }
        public async Task Create(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(object id)
        {
            _set.Remove(await _set.FindAsync(id));
            await _context.SaveChangesAsync();
        }
        //доработать чтобы можно было подтягивать сущности + указывать columnsToFetch
        public T? Get(object id)
        {
            var item = _set.Find(id);
            return item;
        }
    }
}