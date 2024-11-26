using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.SubjectTeachers.Commands.Models;
using SchoolManagementSystem.Core.Features.SubjectTeachers.Queries.Models;
using SchoolManagementSystem.Core.Resources;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("[controller]s")]
    [Authorize(Roles = "admin,hr")]
    [ApiController]
    public class SubjectTeacherController(IMediator mediator, IStringLocalizer<SharedResource> stringLocalizer) : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator = mediator;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer = stringLocalizer;
        #endregion

        #region Handle Functions
        [HttpGet]
        public async Task<ActionResult<Response<PaginatedResult<GetSubjectTeacherResponse>>>> GetSubjectTeachersPaginatedList(int? pageNumber, int? pageSize)
        {
            return Ok(await _mediator.Send(new GetSubjectTeachersPaginatedListQuery(pageNumber, pageSize)));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Response<GetSubjectTeacherResponse>>> GetSubjectTeacherById(int Id)
        {
            var response = await _mediator.Send(new GetSubjectTeacherByIdQuery(Id));
            if (response.Succeeded)
                return Ok(response);
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<IdResponse>>> AddSubjectTeacher(AddSubjectTeacherCommand addSubjectTeacher)
        {
            var response = await _mediator.Send(addSubjectTeacher);
            if (response.Succeeded)
                return Created(_stringLocalizer[SharedResourcesKey.Created], response);
            return BadRequest(response);
        }


        [Authorize(Roles = "admin")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Response<string>>> DeleteSubjectTeacher(int Id)
        {
            var response = await _mediator.Send(new DeleteSubjectTeacherCommand(Id));
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }
        #endregion
    }
}
