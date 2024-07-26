using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.DriversAchievements.Queries
{
    public class GetDriverAchievementQuery : IRequest<Achievement>
    {
        public Guid DriverId { get; set; }

        public GetDriverAchievementQuery(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}