using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.DriversAchievements.Commands
{
    public class PutDriverAchievementHandler : IRequestHandler<PutDriverAchievementRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PutDriverAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PutDriverAchievementRequest request, CancellationToken cancellationToken)
        {
            var driverAchievement = _mapper.Map<Achievement>(request.DriverRequest);
            await _unitOfWork.Achievements.Update(driverAchievement);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        
    }
}