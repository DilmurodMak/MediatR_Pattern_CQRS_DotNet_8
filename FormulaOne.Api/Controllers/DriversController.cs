using AutoMapper;
using FormulaOne.Api.Drivers.Commands;
using FormulaOne.Api.Drivers.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    public class DriversController : BaseController
    {
       
        public DriversController(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IMediator mediator) : base(unitOfWork, mapper, mediator)
        {
        }

        // GetAll: api/Drivers
        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var query = new GetAllDriversQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/DriverId
        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var query = new GetDriverQuery(driverId);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/Drivers
        [HttpPost("")]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateDriverInfoRequest(request);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDriver), new {driverId = result.DriverId}, result);
        }

        // PUT: api/Drivers
        [HttpPut]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UpdateDriverInfoRequest(request);
            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }

        // DELETE: api/Drivers
        [HttpDelete]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var command = new DeleteDriverInfoRequest(driverId);
            var result = await _mediator.Send(command);
            
            return result ? NoContent() : BadRequest();
        }
    }
}