using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly ILogger _logger;
        protected readonly AppDbContext _context;
        internal DbSet<T> dbSet;

        public GenericRepository(AppDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;

            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return true;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}