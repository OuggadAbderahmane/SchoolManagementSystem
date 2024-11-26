using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.StudentsEvaluations.Commands.Models;
using SchoolManagementSystem.Core.Features.StudentsEvaluations.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;
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

        [Authorize(Roles = "admin,hr")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<Response<GetStudentEvaluationResponse>>> GetStudentEvaluationById(int Id)
        {
            var response = await _mediator.Send(new GetStudentEvaluationByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpGet("GetGradeReportByStudentId")]
        public async Task<ActionResult<Response<List<GetGradeReport>>>> GetGradeReportByStudentId([Required] int StudentId, [Required] int YearId, int? SemesterId)
        {
            var response = await _mediator.Send(new GetGradeReportQuery(StudentId, YearId, SemesterId));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(policy: "StudentOnly")]
        [Authorize(Roles = "user")]
        [HttpGet("GetGradeReport")]
        public async Task<ActionResult<Response<List<GetGradeReport>>>> GetGradeReport([Required] int YearId, int? SemesterId)
        {
            var response = await _mediator.Send(new GetStudentGradeReportQuery(YearId, SemesterId));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpPost]
        public async Task<IActionResult> AddStudentEvaluation(AddStudentEvaluationCommand addStudentEvaluation)
        {
            var response = await _mediator.Send(addStudentEvaluation);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }

        [Authorize(Roles = "admin,hr")]
        [HttpPut]
        public async Task<ActionResult<Response<string>>> UpdateStudentEvaluation(UpdateStudentEvaluationCommand updateStudentEvaluation)
        {
            var response = await _mediator.Send(updateStudentEvaluation);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }


        [Authorize(Roles = "admin,hr")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Response<string>>> DeleteStudentEvaluation(int Id)
        {
            var response = await _mediator.Send(new DeleteStudentEvaluationCommand(Id));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}