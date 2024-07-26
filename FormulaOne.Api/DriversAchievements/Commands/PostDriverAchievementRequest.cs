using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.DriversAchievements.Commands
{
   public class PostDriverAchievementRequest:IRequest<DriverAchievementResponse>
   {
        public CreateDriverAchievementRequest DriverRequest { get; }

        public PostDriverAchievementRequest(CreateDriverAchievementRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }
   }
}