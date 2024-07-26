using AutoMapper;
using FormulaOne.Api.DriversAchievements.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.DriversAchievements
{
    public class PostDriverAchievementHandler : IRequestHandler<PostDriverAchievementRequest, DriverAchievementResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostDriverAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DriverAchievementResponse> Handle(PostDriverAchievementRequest request, CancellationToken cancellationToken)
        {
            var achievement = _mapper.Map<Achievement>(request.DriverRequest);
            await _unitOfWork.Achievements.Add(achievement);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<DriverAchievementResponse>(achievement);
        }
    }
}