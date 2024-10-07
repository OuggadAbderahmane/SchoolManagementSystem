using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.Schedules.Commands.Models;
using SchoolManagementSystem.Core.Features.Schedules.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using System.ComponentModel.DataAnnotations;

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
        [HttpGet("GetSectionScheduleById/{Id}")]
        public async Task<IActionResult> GetSectionScheduleById(int Id)
        {
            var response = await _mediator.Send(new GetScheduleByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(policy: "StudentOnly")]
        [Authorize(Roles = "user")]
        [HttpGet("GetStudentSchedule")]
        public async Task<IActionResult> GetStudentSchedule()
        {
            var response = await _mediator.Send(new GetStudentScheduleQuery());
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetTeacherScheduleById/{Id}")]
        public async Task<IActionResult> GetTeacherScheduleById(int Id)
        {
            var response = await _mediator.Send(new GetScheduleByTeacherIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(policy: "TeacherOnly")]
        [Authorize(Roles = "user")]
        [HttpGet("GetTeacherSchedule")]
        public async Task<IActionResult> GetTeacherSchedule()
        {
            var response = await _mediator.Send(new GetTeacherScheduleQuery());
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("IsSessionAvailable")]
        public async Task<IActionResult> IsSessionAvailable([Required] int sectionId, [Required] sbyte day, [Required] sbyte session)
        {
            var response = await _mediator.Send(new IsSessionAvailableQuery(sectionId, day, session));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("IsTeacherAvailable")]
        public async Task<IActionResult> IsTeacherAvailable([Required] int teacherId, [Required] sbyte day, [Required] sbyte session)
        {
            var response = await _mediator.Send(new IsTeacherAvailableQuery(teacherId, day, session));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("IsSubjectTeacherAvailable")]
        public async Task<IActionResult> IsSubjectTeacherAvailable([Required] int subjectTeacherId, [Required] sbyte day, [Required] sbyte session)
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

        [Authorize(Roles = "admin")]
        [HttpDelete("DeleteSchedule/{SectionId}")]
        public async Task<IActionResult> DeleteSchedule(int SectionId)
        {
            var response = await _mediator.Send(new DeleteScheduleBySectionIdCommand(SectionId));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("DeletePartOfSchedule")]
        public async Task<IActionResult> DeleteSchedule([Required] int SectionId, [Required] sbyte Day, [Required] sbyte Session)
        {
            var response = await _mediator.Send(new DeletePartOfScheduleCommand(SectionId, Day, Session));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}
