using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.DAL.AppContext;
using EmployeeManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Repositories.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        protected readonly DbSet<T> DbSet;

        protected BaseRepository(ApplicationContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T> GetAsync(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task AddAsync(T item)
        {
            await DbSet.AddAsync(item);
            await SaveAsync();
        }

        public async Task AddRangeAsync(List<T> items)
        {
            await DbSet.AddRangeAsync(items);
            await SaveAsync();
        }

        public async Task UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var item = await DbSet.FindAsync(id);
            DbSet.Remove(item);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}