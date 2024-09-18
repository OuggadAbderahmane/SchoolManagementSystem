using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Schedules.Commands.Models;
using SchoolManagementSystem.Core.Features.Schedules.Queries.Models;
using SchoolManagementSystem.Core.Resources;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class ScheduleController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetScheduleById(int Id)
        {
            var response = await _mediator.Send(new GetScheduleByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [HttpGet("IsSessionAvailable")]
        public async Task<IActionResult> IsSessionAvailable(int sectionId, sbyte day, sbyte session)
        {
            if (sectionId <= 0 || day <= 0 || session <= 0)
                return BadRequest("subjectTeacherId and day and session must be bigger than 0");
            var response = await _mediator.Send(new IsSessionAvailableQuery(sectionId, day, session));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [HttpGet("IsTeacherAvailable")]
        public async Task<IActionResult> IsTeacherAvailable(int teacherId, sbyte day, sbyte session)
        {
            if (teacherId <= 0 || day <= 0 || session <= 0)
                return BadRequest("subjectTeacherId and day and session must be bigger than 0");
            var response = await _mediator.Send(new IsTeacherAvailableQuery(teacherId, day, session));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [HttpGet("IsSubjectTeacherAvailable")]
        public async Task<IActionResult> IsSubjectTeacherAvailable(int subjectTeacherId, sbyte day, sbyte session)
        {
            if (subjectTeacherId <= 0 || day <= 0 || session <= 0)
                return BadRequest("subjectTeacherId and day and session must be bigger than 0");
            var response = await _mediator.Send(new IsSubjectTeacherAvailableQuery(subjectTeacherId, day, session));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPost("AddPart")]
        public async Task<IActionResult> AddPartOfSchedule(AddPartOfScheduleCommand addPartOfSchedule)
        {
            var response = await _mediator.Send(addPartOfSchedule);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePartOfSchedule(UpdatePartOfScheduleCommand updatePartOfSchedule)
        {
            var response = await _mediator.Send(updatePartOfSchedule);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}
