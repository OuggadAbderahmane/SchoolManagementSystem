﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Features.StudentsEvaluations.Commands.Models;
using SchoolManagementSystem.Core.Features.StudentsEvaluations.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class StudentEvaluationController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions

        [Authorize(Roles = "admin")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudentEvaluationById(int Id)
        {
            var response = await _mediator.Send(new GetStudentEvaluationByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetGradeReportByStudentId")]
        public async Task<IActionResult> GetGradeReportByStudentId([Required] int StudentId, [Required] int YearId, int? SemesterId)
        {
            var response = await _mediator.Send(new GetGradeReportQuery(StudentId, YearId, SemesterId));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(policy: "StudentOnly")]
        [Authorize(Roles = "user")]
        [HttpGet("GetGradeReport")]
        public async Task<IActionResult> GetGradeReport([Required] int YearId, int? SemesterId)
        {
            var response = await _mediator.Send(new GetStudentGradeReportQuery(YearId, SemesterId));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddStudentEvaluation(AddStudentEvaluationCommand addStudentEvaluation)
        {
            var response = await _mediator.Send(addStudentEvaluation);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateStudentEvaluation(UpdateStudentEvaluationCommand updateStudentEvaluation)
        {
            var response = await _mediator.Send(updateStudentEvaluation);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }


        [Authorize(Roles = "admin")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudentEvaluation(int Id)
        {
            var response = await _mediator.Send(new DeleteStudentEvaluationCommand(Id));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}