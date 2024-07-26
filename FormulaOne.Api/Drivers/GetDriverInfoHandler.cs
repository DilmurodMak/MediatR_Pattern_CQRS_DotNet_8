using AutoMapper;
using FormulaOne.Api.Drivers.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Drivers
{
    public class GetDriverInfoHandler : IRequestHandler<CreateDriverInfoRequest, DriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GetDriverInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DriverResponse> Handle(CreateDriverInfoRequest request, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver>(request.DriverRequest);
            await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<DriverResponse>(driver);
        }
    }
}