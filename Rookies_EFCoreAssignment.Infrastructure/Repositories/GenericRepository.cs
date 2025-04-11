using Microsoft.EntityFrameworkCore;
using Rookies_EFCoreAssignment.Infrastructure.Data;
using Rookies_EFCoreAssignment.Domain.Interfaces;
using System.Linq.Expressions;

namespace Rookies_EFCoreAssignment.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<T, bool> expression, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (expression == null)
            {
                return query.ToList();
            }
            return query.Where(expression).ToList();
        }

        public async Task<T> GetAsync(Func<T, bool> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public async Task<T> GetAsync(Func<T, bool> expression, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault(expression);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public Task<int> SaveChangeAsync()
        {
            return _context.SaveChangesAsync();
        }
    }

}
