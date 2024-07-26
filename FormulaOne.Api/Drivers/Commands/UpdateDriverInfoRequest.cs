using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Drivers.Commands
{
    public class UpdateDriverInfoRequest:IRequest<bool>
    {
        public UpdateDriverRequest DriverRequest { get; }

        public UpdateDriverInfoRequest(UpdateDriverRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }
    }
}