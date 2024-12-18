﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Schedules.Commands.Models;
using SchoolManagementSystem.Core.Features.Schedules.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
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

        [Authorize(Roles = "admin,hr")]
        [HttpGet("GetSectionScheduleById/{Id}")]
        public async Task<ActionResult<Response<List<GetPartsOfStudentScheduleResponse>>>> GetSectionScheduleById(int Id)
        {
            var response = await _mediator.Send(new GetScheduleByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(policy: "StudentOnly")]
        [Authorize(Roles = "user")]
        [HttpGet("GetStudentSchedule")]
        public async Task<ActionResult<Response<List<GetPartsOfStudentScheduleResponse>>>> GetStudentSchedule()
        {
            var response = await _mediator.Send(new GetStudentScheduleQuery());
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpGet("GetTeacherScheduleById/{Id}")]
        public async Task<ActionResult<Response<List<GetPartsOfTeacherScheduleResponse>>>> GetTeacherScheduleById(int Id)
        {
            var response = await _mediator.Send(new GetScheduleByTeacherIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(policy: "TeacherOnly")]
        [Authorize(Roles = "user")]
        [HttpGet("GetTeacherSchedule")]
        public async Task<ActionResult<Response<List<GetPartsOfTeacherScheduleResponse>>>> GetTeacherSchedule()
        {
            var response = await _mediator.Send(new GetTeacherScheduleQuery());
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpGet("IsSessionAvailable")]
        public async Task<ActionResult<Response<bool?>>> IsSessionAvailable([Required] int sectionId, [Required] sbyte day, [Required] sbyte session)
        {
            var response = await _mediator.Send(new IsSessionAvailableQuery(sectionId, day, session));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpGet("IsTeacherAvailable")]
        public async Task<ActionResult<Response<bool?>>> IsTeacherAvailable([Required] int teacherId, [Required] sbyte day, [Required] sbyte session)
        {
            var response = await _mediator.Send(new IsTeacherAvailableQuery(teacherId, day, session));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpGet("IsSubjectTeacherAvailable")]
        public async Task<ActionResult<Response<bool?>>> IsSubjectTeacherAvailable([Required] int subjectTeacherId, [Required] sbyte day, [Required] sbyte session)
        {
            var response = await _mediator.Send(new IsSubjectTeacherAvailableQuery(subjectTeacherId, day, session));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("AddPart")]
        public async Task<ActionResult<Response<string>>> AddPartOfSchedule(AddPartOfScheduleCommand addPartOfSchedule)
        {
            var response = await _mediator.Send(addPartOfSchedule);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpPut("UpdatePart")]
        public async Task<ActionResult<Response<string>>> UpdatePartOfSchedule(UpdatePartOfScheduleCommand updatePartOfSchedule)
        {
            var response = await _mediator.Send(updatePartOfSchedule);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpDelete("DeleteSchedule/{SectionId}")]
        public async Task<ActionResult<Response<string>>> DeleteSchedule(int SectionId)
        {
            var response = await _mediator.Send(new DeleteScheduleBySectionIdCommand(SectionId));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpDelete("DeletePartOfSchedule")]
        public async Task<ActionResult<Response<string>>> DeletePartOfSchedule([Required] int SectionId, [Required] sbyte Day, [Required] sbyte Session)
        {
            var response = await _mediator.Send(new DeletePartOfScheduleCommand(SectionId, Day, Session));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}

