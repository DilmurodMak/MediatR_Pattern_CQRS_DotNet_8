using AutoMapper;
using FormulaOne.Api.Drivers.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Drivers
{
    public class GetDriverHandler : IRequestHandler<GetDriverQuery, DriverResponse>
    {
         private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DriverResponse> Handle(GetDriverQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetById(request.DriverId);

            return driver == null ? null : _mapper.Map<DriverResponse>(driver);
        }
    }
}