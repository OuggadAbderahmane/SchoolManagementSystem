using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "admin")]
        [HttpGet("GetScheduleBySectionId/{Id}")]
        public async Task<IActionResult> GetScheduleBySectionId(int Id)
        {
            var response = await _mediator.Send(new GetScheduleByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(policy: "StudentOnly")]
        [Authorize(Roles = "user")]
        [HttpGet("GetSchedule")]
        public async Task<IActionResult> GetSchedule()
        {
            var Id = int.Parse(HttpContext.User.Claims.First(claim => claim.Type == "PersonId").Value);
            var response = await _mediator.Send(new GetScheduleByStudentIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("IsSessionAvailable")]
        public async Task<IActionResult> IsSessionAvailable(int sectionId, sbyte day, sbyte session)
        {
            var response = await _mediator.Send(new IsSessionAvailableQuery(sectionId, day, session));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("IsTeacherAvailable")]
        public async Task<IActionResult> IsTeacherAvailable(int teacherId, sbyte day, sbyte session)
        {
            var response = await _mediator.Send(new IsTeacherAvailableQuery(teacherId, day, session));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("IsSubjectTeacherAvailable")]
        public async Task<IActionResult> IsSubjectTeacherAvailable(int subjectTeacherId, sbyte day, sbyte session)
        {
            var response = await _mediator.Send(new IsSubjectTeacherAvailableQuery(subjectTeacherId, day, session));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("AddPart")]
        public async Task<IActionResult> AddPartOfSchedule(AddPartOfScheduleCommand addPartOfSchedule)
        {
            var response = await _mediator.Send(addPartOfSchedule);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("UpdatePart")]
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
