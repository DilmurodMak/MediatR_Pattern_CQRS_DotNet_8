using AutoMapper;
using FormulaOne.Api.Drivers.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Drivers
{
    public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<DriverResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDriversHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<DriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _unitOfWork.Drivers.All();
            return _mapper.Map<IEnumerable<DriverResponse>>(drivers);
        }
    }
}