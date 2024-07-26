using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.DriversAchievements.Queries
{
    public class GetDriverAchievementHandler : IRequestHandler<GetDriverAchievementQuery, Achievement>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Achievement> Handle(GetDriverAchievementQuery request, CancellationToken cancellationToken)
        {
            var achievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(request.DriverId);
    
            return achievements == null ? null : _mapper.Map<Achievement>(achievements);
        }
    }
}