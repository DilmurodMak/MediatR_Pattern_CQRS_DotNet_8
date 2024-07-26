using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.DriversAchievements.Commands
{
    public class PutDriverAchievementRequest:IRequest<bool>
    {
        public UpdateDriverAchievementRequest DriverRequest { get; }

        public PutDriverAchievementRequest(UpdateDriverAchievementRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }
    }
}