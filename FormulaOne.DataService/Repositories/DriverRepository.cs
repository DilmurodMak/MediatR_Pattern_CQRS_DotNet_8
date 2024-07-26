using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(AppDbContext context, ILogger logger) : base(context, logger)
        { }

        public override async Task<IEnumerable<Driver>> All()
        {
            try{
                return await dbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
            }
            catch (Exception e){
                _logger.LogError(e, message: "{Repo} All function error", typeof (DriverRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var entity = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    return false;
                }

                entity.Status = 0;
                entity.UpdatedDate = DateTime.Now;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, message: "{Repo} Delete function error", typeof(DriverRepository));
                throw;
            }
        }

        public virtual async Task<bool> Update(Driver entity)
        {
            try
            {
                var existingEntity = await dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (existingEntity == null)
                {
                    return false;
                }

                existingEntity.UpdatedDate = DateTime.Now;
                existingEntity.DriverNumber = entity.DriverNumber;
                existingEntity.FirstName = entity.FirstName;
                existingEntity.LastName = entity.LastName;
                existingEntity.DateOfBirth = entity.DateOfBirth;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, message: "{Repo} Update function error", typeof(DriverRepository));
                throw;
            }
        }
    }
}