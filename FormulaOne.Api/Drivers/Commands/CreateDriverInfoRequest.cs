using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Drivers.Commands
{
    public class CreateDriverInfoRequest:IRequest<DriverResponse>
    {
        public CreateDriverRequest DriverRequest { get; }

        public CreateDriverInfoRequest(CreateDriverRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }
    }
}