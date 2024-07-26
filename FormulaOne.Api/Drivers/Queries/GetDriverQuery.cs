using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Drivers.Queries
{
    public class GetDriverQuery : IRequest<DriverResponse>
    {
        public Guid DriverId { get; }

        public GetDriverQuery(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}