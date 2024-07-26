using FormulaOne.Entities.Dtos.Requests;
using MediatR; 

namespace FormulaOne.Api.Drivers.Queries
{
    public class GetAllDriversQuery:IRequest<IEnumerable<DriverResponse>>
    {

    }
}