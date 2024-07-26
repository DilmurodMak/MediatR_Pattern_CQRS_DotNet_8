using AutoMapper;
using FormulaOne.Api.DriversAchievements.Commands;
using FormulaOne.Api.DriversAchievements.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    public class AchievementsController : BaseController
    {
        public AchievementsController(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IMediator mediator) : base(unitOfWork, mapper, mediator)
        {
        }

        // GET: api/Achievements
        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriverAchievement(Guid driverId)
        {
            var query = new GetDriverAchievementQuery(driverId);
            var achievements = await _mediator.Send(query);
            if (achievements == null)
                return NotFound();

            return Ok(achievements);
        }

        // POST: api/Achievements
        [HttpPost]
        public async Task<IActionResult> PostDriverAchievement([FromBody] CreateDriverAchievementRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new PostDriverAchievementRequest(request);
            var achievement = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetDriverAchievement), new {driverId = achievement.DriverId}, achievement);
        }

        // PUT: api/Achievements
        [HttpPut]
        public async Task<IActionResult> PutDriverAchievement([FromBody] UpdateDriverAchievementRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new PutDriverAchievementRequest(request);
            var achievement = await _mediator.Send(command);
            
            return achievement ? NoContent() : BadRequest();
        }
    }
}