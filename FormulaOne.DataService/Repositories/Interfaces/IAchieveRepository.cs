using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataService.Repositories.Interfaces
{
    public interface IAchieveRepository : IGenericRepository<Achievement>
    {
       Task <Achievement?> GetDriverAchievementAsync(Guid driverId);
    }
}